using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Business.Migrations
{
    public partial class UpdatePatient2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "LeftCylinder",
                table: "patient",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LeftEsphere",
                table: "patient",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LeftGlass",
                table: "patient",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "LeftVisualAcuity",
                table: "patient",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "RightCylinder",
                table: "patient",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RightEsphere",
                table: "patient",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RightGlass",
                table: "patient",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "RightVisualAcuity",
                table: "patient",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeftCylinder",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "LeftEsphere",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "LeftGlass",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "LeftVisualAcuity",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "RightCylinder",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "RightEsphere",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "RightGlass",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "RightVisualAcuity",
                table: "patient");
        }
    }
}
