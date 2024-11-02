using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.DB.Data;

namespace Proyecto_Zetta.Server.Repositorio
{
    public class ItemTipoRepositorio : Repositorio<ItemTipo>, IItemTipoRepositorio
    {
        private readonly Context context;

        public ItemTipoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

    }
}
