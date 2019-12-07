namespace EntityFrameworkWrapper.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkWrapper.WordsCountDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityFrameworkWrapper.WordsCountDBContext context)
        {
        }
    }
}
