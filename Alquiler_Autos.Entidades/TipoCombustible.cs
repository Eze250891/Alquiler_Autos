using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Autos.Entidades
{
    public class TipoCombustible
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual List<Vehiculo> VehiculosList { get; set; } = new List<Vehiculo>();
    }
}
