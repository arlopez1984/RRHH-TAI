using Entidades.General;
using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSMR001
    {
        DARHSMR001 dataAccess;
        public List<ThrRisk> GetRiesgos()
        {
            dataAccess = new DARHSMR001();
            var riesgos = dataAccess.BuscarRiesgos();
            return riesgos;
        }
        public clsRiesgo GetRiesg(string idriesgo)
        {
            dataAccess = new DARHSMR001();
            var riesgo = new clsRiesgo();
            var Objriesgo = dataAccess.BuscarRiesgoKey(idriesgo);
            riesgo.riesgokey = Objriesgo.RiskKey;
            riesgo.nombreRiesgo = Objriesgo.RiskID;
            riesgo.descripcionRiesgo = Objriesgo.RiskDescription;
            riesgo.tipo = Objriesgo.RiskType;
            return riesgo;
        }

        public List<ThrPositionRisk> GetRiesgosXCargo(int cargo)
        {
            dataAccess = new DARHSMR001();
            var dataRiesgosXCargo = dataAccess.BuscarRiesgosXCargo(cargo);
            return dataRiesgosXCargo;
        }
        public void AdionarRiesgos(List<ThrRisk> listaRiesgos)
        {
            dataAccess = new DARHSMR001();
            dataAccess.AdicionarRiesgos(listaRiesgos);
        }
        public ThrRisk BuscarRiesgoKey(string id)
        {
            dataAccess = new DARHSMR001();
            var riesgos = dataAccess.BuscarRiesgoKey(id);
            return riesgos;
        }
        public ThrRisk BuscarRiesgo(int key)
        {
            dataAccess = new DARHSMR001();
            var riesgo = dataAccess.BuscarRiesgo(key);
            return riesgo;
        }
        public bool EliminarRiesgo(string id)
        {
            var resultado = dataAccess.DeleteRiesgosLaborales(id);
            return resultado;
        }
    }
}
