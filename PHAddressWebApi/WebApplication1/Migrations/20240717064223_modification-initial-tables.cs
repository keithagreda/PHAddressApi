using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHAddressWebApi.Migrations
{
    /// <inheritdoc />
    public partial class modificationinitialtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PsgcCode",
                table: "Cities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrgyName",
                table: "Barangays",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PsgcCode",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "BrgyName",
                table: "Barangays");
        }
    }
}
