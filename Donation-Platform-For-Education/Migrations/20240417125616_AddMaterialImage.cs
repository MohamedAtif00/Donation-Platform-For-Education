using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Donation_Platform_For_Education.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "items",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "items");
        }
    }
}
