using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sage500AppModel;
using RRHH.Datamodel;

namespace Negocio
{    
    public class ControllerRHSMTT001
    {
        
        DARHSMTT001 dataAccess;       
        public ThrWorkerType GetTipoTrabajador(string codigo)
        {
            dataAccess = new DARHSMTT001();            
            var workertype = dataAccess.BuscarTipoTrabajador(codigo);
            return workertype;
        }
        public void AddWorkerType(ThrWorkerType persona)
        {
            dataAccess = new DARHSMTT001();
            dataAccess.AdicionarTipoTrabajador(persona);
        }
        public bool DeleteWorkerType(string cod)
        {
            dataAccess = new DARHSMTT001();
            var group = dataAccess.BuscarTipoTrabajador(cod);
            int cantdependencias = dataAccess.BuscarDependenciasTipoTrabajador(group);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarTipoTrabajador(cod);
                return true;
            }
            return false;
        }
        public List<ThrWorkerType> ActualizarLista()
        {
            dataAccess = new DARHSMTT001();
            var group = dataAccess.Actualizar();
            return group;
        }
    }
    
}
