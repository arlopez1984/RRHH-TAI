using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSMTL001
    {
        public ThrLicence BuscarLicencia(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var licencia = newcontexto.ThrLicences.Where(d => d.LicenceID == cod).FirstOrDefault();
                return licencia;
            }
        }
        public void AdicionarLicencia(ThrLicence licencia, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var obj = newcontexto.ThrLicences.Where(d => d.LicenceID == licencia.LicenceID).FirstOrDefault();
                if (obj != null)
                {
                    obj.LicenceID = licencia.LicenceID;
                    obj.LicenceName = licencia.LicenceName;
                    obj.AcumulaVacaciones = licencia.AcumulaVacaciones;
                    obj.Resolution = licencia.Resolution;
                }
                else
                {
                    newcontexto.AddToThrLicences(licencia);
                }
                newcontexto.SaveChanges();
            }

        }
        public void EliminarLicence(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var data = newcontexto.ThrLicences.Where(d => d.LicenceID == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasLicence(ThrLicence licencia, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                //var cantidad = newcontexto.ThrPeople.Where(d => d.Subsidykey == subsi.SubsidyKey).ToList();
                //return cantidad.Count;
                return 2;
            }
        }
        public List<ThrLicence> Actualizar(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listdata = newcontexto.ThrLicences.ToList();
                return listdata;
            }
        }
    }
}
