using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budget.Migrations
{
    /// <inheritdoc />
    public partial class modifyTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deposit",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Withdrawal",
                table: "Transactions",
                newName: "Amount");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "Withdrawal");

            migrationBuilder.AddColumn<decimal>(
                name: "Deposit",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
