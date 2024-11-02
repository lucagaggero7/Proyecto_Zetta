using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.DB.Data.Entity;


namespace Proyecto_Zetta.Server.Repositorio
{
    public class ObraRepositorio : Repositorio<Obra>, IObraRepositorio
    {
        private readonly Context context;

        public ObraRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Obra>> SelectByEst(string est)
        {
            return await context.Obras
                .Where(o => o.Estado == est) // Filtra las obras por estado
                .ToListAsync(); // Convierte el resultado a una lista
        }

    }
}
