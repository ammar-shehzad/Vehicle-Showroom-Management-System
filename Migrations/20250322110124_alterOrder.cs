using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle_Showroom_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class alterOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastname",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "order_amount",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_amount",
                table: "orders");

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
