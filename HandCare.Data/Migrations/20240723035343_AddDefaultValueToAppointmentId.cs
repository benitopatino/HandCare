using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

#nullable disable

namespace HandCare.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultValueToAppointmentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>("AppointmentId", "Appointments", defaultValueSql:"NewId()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>("AppointmentId","Appointments", defaultValue: null);
        }
    }
}
