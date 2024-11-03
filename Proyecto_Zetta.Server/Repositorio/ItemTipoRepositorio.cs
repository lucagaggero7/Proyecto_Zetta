using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.DB.Data;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Zetta.Server.Repositorio
{
    public class ItemTipoRepositorio : Repositorio<ItemTipo>, IItemTipoRepositorio
    {
        private readonly Context context;

        public ItemTipoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<ItemTipo> SelectById(int id)
        {
            return await context.ItemsTipo
                .Include(it => it.ItemTipoMateriales)
                    .ThenInclude(itm => itm.Material)
                .FirstOrDefaultAsync(it => it.Id == id);
        }

        public async Task Update(int id, ItemTipo entidad)
        {
            var itemTipo = await SelectById(id);
            if (itemTipo != null)
            {
                context.Entry(itemTipo).CurrentValues.SetValues(entidad);

                // Actualiza la lista de ItemTipoMateriales
                itemTipo.ItemTipoMateriales = entidad.ItemTipoMateriales;

                await context.SaveChangesAsync();
            }
        }

    }
}
