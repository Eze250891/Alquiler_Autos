﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Autos.Controlador.DTOs.TipoDeCombustible
{
    public class TipoDeCombustibleCrearDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Descripcion { get; set; }

    }
}
