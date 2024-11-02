using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.DB.Data;

namespace Proyecto_Zetta.Server.Repositorio
{
    public class FormadePagoRepositorio : Repositorio<FormadePago>, IFormadePagoRepositorio
    {
        private readonly Context context;

        public FormadePagoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

    }
}
