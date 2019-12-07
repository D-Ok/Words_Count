namespace EntityFrameworkWrapper.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class WordsCount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Path = c.String(nullable: false),
                        Chars = c.Long(nullable: false),
                        Words = c.Int(nullable: false),
                        Strings = c.Int(nullable: false),
                        DOR = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        OwnerGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerGuid, cascadeDelete: true)
                .Index(t => t.OwnerGuid);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Login = c.String(nullable: false, maxLength: 256),
                        Email = c.String(nullable: false, maxLength: 256),
                        Password = c.String(nullable: false),
                        DOE = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Guid)
                .Index(t => t.Login, unique: true)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "OwnerGuid", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.Requests", new[] { "OwnerGuid" });
            DropTable("dbo.Users");
            DropTable("dbo.Requests");
        }
    }
}
