namespace EntityFrameworkWrapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestMigration : DbMigration
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
        }

        public override void Down()
        {
            DropForeignKey("dbo.Requests", "OwnerGuid", "dbo.Users");
            DropIndex("dbo.Requests", new[] { "OwnerGuid" });
            DropTable("dbo.Requests");
        }
    }
}
