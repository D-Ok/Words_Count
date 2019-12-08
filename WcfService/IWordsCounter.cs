using System;
using System.Collections.Generic;
using System.ServiceModel;
using WordsCountSkyrtaOliinyk.DBModels;

namespace WcfService
{
    
    [ServiceContract]
    public interface IWordsCounter
    {

        [OperationContract]
        bool AddUser(User user);

        [OperationContract]
        void AddRequest(Request request);

        [OperationContract]
        User GetUser(string login);

        [OperationContract]
        User UpdateUserDate(Guid userGuid);

        [OperationContract]
        IEnumerable<Request> GetAllRequests(User user);

    }


    
}
