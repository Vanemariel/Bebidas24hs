using Bebidas24hs.DataBase.data;
using Bebidas24hs.DataBase.data.database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bebidas24hs.Server.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly bebidabase context;

        public PedidoController(bebidabase context)
        {
            this.context = context;
        }

        [HttpGet]
        //metodo que me muestra la lista
        public async Task<IEnumerable<Pedido>> GetAll()//obtener todo All
        {
            List<Pedido> mercaderias = await context.pedidos.ToListAsync();
            //retorna la lista de la tabla 

            List<Pedido> Listado = new List<Pedido>();

            foreach (Pedido mercaderia in mercaderias)
            {
                Listado.Add(new Pedido
                {
                    codpedido = mercaderia.codpedido,
                    nombre = mercaderia.nombre,
                    valorcompra = mercaderia.valorcompra,
                    descripcion = mercaderia.descripcion,
                });
            }
            return Listado;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            // await metodo a ejecutar asincronico
            Producto prod = await context.productos.Where(x => x.Id == id).FirstOrDefaultAsync();
            //x=>x.id x seria el registro donde esta el id 
            if (prod == null)
            {
                return NotFound($"No existe el Producto con id igual a {id}.");
            }
            return prod;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Insert(Pedido ped)//se el nombre del personaje pero 
                                                                                    //no conozco el ID eso me lo da la base 
        {
            try
            {
                context.pedidos.Add(ped);
                await context.SaveChangesAsync();
                return ped;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //modificacion de datos
        public async Task<ActionResult> Put(int id, [FromBody] Pedido ped)
        {

            //bsco un usuario de la clase estudiante de la tabla personaje x id

            Pedido pedidoencontrado = await context.pedidos.Where(x => x.Id == id).FirstOrDefaultAsync();
            //si mi id es null no existe 
            if (pedidoencontrado == null)
            {
                return NotFound("Pedido a modificar incorrecto.");
            }
            //si es correcto puedo modificar todo lo q sigue
            pedidoencontrado.Id = ped.Id;
            pedidoencontrado.nombre = ped.nombre;
            pedidoencontrado.codpedido = ped.codpedido;
            pedidoencontrado.descripcion = ped.descripcion;
            pedidoencontrado.valorcompra = ped.valorcompra ;
            

            try
            {
                context.pedidos.Update(pedidoencontrado);
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
            
            Pedido ped = await context.pedidos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (ped == null)//parametro de q no puede ser nulo el dato
            {
                return NotFound($"No existe el Pedido con id igual a {id}.");//retorna error
            }
            //try uso de excepcion ya que en la ejecucion hubo un error en el id del producto y se desea que siga
            //ejecutandose por lo q el uso correcto es el try catch
            try
            {
                context.pedidos.Remove(ped);//borrar el pedido de la table pedido
                await context.SaveChangesAsync();//busca el dato guardado
                return Ok($"la pelicua o serie  {ped} ha sido borrado.");//retorna q se borro
            }
            catch (Exception) //se captura la excepcion del try
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }

        }
    }
}
