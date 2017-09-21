namespace AndersonCRMContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyColor = c.String(maxLength: 6),
                        CompanyName = c.String(nullable: false, maxLength: 250),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        DepartmentId = c.Int(),
                        PositionId = c.Int(nullable: false),
                        ManagerEmployeeId = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 250),
                        LastName = c.String(maxLength: 250),
                        MiddleName = c.String(maxLength: 250),
                        Email = c.String(maxLength: 50),
                        JobTitle = c.String(maxLength: 50),
                        HiringDate = c.String(maxLength: 50),
                        StartingDate = c.String(maxLength: 50),
                        Team = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Position", t => t.PositionId)
                .Index(t => t.CompanyId)
                .Index(t => t.DepartmentId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.PeripheralHistory",
                c => new
                    {
                        PeripheralHistoryId = c.Int(nullable: false, identity: true),
                        PeripheralId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PeripheralHistoryId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.Peripheral", t => t.PeripheralId)
                .Index(t => t.PeripheralId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Peripheral",
                c => new
                    {
                        PeripheralId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        PeripheralColor = c.String(maxLength: 6),
                        PeripheralName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 250),
                        SerialNumber = c.String(nullable: false, maxLength: 50),
                        AssetTag = c.String(nullable: false, maxLength: 50),
                        Date = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PeripheralId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PositionColor = c.String(maxLength: 6),
                        PositionName = c.String(nullable: false, maxLength: 250),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "PositionId", "dbo.Position");
            DropForeignKey("dbo.PeripheralHistory", "PeripheralId", "dbo.Peripheral");
            DropForeignKey("dbo.Peripheral", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.PeripheralHistory", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Employee", "CompanyId", "dbo.Company");
            DropIndex("dbo.Peripheral", new[] { "EmployeeId" });
            DropIndex("dbo.PeripheralHistory", new[] { "EmployeeId" });
            DropIndex("dbo.PeripheralHistory", new[] { "PeripheralId" });
            DropIndex("dbo.Employee", new[] { "PositionId" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Employee", new[] { "CompanyId" });
            DropTable("dbo.Position");
            DropTable("dbo.Peripheral");
            DropTable("dbo.PeripheralHistory");
            DropTable("dbo.Department");
            DropTable("dbo.Employee");
            DropTable("dbo.Company");
        }
    }
}
