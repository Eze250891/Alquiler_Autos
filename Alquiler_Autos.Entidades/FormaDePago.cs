using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Autos.Entidades
{
    public class FormaDePago
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual List<Pago> Pagos { get; set; } = new List<Pago>();
    }
}
