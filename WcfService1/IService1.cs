using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace WcfService1
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string[] getTheListString(string name);

        [OperationContract]
        bool removeToDo(int id, string l_name);

        [OperationContract]
        void addToDo(string description, string name, DateTime CreatedDate, DateTime dm, int estimationTime, bool finnished, string l_name);

        [OperationContract]
        string[] FinishedItemsToDo(string l_name);

        [OperationContract]
        int [] GetListFinishedAndUnfinished(string l_name);

        //[OperationContract]
        //bool ifTableNameExist(string name);
        [OperationContract]
        bool addListName(string name);

        [OperationContract]
        bool checkIfListExist(string name);



    }
}
