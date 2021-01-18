using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Rpt
{
    public class clsAusencias
    {
        public clsAusencias()
        { }           
        public string Expediente { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
       // public string UnidadOrganizativa { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }       
        public string HorasDisfrutadas { get; set; }
        //public string Periodo { get; set; }

    }
}
