using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.Datamodel;
using Entidades.General;

namespace Negocio
{
    public class ControllerRHSMCL001
    {
        DARHSMCL001 dataAccess = new DARHSMCL001();
        public List<ThrLaboralCondition> GetCondicionesLaborales()
        {
            var dataCompetencias = dataAccess.BuscarCondicioneslaborales();
            return dataCompetencias;
        }

        public clsCondicionLaboral GetUnidadOrganizativ(string codigo)
        {
            var objcond = new clsCondicionLaboral();
            var condLab = dataAccess.BuscarConditionlaboralKey(codigo);
            objcond.codicionLaboralKey = condLab.ConditionLabkey;
            objcond.codicionLaboralID = condLab.ConditionlabID;
            objcond.codicionLaboralDescrip = condLab.ConditionLabDescription;            
            return objcond;
        }
        public List<ThrPositionConditionLab> GetCondocionesLaboralesXCargo(int cargo)
        {
            var ConditcionesXCargo = dataAccess.BuscarCondocionesLaboralesXCargo(cargo);
            return ConditcionesXCargo;
        }
        public void AdionarCondicionLaboral(List<ThrLaboralCondition> listaCondiciones)
        {
            dataAccess.AdicionarCondicionLaboral(listaCondiciones);
        }
        public ThrLaboralCondition BuscarConditionlaboralKey(string id)
        {
            var condicionLab = dataAccess.BuscarConditionlaboralKey(id);
            return condicionLab;
        }
        public bool EliminarCondicion(string id)
        {
            var resultado = dataAccess.DeleteCondicionesLaborales(id);
            return resultado;
        }
        public ThrLaboralCondition BuscarConditionLab(int key)
        {
            var condition = dataAccess.BuscarConditionlaboral(key);
            return condition;
        }
    }
}
