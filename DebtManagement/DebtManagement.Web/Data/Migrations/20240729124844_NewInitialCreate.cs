using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebtManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_AspNetUsers_UserId",
                table: "Debts");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_AspNetUsers_UserId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Incomes",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_UserId",
                table: "Incomes",
                newName: "IX_Incomes_ClientId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Debts",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Debts_UserId",
                table: "Debts",
                newName: "IX_Debts_ClientId");

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

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Incomes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_ClientId",
                table: "Incomes",
                newName: "IX_Incomes_UserId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Debts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Debts_ClientId",
                table: "Debts",
                newName: "IX_Debts_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_AspNetUsers_UserId",
                table: "Debts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_AspNetUsers_UserId",
                table: "Incomes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
