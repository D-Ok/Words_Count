
using EntityFrameworkWrapper.Migrations;
using EntityFrameworkWrapper.ModelConfigurations;
using System.Data.Entity;
using WordsCountSkyrtaOliinyk.DBModels;


namespace EntityFrameworkWrapper
{
    public class WordsCountDBContext : DbContext
    {

        public WordsCountDBContext() : base("WordsCount")
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
