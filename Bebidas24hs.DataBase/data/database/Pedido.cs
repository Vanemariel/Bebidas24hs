using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bebidas24hs.DataBase.data.database
{
    [Index(nameof(codpedido), Name = "Pedido_Codpedido", IsUnique = true)]
    public class Pedido : EntityBase
    {
        [Required(ErrorMessage = "El nombre del pedido es obligatorio.")]
        [MaxLength(150, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public string nombre { get; set; }

        [Required(ErrorMessage = "El codigo del pedido es obligatorio.")]
        [MaxLength(4, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public int codpedido { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatorio.")]
        [MaxLength(150, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public string descripcion { get; set; }

        [Required(ErrorMessage = "El valor de la compra es obligatorio.")]
        [MaxLength(8, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public int valorcompra { get; set; }
        public List<Producto>Producto { get; set; }
    }
}
