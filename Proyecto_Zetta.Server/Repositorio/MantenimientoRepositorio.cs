using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.DB.Data;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Zetta.Server.Repositorio
{
    public class MantenimientoRepositorio : Repositorio<Mantenimiento>, IMantenimientoRepositorio
    {
        private readonly Context context;

        public MantenimientoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Mantenimiento>> SelectByEst(string est)
        {
            return await context.Mantenimientos
                .Where(o => o.Estado == est) // Filtra las obras por estado
                .ToListAsync(); // Convierte el resultado a una lista
        }

    }
}
