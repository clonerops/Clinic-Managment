using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagment.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddedPatientCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Patients");
        }
    }
}
