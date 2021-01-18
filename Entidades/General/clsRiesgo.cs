using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.General
{
    public class clsRiesgo
    {
        public clsRiesgo()
        {
        }
        public int riesgokey { get; set; }
        public int tipo { get; set; }
        public string nombreRiesgo { get; set; }
        public string descripcionRiesgo { get; set; }
        public int nivel { get; set; }
    }
}
