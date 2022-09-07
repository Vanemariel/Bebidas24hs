using Bebidas24hs.DataBase.Data.Comun;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bebidas24hs.DataBase.Data.Entidades
{
    #region Clave primaria heredada de BaseEntity. 
    #endregion

    [Index(
        nameof(Dia),
        nameof(HorarioDesde),
        nameof(HorarioHasta),
        Name = "TurnoDiaHorarioDesdeHasta",
        IsUnique = true
    )]

    public class Turno: BaseEntity
    {

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Dia { get; set; }


        [Required(ErrorMessage = "Campo obligatorio.")]
        public string HorarioDesde { get; set; }

            
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string HorarioHasta { get; set; }


        public List<Venta> Ventas { get; set; }
    }
}
