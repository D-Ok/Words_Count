
using System;
using System.Collections.Generic;
using System.ServiceModel;
using WordsCountSkyrtaOliinyk.DBModels;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IWordsCounter
    {

        [OperationContract]
        string Answer(string name);

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
