namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "address", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "mark", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "mark", c => c.String());
            AlterColumn("dbo.Students", "address", c => c.String());
            AlterColumn("dbo.Students", "name", c => c.String());
        }
    }
}
