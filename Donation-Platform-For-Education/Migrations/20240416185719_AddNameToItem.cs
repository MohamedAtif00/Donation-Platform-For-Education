using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Donation_Platform_For_Education.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "items");
        }
    }
}
