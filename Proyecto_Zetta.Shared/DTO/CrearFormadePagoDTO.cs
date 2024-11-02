using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class CrearFormadePagoDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(30, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Nombre { get; set; }
    }
}
