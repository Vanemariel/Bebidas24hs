using Bebidas24hs.DataBase.Data;
using Bebidas24hs.DataBase.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bebidas24hs.Server.Controllers
{
    public class TurnoController
    {
        private readonly BDContext context;

        public TurnoController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet]
        //metodo que me muestra la lista
        public async Task<ActionResult<List<Turno>>> GetAll()
        {
            return await context.Turnos.Include(x => x.Ventas).ToListAsync();
            //return await context.Empleados.ToListAsync();
        }

    }
}
