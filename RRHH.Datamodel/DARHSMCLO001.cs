using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.General;
using Sage500AppModel;

namespace RRHH.Datamodel
{
    public class DARHSMCLO001
    {
        public DARHSMCLO001()
        {

        }
        public ThrOcupationClasification BuscarClasificacionOcupacional(string nom)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {               
                var clasOcup = newcontexto.ThrOcupationClasifications.Where(d => d.SpecialtyID == nom).FirstOrDefault();
                return clasOcup;
            }

        }
        public void AdicionarClasificacionOcupacional(ThrOcupationClasification clasfOcup)
        {
            try
            {
                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    var obj = newcontexto.ThrOcupationClasifications.Where(d => d.SpecialtyID == clasfOcup.SpecialtyID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.SpecialtyID = clasfOcup.SpecialtyID;
                        obj.Descripcion = clasfOcup.Descripcion;
                    }
                    else
                    {
                        newcontexto.AddToThrOcupationClasifications(clasfOcup);
                    }
                    newcontexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }        
        public void EliminarClasificacionOcupacional(string nameID)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var objdelete = newcontexto.ThrOcupationClasifications.Where(d => d.SpecialtyID == nameID).FirstOrDefault();
                newcontexto.DeleteObject(objdelete);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasClasificac(string nameID)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var clasf = newcontexto.ThrOcupationClasifications.Where(d => d.SpecialtyID == nameID).FirstOrDefault();
                var cantidad = newcontexto.ThrPeople.Where(d => d.OcupationalClasificacionKey == clasf.OcupationClasificationkey).ToList();
                return cantidad.Count;
            }

        }
        public List<ThrOcupationClasification> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrOcupationClasifications.ToList();
                return data;
            }
        }
    }
}
