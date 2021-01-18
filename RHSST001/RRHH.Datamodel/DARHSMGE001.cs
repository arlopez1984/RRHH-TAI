using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSMGE001
    {
        public DARHSMGE001()
        {
            
        }
        public ThrEscalaGroup BuscarEscalaGroup(string nom, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var groupescala = newcontexto.ThrEscalaGroups.Where(d => d.EscalaGroupID == nom).FirstOrDefault();
                return groupescala;
            }

        }
        public void AdicionarEscalaGropup(ThrEscalaGroup group, string conexion)
        {
            try
            {
                using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
                {
                    var obj = newcontexto.ThrEscalaGroups.Where(d => d.EscalaGroupID == group.EscalaGroupID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.EscalaGroupID = group.EscalaGroupID;
                        obj.EscalaSalario = group.EscalaSalario;
                        obj.Descripcion = group.Descripcion;
                    }
                    else
                    {
                        newcontexto.AddToThrEscalaGroups(group);
                    }
                    newcontexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }          

        }
        public void EliminarEscalaGroup(string name, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrEscalaGroups.Where(d => d.EscalaGroupID == name).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();               
            }
        }
        public int BuscarDependenciasEscalaGroup(ThrEscalaGroup group, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
              var cantidad =  newcontexto.ThrPositions.Where(d => d.EscalaGroupkey == group.EscalaGroupkey).ToList();
                return cantidad.Count;
            }          
           
        }
        public List<ThrEscalaGroup> Actualizar(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrEscalaGroups.OrderBy(d => d.EscalaGroupkey).ToList();                
                return data;
            }
        }
    }
}
