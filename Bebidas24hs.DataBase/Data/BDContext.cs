using Bebidas24hs.DataBase.Data.Entidades;
using Microsoft.EntityFrameworkCore;


namespace Bebidas24hs.DataBase.Data
{
    public class BDContext: DbContext
    {

        public BDContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().HasData(
               new Empleado
               {
                   Id = 1,
                   Name = "Mariano",
                   Password = "TeletubiTutu"
               },
               new Empleado
               {
                   Id = 2,
                   Name = "Juanchi",
                   Password = "JuanchiLanchi"
               },
               new Empleado
               {
                   Id = 3,
                   Name = "Vanesa",
                   Password = "PepeSalta"
               }
            );

            modelBuilder.Entity<Producto>().HasData(  
                new Producto { 
                    Id = 1, 
                    Precio = "200",
                    Codigo = "3FQA",
                    Descripcion = "Coca Cola",
                    VentaId = 112
                },
                new Producto
                {
                    Id = 2,
                    Precio = "300",
                    Codigo = "12312FQA",
                    Descripcion = "Pepsi",
                    VentaId = 2321
                }
            );

            modelBuilder.Entity<Venta>().HasData(
                new Venta
                {
                    EmpleadoId = 1,
                    Id = 2321,
                },
                new Venta
                {
                    EmpleadoId = 1,
                    Id = 112,
                }
            );


        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Producto> Productos { get; set; }
        //public DbSet<Turno> Turnos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }
}
