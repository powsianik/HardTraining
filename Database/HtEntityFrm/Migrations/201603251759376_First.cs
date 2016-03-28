namespace EntityFrameworkDomain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(maxLength: 32),
                        CreationDate = c.DateTime(nullable: false),
                        Password = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserBasicData",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        ProfileId = c.Short(nullable: false),
                        Age = c.Short(nullable: false),
                        Height = c.Short(nullable: false),
                        Weight = c.Short(nullable: false),
                        Neck = c.Short(nullable: false),
                        Arm = c.Short(nullable: false),
                        ForeArm = c.Short(nullable: false),
                        Wrist = c.Short(nullable: false),
                        Chest = c.Short(nullable: false),
                        Waist = c.Short(nullable: false),
                        Hips = c.Short(nullable: false),
                        Thigh = c.Short(nullable: false),
                        Ankle = c.Short(nullable: false),
                        MeasureDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profile", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBasicData", "ProfileId", "dbo.Profile");
            DropIndex("dbo.UserBasicData", new[] { "ProfileId" });
            DropTable("dbo.UserBasicData");
            DropTable("dbo.Profile");
        }
    }
}
