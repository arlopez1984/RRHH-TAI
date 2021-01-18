using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.Datamodel;
using Sage500AppModel;

namespace Negocio
{ 
    public class ControllerRHSMTS001
    {
        DARHSMTS001 dataAccess;
        public ThrSubsidy GetSubsidy(string codigo)
        {
            dataAccess = new DARHSMTS001();
            var subsidy = dataAccess.BuscarSubsidio(codigo);
            return subsidy;
        }
        public void AddSubsidio(ThrSubsidy subsidy)
        {
            dataAccess = new DARHSMTS001();
            dataAccess.AdicionarSubsidy(subsidy);
        }
        public bool DeleteSubsidy(string cod)
        {
            dataAccess = new DARHSMTS001();
            var subsidy = dataAccess.BuscarSubsidio(cod);
            int cantdependencias = dataAccess.BuscarDependenciasSubsidio(subsidy);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarSubsidio(cod);
                return true;
            }
            return false;
        }
        public List<ThrSubsidy> ActualizarLista()
        {
            dataAccess = new DARHSMTS001();
            var listData = dataAccess.Actualizar();
            return listData;
        }
    }
}
