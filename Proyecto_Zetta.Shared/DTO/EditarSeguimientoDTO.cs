using Proyecto_Zetta.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class EditarSeguimientoDTO
    {
        [Required(ErrorMessage = "El Id del seguimiento a modificar es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [MaxLength(12, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Estado { get; set; }

        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? Descripcion { get; set; }

        public bool MantenimientoIncl { get; set; }

        //clave foranea
        public int ObraId { get; set; }
        //public required Obra Obra { get; set; }
    }
}
