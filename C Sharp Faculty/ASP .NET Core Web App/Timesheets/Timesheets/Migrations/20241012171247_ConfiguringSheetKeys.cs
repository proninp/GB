using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheets.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguringSheetKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Contracts_ContractId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ContractId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Services");

            migrationBuilder.CreateIndex(
                name: "IX_Sheets_ContractId",
                table: "Sheets",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheets_EmployeeId",
                table: "Sheets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheets_ServiceId",
                table: "Sheets",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sheets_Contracts_ContractId",
                table: "Sheets",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheets_Employees_EmployeeId",
                table: "Sheets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheets_Services_ServiceId",
                table: "Sheets",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sheets_Contracts_ContractId",
                table: "Sheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheets_Employees_EmployeeId",
                table: "Sheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheets_Services_ServiceId",
                table: "Sheets");

            migrationBuilder.DropIndex(
                name: "IX_Sheets_ContractId",
                table: "Sheets");

            migrationBuilder.DropIndex(
                name: "IX_Sheets_EmployeeId",
                table: "Sheets");

            migrationBuilder.DropIndex(
                name: "IX_Sheets_ServiceId",
                table: "Sheets");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "Services",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ContractId",
                table: "Services",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Contracts_ContractId",
                table: "Services",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");
        }
    }
}
