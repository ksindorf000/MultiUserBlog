namespace Blogit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBodyToBlogPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Teaser = c.String(),
                        Body = c.String(),
                        Created = c.DateTime(nullable: false),
                        Public = c.Boolean(nullable: false),
                        OwnerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.BlogPosts", new[] { "OwnerId" });
            DropTable("dbo.BlogPosts");
        }
    }
}
