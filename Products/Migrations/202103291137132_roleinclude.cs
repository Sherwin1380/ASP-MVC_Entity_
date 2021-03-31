namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleinclude : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duty = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Roles");
        }
    }
}
