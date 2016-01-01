using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A class that stores helpful functions.
/// </summary>
namespace ConsoleApplication1
{
    class Utilities
    {
        public const string INPUT_SYMBOLS = ">> ";

        /// <summary>
        /// Created by Simon Årstam, 2015-12-31.
        /// </summary>
        public static void printNewLine()
        {
            Console.WriteLine("\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
       public static bool checkString(string input)
       {
            if (!(input.Length > 0))
                return false;
            return true;
       }

        /// <summary>
        /// Created by Simon Årstam, 2015-12-31.
        /// </summary>
        /// <param name="msg"></param>
       public static void printErrorMessage(string msg = "")
       {
            if (msg == "")
                Console.WriteLine("Incorrect input. Please try again.");
            else
                Console.WriteLine(msg);
       }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string getInputString(string msg="")
        {
            //Console.WriteLine("What do you want to do?");
            if (!(msg == ""))
                Console.WriteLine(msg);

            Console.Write(Utilities.INPUT_SYMBOLS);
            string temp = Console.ReadLine();
            while (!Utilities.checkString(temp))
            {
                Utilities.printErrorMessage();
                Console.Write(Utilities.INPUT_SYMBOLS);
                temp = Console.ReadLine();
            }

            return temp;
           // return "";
        }

        /// <summary>
        /// Created by Simon Årstam.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string getInputListName(string msg="", string errorMsg="")
        {
            //Console.WriteLine("What do you want to do?");
            if (!(msg == ""))
                Console.WriteLine(msg);

            Console.Write(Utilities.INPUT_SYMBOLS);
            string temp = Console.ReadLine();
            while (!(Utilities.checkListName(temp) || !Utilities.checkString(temp)))
            {
                if (errorMsg != "") Console.WriteLine(errorMsg);
                else Console.WriteLine("That list already exists or use of invalid characters. Please try again.");

               // Utilities.printErrorMessage();
                Console.Write(Utilities.INPUT_SYMBOLS);
                temp = Console.ReadLine();
            }

            return temp;
            // return "";
        }

        /// <summary>
        /// Writen by Lucian.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static int getInputTime(string msg="", string errorMsg="")
        {
            int tempInt;

            if (!(msg == ""))
                Console.WriteLine(msg);
            Console.Write(Utilities.INPUT_SYMBOLS);

            string tempString = Console.ReadLine();

            while (!int.TryParse(tempString, out tempInt) || !(tempInt >= 0 ))
            {
                if (errorMsg == "")
                    Console.WriteLine("It has to be a number!");
                else
                    Console.WriteLine(errorMsg);
                Console.Write(INPUT_SYMBOLS);
                tempString = Console.ReadLine();
            }
            return tempInt;
        }

        /// <summary>
        /// s
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static int getInputYear(string msg="", string errorMsg="")
        {
            //int temp = getInputInt(msg);

            int year;

            if (msg != "")
                Console.WriteLine(msg);
            Console.Write(INPUT_SYMBOLS);
            string stringYear = Console.ReadLine();

            while ((!int.TryParse(stringYear, out year)) || !(year >= 0 && year < 10000))
            {
                if (errorMsg == "")
                    Console.WriteLine(Environment.NewLine + " It has to be a number max 9999");
                else
                    Console.WriteLine(errorMsg);
                Console.Write(INPUT_SYMBOLS);
                stringYear = Console.ReadLine();
            }
            return year;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static int getInputMonth(string msg="", string errorMsg="")
        {
            int month;
            if (msg != "")
                Console.WriteLine(msg);
            Console.Write(INPUT_SYMBOLS);
            string stringMonth = Console.ReadLine();
            while ((!int.TryParse(stringMonth, out month)) || (month <= 0 || month >= 13))
            {
                if (errorMsg == "")
                    Console.WriteLine("It has to be a number between 1 and 12");
                else
                    Console.WriteLine(errorMsg);

                Console.Write(INPUT_SYMBOLS);
                stringMonth = Console.ReadLine();
            }
            return month;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static int getInputDay(string msg="", string errorMsg="")
        {
            int day;
            if (msg != "")
                Console.WriteLine(msg);
            
            Console.Write(INPUT_SYMBOLS);
            string stringDay = Console.ReadLine();
            while (!int.TryParse(stringDay, out day) || (day <= 0 || day >= 31))
            {
                if (errorMsg == "")
                    Console.WriteLine("It has to be a number between 1 and 31");
                else
                    Console.WriteLine(errorMsg);
                Console.Write(INPUT_SYMBOLS);
                stringDay = Console.ReadLine();
            }
            return day;
        }

        /// <summary>
        /// Written by Lucian and Simon Årstam.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool getInputBooleanFromNumber(string msg = "", string errorMsg="")
        {
            if (msg == "")
                Console.WriteLine("Is the jobb finished or not? (1 for true and 0 for false)");
            else
                Console.WriteLine(msg);

            Console.Write(INPUT_SYMBOLS);
            string stringFinished = Console.ReadLine();
            while (!(stringFinished == "1" || stringFinished == "0"))//|| stringFinished != "0")
            {
                if (errorMsg == "")
                    Console.WriteLine("Incorrect input. The value has to be 0 or 1.");
                else
                    Console.WriteLine(errorMsg);
                Console.Write(INPUT_SYMBOLS);
                stringFinished = Console.ReadLine();
            }

            if (stringFinished == "1")
                return true;
            else if (stringFinished == "0")
                return false;

            return true;
        }


        public static int getInputInt(string msg= "", string errorMsg = "")
        {
            int temp;
            if (msg != "")
                Console.WriteLine(msg);

            Console.Write(INPUT_SYMBOLS);
            string stringtemp = Console.ReadLine();
            while (!int.TryParse(stringtemp, out temp) || !(temp > 0))
            {
                if (errorMsg == "")
                    Console.WriteLine("Invalid input! It has to be a positive number above 0.");
                else
                    Console.WriteLine(errorMsg);
                Console.Write(INPUT_SYMBOLS);
                stringtemp = Console.ReadLine();
            }
            return temp;
        }

        /// <summary>
        /// Created by Simon Årstam, 2015-12-31.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool checkListName(string name)
        {
            string validChars = "abcdefghijklmnopqrstuvwxyz0123456789012";
            foreach (char c in name.ToLower())
            {
                if (!validChars.Contains(c)) return false; 
            }

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            if (client.checkIfListExist(name)) return false;

            return true;
        }
    }
}
