using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPedidos.Migrations
{
    public partial class changenprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PedidoArprobacionControl",
                columns: table => new
                {
                    PedidoAprobacionControlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAprobacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    PedidoOrdenPedidoId = table.Column<int>(type: "int", nullable: true),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoArprobacionControl", x => x.PedidoAprobacionControlId);
                    table.ForeignKey(
                        name: "FK_PedidoArprobacionControl_Pedido_PedidoOrdenPedidoId",
                        column: x => x.PedidoOrdenPedidoId,
                        principalTable: "Pedido",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoArprobacionControl_Supervisor_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Supervisor",
                        principalColumn: "SupervisorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoArprobacionControl_PedidoOrdenPedidoId",
                table: "PedidoArprobacionControl",
                column: "PedidoOrdenPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoArprobacionControl_SupervisorId",
                table: "PedidoArprobacionControl",
                column: "SupervisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoArprobacionControl");
        }
    }
}
