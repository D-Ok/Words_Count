using System.Collections.Generic;
using Tester.WordsCountService;
using WordsCountSkyrtaOliinyk.DBModels;

namespace Tester
{
    internal class ServiceClient
    {
        private static ServiceClient _instance;
        private static readonly  object Locker = new object();

        internal static ServiceClient Instance 
        { 
            get 
            {
                if (_instance != null)
                    return _instance;
                lock (Locker)
                {
                    return _instance ?? (_instance = new ServiceClient());
                }
            } 
        }

        public static WordsCounterClient Client { get; private set; }

        private ServiceClient() 
        {
            Client = new WordsCounterClient();
        }

        internal bool AddUser(User user) 
        {
            return Client.AddUser(user);
        }

        internal void AddRequest(Request request) 
        {
            Client.AddRequest(request);
        }

        internal IEnumerable<Request> GetAllRequests(User user) 
        {
            return Client.GetAllRequests(user);
        }

        internal User GetUser(string login)
        {
            return Client.GetUser(login);
        }




    }
}
