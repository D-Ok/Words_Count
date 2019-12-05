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
        List<User> GetAllUsers();

        [OperationContract]
        string Answer(string name);

        [OperationContract]
        void AddUser(User user);

        [OperationContract]
        void AddRequest(Request request);

        [OperationContract]
        User ValidateUser(string login, string password);

        [OperationContract]
        List<Request> GetAllRequests(User user);



    }


    
}
