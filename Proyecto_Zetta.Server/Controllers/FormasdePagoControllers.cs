using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Server.Repositorio;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/FormasdePago")]
    public class FormasdePagoControllers : ControllerBase
    {
        private readonly IFormadePagoRepositorio repositorio;
        private readonly IMapper mapper;

        public FormasdePagoControllers(IFormadePagoRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<FormadePago>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetById/{Id:int}")] //api/GetById/2
        public async Task<ActionResult<FormadePago>> GetById(int Id)
        {
            var Verif = await repositorio.SelectById(Id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("existe/{id:int}")] //api/FormadePago/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearFormadePagoDTO entidadDTO)
        {
            try
            {
                FormadePago entidad = mapper.Map<FormadePago>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpPut("{Id:int}")] //api/FormadePago/2
        public async Task<ActionResult> Put(int Id, [FromBody] EditarFormadePagoDTO entidadDTO)
        {
            try
            {
                FormadePago entidad = mapper.Map<FormadePago>(entidadDTO);

                await repositorio.Update(entidad.Id, entidad);
                return Ok();
                //return Ok(new { message = "Actualización exitosa" });
            }

            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }


        [HttpDelete("{id:int}")] //api/FormadePago/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Drop(id);

            if (!resp)
            {
                return BadRequest("La Forma de Pago no se pudo borrar");

            }
            return Ok();

        }
    }
}
