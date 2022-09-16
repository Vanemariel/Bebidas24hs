//using Bebidas24hs.DataBase.data;
//using Bebidas24hs.DataBase.data.database;
using Bebidas24hs.DataBase.Data;
using Bebidas24hs.DataBase.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bebidas24hs.Server.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly BDContext context;

        public ProductoController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet]
        //metodo que me muestra la lista
        public async Task<ActionResult<List<Producto>>> GetAll()
        {
            List<Producto> productos = await context.Productos
                .Include(x => x.Venta)
                .ToListAsync();
            return productos;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            // await metodo a ejecutar asincronico
            Producto productos = await context.Productos
                .Where(x => x.Id == id)
                .Include(x => x.Venta)
                .FirstOrDefaultAsync();
            //x=>x.id x seria el registro donde esta el id 
            if (productos == null)
            {
                return NotFound($"No existe el Producto con id igual a {id}.");
            }
            return productos;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> Insert(Producto prod)
        {
            try
            {
                context.Productos.Add(prod);
                await context.SaveChangesAsync();
                return prod;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Modified(int id, [FromBody] Producto Producto)
        {
            //bsco un usuario de la clase producto de la tabla Productos x id
            Producto productoencontrado = await context.Productos.Where(x => x.Id == id).FirstOrDefaultAsync();
            //si mi id es null no existe 
            if (productoencontrado == null)
            {
                return NotFound("no existe el producto a modificar.");
            }
            //si es correcto puedo modificar todo lo q sigue
            
            productoencontrado.Codigo = Producto.Codigo;
            productoencontrado.Id = Producto.Id;
            productoencontrado.Descripcion = Producto.Descripcion;
            productoencontrado.Id = Producto.Id;

            try
            {
                context.Productos.Update(productoencontrado);
                await context.SaveChangesAsync();
                return Ok("Los datos han sido cambiados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id:int}")]//metodo borrar 
        public async Task<ActionResult> Delete(int id)
        {
            //await metodo asincronoico
            if (id <= 0)
            {
                return BadRequest("No es correcto");
            }
            Producto prod = await context.Productos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (prod == null)//parametro de q no puede ser nulo el dato
            {
                return NotFound($"No existe el Producto con id igual a {id}.");//retorna error
            }
            //try uso de excepcion ya que en la ejecucion hubo un error en el id del producto y se desea que siga
            //ejecutandose por lo q el uso correcto es el try catch
            try
            {
                context.Productos.Remove(prod);//borrar el producto de la table productos
                await context.SaveChangesAsync();//busca el dato guardado
                return Ok($"El producto {prod} ha sido borrado.");//retorna q se borro
            }
            catch (Exception) //se captura la excepcion del try
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }
    }
}
