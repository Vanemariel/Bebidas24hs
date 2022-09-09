using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bebidas24hs.DataBase.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { 1, "Mariano", "TeletubiTutu" });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { 2, "Juanchi", "JuanchiLanchi" });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { 3, "Vanesa", "PepeSalta" });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "EmpleadoId" },
                values: new object[] { 112, 1 });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "EmpleadoId" },
                values: new object[] { 2321, 1 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Codigo", "Descripcion", "Precio", "VentaId" },
                values: new object[] { 1, "3FQA", "Coca Cola", "200", 112 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Codigo", "Descripcion", "Precio", "VentaId" },
                values: new object[] { 2, "12312FQA", "Pepsi", "300", 2321 });

            migrationBuilder.CreateIndex(
                name: "Entity_Id",
                table: "Empleados",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Entity_Id1",
                table: "Productos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_VentaId",
                table: "Productos",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "Entity_Id2",
                table: "Ventas",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_EmpleadoId",
                table: "Ventas",
                column: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
