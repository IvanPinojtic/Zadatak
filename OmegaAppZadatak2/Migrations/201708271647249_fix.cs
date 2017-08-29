namespace OmegaAppZadatak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Slika", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Slika", c => c.Binary());
        }
    }
}
