using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static string conn =//@"Data Source = 127.,1433; Initial Catalog = DB_ToDoList; User ID = RestFullUser; Password = RestFull123;";
                   @"Data Source = 31.186.250.81,1433; Initial Catalog = DB_ToDoList; User ID = test2; Password = test123; Trusted_Connection=false;";
        static DAL.DAL dal = new DAL.DAL(conn);

        static void Main(string[] args)
        {
            test3();
            Console.ReadKey();
        }
        static void test1()
        {
            List<ToDoList.ToDo> td;// = new ToDoList.ToDo();
            td = new List<ToDoList.ToDo>();
            td = dal.GetToDoListByListName("Simons lista");

            try
            {
                if (td.Count > 0)
                    Console.WriteLine(td.ElementAt(0).Name);
                else
                    Console.WriteLine("Nothing here..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();


        }

        static void test2()
        {

            //addToDo(desc, name, createdDate, dm, estimationTime, finnished, l_name);

            ToDoList.ToDo td = new ToDoList.ToDo()
            {
                Description = "Test",
                Name = "Simon",
                CreatedDate = DateTime.Now,
                DeadLine = DateTime.Now,
                EstimationTime = 30,
                Finnished = true
            };

            dal.AddToDo(td, "test");

            if (!(dal.GetErrorMessage() == ""))
                Console.WriteLine(dal.GetErrorMessage());
        }

        public static void test3()
        {
            dal.DeleteToDoList(19, "testing123");
            if (dal.GetErrorMessage() != "")
                Console.WriteLine(dal.GetErrorMessage());
        }
}
}
