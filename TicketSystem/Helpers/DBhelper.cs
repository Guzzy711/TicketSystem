using System;
using System.Data; 
using MySql.Data.MySqlClient;
using TicketSystem.Models;

namespace TicketSystem.Helpers
{
    public class DBhelper
    {
        public MySqlConnection dbConnection;

        public DBhelper()
        {
            string server = "mysql6.unoeuro.com";
            string dataBase = "guzzy_dk_db2";
            string username = "guzzy_dk";
            string password = "pvnzxc123456";



            string connectionString = $"SERVER={server};DATABASE={dataBase};UID={username};PASSWORD={password}";
            dbConnection = new MySqlConnection(connectionString); 
        }

        public bool OpenDBConnection()
        {
            try
            {
                dbConnection.Open();
                Console.WriteLine($"MySQL version {dbConnection.ServerVersion}");
                return true;
            }
            catch (MySqlException error)
            {
                switch (error.Number)
                {
                    case 0:
                        Console.WriteLine($"Error {error}: Could not connect to server!");
                        break;

                    case 1045:
                        Console.WriteLine($"Error {error}: Wrong username or password!");
                        break; 
                }
                return false; 
            }
        }

        public bool CloseDBConnection()
        {
            try
            {
                dbConnection.Close();
                return true; 
            }
            catch(MySqlException error)
            {
                Console.WriteLine($"{error} Could not close connection");
                return false; 
            }
        }

        public DataTable SelectQuery(string query)
        {
            try
            {
                DataTable result = new DataTable();
                OpenDBConnection();

                MySqlCommand command = new MySqlCommand(query, dbConnection);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                dataAdapter.Fill(result);

                CloseDBConnection();
                dataAdapter.Dispose();

                return result; 
            }

            catch (Exception error)
            {
                Console.WriteLine("Could not get the queried data");
                throw error; 
            }
        }

