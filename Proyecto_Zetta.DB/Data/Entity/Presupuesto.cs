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

        [Required(ErrorMessage = "El tipo es obligatorio.")]
        [MaxLength(45, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Tipo { get; set; }

        public bool MaterialesIncl { get; set; }

        [Required(ErrorMessage = "El precio de insumos es obligatorio.")]
        public long Insumos { get; set; }

        [Required(ErrorMessage = "El precio de la mano de obra es obligatoria.")]
        public long ManodeObra { get; set; }

        public long PrecioFinal { get; set; }

        //claves foraneas
        public int FormadePagoId { get; set; }
        public FormadePago FormadePago { get; set; }
        public int ObraId { get; set; }
        public Obra Obra { get; set; }
        public int ItemTipoId { get; set; }
        public ItemTipo ItemTipo { get; set; }
        

    }
}
