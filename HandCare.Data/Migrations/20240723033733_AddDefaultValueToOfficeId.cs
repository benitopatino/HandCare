using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

#nullable disable

namespace HandCare.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultValueToOfficeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var operation = new AlterColumnOperation()
            {
                Table = "Offices",
                Name = "OfficeId",
                DefaultValueSql = "NewId()"
            };
            migrationBuilder.AlterColumn<bool>("OfficeId", "Offices", defaultValueSql:"NewId()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>("OfficeId","Offices", defaultValue: null);
        }
    }
}
