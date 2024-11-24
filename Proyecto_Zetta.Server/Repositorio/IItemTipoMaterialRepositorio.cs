using Proyecto_Zetta.DB.Data.Entity;

namespace Proyecto_Zetta.Server.Repositorio
{
    public interface IItemTipoMaterialRepositorio
    {

        Task<IEnumerable<ItemTipoMaterial>> SelectByItemTipoId(int id);

        Task<bool> DropItemTipo(int id);
    }
}