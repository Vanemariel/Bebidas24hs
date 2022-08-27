using Bebidas24hs.DataBase.Data.Entidades;
using Microsoft.EntityFrameworkCore;


namespace Bebidas24hs.DataBase.Data
{
    public class BDContext: DbContext
    {

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Venta> Ventas{ get; set; }

        public BDContext(DbContextOptions options) : base(options)
        {
        }
    }
}
