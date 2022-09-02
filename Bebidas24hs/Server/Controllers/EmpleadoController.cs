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
    public class EmpleadoController : ControllerBase
    {
        private readonly BDContext context;

        public EmpleadoController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet]
        //metodo que me muestra la lista completa  
        public async Task<ActionResult<List<Empleado>>> GetAll()
        {
            //return await context.Empleados.Include(x => x.Ventas).ToListAsync();
            return await context.Empleados.ToListAsync();
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult<Empleado>> Insert(Empleado empleado)
        { 
            try
            {
                context.Empleados.Add(empleado);
                await context.SaveChangesAsync();
                return empleado;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Modified(int id, [FromBody] Empleado Persona)
        {
            //bsco un usuario de la clase empleado de la tabla personaje x id
            Empleado personaencontrada = await context.Empleados.Where(x => x.Id == id).FirstOrDefaultAsync();
            //si mi id es null no existe 
            if (personaencontrada == null)
            {
                return NotFound("no existe el empleado a modificar.");
            }
            //si es correcto puedo modificar todo lo q sigue
            personaencontrada.Name = Persona.Name;
            personaencontrada.Password = Persona.Password;
            personaencontrada.Id = Persona.Id;


            try
            {
                context.Empleados.Update(personaencontrada);
                await context.SaveChangesAsync();
                return Ok("Los datos han sido cambiados");
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

            Empleado empleado = await context.Empleados.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (empleado == null)//parametro de q no puede ser nulo el dato
            {
                return NotFound($"No existe el usuario con id igual a {id}.");//retorna error
            }

            try
            {
                context.Empleados.Remove(empleado);
                await context.SaveChangesAsync();
                return Ok($"el usuario {empleado.Name} ha sido borrado.");//retorna q se borro
            }
            catch (Exception) //se captura la excepcion del try
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }
    }
}
