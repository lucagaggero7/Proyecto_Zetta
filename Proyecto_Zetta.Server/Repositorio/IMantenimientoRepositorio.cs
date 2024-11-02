using Proyecto_Zetta.DB.Data.Entity;

namespace Proyecto_Zetta.Server.Repositorio
{
    public interface IMantenimientoRepositorio : IRepositorio<Mantenimiento>
    {
        Task<IEnumerable<Mantenimiento>> SelectByEst(string est);
    }
}