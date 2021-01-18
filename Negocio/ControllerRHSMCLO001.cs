using RRHH.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sage500AppModel;

namespace Negocio
{
    public class ControllerRHSMCLO001
    {
        DARHSMCLO001 dataAccess;
        public ControllerRHSMCLO001()
        {
        }
        public ThrOcupationClasification GetClasificacionOcupacion(string name)
        {
            dataAccess = new DARHSMCLO001();
            var clasfi = dataAccess.BuscarClasificacionOcupacional(name);
            return clasfi;
        }
        public void AddClasificacionOcupacional(ThrOcupationClasification clasfi)
        {
            dataAccess = new DARHSMCLO001();
            dataAccess.AdicionarClasificacionOcupacional(clasfi);            
            
        }
        public bool DeleteClasificacionOcupacional(string name)
        {
            dataAccess = new DARHSMCLO001();          
            int cantdependencias = dataAccess.BuscarDependenciasClasificac(name);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarClasificacionOcupacional(name);
                return true;
            }
            return false;
        }
        public List<ThrOcupationClasification> ActualizarLista()
        {
            dataAccess = new DARHSMCLO001();
            var listClasf = dataAccess.Actualizar();
            return listClasf;
        }

    }
}
