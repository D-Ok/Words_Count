using EntityFrameworkWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WordsCountSkyrtaOliinyk.DBModels;

namespace DBModels
{
    internal class Program
    {
        public static void AddUser(User user)
        {
            using (var context = new WordsCountDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static IEnumerable<User> GetAllUsers()
        {
            using (var context = new WordsCountDBContext())
            {
                return context.Users.ToList();
            }
        }

        public static void AddRequest(String email, Request r)
        {
            using (var context = new WordsCountDBContext())
            {
                context.Users.Where(user => user.Email == email).First().Requests.Add(r);
                //if(u==null) Console.WriteLine("noth");
                //Console.WriteLine(u.FirstName);

                context.SaveChanges();
            }
        }
        public static User GetUser(String email, String pas)
        {
            using (var context = new WordsCountDBContext())
            {
                return context.Users.Where(user => user.Email == email).First();
            }
        }

        public static IEnumerable<Request> GetRequests(Guid id)
        {
            using (var context = new WordsCountDBContext())
            {
                return context.Requests.Where(r => r.OwnerGuid == id).ToList();
               
            }
        }

        private static void Main(string[] args)
        {
        //    AddUser(new User("Daryna", "Oliinyk", "fxghjs", "1111"));
        //    IEnumerable<User> users = GetAllUsers();

        //    foreach (User us in users)
        //    {
        //        Console.WriteLine(us.ToString());
        //    }

        //    User u = GetUser("fxghjs", "1111");
        //    AddRequest("fxghjs", new Request("dfghjkl", 700, 10, 7));

        //    IEnumerable < Request > re= GetRequests(u.Guid);
        //    foreach (Request r in re){
        //            Console.WriteLine(r.Path+" "+r.StringsNumber);
        //        }

            Console.WriteLine("Demo completed.");
            Console.ReadLine();
        }
    }
}
