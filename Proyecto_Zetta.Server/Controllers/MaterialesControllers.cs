using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Server.Repositorio;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/Materiales")]
    public class MaterialesControllers : ControllerBase
    {
        private readonly IMaterialRepositorio repositorio;
        private readonly IMapper mapper;

        public MaterialesControllers(IMaterialRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Material>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetById/{Id:int}")] //api/GetById/2
        public async Task<ActionResult<Material>> GetById(int Id)
        {
            var Verif = await repositorio.SelectById(Id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("existe/{id:int}")] //api/Material/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearMaterialDTO entidadDTO)
        {
            try
            {
                Material entidad = mapper.Map<Material>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpPut("{Id:int}")] //api/Material/2
        public async Task<ActionResult> Put(int Id, [FromBody] EditarMaterialDTO entidadDTO)
        {
            try
            {
                Material entidad = mapper.Map<Material>(entidadDTO);

                await repositorio.Update(entidad.Id, entidad);
                return Ok();
                //return Ok(new { message = "Actualización exitosa" });
            }

            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }


        [HttpDelete("{id:int}")] //api/Material/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Drop(id);

            if (!resp)
            {
                return BadRequest("El Material no se pudo borrar");

            }
            return Ok();

        }
    }
}
