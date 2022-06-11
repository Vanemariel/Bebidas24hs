using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bebidas24hs.DataBase.Migrations
{
    public partial class finalmente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 120, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    codpedido = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    valorcompra = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    fechacreacion = table.Column<DateTime>(type: "datetime2", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 120, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    pasword = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    fechacreacion = table.Column<DateTime>(type: "datetime2", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 120, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codproducto = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Nombreproducto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Proveedor = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Valorproducto = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: true),
                    fechacreacion = table.Column<DateTime>(type: "datetime2", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productos_pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "Entity_Id",
                table: "pedidos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Pedido_Codpedido",
                table: "pedidos",
                column: "codpedido",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Entity_Id1",
                table: "productos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productos_PedidoId",
                table: "productos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "Producto_Codproducto",
                table: "productos",
                column: "codproducto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Entity_Id2",
                table: "usuarios",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Usuario_Pasword",
                table: "usuarios",
                column: "pasword",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "pedidos");
        }
    }
}
