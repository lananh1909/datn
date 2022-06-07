using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Business.Migrations
{
    public partial class AddColumnIsSelfToPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelf",
                table: "patient",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelf",
                table: "patient");
        }
    }
}
