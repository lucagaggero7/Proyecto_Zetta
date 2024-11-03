﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class EditarMantenimientoDTO
    {
        [Required(ErrorMessage = "El Id del seguimiento a modificar es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [MaxLength(12, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Estado { get; set; }

        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? Descripcion { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? FechaVisita { get; set; }

        //claves foraneas
        public int PresupuestoId { get; set; }
        //public required Presupuesto Presupuesto { get; set; }

        public int SeguimientoId { get; set; }
        //public required Seguimiento Seguimiento { get; set; }
    }
}
