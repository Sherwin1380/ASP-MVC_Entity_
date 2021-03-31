namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedaddress : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "address", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
