using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.General
{
    public class clsCompetencias
    {
        public clsCompetencias()
        {
        }
        public int competenciakey { get; set; }
        public int tipo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool requerido { get; set; }
        public int niveles { get; set; }

    }
}
