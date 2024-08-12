using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebtManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_AspNetUsers_ClientId",
                table: "Debts");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_AspNetUsers_ClientId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Debts_DebtId",
                table: "Payments");

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_AspNetUsers_ClientId",
                table: "Debts",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_AspNetUsers_ClientId",
                table: "Incomes",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Debts_DebtId",
                table: "Payments",
                column: "DebtId",
                principalTable: "Debts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_AspNetUsers_ClientId",
                table: "Debts");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_AspNetUsers_ClientId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Debts_DebtId",
                table: "Payments");

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_AspNetUsers_ClientId",
                table: "Debts",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_AspNetUsers_ClientId",
                table: "Incomes",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Debts_DebtId",
                table: "Payments",
                column: "DebtId",
                principalTable: "Debts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
