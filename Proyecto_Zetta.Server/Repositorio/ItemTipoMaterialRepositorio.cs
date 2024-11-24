using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.DB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Zetta.Server.Repositorio
{
    public class ItemTipoMaterialRepositorio : IItemTipoMaterialRepositorio
    {
        private readonly Context context;

        public ItemTipoMaterialRepositorio(Context context) 
        {
            this.context = context;
        }

        public async Task<IEnumerable<ItemTipoMaterial>> SelectByItemTipoId(int id)
        {
            return await context.ItemsTipoMateriales
      .Where(o => o.ItemTipoId == id) // Filtra las obras por estado
      .ToListAsync(); // Convierte el resultado a una lista
        }

        public async Task<bool> DropItemTipo(int id)
        {
            // Obtener todos los materiales asociados al ItemTipoId
            var Verif = await SelectByItemTipoId(id);

            if (Verif == null || !Verif.Any()) // Verifica si la lista está vacía
            {
                return false;
            }

            // Elimina todos los registros relacionados con ese id
            context.ItemsTipoMateriales.RemoveRange(Verif);
            await context.SaveChangesAsync();

            return true;
        }



    }
}
