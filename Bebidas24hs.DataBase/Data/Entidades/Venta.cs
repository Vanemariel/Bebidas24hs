using Bebidas24hs.DataBase.Data.Comun;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bebidas24hs.DataBase.Data.Entidades
{
    #region Clave primaria heredada de BaseEntity. 
    #endregion
    public class Venta : BaseEntity
    {
        //[Required(ErrorMessage = "Campo obligatorio.")]
        //public int TurnoId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public int EmpleadoId { get; set; }


        // Claves foraneas 
        [InverseProperty("Venta")]
        public List<Producto> Productos { get; set; }

        //[ForeignKey("TurnoId")]
        //public Turno Turno { get; set; }
        
        [ForeignKey("EmpleadoId")]
        public Empleado Empleado { get; set; }
    }
}
