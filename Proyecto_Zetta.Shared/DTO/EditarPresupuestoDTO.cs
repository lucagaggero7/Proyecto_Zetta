using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class EditarPresupuestoDTO
    {
        [Required(ErrorMessage = "El Id del cliente a modificar es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [MaxLength(12, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Estado { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio.")]
        [MaxLength(45, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Tipo { get; set; }

        public bool MaterialesIncl { get; set; }

        [Required(ErrorMessage = "El precio de insumos es obligatorio.")]
        public long Insumos { get; set; }

        [Required(ErrorMessage = "El precio de la mano de obra es obligatoria.")]
        public long ManodeObra { get; set; }

        public long PrecioFinal { get; set; }

        //claves foraneas
        public int FormadePagoId { get; set; }
        //public required FormadePago FormadePago { get; set; }
        public int ObraId { get; set; }
        //public required Obra Obra { get; set; }
        public int ItemTipoId { get; set; }
        //public required ItemTipo ItemTipo { get; set; }
    }
}
