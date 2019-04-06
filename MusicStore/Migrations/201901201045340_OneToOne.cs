namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtistDetails",
                c => new
                    {
                        ArtistId = c.Int(nullable: false),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.ArtistId)
                .ForeignKey("dbo.Artists", t => t.ArtistId)
                .Index(t => t.ArtistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtistDetails", "ArtistId", "dbo.Artists");
            DropIndex("dbo.ArtistDetails", new[] { "ArtistId" });
            DropTable("dbo.ArtistDetails");
        }
    }
}
