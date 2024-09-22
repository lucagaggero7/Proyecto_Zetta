using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class CrearObraDTO
    {
        public string Estado { get; set; }

        public string Tipo { get; set; }

        public string? Descripcion { get; set; }

        public string? Materiales { get; set; }

        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public string? AnexarServicio { get; set; }

        public int InstaladorId { get; set; }
    }
}
