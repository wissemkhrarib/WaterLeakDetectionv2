using Microsoft.EntityFrameworkCore.Migrations;

namespace WaterLeakDetection.Migrations
{
    public partial class Leak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leak_Sensors_SensorId1",
                table: "Leak");

            migrationBuilder.DropIndex(
                name: "IX_Leak_SensorId1",
                table: "Leak");

            migrationBuilder.DropColumn(
                name: "SensorId1",
                table: "Leak");

            migrationBuilder.AddColumn<int>(
                name: "SensorId",
                table: "Leak",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Leak_SensorId",
                table: "Leak",
                column: "SensorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leak_Sensors_SensorId",
                table: "Leak",
                column: "SensorId",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leak_Sensors_SensorId",
                table: "Leak");

            migrationBuilder.DropIndex(
                name: "IX_Leak_SensorId",
                table: "Leak");

            migrationBuilder.DropColumn(
                name: "SensorId",
                table: "Leak");

            migrationBuilder.AddColumn<int>(
                name: "SensorId1",
                table: "Leak",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leak_SensorId1",
                table: "Leak",
                column: "SensorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Leak_Sensors_SensorId1",
                table: "Leak",
                column: "SensorId1",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
