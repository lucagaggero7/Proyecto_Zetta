using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.Shared.DTO;
using AutoMapper;
using Proyecto_Zetta.Server.Repositorio;

namespace Proyecto_Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/Contratos")]
    public class ContratosControllers : ControllerBase
    {
        private readonly IObraRepositorio repositorio;
        private readonly IMapper mapper;

        public ContratosControllers(IObraRepositorio repositorio ,IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Obra>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetById/{id:int}")] //api/Obra/2
        public async Task<ActionResult<Obra>> GetById(int id)
        {
            var Verif = await repositorio.SelectById(id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("GetByEst/{est}")] //api/Obra/GetByEst/Activo
        public async Task<ActionResult<Obra>> GetByEst(string est)
        {
            Obra? Verif = await repositorio.SelectByEst(est);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("existe/{id:int}")] //api/Obras/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearObraDTO entidadDTO)
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

                Obra entidad = mapper.Map<Obra>(entidadDTO);


                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpPut("{Id:int}")] //api/Obra/2
        public async Task<ActionResult> Put(int Id, [FromBody] EditarObraDTO entidadDTO)
        {
            try
            {
                if (Id != entidadDTO.Id)
                {
                    return BadRequest("Datos Incorrectos");
                }
                Obra entidad = mapper.Map<Obra>(entidadDTO);
                var Verif = await repositorio.Update(Id, entidad);

                if (!Verif)
                {
                    return BadRequest("No se pudo actualizar el tipo de documento");
                }
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Obra/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Drop(id);

            if(!resp)
            {
                return BadRequest("La obra no se pudo borrar");

            }
            return Ok();

        }
    }
}