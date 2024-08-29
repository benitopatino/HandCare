using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandCare.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNameColumnOffice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Offices",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Offices");
        }
    }
}
