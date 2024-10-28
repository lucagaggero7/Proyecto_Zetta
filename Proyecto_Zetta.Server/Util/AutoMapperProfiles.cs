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
        }
    }
}
