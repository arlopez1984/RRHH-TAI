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
        public ThrDeduction BuscarDeduccion(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var deduccion = newcontexto.ThrDeductions.Where(d => d.DeductionCod == cod).FirstOrDefault();
                return deduccion;
            }
        }
        public ThrDeduction BuscarDeduccionKey(int deductionkey, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var deduccion = newcontexto.ThrDeductions.Where(d => d.DeductionKey == deductionkey).FirstOrDefault();
                return deduccion;
            }
        }
        public ThrDeduction BuscarDeduccionName(string name, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var deduccion = newcontexto.ThrDeductions.Where(d => d.DeductionID == name).FirstOrDefault();
                return deduccion;
            }
        }
        public void AdicionarDeducciones(ThrDeduction deduccion, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
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
        public void EliminarDeduccion(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var data = newcontexto.ThrDeductions.Where(d => d.DeductionCod  == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasDeducciones(ThrDeduction deduction, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                //var cantidad = newcontexto.ThrPeople.Where(d => d.Subsidykey == subsi.SubsidyKey).ToList();
                //return cantidad.Count;
                return 2;
            }
        }
        public List<ThrDeduction> Actualizar(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listdata = newcontexto.ThrDeductions.ToList();
                return listdata;
            }
        }
    }
}
