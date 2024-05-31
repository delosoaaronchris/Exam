namespace Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RecyclableTypes", new[] { "Type" });
            CreateIndex("dbo.RecyclableTypes", "Type", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.RecyclableTypes", new[] { "Type" });
            CreateIndex("dbo.RecyclableTypes", "Type", unique: true);
        }
    }
}
