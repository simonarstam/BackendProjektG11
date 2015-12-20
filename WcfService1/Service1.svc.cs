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
        static string conn =//@"Data Source = 127.,1433; Initial Catalog = DB_ToDoList; User ID = RestFullUser; Password = RestFull123;";
                           @"Data Source = 31.186.250.81,1433; Initial Catalog = DB_ToDoList; User ID = test2; Password = test123; Trusted_Connection=false;";
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
                temp.Add(td.Id + " " + td.Description + " " + td.Name + " " +td.CreatedDate + " " + td.DeadLine + " " + td.EstimationTime + " " + td.Finnished);
            return temp.ToArray();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dal"></param>
        public void addToDo(string description, string name, DateTime CreatedDate, DateTime dm, int estimationTime, bool finnished)
        {
            ToDoList.ToDo td = new ToDoList.ToDo();
         
            td.Description = description;
            td.Name = name;
            td.DeadLine = dm;
            td.CreatedDate = CreatedDate;
            td.EstimationTime = estimationTime;
            td.Finnished = finnished;

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
                //Console.Write("Select ID: ");
                ToDoList.ToDo td = new ToDoList.ToDo();
                int count = dal.GetToDoList().Count();
                //string choice = Console.ReadLine();
                if (id < count)
                {
                    List<ToDoList.ToDo> temp = dal.GetToDoListById(id);

                    if (temp.Count > 0)
                    {
                        dal.DeleteToDoList(id);
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

        //public bool FinnishedToDo(int id)
        //{
        //    ToDoList.ToDo td = new ToDoList.ToDo();


        //}

        public int[] GetListFinishedAndUnfinished()
        {
            //ToDoList.ToDo td = new ToDoList.ToDo();
            List<ToDoList.ToDo> theToDoList = new List<ToDoList.ToDo>();
            theToDoList = dal.GetToDoList();
            List<ToDoList.ToDo> finished = theToDoList.FindAll(final => final.Finnished );
            int countFinished = finished.Count();
            List<ToDoList.ToDo> unfinished = theToDoList.FindAll(final => !final.Finnished);
            int countUnfinished = unfinished.Count();
            int[] getListFinishedAndUnfinished = new int[] { countFinished, countUnfinished };
            return getListFinishedAndUnfinished;
        }
    }
}
