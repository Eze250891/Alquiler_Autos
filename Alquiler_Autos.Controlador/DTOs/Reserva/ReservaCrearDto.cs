using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Autos.Controlador.DTOs.Reserva
{
    public class ReservaCrearDto
    {
        public int IdVehiculo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
    }
}
