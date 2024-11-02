using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.DB.Data.Entity
{
    public class ItemTipoMaterial
    {
        //claves foraneas
        public int ItemTipoId { get; set; }
        public required ItemTipo ItemTipo { get; set; }

        public int MaterialId { get; set; }
        public required Material Material { get; set; }
    }
}
