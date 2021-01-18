
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.General
{
    public class clsHorario
    {
        public int horarioKey { get; set; }
        public string nombrehorario { get; set; }
        public string descripcionhorario { get; set; } 
        public List<clsCicloHorario> listaCiclos { get; set; }
    }
}
