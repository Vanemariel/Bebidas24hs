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
        public async Task<IEnumerable<Producto>> GetAll()//obtener todo All
        {
            List<Producto> mercaderias = await context.Productos.ToListAsync();
            //retorna la lista de la tabla 

            List<Producto> Listado = new List<Producto>();

            foreach (Producto mercaderia in mercaderias)
            {
                Listado.Add(new Producto
                {
                    Id = mercaderia.Id,   
                    Codigo = mercaderia.Codigo, 
                    Precio = mercaderia.Precio,     
                    Descripcion = mercaderia.Descripcion,
                });
            }
            return Listado;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            // await metodo a ejecutar asincronico
            Producto prod = await context.Productos.Where(x => x.Id == id).FirstOrDefaultAsync();
            //x=>x.id x seria el registro donde esta el id 
            if (prod == null)
            {
                return NotFound($"No existe el Producto con id igual a {id}.");
            }
            return prod;
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
