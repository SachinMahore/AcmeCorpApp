using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorp.Service.Migrations
{
    public partial class acmecorpfirstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomerContact",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomerContact", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "tblOrder",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    ContactId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrder", x => x.OrderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCustomer");

            migrationBuilder.DropTable(
                name: "tblCustomerContact");

            migrationBuilder.DropTable(
                name: "tblOrder");
        }
    }
}
