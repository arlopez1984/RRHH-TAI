using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.General
{
    public class clsTiempoTrabajo
    {
        public int PersonKey { get; set; }
        public decimal horasTabajadas { get; set; }
        public decimal horasExtras { get; set; }
        public int diasFeriados { get; set; }
        public int periodoActivo { get; set; }
        public List<clsHorasCondiciones> listaCondicionesHoras { get; set; }
    }
}
