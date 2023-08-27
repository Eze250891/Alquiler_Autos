using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Autos.Controlador.DTOs.Pago
{
    public class PagoCrearDto
    {
        public int IdReserva { get; set; }
        public int IdFormaDePago { get; set; }
        public double Monto { get; set; }
    }
}
