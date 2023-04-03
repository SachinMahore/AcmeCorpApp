using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorp.Service.Migrations
{
    public partial class ordewritem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblOrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderItem", x => x.OrderItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOrderItem");
        }
    }
}
