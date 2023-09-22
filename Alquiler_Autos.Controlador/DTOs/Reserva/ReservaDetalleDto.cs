using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Autos.Controlador.DTOs.Reserva
{
    public class ReservaDetalleDto : ReservaCrearDto
    {
        public int Id { get; set; }

        public double Total { get; set; }
    }
}
