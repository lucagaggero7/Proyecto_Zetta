using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Server.Repositorio;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/ItemsTipoMateriales")]
    public class ItemsTipoMaterialesControllers : ControllerBase
    {
        private readonly IItemTipoMaterialRepositorio repositorio;
        private readonly IMapper mapper;

        public ItemsTipoMaterialesControllers(IItemTipoMaterialRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpDelete("{id:int}")] //api/ItemsTipoMateriales/2
        public async Task<ActionResult> Borrar(int id)
        {
            var resp = await repositorio.DropItemTipo(id);

            if (!resp)
            {
                return BadRequest("El item tipo de la tabla intermedia no se pudo borrar");

            }
            return Ok();

        }

        [HttpGet("GetByItemTipoId/{Id:int}")] //api/GetByItemTipoId/2
        public async Task<ActionResult<IEnumerable<ItemTipoMaterial>>> GetByItemTipoId(int Id)
        {
            var Verif = await repositorio.SelectByItemTipoId(Id);
            if (Verif == null || !Verif.Any()) // Verifica que Seguimiento no sea nulo y que tenga elementos
            {
                return NotFound();
            }
            return Ok(Verif);
        }
    }
}
