using Entidades.General;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSMTD001
    {
        public ThrDeduction BuscarDeduccion(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var deduccion = newcontexto.ThrDeductions.Where(d => d.DeductionCod == cod).FirstOrDefault();
                return deduccion;
            }
        }
        public ThrDeduction BuscarDeduccionKey(int deductionkey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var deduccion = newcontexto.ThrDeductions.Where(d => d.DeductionKey == deductionkey).FirstOrDefault();
                return deduccion;
            }
        }
        public ThrDeduction BuscarDeduccionName(string name)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var deduccion = newcontexto.ThrDeductions.Where(d => d.DeductionID == name).FirstOrDefault();
                return deduccion;
            }
        }
        public void AdicionarDeducciones(ThrDeduction deduccion)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var obj = newcontexto.ThrDeductions.Where(d => d.DeductionCod == deduccion.DeductionCod).FirstOrDefault();
                if (obj != null)
                {
                    obj.DeductionID = deduccion.DeductionID;
                    obj.DeductionDescrip = deduccion.DeductionDescrip;
                }
                else
                {
                    newcontexto.AddToThrDeductions(deduccion);
                }
                newcontexto.SaveChanges();
            }

        }
        public void EliminarDeduccion(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrDeductions.Where(d => d.DeductionCod  == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasDeducciones(ThrDeduction deduction)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidad = newcontexto.ThrPeopleDeduction1s.Where(d => d.DeductionKey == deduction.DeductionKey).ToList();
                return cantidad.Count;                
            }
        }
        public List<ThrDeduction> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listdata = newcontexto.ThrDeductions.ToList();
                return listdata;
            }
        }
    }
}
