namespace MovieApp.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ilk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreationUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movie");
        }
    }
}
