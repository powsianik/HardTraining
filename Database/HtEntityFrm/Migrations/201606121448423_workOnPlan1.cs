namespace EntityFrameworkDomain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workOnPlan1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrainingPlan",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(maxLength: 32),
                        Purpose = c.String(maxLength: 256),
                        AddedDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ProfileId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profile", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.TrainingDay",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        IdOfPlan = c.Short(nullable: false),
                        TrainingPlan_Id = c.Short(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TrainingPlan", t => t.TrainingPlan_Id)
                .Index(t => t.TrainingPlan_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingDay", "TrainingPlan_Id", "dbo.TrainingPlan");
            DropForeignKey("dbo.TrainingPlan", "ProfileId", "dbo.Profile");
            DropIndex("dbo.TrainingDay", new[] { "TrainingPlan_Id" });
            DropIndex("dbo.TrainingPlan", new[] { "ProfileId" });
            DropTable("dbo.TrainingDay");
            DropTable("dbo.TrainingPlan");
        }
    }
}
