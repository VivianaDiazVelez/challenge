using Microsoft.EntityFrameworkCore.Migrations;

namespace Magneto.Migrations
{
    public partial class addUniquDNAtoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DNA",
                table: "Mutants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mutants_DNA",
                table: "Mutants",
                column: "DNA",
                unique: true,
                filter: "[DNA] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldNullable: true);
        }
    }
}
