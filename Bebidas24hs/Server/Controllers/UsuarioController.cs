using Bebidas24hs.DataBase.data;
using Bebidas24hs.DataBase.data.database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bebidas24hs.Server.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly bebidabase context;

        public UsuarioController(bebidabase context)
        {
            this.context = context;
        }

        [HttpPost("{id:int}")]

        public async Task<ActionResult<Usuario>> PostAsync(Usuario usuario)
        {
            try
            {
                context.usuarios.Add(usuario);
                await context.SaveChangesAsync();
                return usuario;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("No es correcto");
            }
            Usuario usuarios = await context.usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (usuarios == null)//parametro de q no puede ser nulo el dato
            {
                return NotFound($"No existe el usuario con id igual a {id}.");//retorna error
            }

            try
            {
                context.usuarios.Remove(usuarios);
                await context.SaveChangesAsync();
                return Ok($"el usuario {usuarios.name} ha sido borrado.");//retorna q se borro
            }
            catch (Exception) //se captura la excepcion del try
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }
    }
}
