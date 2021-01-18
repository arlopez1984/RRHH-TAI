using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sage500AppModel;

namespace RRHH.Datamodel
{
    public class DARHSMCLO001
    {
        public DARHSMCLO001()
        {

        }
        public ThrOcupationClasification BuscarClasificacionOcupacional(string nom, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {               
                var clasOcup = newcontexto.ThrOcupationClasifications.Where(d => d.SpecialtyID == nom).FirstOrDefault();
                return clasOcup;
            }

        }
        public void AdicionarClasificacionOcupacional(ThrOcupationClasification clasfOcup, string conexion)
        {
            try
            {
                using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
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
            catch (Exception ex)
            {
                throw;
            }

        }        
        public void EliminarClasificacionOcupacional(string nameID, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var objdelete = newcontexto.ThrOcupationClasifications.Where(d => d.SpecialtyID == nameID).FirstOrDefault();
                newcontexto.DeleteObject(objdelete);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasClasificac(string nameID, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var clasf = newcontexto.ThrOcupationClasifications.Where(d => d.SpecialtyID == nameID).FirstOrDefault();
                var cantidad = newcontexto.ThrPeople.Where(d => d.OcupationalClasificacionKey == clasf.OcupationClasificationkey).ToList();
                return cantidad.Count;
            }

        }
        public List<ThrOcupationClasification> Actualizar(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrOcupationClasifications.ToList();
                return data;
            }
        }
    }
}
