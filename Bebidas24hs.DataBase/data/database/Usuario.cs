using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bebidas24hs.DataBase.data.database
{
    [Index(nameof(pasword), Name = "Usuario_Pasword", IsUnique = true)]

    public class Usuario: EntityBase   
    {
        [Required(ErrorMessage = "El name del usuario es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public string name { get; set; }

        [Required(ErrorMessage = "El lastname del usuario es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public string lastname { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public string email { get; set; }

        [Required(ErrorMessage = "El pasword del usuario es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public string pasword { get; set; }
    }
}
