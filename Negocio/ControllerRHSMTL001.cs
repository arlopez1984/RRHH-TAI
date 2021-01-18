using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSMTL001
    {
        DARHSMTL001 dataAccess;
        public ThrLicence GetLicence(string codigo)
        {
            dataAccess = new DARHSMTL001();
            var licencia = dataAccess.BuscarLicencia(codigo);
            return licencia;
        }
        public void AddLicencia(ThrLicence licencia)
        {
            dataAccess = new DARHSMTL001();
            dataAccess.AdicionarLicencia(licencia);
        }
        public bool DeleteLicencia(string cod)
        {
            dataAccess = new DARHSMTL001();
            var subsidy = dataAccess.BuscarLicencia(cod);
            int cantdependencias = dataAccess.BuscarDependenciasLicence(subsidy);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarLicence(cod);
                return true;
            }
            return false;
        }
        public List<ThrLicence> ActualizarLista()
        {
            dataAccess = new DARHSMTL001();
            var listData = dataAccess.Actualizar();
            return listData;
        }

    }
}
