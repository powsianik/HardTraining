namespace EntityFrameworkDomain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserBasicData", newName: "UserData");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserData", newName: "UserBasicData");
        }
    }
}
