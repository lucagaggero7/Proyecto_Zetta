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

        public async Task<Obra> SelectByEst(string est)
        {
            Obra? Verif = await context.Obras.FirstOrDefaultAsync(x => x.Estado == est);

            return Verif;
        }

    }
}
