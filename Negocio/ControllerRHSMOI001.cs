using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSMOI001
    {
        DARHSMOI001 dataAccess;
        public ThrIncidence GetIncidencia(string name)
        {
            dataAccess = new DARHSMOI001();
            var incidencia = dataAccess.BuscarIncidencia(name);
            return incidencia;
        }
        public void AddIncidencia(ThrIncidence incidencia)
        {
            dataAccess = new DARHSMOI001();
            dataAccess.AdicionarIncidencia(incidencia);
        }
        public bool DeleteIncidencia(string name)
        {
            dataAccess = new DARHSMOI001();
            var incidencia = dataAccess.BuscarIncidencia(name);
            int cantdependencias = dataAccess.BuscarDependenciasIncidencia(incidencia);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarIncidecencia(name);
                return true;
            }
            return false;
        }
        public List<ThrIncidence> ActualizarLista()
        {
            dataAccess = new DARHSMOI001();
            var listData = dataAccess.Actualizar();
            return listData;
        }
    }
}
