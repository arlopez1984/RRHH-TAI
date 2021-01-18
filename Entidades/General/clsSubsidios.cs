using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.General
{
    public class clsSubsidios
    {
        public int tipoSubsidio { get; set; }
        public DateTime fechInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int Subsidioinicio { get; set; }
        public int hospitalizado { get; set; }
        public int Horas { get; set; }
    }
}
