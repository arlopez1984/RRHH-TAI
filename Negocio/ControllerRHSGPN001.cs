using Entidades.Rpt;
using RRHH.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSGPN001
    {
        DARHSGPN001 access = new DARHSGPN001();
        public List<clsDatosNomina> GetAllDatosNomina(int periodo)
        {           
            var result = access.DevolverAllDatosTrabajadores(periodo);
            return result;
        }
        public List<clsDatosNomina> GetAllDatosNominaXUnidad(int periodo, int unidad)
        {
           var result = access.DevolverAllDatosTrabajadoresXUnidad(periodo, unidad);
           return result;
       }
    }
}
