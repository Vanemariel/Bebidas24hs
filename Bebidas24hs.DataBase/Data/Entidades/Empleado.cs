using Bebidas24hs.DataBase.Data.Comun;
using System.ComponentModel.DataAnnotations;


namespace Bebidas24hs.DataBase.Data.Entidades
{
    #region Clave primaria heredada de BaseEntity. 
    #endregion
    public class Empleado: BaseEntity
    {
        public List<Venta> Ventas { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Password { get; set; }

    }
}
