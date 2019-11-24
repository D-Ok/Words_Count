using EntityFrameworkWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WordsCountSkyrtaOliinyk.DBModels;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WordsCounter" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы WordsCounter.svc или WordsCounter.svc.cs в обозревателе решений и начните отладку.
    public class WordsCounter : IWordsCounter
    {
        public void AddRequest(Request request)
        {
            using (var context = new WordsCountDBContext())
            {
                context.Requests.Add(request);
                context.SaveChanges();
            }
        }

        public void AddUser(User user)
        {
            using (var context = new WordsCountDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public List<Request> GetAllRequests(User user)
        {
            using (var context = new WordsCountDBContext())
            {
                return context.Requests.ToList();
            }
        }

        public User ValidateUser(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}