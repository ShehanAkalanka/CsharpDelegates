using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsharpDelegates.Migrations
{
    /// <inheritdoc />
    public partial class addBalanceAndAvailableBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AvailableBalance",
                table: "Accounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Accounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableBalance",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Accounts");
        }
    }
}
