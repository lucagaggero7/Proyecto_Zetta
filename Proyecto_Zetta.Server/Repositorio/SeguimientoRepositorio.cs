using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.DB.Data;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Zetta.Server.Repositorio
{
    public class SeguimientoRepositorio : Repositorio<Seguimiento>, ISeguimientoRepositorio
    {
        private readonly Context context;

        public SeguimientoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Seguimiento>> SelectByEst(string est)
        {
            return await context.Seguimientos
                .Where(o => o.Estado == est) // Filtra las obras por estado
                .ToListAsync(); // Convierte el resultado a una lista
        }

    }
}
