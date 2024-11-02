using Proyecto_Zetta.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class EditarItemTipoDTO
    {
        [Required(ErrorMessage = "El Id del cliente a modificar es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(60, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El precio de insumos es obligatorio.")]
        public long Insumos { get; set; }

        [Required(ErrorMessage = "El precio de la mano de obra es obligatoria.")]
        public long ManodeObra { get; set; }

        public long PrecioFinal { get; set; }

    }
}
