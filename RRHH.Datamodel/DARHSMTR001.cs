using Entidades.General;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSMTR001
    {
        public ThrRetention BuscarRetencion(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var movement = newcontexto.ThrRetentions.Where(d => d.RetentionCod == cod).FirstOrDefault();
                return movement;
            }

        }
        public ThrRetention BuscarRetencionName(string name)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var movement = newcontexto.ThrRetentions.Where(d => d.RetentionName == name).FirstOrDefault();
                return movement;
            }
        }
        public ThrRetention BuscarRetencionKey(int key)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var movement = newcontexto.ThrRetentions.Where(d => d.Retentionkey == key).FirstOrDefault();
                return movement;
            }
        }
        public void AdicionarRetencion(ThrRetention retencion)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var obj = newcontexto.ThrRetentions.Where(d => d.RetentionCod == retencion.RetentionCod).FirstOrDefault();
                if (obj != null)
                {
                    obj.RetentionName = retencion.RetentionName;
                    obj.RetentionDescription = retencion.RetentionDescription;
                }
                else
                {
                    newcontexto.AddToThrRetentions(retencion);
                }
                newcontexto.SaveChanges();
            }

        }
        public void EliminarRetencion(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrRetentions.Where(d => d.RetentionCod == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasRetenciones(ThrRetention retenc)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidad = newcontexto.ThrPeopleRetentions.Where(d => d.Retentionkey == retenc.Retentionkey).ToList();
                return cantidad.Count;               
            }
        }
        public List<ThrRetention> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listdata = newcontexto.ThrRetentions.ToList();
                return listdata;
            }
        }
    }
}
