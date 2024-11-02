using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class CrearInstaladorDTO
    {
        public bool Activo { get; set; }

        [Required(ErrorMessage = "La actividad es obligatoria.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Actividad { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Apellido { get; set; }

        [Required(ErrorMessage = "El Dni es obligatorio.")]
        public int Dni { get; set; }

        [Required(ErrorMessage = "El numero de telefono es obligatorio.")]
        public long Telefono { get; set; }

    }
}
