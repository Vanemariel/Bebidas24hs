using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bebidas24hs.DataBase.Migrations
{
    public partial class fnal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codproducto",
                table: "pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "Proveedor",
                table: "productos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombreproducto",
                table: "productos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "productos",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "codproducto",
                table: "productos",
                type: "int",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "pedidos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "pedidos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "codpedido",
                table: "pedidos",
                type: "int",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "Entity_Id2",
                table: "usuarios",
                column: "Id",
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
                name: "Entity_Id",
                table: "pedidos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Pedido_Codpedido",
                table: "pedidos",
                column: "codpedido",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_productos_pedidos_PedidoId",
                table: "productos",
                column: "PedidoId",
                principalTable: "pedidos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productos_pedidos_PedidoId",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "Entity_Id2",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "Entity_Id1",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "IX_productos_PedidoId",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "Producto_Codproducto",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "Entity_Id",
                table: "pedidos");

            migrationBuilder.DropIndex(
                name: "Pedido_Codpedido",
                table: "pedidos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "codproducto",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "codpedido",
                table: "pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "Proveedor",
                table: "productos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Nombreproducto",
                table: "productos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "productos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "pedidos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "pedidos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "codproducto",
                table: "pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
