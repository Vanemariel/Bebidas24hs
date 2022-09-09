using Bebidas24hs.DataBase.Data.Comun;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bebidas24hs.DataBase.Data.Entidades
{
    #region Clave primaria heredada de BaseEntity. 
    #endregion
    public class Empleado: BaseEntity
    {

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Password { get; set; }


        [InverseProperty("Empleado")]
        public List<Venta> Ventas { get; set; }
    }
}
