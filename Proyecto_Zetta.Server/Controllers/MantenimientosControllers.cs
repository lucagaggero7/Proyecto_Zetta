using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Server.Repositorio;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/Mantenimientos")]
    public class MantenimientosControllers : ControllerBase
    {
        private readonly IMantenimientoRepositorio repositorio;
        private readonly IMapper mapper;

        public MantenimientosControllers(IMantenimientoRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mantenimiento>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetById/{Id:int}")] //api/GetById/2
        public async Task<ActionResult<Mantenimiento>> GetById(int Id)
        {
            var Verif = await repositorio.SelectById(Id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("GetByEst/{est}")] //api/Mantenimiento/GetByEst/Activo
        public async Task<ActionResult<IEnumerable<Mantenimiento>>> GetByEst(string est)
        {
            var seguimiento = await repositorio.SelectByEst(est);
            if (seguimiento == null || !seguimiento.Any()) // Verifica que Seguimiento no sea nulo y que tenga elementos
            {
                return NotFound();
            }
            return Ok(seguimiento);
        }

        [HttpGet("existe/{id:int}")] //api/Mantenimiento/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearMantenimientoDTO entidadDTO)
        {
            try
            {
                //Obra entidad = new Obra();
                //entidad.Estado = entidadDTO.Estado;
                //entidad.Tipo = entidadDTO.Tipo;
                //entidad.Descripcion = entidadDTO.Descripcion;
                //entidad.Materiales = entidadDTO.Materiales;
                //entidad.FechaAlta = entidadDTO.FechaAlta;
                //entidad.FechaBaja = entidadDTO.FechaBaja;
                //entidad.AnexarServicio = entidadDTO.AnexarServicio;
                //entidad.InstaladorId = entidadDTO.InstaladorId;

                Mantenimiento entidad = mapper.Map<Mantenimiento>(entidadDTO);


                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpPut("{Id:int}")] //api/Mantenimiento/2
        public async Task<ActionResult> Put(int Id, [FromBody] EditarMantenimientoDTO entidadDTO)
        {
            try
            {
                Mantenimiento entidad = mapper.Map<Mantenimiento>(entidadDTO);

                await repositorio.Update(entidad.Id, entidad);
                return Ok();
                //return Ok(new { message = "Actualización exitosa" });
            }

            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }


        [HttpDelete("{id:int}")] //api/Mantenimiento/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Drop(id);

            if (!resp)
            {
                return BadRequest("El Mantenimiento no se pudo borrar");

            }
            return Ok();

        }
    }
}
