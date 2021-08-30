using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPedidos.Migrations
{
    public partial class changeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "Producto",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Producto",
                newName: "ProductoId");
        }
    }
}
