using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.General;
using Sage500AppModel;

namespace RRHH.Datamodel
{
    public class DARHSMTT001
    {
        public ThrWorkerType BuscarTipoTrabajador(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var tipotrabaj = newcontexto.ThrWorkerTypes.Where(d => d.WorkerTypeCod == cod).FirstOrDefault();
                return tipotrabaj;
            }
        }       
        public void AdicionarTipoTrabajador(ThrWorkerType workertype)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {               
                var obj = newcontexto.ThrWorkerTypes.Where(d => d.WorkerTypeCod == workertype.WorkerTypeCod).FirstOrDefault();
                if (obj != null)
                {
                    obj.WorkerTypeID = workertype.WorkerTypeID;
                    obj.WorkerTypeDescription = workertype.WorkerTypeDescription;                   
                }
                else
                {
                    newcontexto.AddToThrWorkerTypes(workertype);
                }
                newcontexto.SaveChanges();
            }

        }
        public void EliminarTipoTrabajador(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrWorkerTypes.Where(d => d.WorkerTypeCod == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasTipoTrabajador(ThrWorkerType group)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidad = newcontexto.ThrPeople.Where(d => d.WorkerTypekey == group.WorkerTypekey).ToList();
                return cantidad.Count;
            }
        }
        public List<ThrWorkerType> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listadata = newcontexto.ThrWorkerTypes.ToList();               
                return listadata;
            }
        }
    }
}
