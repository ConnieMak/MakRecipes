namespace MakRecipes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recipes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomRecipes",
                c => new
                    {
                        CustomRecipeId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomRecipeId)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomRecipes", "PersonId", "dbo.People");
            DropIndex("dbo.CustomRecipes", new[] { "PersonId" });
            DropTable("dbo.CustomRecipes");
        }
    }
}
