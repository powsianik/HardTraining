namespace EntityFrameworkDomain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercise",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Description = c.String(maxLength: 512),
                        IdOfKind = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KindOfExercise", t => t.IdOfKind, cascadeDelete: true)
                .Index(t => t.IdOfKind);
            
            CreateTable(
                "dbo.KindOfExercise",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Description = c.String(maxLength: 512),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainingDay",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        IdOfPlan = c.Short(nullable: false),
                        IdOfDayOfWeek = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DayOfWeek", t => t.IdOfDayOfWeek, cascadeDelete: true)
                .ForeignKey("dbo.TrainingPlan", t => t.IdOfPlan, cascadeDelete: true)
                .Index(t => t.IdOfPlan)
                .Index(t => t.IdOfDayOfWeek);
            
            CreateTable(
                "dbo.DayOfWeek",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainingPlan",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(maxLength: 32),
                        Purpose = c.String(maxLength: 512),
                        AddedDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IdOfProfile = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profile", t => t.IdOfProfile, cascadeDelete: true)
                .Index(t => t.IdOfProfile);
            
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
                "dbo.UserData",
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
                        Calf = c.Short(nullable: false),
                        Ankle = c.Short(nullable: false),
                        MeasureDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profile", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.TrainingDayExercise",
                c => new
                    {
                        TrainingDay_id = c.Short(nullable: false),
                        Exercise_Id = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrainingDay_id, t.Exercise_Id })
                .ForeignKey("dbo.TrainingDay", t => t.TrainingDay_id, cascadeDelete: true)
                .ForeignKey("dbo.Exercise", t => t.Exercise_Id, cascadeDelete: true)
                .Index(t => t.TrainingDay_id)
                .Index(t => t.Exercise_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingDay", "IdOfPlan", "dbo.TrainingPlan");
            DropForeignKey("dbo.UserData", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.TrainingPlan", "IdOfProfile", "dbo.Profile");
            DropForeignKey("dbo.TrainingDayExercise", "Exercise_Id", "dbo.Exercise");
            DropForeignKey("dbo.TrainingDayExercise", "TrainingDay_id", "dbo.TrainingDay");
            DropForeignKey("dbo.TrainingDay", "IdOfDayOfWeek", "dbo.DayOfWeek");
            DropForeignKey("dbo.Exercise", "IdOfKind", "dbo.KindOfExercise");
            DropIndex("dbo.TrainingDayExercise", new[] { "Exercise_Id" });
            DropIndex("dbo.TrainingDayExercise", new[] { "TrainingDay_id" });
            DropIndex("dbo.UserData", new[] { "ProfileId" });
            DropIndex("dbo.TrainingPlan", new[] { "IdOfProfile" });
            DropIndex("dbo.TrainingDay", new[] { "IdOfDayOfWeek" });
            DropIndex("dbo.TrainingDay", new[] { "IdOfPlan" });
            DropIndex("dbo.Exercise", new[] { "IdOfKind" });
            DropTable("dbo.TrainingDayExercise");
            DropTable("dbo.UserData");
            DropTable("dbo.Profile");
            DropTable("dbo.TrainingPlan");
            DropTable("dbo.DayOfWeek");
            DropTable("dbo.TrainingDay");
            DropTable("dbo.KindOfExercise");
            DropTable("dbo.Exercise");
        }
    }
}
