using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandCare.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultvalueToCreatedDateAppointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>("CreatedDate", "Appointments", defaultValueSql:"GetDate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>("CreatedDate","Appointments", defaultValue: null);
        }
    }
}
