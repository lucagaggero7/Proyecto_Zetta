using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class EditarObraDTO
    {
        [Required(ErrorMessage = "El Id del contrato a modificar es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [MaxLength(12, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Estado { get; set; }

        [MaxLength(150, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de alta es obligatoria.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaAlta { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? FechaBaja { get; set; }

        [MaxLength(45, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? AnexarServicio { get; set; }

        //claves foraneas 
        public int InstaladorId { get; set; }
        //public Instalador Instalador { get; set; }
        public int ClienteId { get; set; }
        //public Cliente Cliente { get; set; } 

    }
}
