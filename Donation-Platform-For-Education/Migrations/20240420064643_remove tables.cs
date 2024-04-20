using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Donation_Platform_For_Education.Migrations
{
    /// <inheritdoc />
    public partial class removetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_donors",
                table: "donors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_admins",
                table: "admins");

            migrationBuilder.RenameTable(
                name: "donors",
                newName: "Donor");

            migrationBuilder.RenameTable(
                name: "admins",
                newName: "Admin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donor",
                table: "Donor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donor",
                table: "Donor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "Donor",
                newName: "donors");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "admins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_donors",
                table: "donors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admins",
                table: "admins",
                column: "Id");
        }
    }
}
