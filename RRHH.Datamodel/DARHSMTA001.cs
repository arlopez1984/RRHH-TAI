using Entidades.General;
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
        public ThrAbsence BuscarAusencia(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var ausencia = newcontexto.ThrAbsences.Where(d => d.AbsenceID == cod).FirstOrDefault();
                return ausencia;
            }
        }
        public ThrAbsence BuscarAusenciaKey(int codkey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var ausencia = newcontexto.ThrAbsences.Where(d => d.Absencekey == codkey).FirstOrDefault();
                return ausencia;
            }
        }
        public void AdicionarAusenci(ThrAbsence ausencia)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
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
        public void EliminarAusencia(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrAbsences.Where(d => d.AbsenceID == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasAusencias(ThrAbsence ausencia)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidad = newcontexto.ThrPeopleAbsences.Where(d => d.AbsenceKey == ausencia.Absencekey).ToList();
                return cantidad.Count;                
            }
        }
        public List<ThrAbsence> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listdata = newcontexto.ThrAbsences.ToList();
                return listdata;
            }
        }
    }
}
