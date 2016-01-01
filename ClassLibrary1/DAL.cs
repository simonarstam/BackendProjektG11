using System;
using ToDoList;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class DAL
    {
        private string ErrorMessage { get; set; }
        private SqlConnection conn;
        private static string connString;
        private SqlCommand command;
        private static List<ToDo> toDoList;

        private static List<ListName> listName; // Added

        public DAL(string _connString)
        {
            connString = _connString;
        }

        /// <summary>
        /// Edit: L_name
        /// ToDoList2
        /// Edited by Simon Årstam, 2015-12-31.
        /// Add an ToDo
        /// </summary>
        /// <param name="toDo"></param>
        public void AddToDo(ToDo toDo, string l_name)
        {
            try
            {
                int id = GetListIDByListName(l_name);
                using (conn)
                {
                    //using parametirized query
                    string sqlInserString =
                    "INSERT INTO ToDoList2 (Description, Name, CreatedDate, DeadLine, EstimationTime, Finnished, L_ID) VALUES ( @description, @name, @CreatedDate, @deadLine, @estimationTime, @finnished, @L_ID)";

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandText = sqlInserString;

                    SqlParameter descriptionParam = new SqlParameter("@description", toDo.Description);
                    SqlParameter userParam = new SqlParameter("@name", toDo.Name);
                    SqlParameter createdParam = new SqlParameter("@createdDate", toDo.CreatedDate);
                    SqlParameter deadLineParam = new SqlParameter("@deadLine", toDo.DeadLine);
                    SqlParameter estimateParam = new SqlParameter("@estimationTime", toDo.EstimationTime);
                    SqlParameter flagParam = new SqlParameter("@finnished", toDo.Finnished ? 1 : 0);
                    SqlParameter l_nameParam = new SqlParameter("@L_ID", id);

                    command.Parameters.AddRange(new SqlParameter[] { descriptionParam, userParam, createdParam, deadLineParam, estimateParam, flagParam, l_nameParam });
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        /// <summary>
        /// Update ToDo
        /// </summary>
        /// <param name="toDo"></param>
        public void UpdateToDoList(ToDo toDo)
        {
            try
            {
                using (conn)
                {
                    string sqlUpdateString =
                    "UPDATE ToDoList SET Description=@description, Name=@name, CreatedDate=@createdDate, DeadLine=@deadLine, EstimationTime=@estimationTime, Finnished=@finnished WHERE ID=" + toDo.Id;

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandText = sqlUpdateString;

                    SqlParameter descriptionParam = new SqlParameter("@Description", toDo.Description);
                    SqlParameter userParam = new SqlParameter("@Name", toDo.Name);
                    SqlParameter createdParam = new SqlParameter("@createdDate", toDo.CreatedDate);
                    SqlParameter deadLineParam = new SqlParameter("@deadLine", toDo.DeadLine);
                    SqlParameter estimateParam = new SqlParameter("@EstimationTime", toDo.EstimationTime);
                    SqlParameter flagParam = new SqlParameter("@finnished", toDo.Finnished ? 1 : 0);

                    command.Parameters.AddRange(new SqlParameter[] { descriptionParam, userParam, createdParam, deadLineParam, estimateParam, flagParam });
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        /// <summary>
        /// Delete ToDo, Edited by Simon Årstam, 20+15-12.31.
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteToDoList(int ID, string l_name)
        {
            try
            {
                int id = GetListIDByListName(l_name);
                using (conn)
                {
                    string sqlDeleteString = "DELETE FROM ToDoList2 WHERE ID=@ID AND L_ID=@L_ID";

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandText = sqlDeleteString;

                    SqlParameter IdParam = new SqlParameter("@ID", ID);
                    SqlParameter L_IDParam = new SqlParameter("@L_ID", id);

                    command.Parameters.AddRange(new SqlParameter[] { IdParam, L_IDParam });


                   // command.Parameters.Add(IdParam);
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
              
            }
        }

        /// <summary>
        /// Get ToDo list
        /// </summary>
        /// <returns></returns>
        public List<ToDo> GetToDoList()
        {
            try
            {
                using (conn)
                {
                    toDoList = new List<ToDo>();

                    conn = new SqlConnection(connString);

                    string sqlSelectString = "SELECT * FROM ToDoList";
                    command = new SqlCommand(sqlSelectString, conn);
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ToDo toDo = new ToDo();
                        toDo.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                        toDo.Description = reader.GetString(reader.GetOrdinal("Description"));
                        toDo.Name = reader.GetString(reader.GetOrdinal("Name"));
                        toDo.DeadLine = reader.GetDateTime(reader.GetOrdinal("DeadLine"));
                        toDo.CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                        toDo.EstimationTime = reader.GetInt32(reader.GetOrdinal("EstimationTime"));
                        toDo.Finnished = reader.GetBoolean(reader.GetOrdinal("Finnished"));
                        toDoList.Add(toDo);
                    }
                    command.Connection.Close();
                    return toDoList;
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return null;
        }


        /// <summary>
        /// Created by Simon Årstam, 2015-12-31.
        /// Add a List
        /// </summary>
        /// <param name="toDo"></param>
        public bool AddList(string name)
        {
            try
            {
                using (conn)
                {
                    //using parametirized query
                    string sqlInserString =
                    "INSERT INTO ListName (L_Name) VALUES (@name)";

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandText = sqlInserString;

                    SqlParameter userParam = new SqlParameter("@name", name);

                    command.Parameters.AddRange(new SqlParameter[] { userParam });
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Created by Simon Årstam, 2015-12-31.
        /// </summary>
        /// <param name="L_ID"></param>
        /// <returns></returns>
        public int GetListIDByListName(string L_Name)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    //conn = new SqlConnection(connString);
                    string sqlSelectString = "SELECT * FROM ListName WHERE L_Name=@name";

                    using (command = new SqlCommand())
                    {
                      //  command = new SqlCommand();
                        command.Connection = conn;
                        command.Connection.Open();
                        command.CommandText = sqlSelectString;
                        SqlParameter IdParam = new SqlParameter("@name", L_Name);
                        command.Parameters.Add(IdParam);

                        //command.Connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            ListName l_n = new ListName();
                            // return 32;
                            while (reader.Read())
                            {
                                l_n.L_ID = reader.GetInt32(reader.GetOrdinal("L_ID"));
                                l_n.L_Name = reader.GetString(reader.GetOrdinal("L_Name"));
                            }

                            if (l_n.L_ID > 0)
                                return l_n.L_ID;
                            //command.Connection.Close();
                            // reader.Close();
                            //  conn.Close();
                        }
                    }

                    
                    //return toDoList;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                //return ex.Message;
                Console.WriteLine(ex.Message);
               return 0;
            }
            //return 54; // 0 = means nothing was found.
            return 0;
        }

        /// <summary>
        /// By Simon Årstam, 2015-12-31.
        /// </summary>
        /// <returns></returns>
        public List<ToDo> GetToDoListByListName(string name)
        {




            //toDoList = new List<ToDo>() { new ToDo { Id = GetListIDByListName(name), Description ="" , Name = "sd", DeadLine = DateTime.Now,
            //           EstimationTime = 34, Finnished = true, ListID = 2} };
            //return toDoList;

            //toDoList = new List<ToDo>() { new ToDo { Id = 52, Description = "test", Name = "sd", DeadLine = DateTime.Now,
            //             EstimationTime = 34, Finnished = false, ListID = 4} };
            //return toDoList;
            int id = GetListIDByListName(name);
            //Console.WriteLine(id);
            try
            {
        
                using (SqlConnection conn = new SqlConnection(connString))
               {
                    //if (!(GetListIDByListName(name) > 0))
                    //{
                    //    toDoList = new List<ToDo>() { new ToDo { Id = 52, Description = "test", Name = "sd", DeadLine = DateTime.Now,
                   //     EstimationTime = 34, Finnished = false, ListID = 4} };
                    //    return toDoList;
                   // }
                    
                    using (command = new SqlCommand())
                    {
                        toDoList = new List<ToDo>();
                        //conn = new SqlConnection(connString);
                        string sqlSelectString = "SELECT * FROM ToDoList2 WHERE L_ID=@L_ID";
                        command = new SqlCommand();
                        command.Connection = conn;
                        command.Connection.Open();
                        command.CommandText = sqlSelectString;
                        //Console.WriteLine(GetListIDByListName(name));
                        SqlParameter IdParam = new SqlParameter("@L_ID", id);

                        command.Parameters.Add(IdParam);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ToDo toDo = new ToDo();
                                toDo.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                                toDo.Description = reader.GetString(reader.GetOrdinal("Description"));
                                toDo.Name = reader.GetString(reader.GetOrdinal("Name"));
                                toDo.DeadLine = reader.GetDateTime(reader.GetOrdinal("DeadLine"));
                                toDo.CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                                toDo.EstimationTime = reader.GetInt32(reader.GetOrdinal("EstimationTime"));
                                toDo.Finnished = reader.GetBoolean(reader.GetOrdinal("Finnished"));
                                toDo.ListID = reader.GetInt32(reader.GetOrdinal("L_ID"));
                                toDoList.Add(toDo);
                            }
                            //command.Connection.Close();
                            //reader.Close();
                            //conn.Close();
                        }
                        return toDoList;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Console.WriteLine(ex.Message);
                //Console.WriteLine(GetListIDByListName(name));
               Console.WriteLine(ErrorMessage);
            }
            return null;
        }

        /// <summary>
        /// Get ToDo list
        /// </summary>
        /// <returns></returns>
        public List<ToDo> GetToDoListById(int id)
        {
            try
            {
                using (conn)
                {
                    toDoList = new List<ToDo>();

                    conn = new SqlConnection(connString);

                    string sqlSelectString = "SELECT * FROM ToDoLIst WHERE ID=" + id;
                    command = new SqlCommand(sqlSelectString, conn);
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ToDo toDo = new ToDo();
                        toDo.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                        toDo.Description = reader.GetString(reader.GetOrdinal("Description"));
                        toDo.Name = reader.GetString(reader.GetOrdinal("Name"));
                        toDo.DeadLine = reader.GetDateTime(reader.GetOrdinal("DeadLine"));
                        toDo.CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                        toDo.EstimationTime = reader.GetInt32(reader.GetOrdinal("EstimationTime"));
                        toDo.Finnished = reader.GetBoolean(reader.GetOrdinal("Finnished"));
                        toDoList.Add(toDo);
                    }
                    command.Connection.Close();
                    return toDoList;
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return null;


        }

        public List<ToDo> GetToDoListByName(string name)
        {
            try
            {
                using (conn)
                {
                    toDoList = new List<ToDo>();

                    conn = new SqlConnection(connString);

                    string sqlSelectString = "select * from ToDoList where Name like '%" + name + "%'";
                    command = new SqlCommand(sqlSelectString, conn);
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ToDo toDo = new ToDo();
                        toDo.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                        toDo.Description = reader.GetString(reader.GetOrdinal("Description"));
                        toDo.Name = reader.GetString(reader.GetOrdinal("Name"));
                        toDo.DeadLine = reader.GetDateTime(reader.GetOrdinal("DeadLine"));
                        toDo.CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                        toDo.EstimationTime = reader.GetInt32(reader.GetOrdinal("EstimationTime"));
                        toDo.Finnished = reader.GetBoolean(reader.GetOrdinal("Finnished"));
                        toDoList.Add(toDo);
                    }
                    command.Connection.Close();
                    return toDoList;
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return null;
        }

        public String GetErrorMessage()
        {
            return ErrorMessage;
        }


    }
}
