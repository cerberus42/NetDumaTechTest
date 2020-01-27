using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration; 
using System.Collections;

namespace NetDumaTechTestC
{

    class Program
    {
        public int dataflag;

        public Menus menu;
        static void Main(string[] args)
        {
            Title t = new Title();
            //t.databaseSelection();
            Menus menu = new Menus();

            menu.mainMenu();
            Console.ReadKey();

        }
    }

    class Title
    {
        Program p = new Program();
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
        int dataAttempt = 1;
        public void databaseSelection()
        {
            bool running = true;
            Console.WriteLine("Would you like to connect to azure or local db?\n1. Local database\n2. Azure Database");
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
                    dataAttempt = 0;
                    break;
                case 2:
                    dataAttempt = 1;
                    break;
            }
        }
        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
        public void openConnection()
        {
            if(dataAttempt == 1)
            {
                try
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
                catch (SqlException e) //Catching any exception caused by sql
                {
                    Console.WriteLine("Server has refused connection to the IP address");
                }
            }

            else if(dataAttempt == 0)
            {
                try
                {
                    string setting = GetConnectionStringByName("localdb");
                    conn = new SqlConnection(setting);
                    conn.Open();
                    Console.WriteLine("Server Status : " + conn.State);
                }
                catch (SqlException e) //Catching any exception caused by sql
                {
                    Console.WriteLine("Cannot open mdf file");
                }
            }


        }
    }
}
