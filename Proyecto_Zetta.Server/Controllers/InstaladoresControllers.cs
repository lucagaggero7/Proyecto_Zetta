using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.Shared.DTO;
using AutoMapper;
using Proyecto_Zetta.Server.Repositorio;
using System.IO.Pipelines;

namespace Proyecto_Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/Instaladores")]
    public class InstaladoresControllers : ControllerBase
    {
        private readonly IInstaladorRepositorio repositorio;
        private readonly IMapper mapper;

        public InstaladoresControllers(IInstaladorRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Instalador>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetById/{Id:int}")] //api/GetById/2
        public async Task<ActionResult<Instalador>> GetById(int Id)
        {
            var Verif = await repositorio.SelectById(Id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }


        [HttpGet("existe/{id:int}")] //api/Instaladores/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearInstaladorDTO entidadDTO)
        {
            try
            {
                Instalador entidad = mapper.Map<Instalador>(entidadDTO);


                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpPut("{Id:int}")] //api/Instalador/2
        public async Task<ActionResult> Put(int Id, [FromBody] EditarInstaladorDTO entidadDTO)
        {
            try
            {
                Instalador entidad = mapper.Map<Instalador>(entidadDTO);

                await repositorio.Update(entidad.Id, entidad);
                return Ok();
                //return Ok(new { message = "Actualización exitosa" });
            }

            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }


        [HttpDelete("{id:int}")] //api/Instalador/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Drop(id);

            if (!resp)
            {
                return BadRequest("La obra no se pudo borrar");

            }
            return Ok();

        }
    }
}