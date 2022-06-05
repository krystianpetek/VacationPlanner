using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationPlannerAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolePerson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersLogin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordLastChanged = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersLogin_RolePerson_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RolePerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdministratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_UsersLogin_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "UsersLogin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    AvailableNumberOfDays = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserLoginId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_UsersLogin_UserLoginId",
                        column: x => x.UserLoginId,
                        principalTable: "UsersLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DayOffRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfRequest = table.Column<int>(type: "int", nullable: false),
                    DayOffRequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOffRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayOffRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AdministratorId",
                table: "Companies",
                column: "AdministratorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DayOffRequests_EmployeeId",
                table: "DayOffRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserLoginId",
                table: "Employees",
                column: "UserLoginId",
                unique: true,
                filter: "[UserLoginId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLogin_RoleId",
                table: "UsersLogin",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersLogin_Username",
                table: "UsersLogin",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayOffRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "UsersLogin");

            migrationBuilder.DropTable(
                name: "RolePerson");
        }
    }
}
