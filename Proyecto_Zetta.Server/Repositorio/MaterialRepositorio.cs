using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.DB.Data;

namespace Proyecto_Zetta.Server.Repositorio
{
    public class MaterialRepositorio : Repositorio<Material>, IMaterialRepositorio
    {
        private readonly Context context;

        public MaterialRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

    }
}
