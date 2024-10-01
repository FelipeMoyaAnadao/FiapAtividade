using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Atividade.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_casa",
                columns: table => new
                {
                    CasaId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_casa", x => x.CasaId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ocorrencia",
                columns: table => new
                {
                    OcorrenciaId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DiaOcorrencia = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ocorrencia", x => x.OcorrenciaId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_sistema_alarme",
                columns: table => new
                {
                    SistemaAlarmeId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_sistema_alarme", x => x.SistemaAlarmeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_casa_Localizacao",
                table: "tbl_casa",
                column: "Localizacao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_sistema_alarme_Localizacao",
                table: "tbl_sistema_alarme",
                column: "Localizacao",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_casa");

            migrationBuilder.DropTable(
                name: "tbl_ocorrencia");

            migrationBuilder.DropTable(
                name: "tbl_sistema_alarme");
        }
    }
}
