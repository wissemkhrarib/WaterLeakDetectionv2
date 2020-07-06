using Microsoft.EntityFrameworkCore.Migrations;

namespace WaterLeakDetection.Migrations
{
    public partial class leaks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leak_Sensors_SensorId",
                table: "Leak");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leak",
                table: "Leak");

            migrationBuilder.RenameTable(
                name: "Leak",
                newName: "Leaks");

            migrationBuilder.RenameIndex(
                name: "IX_Leak_SensorId",
                table: "Leaks",
                newName: "IX_Leaks_SensorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leaks",
                table: "Leaks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leaks_Sensors_SensorId",
                table: "Leaks",
                column: "SensorId",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leaks_Sensors_SensorId",
                table: "Leaks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leaks",
                table: "Leaks");

            migrationBuilder.RenameTable(
                name: "Leaks",
                newName: "Leak");

            migrationBuilder.RenameIndex(
                name: "IX_Leaks_SensorId",
                table: "Leak",
                newName: "IX_Leak_SensorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leak",
                table: "Leak",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leak_Sensors_SensorId",
                table: "Leak",
                column: "SensorId",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
