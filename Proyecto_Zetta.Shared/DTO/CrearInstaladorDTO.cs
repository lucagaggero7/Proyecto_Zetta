﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class CrearInstaladorDTO
    {
        [Required(ErrorMessage = "El estado es obligatorio.")]
        public bool Activo { get; set; }

        [Required(ErrorMessage = "La actividad es obligatoria.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Actividad { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Dni es obligatorio.")]
        [MaxLength(12, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public int Dni { get; set; }

        [Required(ErrorMessage = "El numero de telefono es obligatorio.")]
        [MaxLength(15, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public long Telefono { get; set; }

    }
}
