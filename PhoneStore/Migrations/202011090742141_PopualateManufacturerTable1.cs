namespace PhoneStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopualateManufacturerTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Manufacturers (name) values ('Samsung')");
            Sql("insert into Manufacturers (name) values ('Apple')");
            Sql("insert into Manufacturers (name) values ('Xiami')");
            Sql("insert into Manufacturers (name) values ('Redmi')");
        }
        
        public override void Down()
        {
        }
    }
}
