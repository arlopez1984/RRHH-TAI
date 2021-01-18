using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSMTA001
    {
        public ThrAbsence BuscarAusencia(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var ausencia = newcontexto.ThrAbsences.Where(d => d.AbsenceID == cod).FirstOrDefault();
                return ausencia;
            }
        }
        public void AdicionarAusenci(ThrAbsence ausencia, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var obj = newcontexto.ThrAbsences.Where(d => d.AbsenceID == ausencia.AbsenceID).FirstOrDefault();
                if (obj != null)
                {
                    obj.AbsenceID = ausencia.AbsenceID;
                    obj.AbsenceName = ausencia.AbsenceName;
                    obj.Resolucion = ausencia.Resolucion;
                }
                else
                {
                    newcontexto.AddToThrAbsences(ausencia);
                }
                newcontexto.SaveChanges();
            }

        }
        public void EliminarAusencia(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var data = newcontexto.ThrAbsences.Where(d => d.AbsenceID == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasAusencias(ThrAbsence ausencia, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                //var cantidad = newcontexto.ThrPeople.Where(d => d.Subsidykey == subsi.SubsidyKey).ToList();
                //return cantidad.Count;
                return 2;
            }
        }
        public List<ThrAbsence> Actualizar(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listdata = newcontexto.ThrAbsences.ToList();
                return listdata;
            }
        }
    }
}
