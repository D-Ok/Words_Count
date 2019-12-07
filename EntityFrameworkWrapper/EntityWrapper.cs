using System;
using System.Collections.Generic;
using System.Linq;
using WordsCountSkyrtaOliinyk.DBModels;

namespace EntityFrameworkWrapper
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

        public static void Main() {
            
           // AddUser(new User("Daryna", "Oliinyk","sdfgh@ghjk.hj", "fxghjs", "1111"));
           // User us= GetUser("fxghjs");

           //Console.WriteLine(us.ToString());
            
           // Console.WriteLine("demo completed.");
           // Console.ReadLine();
        }

    }
}
