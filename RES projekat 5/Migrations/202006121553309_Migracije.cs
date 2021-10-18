namespace RES_projekat_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage] //Deo UI-a
    public partial class Migracije : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnergijaIzBaterijes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Snaga = c.Double(nullable: false),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SnagaElektrodistribucijas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Snaga = c.Double(nullable: false),
                        Cena = c.Double(nullable: false),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PotrosnjaPotrosacas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Snaga = c.Double(nullable: false),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProizvodnjaSolarnihPanelas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Snaga = c.Double(nullable: false),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProizvodnjaSolarnihPanelas");
            DropTable("dbo.PotrosnjaPotrosacas");
            DropTable("dbo.SnagaElektrodistribucijas");
            DropTable("dbo.EnergijaIzBaterijes");
        }
    }
}
