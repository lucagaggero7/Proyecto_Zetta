using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.DB.Data.Entity
{
    public class Seguimiento : EntityBase
    {
        [Required(ErrorMessage = "El estado es obligatorio.")]
        [MaxLength(12, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Estado { get; set; }

        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El mantenimiento es obligatorio.")]
        public bool Mantenimiento_SN { get; set; }

        //clave foranea
        public int ObraId { get; set; }
        public Obra Obra { get; set; }

        public int MantenimientoId { get; set; }
        public Mantenimiento Mantenimiento { get; set; }
    }
}