        public bool InsertQueryToDB(string query)
        {
            try
            {
                OpenDBConnection();
                MySqlCommand command = new MySqlCommand(query, dbConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                CloseDBConnection();
                return true; 
            }

            catch (Exception error)
            {
                Console.WriteLine("Could not insert into database");
                throw error; 
            }
        }

        public bool DeleteQuery(string query)
        {
            try
            {
                OpenDBConnection();
                MySqlCommand command = new MySqlCommand(query, dbConnection);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                dataAdapter.DeleteCommand = command; 
                dataAdapter.DeleteCommand.ExecuteNonQuery();
                command.Dispose();
                CloseDBConnection();
                return true; 
            }
            catch(Exception error)
            {
                Console.WriteLine("Could not delete from database");
                throw error; 
            }
        }

        public Event CreateOneEventObject(int ID)
        {
            string query = $"SELECT * FROM events WHERE id = {ID}";
            var queryResult = SelectQuery(query);

            Event eventt = new Event();

            foreach (DataRow row in queryResult.Rows)
            {
                var EventID = (int)row["id"];
                var EventName = (string)row["event_name"];
                var Location = (string)row["location"];
                var Date = (DateTime)row["date"];
                var Time = (TimeSpan)row["time"];
                var TicketAmount = (int)row["ticket_amount"];
                var Price = (float)row["price"];
                var Image = (string)row["image"];
                var Description = (string)row["description"];
                var ActiveState = (bool)row["active_state"];
                var TicketsSold = TicketCounter(EventID);
                var OrganizerID = (int)row["organizer_id"];

                eventt = new Event(EventID, EventName, Location, Date, Time, TicketAmount, Price, Image, Description, ActiveState, TicketsSold, OrganizerID);
               
            }

            return eventt;
        }


        public Event[] CreateEventObjectsFromQuery(string query)
        {

            DataTable queryResult = SelectQuery(query);

            Event[] events = new Event[queryResult.Rows.Count];

            int counter = 0;

            foreach (DataRow row in queryResult.Rows)
            {
                var EventID = (int)row["id"];
                var EventName = (string)row["event_name"];
                var Location = (string)row["location"];
                var Date = (DateTime)row["date"];
                var Time = (TimeSpan)row["time"];
                var TicketAmount = (int)row["ticket_amount"];
                var Price = (float)row["price"];
                var Image = (string)row["image"];
                var Description = (string)row["description"];
                var ActiveState = (bool)row["active_state"];
                var TicketsSold = TicketCounter(EventID);
                var OrganizerID = (int)row["organizer_id"];
                events[counter] = new Event(EventID,EventName,Location,Date,Time,TicketAmount,Price,Image,Description,ActiveState,TicketsSold, OrganizerID);
                counter++; 
            }

            return events; 
        }
        /*
        public Event[] CreateEventObjectsFromQuery(string query)
        {

            DataTable queryResult = SelectQuery(query);

            Event[] events = new Event[queryResult.Rows.Count];

            int counter = 0;

            foreach (DataRow row in queryResult.Rows)
            {
                var EventID = (int)row["id"];
                events[counter] = CreateOneEventObject(EventID); 
                counter++;
            }

            return events;
        }*/

        public Ticket[] CreateTicketObjectsFromQuery(string query)
        {
            DataTable queryResult = SelectQuery(query);

            Ticket[] tickets = new Ticket[queryResult.Rows.Count];

            int counter = 0; 

            foreach (DataRow row in queryResult.Rows)
            {
                var TicketID = (int)row["id"];
                var EventID = (int)row["event_id"];
                var CustomerFirstname = (string)row["customer_first_name"];
                var CustomerSurname = (string)row["customer_surname"];
                var CustomerEmail = (string)row["customer_email"];
                var CustomerPhone = (int)row["customer_phone_number"];
                var TicketUsed = (bool)row["ticket_used"];

                tickets[counter] = new Ticket(CustomerFirstname, CustomerSurname, CustomerEmail, CustomerPhone, TicketID, EventID, TicketUsed);

                counter++; 
            }

            return tickets; 
        }

        public Ticket CreateOneTicketObject(int ID)
        {
            string query = $"SELECT * FROM tickets WHERE id = {ID}";
            var queryResult = SelectQuery(query);

            Ticket ticket = new Ticket();

            foreach (DataRow row in queryResult.Rows)
            {
                var TicketID = (int)row["id"];
                var EventID = (int)row["event_id"];
                var CustomerFirstname = (string)row["customer_first_name"];
                var CustomerSurname = (string)row["customer_surname"];
                var CustomerEmail = (string)row["customer_email"];
                var CustomerPhone = (int)row["customer_phone_number"];
                var TicketUsed = (bool)row["ticket_used"];

                ticket = new Ticket(CustomerFirstname, CustomerSurname, CustomerEmail, CustomerPhone, TicketID, EventID, TicketUsed);
            }

            return ticket; 
        }


        public Organizer CreateOrganizerObject(int ID)
        {
            string query = $"SELECT * FROM organizers WHERE id = {ID}";
            var queryResult = SelectQuery(query);

            Organizer organizer = new Organizer();

            foreach (DataRow row in queryResult.Rows)
            {
                string organizationName = (string)row["organization_name"];
                string contactPerson = (string)row["contact_person"];
                string phoneNumber = (string)row["phone_number"];
                string emailAddress = (string)row["email_address"];
                string passWord = (string)row["password"];
                int organizerID = (int)row["id"];

                organizer = new Organizer(contactPerson, passWord, phoneNumber, emailAddress, organizationName, organizerID);
            }

            return organizer;
        }

        public Int64 TicketCounter(int eventID)
        {
            string query = $"SELECT COUNT(*) FROM tickets WHERE event_id = {eventID}";
            var queryResult = SelectQuery(query);

            Int64 count = 0; 

            foreach (DataRow row in queryResult.Rows)
            {
                count = (Int64)row["COUNT(*)"]; 
            }

            return count; 
        }

        public Ticket CheckTicket(int TicketID, int EventID)
        {
            Ticket ticket = null;
            string query = $"SELECT * FROM tickets WHERE id={TicketID} AND event_id= {EventID}";
            var queryResult = SelectQuery(query); 

            foreach(DataRow row in queryResult.Rows)
            {
                ticket = CreateOneTicketObject((int)row["id"]); 
            }

            return ticket; 

        }

        public void UseTicket(int TicketID)
        {
            string query = $"UPDATE tickets SET ticket_used = true WHERE id = {TicketID}";
            SelectQuery(query);
        }
    }
}
