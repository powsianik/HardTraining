namespace EntityFrameworkDomain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserData", "Weight", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserData", "Weight", c => c.Short(nullable: false));
        }
    }
}
