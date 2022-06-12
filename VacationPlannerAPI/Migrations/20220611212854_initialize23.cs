using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationPlannerAPI.Migrations
{
    public partial class initialize23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOffRequests_TypeOfLeave_TypeOfLeaveId",
                table: "DayOffRequests");

            migrationBuilder.AddColumn<Guid>(
                name: "DayOffRequestId",
                table: "TypeOfLeave",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfLeave_DayOffRequestId",
                table: "TypeOfLeave",
                column: "DayOffRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOffRequests_TypeOfLeave_TypeOfLeaveId",
                table: "DayOffRequests",
                column: "TypeOfLeaveId",
                principalTable: "TypeOfLeave",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeOfLeave_DayOffRequests_DayOffRequestId",
                table: "TypeOfLeave",
                column: "DayOffRequestId",
                principalTable: "DayOffRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOffRequests_TypeOfLeave_TypeOfLeaveId",
                table: "DayOffRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeOfLeave_DayOffRequests_DayOffRequestId",
                table: "TypeOfLeave");

            migrationBuilder.DropIndex(
                name: "IX_TypeOfLeave_DayOffRequestId",
                table: "TypeOfLeave");

            migrationBuilder.DropColumn(
                name: "DayOffRequestId",
                table: "TypeOfLeave");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOffRequests_TypeOfLeave_TypeOfLeaveId",
                table: "DayOffRequests",
                column: "TypeOfLeaveId",
                principalTable: "TypeOfLeave",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
