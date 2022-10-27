using Bebidas24hs.DataBase.Data;
using Bebidas24hs.DataBase.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bebidas24hs.Server.Controllers
{

    [ApiController]
    [Route("Api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly BDContext context;

        public VentaController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet]
        //metodo que me muestra la lista
        public async Task<ActionResult<List<Venta>>> GetAll()
        {
            List<Venta> ventas =await context.Ventas.Include(x => x.Empleado).ToListAsync();
            return ventas;
            //return await context.Ventas.ToListAsync();
        }

        [HttpPost("{id:int}")]

        public async Task<ActionResult<Venta>> Insert(Venta venta)
        {
            try
            {
                context.Ventas.Add(venta);
                await context.SaveChangesAsync();
                return venta; 
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Modified(int id, [FromBody] Venta Producto)
        {

            //bsco un usuario de la clase estudiante de la tabla personaje x id

            Venta ventaencontrada = await context.Ventas.Where(x => x.Id == id).FirstOrDefaultAsync();
            //si mi id es null no existe 
            if (ventaencontrada == null)
            {
                return NotFound("no existe la venta a modificar.");
            }
            //si es correcto puedo modificar todo lo q sigue
            //ventaencontrada.TurnoId = Producto.TurnoId;
            ventaencontrada.EmpleadoId = Producto.EmpleadoId;
            ventaencontrada.Id = Producto.Id;
            

            try
            {
                context.Ventas.Update(ventaencontrada);
                await context.SaveChangesAsync();
                return Ok("Los datos han sido cambiados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
