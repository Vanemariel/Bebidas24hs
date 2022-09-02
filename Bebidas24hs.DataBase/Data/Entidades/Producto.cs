using Bebidas24hs.DataBase.Data.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bebidas24hs.DataBase.Data.Entidades
{
    /// TODO: Definir clave primaria y etiquetas
    
    
    public class Producto : BaseEntity
    {
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Precio { get; set; }


        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Codigo { get; set; }

        
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Descripcion { get; set; }

    } 
}
