using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Autos.Entidades
{
    public class Pago
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public int IdFormaDePago { get; set; }
        public double Monto { get; set; }

        public virtual Reserva Reserva { get; set; }
        public virtual FormaDePago FormaDePago { get; set;}

        
    }
}
