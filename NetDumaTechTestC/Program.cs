using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NetDumaTechTestC
{
    class Program
    {

        static void Main(string[] args)
        {
            titlePrint("Welcome to the Address Book");
            bool running = true;
            Adding add = new Adding();
            Removal remove = new Removal();
            Console.WriteLine("What would you like to do with the address book?\n1. Add a contact to the database\n2. Delete a contact from the database\n3. Search through the database\n4. Exit");

            int switchInput = 0;
            while (running == true)
            {
                var input = Console.ReadKey();
                if (char.IsDigit(input.KeyChar))
                {
                    switchInput = int.Parse(input.KeyChar.ToString());
                    Console.WriteLine("\nUser Inserted : {0}", switchInput); // Say what user inserted 
                    running = false;
                }
                else
                {
                    running = true;  // Else we assign a default value
                    Console.WriteLine("\nUser didn't insert a Number"); // Say it wasn't a number
                }
            }
            switch (switchInput)
            {
                case 1:
                    add.newContact();
                    break;
                case 2:
                    remove.removeContact();
                    break;
                case 3:
                    searchMenu();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
            mainMenu();
        }

    }
        

    class Title
    {
        public int dataflag = 1; // global variable to change between the local db and azure db
        public SqlConnection conn;
        public SqlDataReader dataReader;

        public void titlePrint(string title)
        {
            Console.BufferWidth = Console.WindowWidth; //setting the buffer width as the width of the window to allow for pretty and easily constructed titles
            Console.BufferHeight = Console.WindowHeight;

            string s = "";
            for (int i = 0; i < Console.BufferWidth; i++)
                s += ("=").ToString();
            Console.WriteLine(s);
            Console.WriteLine(title.PadLeft(Console.BufferWidth / 2));
            Console.WriteLine(s);
        }
        //This is on the basis of using an online server, I want to make it offline
        public void openConnection()
        {
            try
            {
                if (dataflag == 1)
                {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(); //Using the string builder so the access variables to the server are not visible
                builder.DataSource = "temporarydb.database.windows.net,1433";
                builder.UserID = "Jez";
                builder.Password = "Temporary42";
                builder.InitialCatalog = "AddressBook";
                conn = new SqlConnection(builder.ConnectionString);
                conn.Open();
                Console.WriteLine("Server Status : " + conn.State);
                }
                else if (dataflag == 0)
                {
                    conn = new SqlConnection();
                    conn.Open();
                    Console.WriteLine("Server Status : " + conn.State);
                }

            }
            catch (SqlException e) //Catching any exception caused by sql
            {
                Console.WriteLine("Server has refused connection to the IP address");
            }
        }


    }
}
