using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisAluguel.Migrations
{
    public partial class sisAluguel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "db_cliente",
                schema: "dbo",
                columns: table => new
                {
                    cd_cliente = table.Column<Guid>(nullable: false),
                    nm_cliente = table.Column<string>(nullable: false),
                    tf_cliente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_db_cliente", x => x.cd_cliente);
                });

            migrationBuilder.CreateTable(
                name: "db_aluguel",
                schema: "dbo",
                columns: table => new
                {
                    cd_aluguel = table.Column<Guid>(nullable: false),
                    cd_cliente = table.Column<Guid>(nullable: false),
                    de_aluguel = table.Column<DateTime>(nullable: false),
                    dd_aluguel = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_db_aluguel", x => x.cd_aluguel);
                    table.ForeignKey(
                        name: "FK_db_aluguel_db_cliente_cd_cliente",
                        column: x => x.cd_cliente,
                        principalSchema: "dbo",
                        principalTable: "db_cliente",
                        principalColumn: "cd_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "db_livro",
                schema: "dbo",
                columns: table => new
                {
                    cd_livro = table.Column<Guid>(nullable: false),
                    nm_livro = table.Column<string>(maxLength: 100, nullable: false),
                    st_livro = table.Column<int>(nullable: false),
                    AluguelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_db_livro", x => x.cd_livro);
                    table.ForeignKey(
                        name: "FK_db_livro_db_aluguel_AluguelId",
                        column: x => x.AluguelId,
                        principalSchema: "dbo",
                        principalTable: "db_aluguel",
                        principalColumn: "cd_aluguel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_db_aluguel_cd_cliente",
                schema: "dbo",
                table: "db_aluguel",
                column: "cd_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_db_livro_AluguelId",
                schema: "dbo",
                table: "db_livro",
                column: "AluguelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "db_livro",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "db_aluguel",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "db_cliente",
                schema: "dbo");
        }
    }
}
