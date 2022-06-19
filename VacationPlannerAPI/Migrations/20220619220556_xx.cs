using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationPlannerAPI.Migrations
{
    public partial class xx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DayOffRequests_TypeOfLeaveId",
                table: "DayOffRequests");

            migrationBuilder.UpdateData(
                table: "TypeOfLeave",
                keyColumn: "Id",
                keyValue: 7,
                column: "TypeOfLeave",
                value: "Time off in lieu for overtime");

            migrationBuilder.CreateIndex(
                name: "IX_DayOffRequests_TypeOfLeaveId",
                table: "DayOffRequests",
                column: "TypeOfLeaveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DayOffRequests_TypeOfLeaveId",
                table: "DayOffRequests");

            migrationBuilder.UpdateData(
                table: "TypeOfLeave",
                keyColumn: "Id",
                keyValue: 7,
                column: "TypeOfLeave",
                value: "Tyime off in lieu for overtime");

            migrationBuilder.CreateIndex(
                name: "IX_DayOffRequests_TypeOfLeaveId",
                table: "DayOffRequests",
                column: "TypeOfLeaveId",
                unique: true);
        }
    }
}
