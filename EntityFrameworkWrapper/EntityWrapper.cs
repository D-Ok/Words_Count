using EntityFrameworkWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WordsCountSkyrtaOliinyk.DBModels;

namespace DBModels
{
    public static class EntityWrapper
    {
        public static void AddUser(User user)
        {
            using (var context = new WordsCountDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void AddRequest(Request request)
        {
            using (var context = new WordsCountDBContext())
            {
                context.Requests.Add(request);
                context.SaveChanges();
            }
        }
        public static User GetUser(String login)
        {
            using (var context = new WordsCountDBContext())
            {
                return context.Users.Where(user => user.Login == login).First();
            }
        }

        public static IEnumerable<Request> GetRequests(Guid id)
        {
            using (var context = new WordsCountDBContext())
            {
                return context.Requests.Where(r => r.OwnerGuid == id).ToList();
               
            }
        }

    }
}
