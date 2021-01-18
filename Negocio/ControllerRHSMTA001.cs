using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSMTA001
    {
        DARHSMTA001 dataAccess;
        public ThrAbsence GetAusencia(string codigo)
        {
            dataAccess = new DARHSMTA001();
            var subsidy = dataAccess.BuscarAusencia(codigo);
            return subsidy;
        }
        public void AddAusencia(ThrAbsence ausencia)
        {
            dataAccess = new DARHSMTA001();
            dataAccess.AdicionarAusenci(ausencia);
        }
        public bool DeleteAusencia(string cod)
        {
            dataAccess = new DARHSMTA001();
            var ausencia = dataAccess.BuscarAusencia(cod);
            int cantdependencias = dataAccess.BuscarDependenciasAusencias(ausencia);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarAusencia(cod);
                return true;
            }
            return false;
        }
        public List<ThrAbsence> ActualizarLista()
        {
            dataAccess = new DARHSMTA001();
            var listData = dataAccess.Actualizar();
            return listData;
        }
    }
}
