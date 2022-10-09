using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_movimentoManual.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MOVIMENTO_MANUAL",
                columns: table => new
                {
                    DAT_MES = table.Column<int>(type: "INTEGER", nullable: false),
                    DAT_ANO = table.Column<int>(type: "INTEGER", nullable: false),
                    NUM_LANCAMENTO = table.Column<int>(type: "INTEGER", nullable: false),
                    COD_PRODUTO = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    COD_COSIF = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    DES_DESCRICAO = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DAT_MOVIMENTO = table.Column<DateTime>(type: "TEXT", nullable: false),
                    COD_USUARIO = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    VAL_VALOR = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIMENTO_MANUAL", x => new { x.DAT_MES, x.DAT_ANO, x.NUM_LANCAMENTO, x.COD_PRODUTO, x.COD_COSIF });
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    COD_PRODUTO = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    DES_PRODUTO = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    STA_STATUS = table.Column<string>(type: "TEXT", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.COD_PRODUTO);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO_COSIF",
                columns: table => new
                {
                    COD_PRODUTO = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    COD_COSIF = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    COD_CLASSIFICACAO = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    STA_STATUS = table.Column<string>(type: "TEXT", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO_COSIF", x => new { x.COD_COSIF, x.COD_PRODUTO });
                });

            migrationBuilder.InsertData(
                table: "PRODUTO",
                columns: new[] { "COD_PRODUTO", "DES_PRODUTO", "STA_STATUS" },
                values: new object[] { "PR01", "PRD 001", "A" });

            migrationBuilder.InsertData(
                table: "PRODUTO",
                columns: new[] { "COD_PRODUTO", "DES_PRODUTO", "STA_STATUS" },
                values: new object[] { "PR02", "PRD 002", "D" });

            migrationBuilder.InsertData(
                table: "PRODUTO",
                columns: new[] { "COD_PRODUTO", "DES_PRODUTO", "STA_STATUS" },
                values: new object[] { "PR03", "PRD 003", "A" });

            migrationBuilder.InsertData(
                table: "PRODUTO_COSIF",
                columns: new[] { "COD_COSIF", "COD_PRODUTO", "COD_CLASSIFICACAO", "STA_STATUS" },
                values: new object[] { "PRDCOS001", "PR01", "CL1", "A" });

            migrationBuilder.InsertData(
                table: "PRODUTO_COSIF",
                columns: new[] { "COD_COSIF", "COD_PRODUTO", "COD_CLASSIFICACAO", "STA_STATUS" },
                values: new object[] { "PRDCOS999", "PR01", "CL999", "A" });

            migrationBuilder.InsertData(
                table: "PRODUTO_COSIF",
                columns: new[] { "COD_COSIF", "COD_PRODUTO", "COD_CLASSIFICACAO", "STA_STATUS" },
                values: new object[] { "PRDCOS002", "PR02", "CL2", "D" });

            migrationBuilder.InsertData(
                table: "PRODUTO_COSIF",
                columns: new[] { "COD_COSIF", "COD_PRODUTO", "COD_CLASSIFICACAO", "STA_STATUS" },
                values: new object[] { "PRDCOS003", "PR03", "CL3", "A" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MOVIMENTO_MANUAL");

            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "PRODUTO_COSIF");
        }
    }
}
