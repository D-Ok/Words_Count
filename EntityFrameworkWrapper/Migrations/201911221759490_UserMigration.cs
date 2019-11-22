namespace EntityFrameworkWrapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 256),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Email" });
            DropTable("dbo.Users");
        }
    }
}
