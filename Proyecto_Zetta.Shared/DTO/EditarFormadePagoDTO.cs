using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class EditarFormadePagoDTO
    {
        [Required(ErrorMessage = "El Id de la forma de pago a modificar es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(30, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Nombre { get; set; }
    }
}
