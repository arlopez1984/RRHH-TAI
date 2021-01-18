using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.General
{
    public class clsAusencia
    {
        public int tipoAusencia { get; set; }
        public DateTime fechInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string HorasDisfrutadas { get; set; }
    }
}
