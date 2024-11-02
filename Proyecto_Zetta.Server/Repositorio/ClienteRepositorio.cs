using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.DB.Data;

namespace Proyecto_Zetta.Server.Repositorio
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        private readonly Context context;

        public ClienteRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

    }
}
