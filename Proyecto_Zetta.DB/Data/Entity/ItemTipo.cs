using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Zetta.DB.Data.Entity
{
    public class ItemTipo : EntityBase
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(60, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El precio de insumos es obligatorio.")]
        public long Insumos { get; set; }

        [Required(ErrorMessage = "El precio de la mano de obra es obligatoria.")]
        public long ManodeObra { get; set; }

        public long PrecioFinal { get; set; }

        public ICollection<ItemTipoMaterial> ItemTipoMateriales { get; set; }

        public ItemTipo()
        {
            ItemTipoMateriales = new List<ItemTipoMaterial>();
        }
    }
}
