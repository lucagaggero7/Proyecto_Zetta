using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.DB.Data.Entity
{
    public class Obra : EntityBase
    {
        [Required(ErrorMessage = "El estado es obligatorio.")]
        [MaxLength(12, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El tipo de obra es obligatorio.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Tipo { get; set; }

        [MaxLength(150, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? Descripcion { get; set; }

        [MaxLength(250, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? Materiales { get; set; }

        [Required(ErrorMessage = "La fecha de alta es obligatoria.")]
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        [MaxLength(45, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? AnexarServicio { get; set; }

        //claves foraneas 
        public int InstaladorId { get; set; }
        public Instalador Instalador { get; set; }
    }
}
