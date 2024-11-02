using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.DB.Data.Entity
{
    public class Material : EntityBase
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(30, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "La unidad de medida es obligatoria.")]
        [MaxLength(30, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string UnidadMedida { get; set; }

        [Required(ErrorMessage = "El precio del material es obligatorio.")]
        public long Precio { get; set; }

        public ICollection<ItemTipoMaterial> ItemTipoMateriales { get; set; }

        public Material()
        {
            ItemTipoMateriales = new List<ItemTipoMaterial>();
        }
    }
}
