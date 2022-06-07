using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Business.Migrations
{
    public partial class AddColumnUserIdToPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "patient",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "patient");
        }
    }
}
