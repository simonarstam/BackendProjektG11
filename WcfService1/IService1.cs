﻿using System;
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
        string[] getTheListString();

        [OperationContract]
        bool removeToDo(int id);

        [OperationContract]
        void addToDo(string description, string name, DateTime CreatedDate, DateTime dm, int estimationTime, bool finnished);

        //[OperationContract]
        //bool FinnishedToDO(int id);

        [OperationContract]
        int [] GetListFinishedAndUnfinished();
    }
}
