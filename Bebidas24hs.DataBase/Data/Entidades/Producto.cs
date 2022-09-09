using Bebidas24hs.DataBase.Data.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bebidas24hs.DataBase.Data.Entidades
{

    public class Producto : BaseEntity
    {
        public int VentaId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Precio { get; set; }


        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Codigo { get; set; }

        
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Descripcion { get; set; }


        [ForeignKey("VentaId")]
        public Venta Venta { get; set; }
    } 
}
