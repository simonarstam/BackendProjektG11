﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getTheListString", ReplyAction="http://tempuri.org/IService1/getTheListStringResponse")]
        string[] getTheListString(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getTheListString", ReplyAction="http://tempuri.org/IService1/getTheListStringResponse")]
        System.Threading.Tasks.Task<string[]> getTheListStringAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/removeToDo", ReplyAction="http://tempuri.org/IService1/removeToDoResponse")]
        bool removeToDo(int id, string l_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/removeToDo", ReplyAction="http://tempuri.org/IService1/removeToDoResponse")]
        System.Threading.Tasks.Task<bool> removeToDoAsync(int id, string l_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/addToDo", ReplyAction="http://tempuri.org/IService1/addToDoResponse")]
        void addToDo(string description, string name, System.DateTime CreatedDate, System.DateTime dm, int estimationTime, bool finnished, string l_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/addToDo", ReplyAction="http://tempuri.org/IService1/addToDoResponse")]
        System.Threading.Tasks.Task addToDoAsync(string description, string name, System.DateTime CreatedDate, System.DateTime dm, int estimationTime, bool finnished, string l_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/FinishedItemsToDo", ReplyAction="http://tempuri.org/IService1/FinishedItemsToDoResponse")]
        string[] FinishedItemsToDo(string l_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/FinishedItemsToDo", ReplyAction="http://tempuri.org/IService1/FinishedItemsToDoResponse")]
        System.Threading.Tasks.Task<string[]> FinishedItemsToDoAsync(string l_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetListFinishedAndUnfinished", ReplyAction="http://tempuri.org/IService1/GetListFinishedAndUnfinishedResponse")]
        int[] GetListFinishedAndUnfinished(string l_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetListFinishedAndUnfinished", ReplyAction="http://tempuri.org/IService1/GetListFinishedAndUnfinishedResponse")]
        System.Threading.Tasks.Task<int[]> GetListFinishedAndUnfinishedAsync(string l_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/addListName", ReplyAction="http://tempuri.org/IService1/addListNameResponse")]
        bool addListName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/addListName", ReplyAction="http://tempuri.org/IService1/addListNameResponse")]
        System.Threading.Tasks.Task<bool> addListNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/checkIfListExist", ReplyAction="http://tempuri.org/IService1/checkIfListExistResponse")]
        bool checkIfListExist(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/checkIfListExist", ReplyAction="http://tempuri.org/IService1/checkIfListExistResponse")]
        System.Threading.Tasks.Task<bool> checkIfListExistAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateToDo", ReplyAction="http://tempuri.org/IService1/UpdateToDoResponse")]
        bool UpdateToDo(int idUpdate, string descriptionUpdate, string nameUpdate, System.DateTime CreatedDateUpdate, System.DateTime dmUpdate, int estimationTimeUpdate, bool finnishedUpdate, string l_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateToDo", ReplyAction="http://tempuri.org/IService1/UpdateToDoResponse")]
        System.Threading.Tasks.Task<bool> UpdateToDoAsync(int idUpdate, string descriptionUpdate, string nameUpdate, System.DateTime CreatedDateUpdate, System.DateTime dmUpdate, int estimationTimeUpdate, bool finnishedUpdate, string l_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ImportantItemsToDo", ReplyAction="http://tempuri.org/IService1/ImportantItemsToDoResponse")]
        string[] ImportantItemsToDo(string l_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ImportantItemsToDo", ReplyAction="http://tempuri.org/IService1/ImportantItemsToDoResponse")]
        System.Threading.Tasks.Task<string[]> ImportantItemsToDoAsync(string l_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/TotalEstimationsItemsToDo", ReplyAction="http://tempuri.org/IService1/TotalEstimationsItemsToDoResponse")]
        int TotalEstimationsItemsToDo(string l_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/TotalEstimationsItemsToDo", ReplyAction="http://tempuri.org/IService1/TotalEstimationsItemsToDoResponse")]
        System.Threading.Tasks.Task<int> TotalEstimationsItemsToDoAsync(string l_name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ConsoleApplication1.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ConsoleApplication1.ServiceReference1.IService1>, ConsoleApplication1.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] getTheListString(string name) {
            return base.Channel.getTheListString(name);
        }
        
        public System.Threading.Tasks.Task<string[]> getTheListStringAsync(string name) {
            return base.Channel.getTheListStringAsync(name);
        }
        
        public bool removeToDo(int id, string l_name) {
            return base.Channel.removeToDo(id, l_name);
        }
        
        public System.Threading.Tasks.Task<bool> removeToDoAsync(int id, string l_name) {
            return base.Channel.removeToDoAsync(id, l_name);
        }
        
        public void addToDo(string description, string name, System.DateTime CreatedDate, System.DateTime dm, int estimationTime, bool finnished, string l_name) {
            base.Channel.addToDo(description, name, CreatedDate, dm, estimationTime, finnished, l_name);
        }
        
        public System.Threading.Tasks.Task addToDoAsync(string description, string name, System.DateTime CreatedDate, System.DateTime dm, int estimationTime, bool finnished, string l_name) {
            return base.Channel.addToDoAsync(description, name, CreatedDate, dm, estimationTime, finnished, l_name);
        }
        
        public string[] FinishedItemsToDo(string l_name) {
            return base.Channel.FinishedItemsToDo(l_name);
        }
        
        public System.Threading.Tasks.Task<string[]> FinishedItemsToDoAsync(string l_name) {
            return base.Channel.FinishedItemsToDoAsync(l_name);
        }
        
        public int[] GetListFinishedAndUnfinished(string l_name) {
            return base.Channel.GetListFinishedAndUnfinished(l_name);
        }
        
        public System.Threading.Tasks.Task<int[]> GetListFinishedAndUnfinishedAsync(string l_name) {
            return base.Channel.GetListFinishedAndUnfinishedAsync(l_name);
        }
        
        public bool addListName(string name) {
            return base.Channel.addListName(name);
        }
        
        public System.Threading.Tasks.Task<bool> addListNameAsync(string name) {
            return base.Channel.addListNameAsync(name);
        }
        
        public bool checkIfListExist(string name) {
            return base.Channel.checkIfListExist(name);
        }
        
        public System.Threading.Tasks.Task<bool> checkIfListExistAsync(string name) {
            return base.Channel.checkIfListExistAsync(name);
        }
        
        public bool UpdateToDo(int idUpdate, string descriptionUpdate, string nameUpdate, System.DateTime CreatedDateUpdate, System.DateTime dmUpdate, int estimationTimeUpdate, bool finnishedUpdate, string l_name) {
            return base.Channel.UpdateToDo(idUpdate, descriptionUpdate, nameUpdate, CreatedDateUpdate, dmUpdate, estimationTimeUpdate, finnishedUpdate, l_name);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateToDoAsync(int idUpdate, string descriptionUpdate, string nameUpdate, System.DateTime CreatedDateUpdate, System.DateTime dmUpdate, int estimationTimeUpdate, bool finnishedUpdate, string l_name) {
            return base.Channel.UpdateToDoAsync(idUpdate, descriptionUpdate, nameUpdate, CreatedDateUpdate, dmUpdate, estimationTimeUpdate, finnishedUpdate, l_name);
        }
        
        public string[] ImportantItemsToDo(string l_name) {
            return base.Channel.ImportantItemsToDo(l_name);
        }
        
        public System.Threading.Tasks.Task<string[]> ImportantItemsToDoAsync(string l_name) {
            return base.Channel.ImportantItemsToDoAsync(l_name);
        }
        
        public int TotalEstimationsItemsToDo(string l_name) {
            return base.Channel.TotalEstimationsItemsToDo(l_name);
        }
        
        public System.Threading.Tasks.Task<int> TotalEstimationsItemsToDoAsync(string l_name) {
            return base.Channel.TotalEstimationsItemsToDoAsync(l_name);
        }
    }
}
