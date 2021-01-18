using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.Datamodel;
using Sage500AppModel;

namespace Negocio
{
    public class ControllerRHSMGE001
    {
       
        DARHSMGE001 dataAccess;
        public ControllerRHSMGE001()
        {
          
        }
        public ThrEscalaGroup GetGrupoEscala(string codigo)
        {
            dataAccess = new DARHSMGE001();
            ThrEscalaGroup escalgroup = new ThrEscalaGroup();
            escalgroup = dataAccess.BuscarEscalaGroup(codigo);
            return escalgroup;
        }
        public void AddEscalaGroup(ThrEscalaGroup Grupescala)
        {
            dataAccess = new DARHSMGE001();
            dataAccess.AdicionarEscalaGropup(Grupescala);
        }
        public bool DeleteEscalaGroup(string name)
        {
            dataAccess = new DARHSMGE001();
            ThrEscalaGroup group = dataAccess.BuscarEscalaGroup(name);                      
            int cantdependencias = dataAccess.BuscarDependenciasEscalaGroup(group);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarEscalaGroup(name);
                return true;
            }
            return false;
        }
        public List<ThrEscalaGroup> ActualizarLista()
        {
            dataAccess = new DARHSMGE001();
            List<ThrEscalaGroup> group = dataAccess.Actualizar();            
            return group;
        }

    }
}
