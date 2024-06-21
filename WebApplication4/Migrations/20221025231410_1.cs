using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockReasons",
                columns: table => new
                {
                    Reason = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ItemMasterDatas",
                columns: table => new
                {
                    ItemCode = table.Column<string>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    FirmName = table.Column<string>(nullable: true),
                    PartNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MaterialInspectLines",
                columns: table => new
                {
                    ParamId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Measurement = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    BlockQty = table.Column<decimal>(type: "decimal(19,6)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(19,6)", nullable: false),
                    Id_MaterialInspect = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    DateRelease = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MaterialInspects",
                columns: table => new
                {
                    ItemCode = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    CardCode = table.Column<string>(nullable: true),
                    ParamCode = table.Column<string>(nullable: true),
                    BlockReason = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Invoice = table.Column<int>(nullable: false),
                    DocEntry = table.Column<int>(nullable: false),
                    LineNum = table.Column<int>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmpId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    DateRelease = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ProductInspects",
                columns: table => new
                {
                    DocEntry = table.Column<int>(nullable: false),
                    TimeRegisterID = table.Column<int>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    EndTimeRegister = table.Column<DateTime>(nullable: false),
                    OpenQty = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ReceiptOfGoods",
                columns: table => new
                {
                    DocEntry = table.Column<int>(nullable: false),
                    Invoice = table.Column<int>(nullable: false),
                    CardName = table.Column<string>(nullable: true),
                    DocDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmpID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockReasons");

            migrationBuilder.DropTable(
                name: "ItemMasterDatas");

            migrationBuilder.DropTable(
                name: "MaterialInspectLines");

            migrationBuilder.DropTable(
                name: "MaterialInspects");

            migrationBuilder.DropTable(
                name: "ProductInspects");

            migrationBuilder.DropTable(
                name: "ReceiptOfGoods");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
