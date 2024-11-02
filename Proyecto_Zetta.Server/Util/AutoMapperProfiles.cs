using AutoMapper;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearObraDTO, Obra>();

            CreateMap<EditarObraDTO, Obra>();

            CreateMap<CrearInstaladorDTO, Instalador>();

            CreateMap<EditarInstaladorDTO, Instalador>();

            CreateMap<CrearClienteDTO, Cliente>();

            CreateMap<EditarClienteDTO, Cliente>();

            CreateMap<CrearSeguimientoDTO, Seguimiento>();

            CreateMap<EditarSeguimientoDTO, Seguimiento>();

            CreateMap<CrearFormadePagoDTO, FormadePago>();

            CreateMap<EditarFormadePagoDTO, FormadePago>();

            CreateMap<CrearMaterialDTO, Material>();

            CreateMap<EditarMaterialDTO, Material>();

            CreateMap<CrearMantenimientoDTO, Mantenimiento>();

            CreateMap<EditarMantenimientoDTO, Mantenimiento>();

            CreateMap<CrearItemTipoDTO, ItemTipo>();

            CreateMap<EditarItemTipoDTO, ItemTipo>();

            CreateMap<CrearPresupuestoDTO, Presupuesto>();

            CreateMap<EditarPresupuestoDTO, Presupuesto>();

        }
    }
}
