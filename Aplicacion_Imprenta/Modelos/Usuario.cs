﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Modelos
{
    public class Usuario
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [MinLength(6, ErrorMessage = "La clave debe tener como mínimo 6 caracteres")]
        [Required(ErrorMessage = "La clave es obligatoria")]
        public string Clave { get; set; }
        [Required(ErrorMessage = "El rol es obligatorio")]
        public string Rol { get; set; }
        public bool EstadoActivo { get; set; }
    }
}
