using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FS0924_BE_S7_L1.Migrations
{
    /// <inheritdoc />
    public partial class newRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14650285-4BD6-4009-8836-B1C61090F1E2", "14650285-4BD6-4009-8836-B1C61090F1E2", "Admin", "ADMIN" },
                    { "7065CF28-3402-4751-8B37-406D2DE5214B", "7065CF28-3402-4751-8B37-406D2DE5214B", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14650285-4BD6-4009-8836-B1C61090F1E2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7065CF28-3402-4751-8B37-406D2DE5214B");
        }
    }
}
