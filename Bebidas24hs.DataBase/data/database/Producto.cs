using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bebidas24hs.DataBase.data.database
{
    [Index(nameof(codproducto), Name = "Producto_Codproducto", IsUnique = true)]

    public class Producto : EntityBase
    {
        [Required(ErrorMessage = "El codigo del producto es obligatorio.")]
        [MaxLength(4, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public int codproducto { get; set; }

        [Required(ErrorMessage = "El nombre del prducto es obligatorio es obligatorio.")]
        [MaxLength(150, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public string Nombreproducto { get; set; }

        [Required(ErrorMessage = "El nombre del proveedor es obligatorio.")]
        [MaxLength(150, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public string Proveedor { get; set; }
         
        [Required(ErrorMessage = "El valor del producto es obligatorio.")]
        [MaxLength(4, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public int Valorproducto { get; set; }

        [Required(ErrorMessage = "la descripcion es obligatoria.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public string Descripcion { get; set; }

    }
}
