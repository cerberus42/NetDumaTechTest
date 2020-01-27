using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace NetDumaTechTestC
{

    class Program
    {
        public Menus menu;
        static void Main(string[] args)
        {
            Menus menu = new Menus();
            menu.mainMenu();
            Console.ReadKey();

        }
    }

    class Title
    {
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

        public void openConnection()
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
    }
}
