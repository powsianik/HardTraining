namespace EntityFrameworkDomain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPositionToUserData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserData", "Calf", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserData", "Calf");
        }
    }
}
