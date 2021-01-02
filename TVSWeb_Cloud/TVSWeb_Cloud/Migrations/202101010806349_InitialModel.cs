namespace TVSWeb_Cloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuestionTitle = c.String(),
                        QuestionContent = c.String(),
                        TypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.TypeOfQuestions", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.TypeOfQuestions",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "TypeID", "dbo.TypeOfQuestions");
            DropIndex("dbo.Questions", new[] { "TypeID" });
            DropTable("dbo.TypeOfQuestions");
            DropTable("dbo.Questions");
        }
    }
}
