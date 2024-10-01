using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Atividade.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoRevert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_cas",
                table: "tbl_cas");

            migrationBuilder.RenameTable(
                name: "tbl_cas",
                newName: "tbl_casa");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_cas_Localizacao",
                table: "tbl_casa",
                newName: "IX_tbl_casa_Localizacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_casa",
                table: "tbl_casa",
                column: "CasaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_casa",
                table: "tbl_casa");

            migrationBuilder.RenameTable(
                name: "tbl_casa",
                newName: "tbl_cas");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_casa_Localizacao",
                table: "tbl_cas",
                newName: "IX_tbl_cas_Localizacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_cas",
                table: "tbl_cas",
                column: "CasaId");
        }
    }
}
