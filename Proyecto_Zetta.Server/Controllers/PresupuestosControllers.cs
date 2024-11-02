using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.Shared.DTO;
using AutoMapper;
using Proyecto_Zetta.Server.Repositorio;
using System.Linq;
using System.IO.Pipelines;

namespace Proyecto_Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/Presupuestos")]
    public class PresupuestosControllers : ControllerBase
    {
        private readonly IPresupuestoRepositorio repositorio;
        private readonly IMapper mapper;

        public PresupuestosControllers(IPresupuestoRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Presupuesto>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetById/{Id:int}")] //api/GetById/2
        public async Task<ActionResult<Presupuesto>> GetById(int Id)
        {
            var Verif = await repositorio.SelectById(Id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("GetByEst/{est}")] //api/Presupuesto/GetByEst/Activo
        public async Task<ActionResult<IEnumerable<Presupuesto>>> GetByEst(string est)
        {
            var obras = await repositorio.SelectByEst(est);
            if (obras == null || !obras.Any()) // Verifica que obras no sea nulo y que tenga elementos
            {
                return NotFound();
            }
            return Ok(obras);
        }

        [HttpGet("existe/{id:int}")] //api/Presupuesto/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPresupuestoDTO entidadDTO)
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

                Presupuesto entidad = mapper.Map<Presupuesto>(entidadDTO);


                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpPut("{Id:int}")] //api/Presupuesto/2
        public async Task<ActionResult> Put(int Id, [FromBody] EditarPresupuestoDTO entidadDTO)
        {
            try
            {
                Presupuesto entidad = mapper.Map<Presupuesto>(entidadDTO);

                await repositorio.Update(entidad.Id, entidad);
                return Ok();
                //return Ok(new { message = "Actualización exitosa" });
            }

            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }


        [HttpDelete("{id:int}")] //api/Presupuesto/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Drop(id);

            if (!resp)
            {
                return BadRequest("El Presupuesto no se pudo borrar");

            }
            return Ok();

        }
    }
}