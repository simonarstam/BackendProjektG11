using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
           
        // string conn = @"Data Source = localhost; Initial Catalog = DB_ToDoList; User ID = RestFullUser; Password = RestFull123; Trusted_Connection=true;";
        //    try
        //    {
        //        SqlConnection conn1 = new SqlConnection(conn);
        //conn1.Open();
        //    } catch(Exception ex)
        //    {
        //        Console.Write(ex);
        //    }


                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            while (true)
            {
                Console.WriteLine("1. List whole TodoList");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Remove");
                Console.Write(">> ");
                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        foreach (string s in client.getTheListString())
                        {
                            Console.WriteLine(s);
                        }
                        break;
                    
                    case "2":
                        Console.WriteLine("What do you want to do?");
                        string description = Console.ReadLine();

                        Console.WriteLine("Who is going to do the jobb?");
                        string name = Console.ReadLine();

                        Console.WriteLine("How much time is gone take to do the jobb?");
                        int estimationTime;
                        bool intEstimationTime = int.TryParse(Console.ReadLine(), out estimationTime);

                        Console.WriteLine("When the jobb should be done? Year");
                        int year;
                        bool intYear = int.TryParse(Console.ReadLine(), out year);
                        Console.WriteLine("When the jobb should be done? Month");
                        int month;

                        bool intMonth = int.TryParse(Console.ReadLine(), out month);
                        Console.WriteLine("When the jobb should be done? Day");
                        int day;
                        string stringDay = Console.ReadLine();
                        while (!int.TryParse(stringDay, out day))
                        {
                            Console.WriteLine(Environment.NewLine + " It has to be a number between 1 and 31");
                            Console.Write(Environment.NewLine);
                            stringDay = Console.ReadLine();
                        }

                        while (day <= 0 || day >= 31) 
                        {
                            Console.WriteLine(Environment.NewLine + " It has to be a number between 1 and 31");
                            Console.Write(Environment.NewLine);
                            stringDay = Console.ReadLine();
                            int.TryParse(stringDay, out day);
                        }
                            DateTime dm = new DateTime(year, month, day, 12, 5, 13);

                        Console.WriteLine("Is the jobb finished or not? \n 1 for true and 0 for false");
                        string stringFinnished = Console.ReadLine();
                        bool finnished = true;

                        switch (stringFinnished)
                        {
                            case "1":
                                finnished = true;
                                Console.WriteLine(finnished);
                                break;

                            case "0":
                                finnished = false;
                                break;
                        }

                        client.addToDo(description, name, dm, estimationTime, finnished);

                        break;

                    case "3":
                        int id;
                        Console.WriteLine("Select ID:");
                        string stringId = Console.ReadLine();
                        while (!int.TryParse(stringId, out id))
                        {
                            Console.WriteLine(Environment.NewLine + " Choose a number");
                            Console.Write(Environment.NewLine);
                            stringId = Console.ReadLine();
                        }
                        client.removeToDo(id);
                        break;

                    default:
                        Console.WriteLine("Invalid choice...");
                        break;
                }
            }
            //client.Close();









           // Console.ReadKey();
        }
    }
}
