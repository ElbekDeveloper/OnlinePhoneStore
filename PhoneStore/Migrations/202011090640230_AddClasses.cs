namespace PhoneStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RamInGb = c.Short(nullable: false),
                        HddInGb = c.Short(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Battery = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WeightInKg = c.Int(nullable: false),
                        DimensionInInch = c.Int(nullable: false),
                        FrontCameraCount = c.Byte(nullable: false),
                        MainCameraCount = c.Byte(nullable: false),
                        FrontCameraPrecisonInPx = c.Short(nullable: false),
                        MainCameraPrecisonInPx = c.Short(nullable: false),
                        Manufacturer_Id = c.Int(),
                        Materials_Id = c.Int(),
                        Model_Id = c.Int(),
                        OperatingSystem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .ForeignKey("dbo.Materials", t => t.Materials_Id)
                .ForeignKey("dbo.Models", t => t.Model_Id)
                .ForeignKey("dbo.OperatingSystems", t => t.OperatingSystem_Id)
                .Index(t => t.Manufacturer_Id)
                .Index(t => t.Materials_Id)
                .Index(t => t.Model_Id)
                .Index(t => t.OperatingSystem_Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OperatingSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneColors",
                c => new
                    {
                        Phone_Id = c.Int(nullable: false),
                        Color_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Phone_Id, t.Color_Id })
                .ForeignKey("dbo.Phones", t => t.Phone_Id, cascadeDelete: true)
                .ForeignKey("dbo.Colors", t => t.Color_Id, cascadeDelete: true)
                .Index(t => t.Phone_Id)
                .Index(t => t.Color_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "OperatingSystem_Id", "dbo.OperatingSystems");
            DropForeignKey("dbo.Phones", "Model_Id", "dbo.Models");
            DropForeignKey("dbo.Phones", "Materials_Id", "dbo.Materials");
            DropForeignKey("dbo.Phones", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.PhoneColors", "Color_Id", "dbo.Colors");
            DropForeignKey("dbo.PhoneColors", "Phone_Id", "dbo.Phones");
            DropIndex("dbo.PhoneColors", new[] { "Color_Id" });
            DropIndex("dbo.PhoneColors", new[] { "Phone_Id" });
            DropIndex("dbo.Phones", new[] { "OperatingSystem_Id" });
            DropIndex("dbo.Phones", new[] { "Model_Id" });
            DropIndex("dbo.Phones", new[] { "Materials_Id" });
            DropIndex("dbo.Phones", new[] { "Manufacturer_Id" });
            DropTable("dbo.PhoneColors");
            DropTable("dbo.OperatingSystems");
            DropTable("dbo.Models");
            DropTable("dbo.Materials");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Phones");
            DropTable("dbo.Colors");
        }
    }
}
