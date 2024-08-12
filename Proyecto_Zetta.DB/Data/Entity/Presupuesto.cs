using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.DB.Data.Entity
{
    public class Presupuesto : EntityBase
    {
        [Required(ErrorMessage = "El estado es obligatorio.")]
        [MaxLength(12, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El precio de insumos es obligatorio.")]
        [MaxLength(30, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public long Insumos { get; set; }

        [Required(ErrorMessage = "El precio de la mano de obra es obligatoria.")]
        [MaxLength(30, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public long ManodeObra { get; set; }

        [Required(ErrorMessage = "El precio final es obligatorio.")]
        [MaxLength(30, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public long PrecioFinal { get; set; }

        [MaxLength(30, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? FormadePago { get; set; }

        //clave foranea
        public int ObraId { get; set; }
        public  Obra Obra { get; set; }

    }
}
