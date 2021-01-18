using Entidades.General;
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
        public ThrLicence BuscarLicencia(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var licencia = newcontexto.ThrLicences.Where(d => d.LicenceID == cod).FirstOrDefault();
                return licencia;
            }
        }
        public void AdicionarLicencia(ThrLicence licencia)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
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
        public void EliminarLicence(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrLicences.Where(d => d.LicenceID == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasLicence(ThrLicence licencia)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidad = newcontexto.ThrPeopleLicences.Where(d => d.LicenceKey == licencia.Licencekey).ToList();
                return cantidad.Count;
            }
        }
        public List<ThrLicence> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listdata = newcontexto.ThrLicences.ToList();
                return listdata;
            }
        }
    }
}
