using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NetDumaTechTestC
{
    class Adding : Title
    {

        Menus menu = new Menus();
        bool running = true;
        public void newContact()
        {
            string[] temp = new string[9];
            Console.WriteLine("Please enter all the information in as correct as possible. Maximum field sizes vary.");
            Console.WriteLine("Please enter your first name");
            while (running == true)
            {

                temp[0] = Console.ReadLine();
                if (isInt(temp[0]) == true) running = false;
                else if (isInt(temp[0]) == false) Console.WriteLine("You entered {0} please enter a valid string", temp[0]);

            }
            running = true;
            Console.WriteLine("Please enter your last name");
            while (running == true)
            {
                temp[1] = Console.ReadLine();
                if (isInt(temp[1]) == true) running = false;
                else if (isInt(temp[1]) == false) Console.WriteLine("You entered {0} please enter a valid string", temp[1]);
            }
            running = true;
            Console.WriteLine("Please enter your email");
            string[] testing = { "@", ".com", ".uk", ".co" };
            while (running == true)
            {
                temp[2] = Console.ReadLine();
                if (testing.Any(temp[2].Contains) == true) running = false;
                else if (testing.Any(temp[2].Contains) == false) Console.WriteLine("You entered {0} please enter a valid string", temp[2]);
            }
            running = true;

            Console.WriteLine("Please enter your phonenumber");
            while (running == true)
            {
                temp[3] = Console.ReadLine();
                if (isNotInt(temp[3]) == true) running = false;
                else if (isNotInt(temp[3]) == false) Console.WriteLine("You entered {0} please enter a valid string", temp[3]);
            }
            running = true;
            Console.WriteLine("Please enter your Street");
            while (running == true)
            {
                temp[4] = Console.ReadLine();
                if (isInt(temp[4]) == true) running = false;
                else if (isInt(temp[4]) == false) Console.WriteLine("You entered {0} please enter a valid string", temp[4]);
            }
            running = true;
            Console.WriteLine("Please enter your Town");
            while (running == true)
            {
                temp[5] = Console.ReadLine();
                if (isInt(temp[5]) == true) running = false;
                else if (isInt(temp[5]) == false) Console.WriteLine("You entered {0} please enter a valid string", temp[5]);
            }
            running = true;
            Console.WriteLine("Please enter your Country");
            while (running == true)
            {
                temp[6] = Console.ReadLine();
                if (isInt(temp[6]) == true) running = false;
                else if (isInt(temp[6]) == false) Console.WriteLine("You entered {0} please enter a valid string", temp[6]);
            }
            running = true;

            Console.WriteLine("Does this information look correct?\n" + "Full Name : " + temp[0] + temp[1] + "\nEmail : " + temp[2] + "\nTelephone : " + temp[3] + "Address : " + temp[4] + ", " + temp[5] + ", " + temp[6]);
            menu.confirmAdditionMenu();


            openConnection();
            string statement = string.Format("INSERT INTO Contact_Info (First_Name, Other_Name, Email, Telephone, Street, Town, Country) VALUES ('{0}', '{1}', '{2}' , '{3}', '{4}', '{5}', '{6}')", temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6]);

            try
            {
            SqlCommand insertCommand = new SqlCommand(statement, conn);
            dataReader = insertCommand.ExecuteReader();
            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    Console.Write(dataReader.GetValue(i));
                }
            }
            }
            catch (InvalidOperationException f)
            {
                Console.WriteLine("Connection to the database has failed");
            }

        }


        public bool isInt(string word)
        {
            if (word.Any(Char.IsDigit)) return false;
            else return true;
        }
        public bool isNotInt(string word)
        {
            if (word.Any(Char.IsLetter)) return false;
            else return true;
        }
        public void editContact()
        {

        }
    }
}
