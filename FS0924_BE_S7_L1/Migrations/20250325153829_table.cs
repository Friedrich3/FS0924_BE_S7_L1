using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FS0924_BE_S7_L1.Migrations
{
    /// <inheritdoc />
    public partial class table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfile_Studenti_StudentId",
                table: "StudentProfile");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_Email",
                table: "Studenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProfile",
                table: "StudentProfile");

            migrationBuilder.RenameTable(
                name: "StudentProfile",
                newName: "StudentProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_StudentProfile_StudentId",
                table: "StudentProfiles",
                newName: "IX_StudentProfiles_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProfiles",
                table: "StudentProfiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfiles_Studenti_StudentId",
                table: "StudentProfiles",
                column: "StudentId",
                principalTable: "Studenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfiles_Studenti_StudentId",
                table: "StudentProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProfiles",
                table: "StudentProfiles");

            migrationBuilder.RenameTable(
                name: "StudentProfiles",
                newName: "StudentProfile");

            migrationBuilder.RenameIndex(
                name: "IX_StudentProfiles_StudentId",
                table: "StudentProfile",
                newName: "IX_StudentProfile_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProfile",
                table: "StudentProfile",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_Email",
                table: "Studenti",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfile_Studenti_StudentId",
                table: "StudentProfile",
                column: "StudentId",
                principalTable: "Studenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
