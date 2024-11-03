using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Server.Repositorio;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/ItemsTipo")]
    public class ItemsTipoControllers : ControllerBase
    {
        private readonly IItemTipoRepositorio repositorio;
        private readonly IMapper mapper;

        public ItemsTipoControllers(IItemTipoRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemTipo>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetById/{Id:int}")] //api/GetById/2
        public async Task<ActionResult<ItemTipo>> GetById(int Id)
        {
            var Verif = await repositorio.SelectById(Id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("existe/{id:int}")] //api/ItemTipo/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearItemTipoDTO entidadDTO)
        {
            try
            {
                ItemTipo entidad = mapper.Map<ItemTipo>(entidadDTO);

                // Si el DTO incluye una lista de IDs de Materiales, puedes agregarlos
                if (entidadDTO.MaterialesIds != null)
                {
                    foreach (var materialId in entidadDTO.MaterialesIds)
                    {
                        entidad.ItemTipoMateriales.Add(new ItemTipoMaterial { MaterialId = materialId });
                    }
                }

                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
        }


        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(int Id, [FromBody] EditarItemTipoDTO entidadDTO)
        {
            try
            {
                ItemTipo entidad = await repositorio.SelectById(Id);
                if (entidad == null)
                {
                    return NotFound();
                }

                mapper.Map(entidadDTO, entidad);

                // Limpia las relaciones existentes de Materiales si se envía una nueva lista
                entidad.ItemTipoMateriales.Clear();
                if (entidadDTO.MaterialesIds != null)
                {
                    foreach (var materialId in entidadDTO.MaterialesIds)
                    {
                        entidad.ItemTipoMateriales.Add(new ItemTipoMaterial { MaterialId = materialId });
                    }
                }

                await repositorio.Update(Id, entidad);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
        }


        [HttpDelete("{id:int}")] //api/ItemTipo/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Drop(id);

            if (!resp)
            {
                return BadRequest("El Item Tipo no se pudo borrar");

            }
            return Ok();

        }
    }
}
