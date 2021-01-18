using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sage500AppModel;

namespace RRHH.Datamodel
{
    public class DARHSMTT001
    {
        public ThrWorkerType BuscarTipoTrabajador(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var tipotrabaj = newcontexto.ThrWorkerTypes.Where(d => d.WorkerTypeCod == cod).FirstOrDefault();
                return tipotrabaj;
            }
        }       
        public void AdicionarTipoTrabajador(ThrWorkerType workertype, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
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
        public void EliminarTipoTrabajador(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var data = newcontexto.ThrWorkerTypes.Where(d => d.WorkerTypeCod == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasTipoTrabajador(ThrWorkerType group, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var cantidad = newcontexto.ThrPeople.Where(d => d.WorkerTypekey == group.WorkerTypekey).ToList();
                return cantidad.Count;
            }
        }
        public List<ThrWorkerType> Actualizar(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listadata = newcontexto.ThrWorkerTypes.ToList();               
                return listadata;
            }
        }
    }
}
