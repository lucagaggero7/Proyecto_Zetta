using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.DB.Data.Entity
{
    public class Forma_de_Pago : EntityBase
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(30, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Nombre { get; set; }
    }
}
