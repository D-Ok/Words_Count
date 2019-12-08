using EntityFrameworkWrapper;
using System;
using System.Collections.Generic;
using WordsCountSkyrtaOliinyk.DBModels;


namespace WcfService
{
     public class WordsCounter : IWordsCounter
    {
        
        public bool AddUser(User user)
        {
            return EntityWrapper.AddUser(user);
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

        public User UpdateUserDate(Guid userGuid)
        {
            return EntityWrapper.UpdateUserDate(userGuid);
        }
    }
}