using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budget.Migrations
{
    /// <inheritdoc />
    public partial class addEndingBalanceToTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "EndingBalance",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndingBalance",
                table: "Transactions");
        }
    }
}
