using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NetDumaTechTestC
{
    class Removal : Title
    {
        public void removeContact()
        {
            Console.WriteLine("How would you like to remove contacts?\n1. By Contact_ID\n2. Search name then delete via ID");
            bool running = true;
            ;
            Searching search = new Searching();
            int switchInput = 0;
            while (running == true)
            {
                var input = Console.ReadKey();
                if (char.IsDigit(input.KeyChar))
                {
                    switchInput = int.Parse(input.KeyChar.ToString());
                    Console.WriteLine("\nUser Inserted : {0}", switchInput); // Say what user inserted 
                    Console.WriteLine("Please enter the ID number for the contact you wish to delete");
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
                    search.searchSpecific();
                    break;
                case 3:
                    Menus menu = new Menus();
                    menu.mainMenu();
                    break;
            }
            running = true;
            int idsearch = 0;
            while (running == true)
            {
                var searchid = Console.ReadKey();
                if (char.IsDigit(searchid.KeyChar))
                {
                    idsearch = int.Parse(searchid.KeyChar.ToString());
                    Console.WriteLine("\nUser Inserted : {0}", idsearch); // Say what user inserted 
                    running = false;
                }
                else
                {
                    running = true;  // Else we assign a default value
                    Console.WriteLine("\nUser didn't insert a Number"); // Say it wasn't a number
                }
            }
            string statement = string.Format("SELECT * FROM Contact_Info WHERE Contact_ID = {0}", idsearch);

            openConnection();
            SqlCommand searchCommand = new SqlCommand(statement, conn);
            dataReader = searchCommand.ExecuteReader();
            int flag = 0;
            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    flag++;
                    Console.Write(dataReader.GetValue(i));
                }
            }
            if (flag == 0) { Console.WriteLine("Failed to find ID: " + idsearch); removeContact(); }
            running = true;

            while (running == true)
            {
                Console.WriteLine("Type yes to confirm, no to cancel");
                string wording = Console.ReadLine();
                if (wording == "yes") running = false;
                else if (wording == "no") { Menus menu = new Menus(); menu.mainMenu(); }
                else { }
            }


            string destatement = string.Format("DELETE FROM Contact_Info WHERE Contact_ID = {0}", idsearch);

            openConnection();
            SqlCommand deleteCommand = new SqlCommand(destatement, conn);
            dataReader = deleteCommand.ExecuteReader();

        }
    }
}
