using Entidades.General;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSMOI001
    {
        public ThrIncidence BuscarIncidencia(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var incidencia = newcontexto.ThrIncidences.Where(d => d.IncidenceCod == cod).FirstOrDefault();
                return incidencia;
            }
        }
        public void AdicionarIncidencia(ThrIncidence incidencia)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var obj = newcontexto.ThrIncidences.Where(d => d.IncidenceCod == incidencia.IncidenceCod).FirstOrDefault();
                if (obj != null)
                {
                    obj.IncidenceID = incidencia.IncidenceID;
                    obj.IncidencePCientoPagar = incidencia.IncidencePCientoPagar;
                    obj.Resolution = incidencia.Resolution;
                }
                else
                {
                    newcontexto.AddToThrIncidences(incidencia);
                }
                newcontexto.SaveChanges();
            }

        }
        public void EliminarIncidecencia(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrIncidences.Where(d => d.IncidenceCod == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasIncidencia(ThrIncidence incidencia)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidad = newcontexto.ThrPeopleIncidences.Where(d => d.IncidenceKey == incidencia.Incidencekey).ToList();
                return cantidad.Count;                
            }
        }
        public List<ThrIncidence> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listdata = newcontexto.ThrIncidences.ToList();
                return listdata;
            }
        }
    }
}
