using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSMTR001
    {
        DARHSMTR001 dataAccess = new DARHSMTR001();
        public ThrRetention GetRetencion(string codigo)
        {
            var retencion = dataAccess.BuscarRetencion(codigo);
            return retencion;
        }
        public ThrRetention GetRetencionKey(int retenkey)
        {
            var retencion = dataAccess.BuscarRetencionKey(retenkey);
            return retencion;
        }
        public ThrRetention GetRetencionName(string name)
        {
            var retencion = dataAccess.BuscarRetencionName(name);
            return retencion;
        }
        public void AddRetencion(ThrRetention retencion)
        {
            dataAccess.AdicionarRetencion(retencion);
        }
        public bool DeleteRetencion(string cod)
        {
            var retencion = dataAccess.BuscarRetencion(cod);
            int cantdependencias = dataAccess.BuscarDependenciasRetenciones(retencion);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarRetencion(cod);
                return true;
            }
            return false;
        }
        public List<ThrRetention> ActualizarLista()
        {
            var listData = dataAccess.Actualizar();
            return listData;
        }
    }
}
