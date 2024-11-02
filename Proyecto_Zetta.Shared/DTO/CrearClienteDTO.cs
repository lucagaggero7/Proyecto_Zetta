using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class CrearClienteDTO
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Apellido { get; set; }

        [Required(ErrorMessage = "La direccion es obligatoria.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Direccion { get; set; }

        [Required(ErrorMessage = "La localidad es obligatoria.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Localidad { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio.")]
        public long Telefono { get; set; }

        [MaxLength(30, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? Mail { get; set; }

        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? Descripcion { get; set; }
    }
}
