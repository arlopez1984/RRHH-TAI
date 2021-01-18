using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.General;

namespace Negocio
{
    public class ControllerRHSMCA001
    {
        DARHSMCA001 dataAccess;
        public ThrAnormalCondition GetAnormalCondition(string codigo)
        {
            dataAccess = new DARHSMCA001();
            ThrAnormalCondition anormalCond = new ThrAnormalCondition();
            anormalCond = dataAccess.BuscarCondicionAnormal(codigo);
            return anormalCond;
        }
        public ThrAnormalCondition GetAnormalConditionXID(string codigo)
        {
            dataAccess = new DARHSMCA001();
            ThrAnormalCondition anormalCond = new ThrAnormalCondition();
            anormalCond = dataAccess.BuscarCondicionAnormalID(codigo);
            return anormalCond;
        }
        public ThrAnormalCondition GetAnormalCondicion(int key)
        {
            dataAccess = new DARHSMCA001();
            ThrAnormalCondition anormalCond = new ThrAnormalCondition();
            anormalCond = dataAccess.BuscarCondicionAnormalKey(key);
            return anormalCond;
        }
        public clsCondicionesAnormales GetAnormalCondi(string idCondicion)
        {
            dataAccess = new DARHSMCA001();
            var condAnormal = new clsCondicionesAnormales();
            var anormalCond = dataAccess.BuscarCondicionAnormal(idCondicion);
            condAnormal.AnormalConditionkey = anormalCond.AnormalConditionkey;
            condAnormal.anormalconditionID = anormalCond.AnormalCondID;
            condAnormal.amormalname = anormalCond.AnormalName;
            condAnormal.anormaltarifa = Convert.ToDecimal(anormalCond.AnormalTarifa);
            condAnormal.anormalresolution = anormalCond.AnormalResolution;
            return condAnormal; 
        }
        public void AddAnormalCondition(ThrAnormalCondition Anormalcond)
        {
            dataAccess = new DARHSMCA001();
            dataAccess.AdicionarCondicionAnormal(Anormalcond);
        }
        public bool DeleteAnormalCondition(string cod)
        {
            dataAccess = new DARHSMCA001();
            ThrAnormalCondition anormalCond = dataAccess.BuscarCondicionAnormalID(cod);
            int cantdependencias = dataAccess.BuscarDependenciasCondicionesAnormales(anormalCond);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarCondicionAnormal(cod);
                return true;
            }
            return false;
        }
        public List<ThrAnormalCondition> ActualizarLista()
        {
            dataAccess = new DARHSMCA001();
            List<ThrAnormalCondition> listanormalCond = dataAccess.Actualizar();
            return listanormalCond;
        }

    }
}
