using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class ControllerRHSMCP001
    {
        DARHSMCP001 dataAccess;
        public List<ThrCompetencia> GetCompetencias()
        {
            dataAccess = new DARHSMCP001();
            var dataCompetencias = dataAccess.BuscarCompetencias();
            return dataCompetencias;
        }
        public List<ThrCompetenciaCargo> GetCompetenciasXCargo(int cargo)
        {
            dataAccess = new DARHSMCP001();
            var dataCompetenciasXCargo = dataAccess.BuscarCompetenciasXCargo(cargo);
            return dataCompetenciasXCargo;
        }
        public void AdionarCompetencias(List<ThrCompetencia>listaCompetencias)
        {
            dataAccess = new DARHSMCP001();
            dataAccess.AdicionarCompetencias(listaCompetencias);
        }
        public ThrCompetencia BuscarCompetenciaKey(string id)
        {
            dataAccess = new DARHSMCP001();
            var competencia = dataAccess.BuscarCompetenciaKey(id);
            return competencia;
        }
        public bool EliminarCompetencia(string id)
        {
            dataAccess = new DARHSMCP001();
            var resultado = dataAccess.DeleteCompetencias(id);
            return resultado;
        }       
        public ThrCompetencia BuscarCompetencia(int key)
        {
            dataAccess = new DARHSMCP001();
            var competencia = dataAccess.BuscarCompetencia(key);
            return competencia;
        }

    }
    
}
