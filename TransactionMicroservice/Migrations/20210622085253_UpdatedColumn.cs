using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionMicroservice.Migrations
{
    public partial class UpdatedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "TransactionHistory",
                newName: "TransferAmount");

            migrationBuilder.AddColumn<double>(
                name: "ClosingBalance",
                table: "TransactionHistory",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingBalance",
                table: "TransactionHistory");

            migrationBuilder.RenameColumn(
                name: "TransferAmount",
                table: "TransactionHistory",
                newName: "Amount");
        }
    }
}
