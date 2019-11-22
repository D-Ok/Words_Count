
using EntityFrameworkWrapper.Migrations;
using EntityFrameworkWrapper.ModelConfigurations;
using System.Data.Entity;
using WordsCountSkyrtaOliinyk.DBModels;


namespace EntityFrameworkWrapper
{
    public class WordsCountDBContext : DbContext
    {
        //public WordsCountDBContext() : base(@"Server=KIYVMANAGERSURF\ARTSYLPRODUCTS10;Integrated security = true;database=WalletSimulator")

        public WordsCountDBContext() : base("DB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WordsCountDBContext, Configuration>());
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RequestConfiguration());
        }
    }

}
