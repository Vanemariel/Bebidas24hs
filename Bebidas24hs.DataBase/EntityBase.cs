using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bebidas24hs.DataBase
{
    [Index(nameof(Id), Name = "Entity_Id", IsUnique = true)]
    public class EntityBase
    {
        [Required(ErrorMessage = "El Id es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public int Id {get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public DateTime fechacreacion { get; set; }
    }
}
