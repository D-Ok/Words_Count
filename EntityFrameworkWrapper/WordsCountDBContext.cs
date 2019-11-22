
using EntityFrameworkWrapper.Migrations;
using EntityFrameworkWrapper.ModelConfigurations;
using System.Data.Entity;
using WordsCountSkyrtaOliinyk.DBModels;


namespace EntityFrameworkWrapper
{
        public class WordsCountDBContextusing : DbContext
        {
        //public WordsCountDBContext() : base(@"Server=KIYVMANAGERSURF\ARTSYLPRODUCTS10;Integrated security = true;database=WalletSimulator")

        public WordsCountDBContextusing() : base("DB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WordsCountDBContextusing, Configuration>());
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new UserConfiguration());
                modelBuilder.Configurations.Add(new RequestConfiguration());
        }
        }
    
}
