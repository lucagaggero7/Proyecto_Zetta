using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.DB.Data.Entity;


namespace Proyecto_Zetta.Server.Repositorio
{
    public class InstaladorRepositorio : Repositorio<Instalador>, IInstaladorRepositorio
    {
        private readonly Context context;

        public InstaladorRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

    }
}
