using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Autos.Entidades
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public int IdTipoCombustible { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public int CantidadPasajeros { get; set; }
        public int CantidadPuertas { get; set; }
        public int CapacidadCombustible { get; set; }
        public double PrecioAlquilerPorDia { get; set; }
        public int? CapacidadBault { get; set; }

    }
}
