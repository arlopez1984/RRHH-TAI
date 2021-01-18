using Entidades.Rpt;
using RRHH.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSRO001
    {
        DARHSRO001 access = new DARHSRO001();
        public List<clsLicencias> GetAllLicenciasXPeriodo(int periodo)
        {
            var result = access.BuscarLicenciasXPeriodo(periodo);
            return result;
        }
        public List<clsAusencias> GetAllAusenciasXPeriodo(int periodo)
        {
            var result = access.BuscarAusenciasXPeriodo(periodo);
            return result;
        }
        public List<clsSubsidios> GetAllSubsidiosXPeriodo(int periodo)
        {
            var result = access.BuscarSubsidiosXPeriodo(periodo);
            return result;
        }
        public List<clsVacaciones> GetAllVacacionesXPeriodo(int periodo)
        {
            var result = access.BuscarVacacionesXPeriodo(periodo);
            return result;
        }
        public List<clsSubsidios> GetAllCertificadosAccidentesXPeriodo(int periodo)
        {
            var result = access.BuscarSubsidiosCertificadosAccidentesXPeriodo(periodo);
            return result;
        }
    }
}
