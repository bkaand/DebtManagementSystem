using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebtManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddClientDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Clients_ClientId1",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_ClientId1",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "ClientName",
                table: "Clients",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Clients",
                newName: "ClientName");

            migrationBuilder.AddColumn<int>(
                name: "ClientId1",
                table: "Incomes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_ClientId1",
                table: "Incomes",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Clients_ClientId1",
                table: "Incomes",
                column: "ClientId1",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
