using Microsoft.EntityFrameworkCore.Migrations;

namespace Magneto.Migrations
{
    public partial class DNAHashToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Mutants_DNA",
                table: "Mutants");

            migrationBuilder.AlterColumn<string>(
                name: "DNA",
                table: "Mutants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DNAHash",
                table: "Mutants",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mutants_DNAHash",
                table: "Mutants",
                column: "DNAHash",
                unique: true,
                filter: "[DNAHash] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Mutants_DNAHash",
                table: "Mutants");

            migrationBuilder.DropColumn(
                name: "DNAHash",
                table: "Mutants");

            migrationBuilder.AlterColumn<string>(
                name: "DNA",
                table: "Mutants",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mutants_DNA",
                table: "Mutants",
                column: "DNA",
                unique: true,
                filter: "[DNA] IS NOT NULL");
        }
    }
}
