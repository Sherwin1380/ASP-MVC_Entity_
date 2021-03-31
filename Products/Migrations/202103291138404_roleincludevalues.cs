namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleincludevalues : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into roles(Name,Duty) values ('Leader','Patrol');");
            Sql("Insert into roles(Name,Duty) values ('Assistant_Leader','Patrol');");
            Sql("Insert into roles(Name,Duty) values ('Student','Study');");
        }
        
        public override void Down()
        {
        }
    }
}
