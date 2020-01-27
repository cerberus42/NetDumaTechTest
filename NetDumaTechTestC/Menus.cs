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
            Adding add = new Adding();
            //Removal remove = new Removal();
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
                    //remove.removeContact();
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
        public void searchMenu()
        {
            Searching s = new Searching();
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
                    s.listAll();
                    break;
                case 2:
                    s.sortBy();
                    break;
                case 3:
                    s.searchSpecific();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
        public void addingEntryMenu()
        {
            Searching s = new Searching();
            Console.Clear();
            titlePrint("Adding a contact into the address book");
            bool running = true;
            Console.WriteLine("What would you like to do with the address book?\n1. Add a brand new contact into the address book\n2. Ammend and updated existing contacts\n3. Search through the database\n4. Exit");
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
                    s.listAll();
                    break;
                case 2:
                    s.sortBy();
                    break;
                case 3:
                    searchMenu();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

        public void confirmAdditionMenu()
        {
            Console.WriteLine("\nProceed? \n1. Yes\n2. No\n3. Go back to menu\n4. Exit");
            bool running = true;
            int switchInput = 0;
            Adding add = new Adding();

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
                    add.newContact();
                    break;
                case 3:
                    searchMenu();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
