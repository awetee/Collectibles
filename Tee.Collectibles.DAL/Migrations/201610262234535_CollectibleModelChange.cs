namespace Tee.Collectibles.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectibleModelChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Collectibles", "IsShared", c => c.Boolean(nullable: false));
            DropColumn("dbo.Collectibles", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Collectibles", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Collectibles", "IsShared");
        }
    }
}
