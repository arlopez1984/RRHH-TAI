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
        public ThrIncidence BuscarIncidencia(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var incidencia = newcontexto.ThrIncidences.Where(d => d.IncidenceCod == cod).FirstOrDefault();
                return incidencia;
            }
        }
        public void AdicionarIncidencia(ThrIncidence incidencia, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
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
        public void EliminarIncidecencia(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var data = newcontexto.ThrIncidences.Where(d => d.IncidenceCod == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasIncidencia(ThrIncidence incidencia, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                //var cantidad = newcontexto.ThrPeople.Where(d => d.Subsidykey == subsi.SubsidyKey).ToList();
                //return cantidad.Count;
                return 2;
            }
        }
        public List<ThrIncidence> Actualizar(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listdata = newcontexto.ThrIncidences.ToList();
                return listdata;
            }
        }
    }
}
