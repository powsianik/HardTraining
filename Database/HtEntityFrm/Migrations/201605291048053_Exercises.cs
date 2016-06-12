namespace EntityFrameworkDomain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exercises : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercise",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IdOfKind = c.Short(nullable: false),
                        KindOfExcExercise_Id = c.Short(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KindOfExercise", t => t.KindOfExcExercise_Id)
                .Index(t => t.KindOfExcExercise_Id);
            
            CreateTable(
                "dbo.KindOfExercise",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercise", "KindOfExcExercise_Id", "dbo.KindOfExercise");
            DropIndex("dbo.Exercise", new[] { "KindOfExcExercise_Id" });
            DropTable("dbo.KindOfExercise");
            DropTable("dbo.Exercise");
        }
    }
}
