using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class HorariosMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TempoHoras = table.Column<int>(type: "int", nullable: false),
                    TempoMinutos = table.Column<int>(type: "int", nullable: false),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraInicio = table.Column<int>(type: "int", nullable: true),
                    HoraFim = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "Date", nullable: false),
                    Horas = table.Column<int>(type: "int", nullable: false),
                    Minutos = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    FuncionarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agendamento_Usuario_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agendamento_Usuario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "CPF", "Celular", "Email", "HoraFim", "HoraInicio", "Nome", "Senha", "Tipo" },
                values: new object[] { 1, "", "", "Admin", null, null, "Admin", "$2a$06$q/Euk22vypCSm11iNowK6uyX/zBK1UVBCyUnvZ.e1knaCS8PI0hyy", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ClienteId",
                table: "Agendamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_FuncionarioId",
                table: "Agendamento",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ServicoId",
                table: "Agendamento",
                column: "ServicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
