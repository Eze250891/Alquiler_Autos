using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Autos.Entidades
{
    public class ResultadoApi
    {
        public string Mensaje { get; set; }
        public List<Vehiculo> ListaDeVehiculos { get; set; }
        public Vehiculo Vehiculo { get; set; }
    }
}
