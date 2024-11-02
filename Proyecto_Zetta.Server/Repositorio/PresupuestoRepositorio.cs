using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.DB.Data;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Zetta.Server.Repositorio
{
    public class PresupuestoRepositorio : Repositorio<Presupuesto>, IPresupuestoRepositorio
    {
        private readonly Context context;

        public PresupuestoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Presupuesto>> SelectByEst(string est)
        {
            return await context.Presupuestos
                .Where(o => o.Estado == est) // Filtra las obras por estado
                .ToListAsync(); // Convierte el resultado a una lista
        }

    }
}
