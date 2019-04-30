namespace eLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AuthorName = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "BookId", "dbo.Books");
            DropIndex("dbo.People", new[] { "BookId" });
            DropTable("dbo.People");
            DropTable("dbo.Books");
        }
    }
}
