using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Rpt
{
    public class clsDatosNomina
    {
        public clsDatosNomina()
        { }      

       
        public string Expediente { get; set; }

        public string Nombre { get; set; }

        public string UnidadOrganizativa { get; set; }

        public string TiempoAusencia { get; set; }

        public string TiempoLicencia { get; set; }

        public string TiempoSubsidio { get; set; }

        public string TiempoVacaciones { get; set; }
       // public string Periodo { get; set; }

    }
}
