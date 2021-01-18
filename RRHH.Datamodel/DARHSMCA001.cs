using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.General;
using Sage500AppModel;

namespace RRHH.Datamodel
{
    public class DARHSMCA001
    {
        public ThrAnormalCondition BuscarCondicionAnormal(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrAnormalCondition condanormal = new ThrAnormalCondition();
                condanormal = newcontexto.ThrAnormalConditions.Where(d => d.AnormalName == cod).FirstOrDefault();
                return condanormal;
            }
        }
        public ThrAnormalCondition BuscarCondicionAnormalID(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrAnormalCondition condanormal = new ThrAnormalCondition();
                condanormal = newcontexto.ThrAnormalConditions.Where(d => d.AnormalCondID == cod).FirstOrDefault();
                return condanormal;
            }
        }
        public void AdicionarCondicionAnormal(ThrAnormalCondition condAnormal)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrAnormalCondition obj = new ThrAnormalCondition();
                obj = newcontexto.ThrAnormalConditions.Where(d => d.AnormalCondID == condAnormal.AnormalCondID).FirstOrDefault();
                if (obj != null)
                {
                    obj.AnormalCondID = condAnormal.AnormalCondID;
                    obj.AnormalName = condAnormal.AnormalName;
                    obj.AnormalTarifa = condAnormal.AnormalTarifa;
                    obj.AnormalResolution = condAnormal.AnormalResolution;
                }
                else
                {
                    newcontexto.AddToThrAnormalConditions(condAnormal);
                }
                newcontexto.SaveChanges();
            }

        }
        public void EliminarCondicionAnormal(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrAnormalCondition data;
                data = newcontexto.ThrAnormalConditions.Where(d => d.AnormalCondID == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasCondicionesAnormales(ThrAnormalCondition group)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidad = newcontexto.ThrAnormalCondPositions.Where(d => d.AnormalConditionKey == group.AnormalConditionkey).Count();
                return cantidad; 
            }
        }
        public List<ThrAnormalCondition> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrAnormalConditions.OrderBy(d => d.AnormalConditionkey).ToList();
                List<ThrAnormalCondition> listaObj = data;
                return listaObj;
            }
        }
        public ThrAnormalCondition BuscarCondicionAnormalKey(int anormalKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrAnormalCondition condanormal = new ThrAnormalCondition();
                condanormal = newcontexto.ThrAnormalConditions.Where(d => d.AnormalConditionkey == anormalKey).FirstOrDefault();
                return condanormal;
            }
        }
        public List<ThrAnormalCondPosition> BuscarAnormalCondPosition(int PositionKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listaCondicionesAnormalesCargo = newcontexto.ThrAnormalCondPositions.Where(d => d.PositionKey == PositionKey).ToList();
                return listaCondicionesAnormalesCargo;
            }

        }
    }
}
