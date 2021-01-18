using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.General
{
    public class clsCondicionLaboral
    {
        public clsCondicionLaboral()
        {
        }
        public int codicionLaboralKey { get; set; }
        public int tipo { get; set; }
        public string codicionLaboralID { get; set; }
        public string codicionLaboralDescrip { get; set; }
        public bool requerido { get; set; }
        public int niveles { get; set; }
    }
}
