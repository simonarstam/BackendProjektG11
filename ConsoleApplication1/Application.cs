using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Application
    {
        private ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        private string l_name;
        //private string m_errorMsg;

        /// <summary>
        /// Print menu.
        /// </summary>
        private void printMenu()
        {
            Console.WriteLine("\n1. List whole TodoList");
            Console.WriteLine("2. Add");
            Console.WriteLine("3. Remove");
            Console.WriteLine("4. Get the number of finished or unfinished toDos");
            Console.WriteLine("5. Show the list with the finished items");
        }

        /// <summary>
        ///  Start function
        /// </summary>
        public void start()
        {
            menuAskAboutList();
            while (true)
            {
                printMenu();
                Console.Write(Utilities.INPUT_SYMBOLS);
                string choice = Console.ReadLine();
               // Utilities.printNewLine();

                switch (choice)
                {
                    case "1":
                        printWholeList();
                        break;
                    case "2":
                        addToDo();
                        break;
                    case "3":
                        remove();
                        break;
                    case "4":
                        amountOfFinishedAndUnfinished();
                        break;
                    case "5":
                        finishedList();
                        break;
                    default:
                        Console.WriteLine("Invalid choice...");
                        break;
                }
            }
        }

        /// <summary>
        /// Created by Simon Årstam, 2015-12-31.
        /// </summary>
        private void menuAskAboutList()
        {
            bool choosingTODOLIST = true;
            while (choosingTODOLIST)
            {
                choosingTODOLIST = false;
                Console.WriteLine("1. Use an already existing TODO-list");
                Console.WriteLine("2. Create a new TODO-list");

                Console.Write(Utilities.INPUT_SYMBOLS);
                string input = Console.ReadLine();
                int number;
                int.TryParse(input, out number);
                switch (number)
                {
                    case 1:
                        if (!tryUseExistingList())
                            choosingTODOLIST = true;
                        break;
                    case 2:
                        tryCreateNewList();
                        break;
                    default:
                        choosingTODOLIST = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Written by Simon Årstam, 2015-12-31.
        /// </summary>
        /// <returns></returns>
        private bool tryUseExistingList()
        {
            l_name = Utilities.getInputString("Enter the name: ");

            if (!client.checkIfListExist(l_name))
            {
                Console.WriteLine("The list \"" + l_name + "\" doesn't exist. Please try another one!");
                return false;
            }
            else
                Console.WriteLine(l_name + " is now the selected list!");

            return true;
        }

        /// <summary>
        ///  Written by Simon Årstam, 2015-12-31.
        /// </summary>
        /// <returns></returns>
        private bool tryCreateNewList()
        {
            l_name = Utilities.getInputListName("Type in a list name. Allowed characters a-z, allowed numbers 0-9");
            if (client.addListName(l_name))
            {
                Console.WriteLine("Success");
            }
            else { 
                Console.WriteLine("Fail");
                return false;
            }
            return true;
        }


        /// <summary>
        /// Print the whole ToDoList
        /// </summary>
        private void printWholeList()
        {
            string[] st = client.getTheListString(l_name);

            if (st.Count() > 0)
            {
                foreach (string s in st)
                    Console.WriteLine(s);
            }
            else
                Console.WriteLine("There is no tasks in the list!");
        }

        /// <summary>
        /// Adding a ToDo
        /// </summary>
        private void addToDo()
        {
            string description = Utilities.getInputString("What do you want to do? (ex. \"do laundry\" or \"do laundry, do dishes\" will create multiple list items)");
            string name = Utilities.getInputString("Who is going to do the task? (ex. Anna)");
            int estimationTime = Utilities.getInputTime("How long time is the task going to take (in minutes)?", "It has to be a positive number!");
            int year = Utilities.getInputYear("When should the task be done? Year", "It has to be a number between 0 and 9999!");
            int month = Utilities.getInputMonth("When should the task be done? Month", "It has to be a number between 1 and 12");
            int day = Utilities.getInputDay("When should the task be done? Day", "It has to be a number between 1 and 31");

            DateTime time = DateTime.Now;
            DateTime dm = new DateTime();
            bool datetime_ok = false;
            while(!datetime_ok)
            {
                try
                {
                    dm = new DateTime(year, month, day, time.Hour, time.Minute, time.Second);
                    datetime_ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid date! Please try again.");
                    year = Utilities.getInputYear("When should the task be done? Year", "It has to be a number between 0 and 9999!");
                    month = Utilities.getInputMonth("When should the task be done? Month", "It has to be a number between 1 and 12");
                    day = Utilities.getInputDay("When should the task be done? Day", "It has to be a number between 1 and 31");
                }
            }

            bool finnished = Utilities.getInputBooleanFromNumber("Is the task finished or not? (1 for true and 0 for false)", 
                "Incorrect input. The value has to be 0 or 1.");
            DateTime createdDate = System.DateTime.Now;

            string[] descs = description.Split(',');

            foreach (string desc in descs)
            {
                client.addToDo(desc.Trim(), name, createdDate, dm, estimationTime, finnished, l_name);
                Console.WriteLine("The task \"" + desc.Trim() + "\" has been successfully addded to the list.");
            }
        }

        /// <summary>
        /// removes a ToDo
        /// </summary>
        public void remove()
        {
            int id = Utilities.getInputInt("Select ID (positive number above 0).", "Invalid input! It has to be a positive number above 0.");

            if (client.removeToDo(id, l_name))
                Console.WriteLine("The task which had ID \"" + id + "\" from tasklist \"" + l_name + "\" is now deleted!");
            else
                Console.WriteLine("The selected task ID couldn't get deleted or couldn't be found.");
        }

        /// <summary>
        /// Print the amount of finished and unfinished ToDo tasks.
        /// </summary>
        public void amountOfFinishedAndUnfinished()
        {
            int[] idQuantity = client.GetListFinishedAndUnfinished(l_name);
            Console.WriteLine("The number of finished items is {0} and the number of unfinished items is {1} "
                , idQuantity[0], idQuantity[1]);
        }

        /// <summary>
        /// Prints the finished tasks from the ToDo-list.
        /// </summary>
        public void finishedList()
        {
            string[] tdl = client.FinishedItemsToDo(l_name);
            if (tdl.Count() > 0)
            {
                foreach (string s in tdl)
                    Console.WriteLine(s);
            }
            else
                Console.WriteLine("There is no finished tasks in the list.");

        }
    }
}
