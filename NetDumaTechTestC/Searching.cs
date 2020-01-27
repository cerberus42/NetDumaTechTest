using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NetDumaTechTestC
{
    class Searching : Title
    {
        public static string Indent(int count)
        {
            return "".PadLeft(count);
        }
        public void listAll()
        {
            try
            {
                openConnection();
                SqlCommand selectCommand = new SqlCommand("SELECT * FROM Contact_Info WHERE Contact_ID > 0", conn);
                dataReader = selectCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    int count = 0;
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        count++;
                        if (count == 2) Console.Write(Indent(2));
                        Console.Write(dataReader.GetValue(i));
                        if (count >= 8) { Console.WriteLine(); if (count == 16) count = 0; }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Connecting to server");
            }
            catch (InvalidOperationException f)
            {
                Console.WriteLine("The connection to the database is offline");
            }

        }

        public void searchSpecific()
        {
            Console.WriteLine("What would you like to search via?\n1. First Name\n2. Last Name\n3. Email\n4. Telephone\n5. Town\n6. Country\n7. Main Menu\n8. Exit");
            Menus menu = new Menus();
            string varSwitch = "", keyword = "";
            bool running = true;
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
                    varSwitch = "First_Name";
                    break;
                case 2:
                    varSwitch = "Other_Name";
                    break;
                case 3:
                    varSwitch = "Email";
                    break;
                case 4:
                    varSwitch = "Telephone";
                    break;
                case 5:
                    varSwitch = "Town";
                    break;
                case 6:
                    varSwitch = "Country";
                    break;
                case 7:
                    menu.mainMenu();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
            }
            Console.WriteLine("Searching in Column : " + varSwitch);
            Console.WriteLine("Please enter what you would like to search.");
            keyword = Console.ReadLine();
            string statement = string.Format("SELECT * FROM Contact_Info WHERE {0}='{1}'", varSwitch, keyword);

            openConnection();
            SqlCommand searchCommand = new SqlCommand(statement, conn);
            dataReader = searchCommand.ExecuteReader();
            int flag = 0;
            heading();
            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    flag++;
                    Console.Write(dataReader.GetValue(i));
                }
            }
            if (flag == 0) Console.WriteLine("Unable to find anything matching your search");
        }
        public void heading()
        {
            Console.WriteLine("ID" + Indent(3) + "First Name" + Indent(3) + "Other Names" + Indent(4) + "Email" + Indent(25) + "Telephone" + Indent(10) + "Street" + Indent(20) + "Country" + Indent(20) + "Town");
        }
        public void sortBy()
        {
            Console.Clear();

            Console.WriteLine("Would you like to concat when you order?\n Y or N");
            string temp = Console.ReadLine();
            int concatFlag = 0;
            string keypress = temp.ToString();
            if (temp == "y")
            {
                concatFlag = 1;
            }
            else if (temp == "n")
            {
                concatFlag = 0;
            }
            else { sortBy(); }
            Console.WriteLine("How would you like to order it?\n1. Contact ID" + Indent(3) + "2. First Name\n3. Last Name" + Indent(3) + "4. Street\n5. Town" + Indent(3) + "6. country\n7. Exit");
            string varSwitch = "", keyword = "";
            bool running = true;
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

        }

    }

}

