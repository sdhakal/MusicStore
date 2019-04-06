namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviewers",
                c => new
                    {
                        ReviewerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ReviewerId);
            
            CreateTable(
                "dbo.ReviewerAlbums",
                c => new
                    {
                        Reviewer_ReviewerId = c.Int(nullable: false),
                        Album_AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reviewer_ReviewerId, t.Album_AlbumId })
                .ForeignKey("dbo.Reviewers", t => t.Reviewer_ReviewerId, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId, cascadeDelete: true)
                .Index(t => t.Reviewer_ReviewerId)
                .Index(t => t.Album_AlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReviewerAlbums", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.ReviewerAlbums", "Reviewer_ReviewerId", "dbo.Reviewers");
            DropIndex("dbo.ReviewerAlbums", new[] { "Album_AlbumId" });
            DropIndex("dbo.ReviewerAlbums", new[] { "Reviewer_ReviewerId" });
            DropTable("dbo.ReviewerAlbums");
            DropTable("dbo.Reviewers");
        }
    }
}
