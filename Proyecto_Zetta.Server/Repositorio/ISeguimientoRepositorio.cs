using Proyecto_Zetta.DB.Data.Entity;

namespace Proyecto_Zetta.Server.Repositorio
{
    public interface ISeguimientoRepositorio : IRepositorio<Seguimiento>
    {
        Task<IEnumerable<Seguimiento>> SelectByEst(string est);
    }
}