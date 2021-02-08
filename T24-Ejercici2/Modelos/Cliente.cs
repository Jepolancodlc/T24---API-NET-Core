using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T24_Ejercici1.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int DNI { get; set; }
        public DateTime fecha { get; set; }
    }
}
