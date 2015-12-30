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
                Console.WriteLine("\n1. List whole TodoList");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Remove");
                Console.WriteLine("4. Get the number of finished or unfinished toDos");
                Console.WriteLine("5. Show the list with the finished items");
                Console.Write(">> ");
                string choice = Console.ReadLine();
                Console.WriteLine("\n");


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
                        string stringEstimationTime = Console.ReadLine();
                        while (!int.TryParse(stringEstimationTime, out estimationTime))
                        {
                            Console.WriteLine(Environment.NewLine + " It has to be a number");
                            Console.Write(Environment.NewLine);
                            stringEstimationTime = Console.ReadLine();
                        }


                        Console.WriteLine("When the jobb should be done? Year");
                        int year;
                        string stringYear = Console.ReadLine();
                        while (!int.TryParse(stringYear, out year))
                        {
                            Console.WriteLine(Environment.NewLine + " It has to be a number max 9999");
                            Console.Write(Environment.NewLine);
                            stringYear = Console.ReadLine();
                        }

                        while (year <= 0 || year >= 10000)
                        {
                            Console.WriteLine(Environment.NewLine + " It has to be a number max 9999");
                            Console.Write(Environment.NewLine);
                            stringYear = Console.ReadLine();
                            int.TryParse(stringYear, out year);
                        }
                      

                        Console.WriteLine("When the jobb should be done? Month");
                        int month;
                        string stringMonth = Console.ReadLine();
                        while (!int.TryParse(stringMonth, out month))
                        {
                            Console.WriteLine(Environment.NewLine + " It has to be a number between 1 and 12");
                            Console.Write(Environment.NewLine);
                            stringMonth = Console.ReadLine();
                        }

                        while (month <= 0 || month >= 13)
                        {
                            Console.WriteLine(Environment.NewLine + " It has to be a number between 1 and 12");
                            Console.Write(Environment.NewLine);
                            stringMonth = Console.ReadLine();
                            int.TryParse(stringMonth, out month);
                        }

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
                        var time = DateTime.Now;
                            DateTime dm = new DateTime(year, month, day, time.Hour, time.Minute, time.Second);

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
                        DateTime createdDate = System.DateTime.Now;
                        client.addToDo(description, name, createdDate, dm, estimationTime, finnished);

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

                    case "4":
                        int[] idQuantity = client.GetListFinishedAndUnfinished();
                        //foreach (int i in idQuantity)
                        //{
                            Console.WriteLine("\n The number of finished items is {0} and the number of unfinished items is {1} ", idQuantity[0], idQuantity[1] + "\n");
                        //}
                            break;

                    case "5":
                        foreach (string s in client.FinishedItemsToDo())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice...");
                        break;

                    case "6":

                        int idUpdate;
                        Console.WriteLine("Select ID:");
                        string stringIdUpdate = Console.ReadLine();
                        while (!int.TryParse(stringIdUpdate, out idUpdate))
                        {
                            Console.WriteLine(Environment.NewLine + " Choose a number");
                            Console.Write(Environment.NewLine);
                            stringId = Console.ReadLine();
                        }
                        //client.removeToDo(id);

                        Console.WriteLine("What do you want to do?");
                        string descriptionUpdate = Console.ReadLine();

                        Console.WriteLine("Who is going to do the jobb?");
                        string nameUpdate = Console.ReadLine();

                        Console.WriteLine("How much time is gone take to do the jobb?");
                        int estimationTimeUpdate;
                        string stringEstimationTimeUpdate = Console.ReadLine();
                        while (!int.TryParse(stringEstimationTimeUpdate, out estimationTimeUpdate))
                        {
                            Console.WriteLine(Environment.NewLine + " It has to be a number");
                            Console.Write(Environment.NewLine);
                            stringEstimationTime = Console.ReadLine();
                        }


                        Console.WriteLine("When the jobb should be done? Year");
                        int yearUpdate;
                        string stringYearUpdate = Console.ReadLine();
                        while (!int.TryParse(stringYearUpdate, out year))
                        {
                            Console.WriteLine(Environment.NewLine + " It has to be a number max 9999");
                            Console.Write(Environment.NewLine);
                            stringYear = Console.ReadLine();
                        }

                        while (year <= 0 || year >= 10000)
                        {
                            Console.WriteLine(Environment.NewLine + " It has to be a number max 9999");
                            Console.Write(Environment.NewLine);
                            stringYear = Console.ReadLine();
                            int.TryParse(stringYear, out year);
                        }


                        Console.WriteLine("When the jobb should be done? Month");
                        int monthUpdate;
                        string stringMonthUpdate = Console.ReadLine();
                        while (!int.TryParse(stringMonthUpdate, out month))
                        {
                            Console.WriteLine(Environment.NewLine + " It has to be a number between 1 and 12");
                            Console.Write(Environment.NewLine);
                            stringMonth = Console.ReadLine();
                        }

                        while (month <= 0 || month >= 13)
                        {
                            Console.WriteLine(Environment.NewLine + " It has to be a number between 1 and 12");
                            Console.Write(Environment.NewLine);
                            stringMonth = Console.ReadLine();
                            int.TryParse(stringMonth, out month);
                        }

                        Console.WriteLine("When the jobb should be done? Day");
                        int dayUpdate;
                        string stringDayUpdate = Console.ReadLine();
                        while (!int.TryParse(stringDayUpdate, out day))
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
                        var timeUpdate = DateTime.Now;
                        DateTime dmUpdate = new DateTime(year, month, day, timeUpdate.Hour, timeUpdate.Minute, timeUpdate.Second);

                        Console.WriteLine("Is the jobb finished or not? \n 1 for true and 0 for false");
                        string stringFinnishedUpdate = Console.ReadLine();
                        bool finnishedUpdate = true;

                        switch (stringFinnishedUpdate)
                        {
                            case "1":
                                finnished = true;
                                Console.WriteLine(finnished);
                                break;

                            case "0":
                                finnished = false;
                                break;
                        }
                        DateTime createdDateUpdate = System.DateTime.Now;
                        client.UpdateToDo(idUpdate, descriptionUpdate, nameUpdate, createdDateUpdate, dmUpdate, estimationTimeUpdate, finnishedUpdate);

                        break;


                }
            }
            //client.Close();









           // Console.ReadKey();
        }
    }
}
