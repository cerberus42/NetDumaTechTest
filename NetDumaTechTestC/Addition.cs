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
            string[] titleName = {"First Name", "Last Name", "Email", "Telephone", "Street", "Town", "Country" }; 
            Console.WriteLine("Please enter all the information in as correct as possible. Maximum field sizes vary.");
            int i = -1;
            foreach(string s in titleName)
            {
                running = true;
                i++;
                string header = string.Format("Please enter your {0}", titleName[i]);
                Console.WriteLine(header);
                if(i == 2)
                {
                    string[] testing = { "@", ".com", ".uk", ".co" };
                    while (running == true)
                    {
                        temp[2] = Console.ReadLine();
                        if (testing.Any(temp[2].Contains) == true) running = false;
                        else if (testing.Any(temp[2].Contains) == false) Console.WriteLine("You entered {0} please enter a valid string", temp[2]);
                    }
                }
                if(i == 3)
                {
                    {
                        temp[3] = Console.ReadLine();
                        if (isNotInt(temp[3]) == true) running = false;
                        else if (isNotInt(temp[3]) == false) Console.WriteLine("You entered {0} please enter a valid string", temp[3]);
                    }
                }
                while (running == true)
                {
                    temp[i] = Console.ReadLine();
                    if (isInt(temp[i]) == true) running = false;
                    else if (isInt(temp[i]) == false) Console.WriteLine("You entered {0} please enter a valid string", temp[i]);
                }

            }
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
                for (int x = 0; i < dataReader.FieldCount; x++)
                {
                    Console.Write(dataReader.GetValue(x));
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
