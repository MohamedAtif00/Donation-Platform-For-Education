using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Donation_Platform_For_Education.Migrations
{
    /// <inheritdoc />
    public partial class changeitemforeigkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_donors_donorId",
                table: "items");

            migrationBuilder.AddForeignKey(
                name: "FK_items_AspNetUsers_donorId",
                table: "items",
                column: "donorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_AspNetUsers_donorId",
                table: "items");

            migrationBuilder.AddForeignKey(
                name: "FK_items_donors_donorId",
                table: "items",
                column: "donorId",
                principalTable: "donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
