namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class housechanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        houseid = c.Int(nullable: false, identity: true),
                        housename = c.String(),
                    })
                .PrimaryKey(t => t.houseid);
            
            AddColumn("dbo.Students", "houseid", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "houseid");
            AddForeignKey("dbo.Students", "houseid", "dbo.Houses", "houseid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "houseid", "dbo.Houses");
            DropIndex("dbo.Students", new[] { "houseid" });
            DropColumn("dbo.Students", "houseid");
            DropTable("dbo.Houses");
        }
    }
}
