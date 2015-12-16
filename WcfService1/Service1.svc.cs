using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    public class Service1 : IService1
    {
        static string conn = @"Data Source = 31.186.250.81,1433; Initial Catalog = DB_ToDoList; User ID = test2; Password = test123; Trusted_Connection=false;";
        static DAL.DAL dal = new DAL.DAL(conn);


        public string[] getTheListString()
        {
            //
            List<ToDoList.ToDo> theToDoList = new List<ToDoList.ToDo>();
            theToDoList = dal.GetToDoList();
            theToDoList = theToDoList.OrderBy(x => x.DeadLine).ToList();
            //

            List<string> temp = new List<string>();
            foreach (ToDoList.ToDo td in theToDoList)
                temp.Add(td.Id + " " + td.Description + " " + td.Name + " " + td.DeadLine + " " + td.EstimationTime + " " + td.Finnished);
            return temp.ToArray();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dal"></param>
        public void addToDo()
        {
            ToDoList.ToDo td = new ToDoList.ToDo();
            td.Id = 4;
            td.Description = "Sova";
            td.Name = "Simon";

            DateTime thisdate = System.DateTime.Now;
            td.DeadLine = thisdate;
            td.CreatedDate = System.DateTime.Now;
            td.EstimationTime = 40;
            td.Finnished = false;

            dal.AddToDo(td);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="dal"></param>
        public bool removeToDo(int id)
        {
            try
            {
                Console.Write("Select ID: ");
                ToDoList.ToDo td = new ToDoList.ToDo();
                int count = dal.GetToDoList().Count();
                string choice = Console.ReadLine();
                if (int.Parse(choice) < count)
                {
                    List<ToDoList.ToDo> temp = dal.GetToDoListById(int.Parse(choice));

                    if (temp.Count > 0)
                    {
                        dal.DeleteToDoList(int.Parse(choice));
                        Console.WriteLine(temp.ElementAt(0).Id + " has been deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Nothing happend");
                        return false;
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }
    }
}
