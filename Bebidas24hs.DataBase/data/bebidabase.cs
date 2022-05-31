using Bebidas24hs.DataBase.data.database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bebidas24hs.DataBase.data
{

    public class bebidabase : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Pedido> pedidos { get; set; }
        public DbSet<Producto> productos { get; set; }

        public bebidabase(DbContextOptions options)
            : base(options)
        {
        }
    }
}
