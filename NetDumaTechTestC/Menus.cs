using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDumaTechTestC
{

    class Menus : Title
    {

   
        public void mainMenu()
        {
            titlePrint("Welcome to the Address Book");
            bool running = true;
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
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
            mainMenu();
        }
        public void databaseType()
        {
            bool running = true;
            Console.WriteLine("What type of database would you like to use?\n1. Locally Stored\n2. Azure stored database");
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
                    running = true;
                    Console.WriteLine("\nUser didn't insert a Number"); // Say it wasn't a number
                }
            }
            switch (switchInput)
            {
                case 1:dataflag = 0;
                    break;
                case 2: dataflag = 1;
                    break;
            }

        }
        public void searchMenu()
        {
            Console.Clear();
            titlePrint("Searching through the Database");
            bool running = true;
            Console.WriteLine("What would you like to do with the address book?\n1. List All entries in address book\n2. Sort through the address book and concat names for easy reading\n3. Search through the database\n4. Exit");
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
                    running = true;
                    Console.WriteLine("\nUser didn't insert a Number"); // Say it wasn't a number
                }
            }
            switch (switchInput)
            {
                case 1:
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

    }
}
