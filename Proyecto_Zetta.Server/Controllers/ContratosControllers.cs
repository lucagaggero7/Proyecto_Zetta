using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/Contratos")]
    public class ContratosControllers : ControllerBase
    {
        private readonly Context context;
        public ContratosControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Obra>>> get()
        {
            return await context.Obras.ToListAsync();
        }

        [HttpGet("GetById/{id:int}")] //api/Obra/2
        public async Task<ActionResult<Obra>> GetById(int id)
        {
            var Verif = await context.Obras.FirstOrDefaultAsync(x => x.Id == id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("GetByEst/{nom}")] //api/Obra/2
        public async Task<ActionResult<Obra>> GetByNom(string est)
        {
            var Verif = await context.Obras.FirstOrDefaultAsync(x => x.Estado == est);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearObraDTO entidadDTO)
        {
            try
            {
                Obra entidad = new Obra();
                entidad.Estado = entidadDTO.Estado;
                entidad.Tipo = entidadDTO.Tipo;
                entidad.Descripcion = entidadDTO.Descripcion;
                entidad.Materiales = entidadDTO.Materiales;
                entidad.FechaAlta = entidadDTO.FechaAlta;
                entidad.FechaBaja = entidadDTO.FechaBaja;
                entidad.AnexarServicio = entidadDTO.AnexarServicio;
                entidad.InstaladorId = entidadDTO.InstaladorId;


                context.Obras.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Obra/2
        public async Task<ActionResult> Put(int Id, [FromBody] Obra entidad)
        {
            if (Id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var Verif = await context.Obras
                .Where(reg => reg.Id == Id).FirstOrDefaultAsync();

            if (Verif == null)
            {
                return NotFound("No existe el recurso buscado.");
            }

            Verif.Estado = entidad.Estado;
            Verif.Tipo = entidad.Tipo;
            Verif.Descripcion = entidad.Descripcion;
            Verif.Materiales = entidad.Materiales;
            Verif.FechaAlta = entidad.FechaAlta;
            Verif.FechaBaja = entidad.FechaBaja;
            Verif.AnexarServicio = entidad.AnexarServicio;

            try
            {
                context.Obras.Update(Verif);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Obra/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Obras.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($" El recurso {id} no existe.");
            }

            Obra EntidadABorrar = new Obra();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}