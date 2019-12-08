using System;
using System.Collections.Generic;
using System.Linq;
using WordsCountSkyrtaOliinyk.DBModels;

namespace EntityFrameworkWrapper
{
    public static class EntityWrapper
    {
        public static bool AddUser(User user)
        {
            using (var context = new WordsCountDBContext())
            {
                context.Users.Add(user);
                try
                {
                    context.SaveChanges();
                    return true;
                } 
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public static bool AddRequest(Request request)
        {
            using (var context = new WordsCountDBContext())
            {
                context.Requests.Add(request);
                //try
               // {
                    context.SaveChanges();
                    return true;
              //  }
                //catch (Exception e)
                //{
                //    return false;
                //}
            }
        }
        public static User GetUser(String login)
        {
            using (var context = new WordsCountDBContext())
            {
                IEnumerable<User> us = context.Users.Where(user => user.Login == login);
                if (us.Count() > 0)
                    return us.First();
                else return null;
            }
        }

        public static IEnumerable<Request> GetRequests(Guid id)
        {
            using (var context = new WordsCountDBContext())
            {
                return context.Requests.Where(r => r.OwnerGuid == id).ToList();
            }
        }

        public static void Main() {
            
        }

    }
}
