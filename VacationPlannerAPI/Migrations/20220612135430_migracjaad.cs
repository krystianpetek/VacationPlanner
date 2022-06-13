using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationPlannerAPI.Migrations
{
    public partial class migracjaad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "DayOffRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DayOffRequests_CompanyId",
                table: "DayOffRequests",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOffRequests_Companies_CompanyId",
                table: "DayOffRequests",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOffRequests_Companies_CompanyId",
                table: "DayOffRequests");

            migrationBuilder.DropIndex(
                name: "IX_DayOffRequests_CompanyId",
                table: "DayOffRequests");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "DayOffRequests");
        }
    }
}
