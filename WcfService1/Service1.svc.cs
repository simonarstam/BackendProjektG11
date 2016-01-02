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


        /// <summary>
        /// Created by Simon Årstam.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string[] getTheListString(string name)
        {
            //
            List<ToDoList.ToDo> theToDoList = new List<ToDoList.ToDo>();
            //theToDoList = dal.GetToDoList();
            theToDoList = dal.GetToDoListByListName(name);



            theToDoList = theToDoList.OrderBy(x => x.DeadLine).ToList();
            //

            List<string> temp = new List<string>();
            foreach (ToDoList.ToDo td in theToDoList)
                temp.Add(td.Id + " " + td.Description + " " + td.Name + " " +td.CreatedDate + " " + td.DeadLine + " " + td.EstimationTime + " " + td.Finnished);
            return temp.ToArray();
        }

        /// <summary>
        /// Created by Simon Årstam, 2015-12-31.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool checkIfListExist(string name)
        {
            if (!(dal.GetListIDByListName(name) > 0))
                return false;
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dal"></param>
        public void addToDo(string description, string name, DateTime CreatedDate, DateTime dm, int estimationTime, bool finnished, string l_name)
        {
            ToDoList.ToDo td = new ToDoList.ToDo();
         
            td.Description = description;
            td.Name = name;
            td.DeadLine = dm;
            td.CreatedDate = CreatedDate;
            td.EstimationTime = estimationTime;
            td.Finnished = finnished;
            
            dal.AddToDo(td, l_name);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="dal"></param>
        public bool removeToDo(int id, string l_name)
        {
            try
            {
                //Console.Write("Select ID: ");
                ToDoList.ToDo td = new ToDoList.ToDo();
                //int count = dal.GetToDoList().Count();
                //string choice = Console.ReadLine();



                if (dal.GetListIDByListName(l_name) > 0)
                {
                    List<ToDoList.ToDo> temp = dal.GetToDoListByListName(l_name);

                    if (temp.Count > 0)
                        dal.DeleteToDoList(id, l_name);
                    else
                        return false;
                    //Console.WriteLine("Nothing happend");
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        public string[] FinishedItemsToDo(string l_name)
        {
            List<ToDoList.ToDo> theToDoList = new List<ToDoList.ToDo>();
            theToDoList = dal.GetToDoListByListName(l_name);
            List<ToDoList.ToDo> finishedItems = theToDoList.FindAll(finished => finished.Finnished);

            List<string> listToArray = new List<string>();
            foreach (ToDoList.ToDo td in finishedItems) 
                {
               
                    listToArray.Add(td.Id + " " + td.Description + " " + td.Name + " " + td.CreatedDate + " " + td.DeadLine + " " + td.EstimationTime + " " + td.Finnished);
                
                }
            return listToArray.ToArray();
            

        }

        public string[] ImportantItemsToDo(string l_name)
        {
            List<ToDoList.ToDo> theToDoList = new List<ToDoList.ToDo>();
            theToDoList = dal.GetToDoListByListName(l_name);
            List<ToDoList.ToDo> finishedItems = theToDoList.FindAll(finished => finished.Finnished);

            List<string> listToArray = new List<string>();
            foreach (ToDoList.ToDo td in finishedItems)
            {
                string important = td.Name.Substring(td.Name.Length - 1, 1); 
                if (  (important == "!"))
                {
                    listToArray.Add(td.Id + " " + td.Description + " " + td.Name + " " + td.CreatedDate + " " + td.DeadLine + " " + td.EstimationTime + " " + td.Finnished);
                }
            }
            return listToArray.ToArray();

        }
        public int[] GetListFinishedAndUnfinished(string l_name)
        {
            List<ToDoList.ToDo> theToDoList = new List<ToDoList.ToDo>();
            theToDoList = dal.GetToDoListByListName(l_name);
            List<ToDoList.ToDo> finished = theToDoList.FindAll(final => final.Finnished );
            int countFinished = finished.Count();
            List<ToDoList.ToDo> unfinished = theToDoList.FindAll(final => !final.Finnished);
            int countUnfinished = unfinished.Count();
            int[] getListFinishedAndUnfinished = new int[] { countFinished, countUnfinished };
            return getListFinishedAndUnfinished;
        }

        /// <summary>
        /// Created by Simon Årstam.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool addListName(string name)
        { 
            ToDoList.ListName ln = new ToDoList.ListName() { L_Name = name };
            
            // Check if errors in name etc.
            if (!ln.checkData()) return false;

            // Check if exist in database already.
            if (this.checkIfListExist(name)) return false;

            dal.AddList(name);             

          //  response = "Sucessful!";
            return true;
        }

        public bool UpdateToDo(int idUpdate, string descriptionUpdate, string nameUpdate, DateTime CreatedDateUpdate, DateTime dmUpdate, int estimationTimeUpdate, bool finnishedUpdate, string l_name)
        {
            try
            {

                //Console.Write("Select ID: ");
                ToDoList.ToDo td = new ToDoList.ToDo();
                td.Id = idUpdate;
                td.Description = descriptionUpdate;
                td.Name = nameUpdate;
                td.DeadLine = dmUpdate;
                td.CreatedDate = CreatedDateUpdate;
                td.EstimationTime = estimationTimeUpdate;
                td.Finnished = finnishedUpdate;

                int count = dal.GetToDoList().Count();
                //string choice = Console.ReadLine();
                if (idUpdate < count)
                {
                    List<ToDoList.ToDo> temp = dal.GetToDoListById(idUpdate);

                    if (temp.Count > 0)
                    {
                        dal.UpdateToDoList(td, l_name);
                        Console.WriteLine(temp.ElementAt(0).Id + " has been updated.");
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
