using DBModels;
using System.Collections.Generic;
using WordsCountSkyrtaOliinyk.DBModels;


namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WordsCounter" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы WordsCounter.svc или WordsCounter.svc.cs в обозревателе решений и начните отладку.
    public class WordsCounter : IWordsCounter
    {
        
        public void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        public string Answer(string name)
        {
            return $"Hello,{name}";
        }

        public IEnumerable<Request> GetAllRequests(User user)
        {
            return EntityWrapper.GetRequests(user.Guid);
        }


        public User GetUser(string login)
        {
            return EntityWrapper.GetUser(login);
        }

        
        public void AddRequest(Request request)
        {
            EntityWrapper.AddRequest(request);
        }
    }
}