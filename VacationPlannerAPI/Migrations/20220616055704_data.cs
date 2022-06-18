using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationPlannerAPI.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TypeOfLeave",
                columns: new[] { "Id", "TypeOfLeave" },
                values: new object[,]
                {
                    { 3, "Ocassional leave" },
                    { 4, "Unpaid leave" },
                    { 5, "Parental leave" },
                    { 6, "Sick leave" },
                    { 7, "Time off in lieu for overtime" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypeOfLeave",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TypeOfLeave",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TypeOfLeave",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TypeOfLeave",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TypeOfLeave",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
