using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstallmentPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    View = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPaymentUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    InstallmentStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearsCount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    InstallmentPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPaymentUnits_InstallmentPlans_InstallmentPlanId",
                        column: x => x.InstallmentPlanId,
                        principalTable: "InstallmentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPaymentUnits_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPaymentUnits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPaymentUnitInstallments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstallmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstallmentAmount = table.Column<double>(type: "float", nullable: false),
                    InstallmentNumber = table.Column<int>(type: "int", nullable: false),
                    InstallmentPaymentUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentUnitInstallments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPaymentUnitInstallments_UserPaymentUnits_InstallmentPaymentUnitId",
                        column: x => x.InstallmentPaymentUnitId,
                        principalTable: "UserPaymentUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InstallmentPlans",
                columns: new[] { "Id", "PlanName" },
                values: new object[,]
                {
                    { 1, "Yearly" },
                    { 2, "Quarterly" },
                    { 3, "Semi-Annual" },
                    { 4, "Monthly " }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "AvailabilityStatus", "Floor", "RoomCount", "UnitName", "View" },
                values: new object[,]
                {
                    { 1, true, 1, 3, "400", "Nile" },
                    { 2, true, 1, 4, "401", "Nile" },
                    { 3, false, 2, 2, "402", "City" },
                    { 4, true, 2, 3, "403", "Nile" },
                    { 5, true, 3, 3, "404", "City" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, "kirofayez23@gmail.com", "Kerolos Fayez", "S9kdBKUu2pUOQVQPJjyiiGVrhKCRJkSlgv20eeU/qWQ74Jxl", "01202982836" },
                    { 2, "mosalah@gmail.com", "Mo Salah", "SciBOug4eixdTH0swqPjOGl+HJzrEY9x53byG3uB9yXwdYaG", "01202982835" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentUnitInstallments_InstallmentPaymentUnitId",
                table: "UserPaymentUnitInstallments",
                column: "InstallmentPaymentUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentUnits_InstallmentPlanId",
                table: "UserPaymentUnits",
                column: "InstallmentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentUnits_UnitId",
                table: "UserPaymentUnits",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentUnits_UserId",
                table: "UserPaymentUnits",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPaymentUnitInstallments");

            migrationBuilder.DropTable(
                name: "UserPaymentUnits");

            migrationBuilder.DropTable(
                name: "InstallmentPlans");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
