using Entidades.General;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSMTS001
    {
        public ThrSubsidy BuscarSubsidio(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {              
                var subsidy = newcontexto.ThrSubsidies.Where(d => d.SubsideID == cod).FirstOrDefault();
                return subsidy;
            }
        }
        public void AdicionarSubsidy(ThrSubsidy subsidy)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {                
                var obj = newcontexto.ThrSubsidies.Where(d => d.SubsideID == subsidy.SubsideID).FirstOrDefault();
                if (obj != null)
                {
                    obj.SubsideID = subsidy.SubsideID;
                    obj.SubsidyName = subsidy.SubsidyName;
                    obj.PorCientoPagar = subsidy.PorCientoPagar;
                    obj.Resolucion = subsidy.Resolucion;
                }
                else
                {
                    newcontexto.AddToThrSubsidies(subsidy);
                }
                newcontexto.SaveChanges();
            }

        }
        public void EliminarSubsidio(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrSubsidies.Where(d => d.SubsideID == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasSubsidio(ThrSubsidy subsi)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidad = newcontexto.ThrPeopleSubsidies.Where(d => d.SubsidyKey == subsi.SubsidyKey).ToList();
                return cantidad.Count;                
            }
        }
        public List<ThrSubsidy> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listdata = newcontexto.ThrSubsidies.ToList();            
                return listdata;
            }
        }

    }
}
