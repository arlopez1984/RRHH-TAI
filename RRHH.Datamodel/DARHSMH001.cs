using Entidades.General;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RRHH.Datamodel
{
    public class DARHSMH001
    {
        public void AdicionarHorario(ThrShedule horario, List<clsCicloHorario> listaCiclos)
        {
            int horariokey;
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {

                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    var obj = newcontexto.ThrShedules.Where(d => d.HorarioID == horario.HorarioID).FirstOrDefault();
                   
                    if (obj != null)
                    {
                        var listCiclosXHorario = newcontexto.ThrSheduleJornadas.Where(d => d.HorarioKey == obj.Horariokey).ToList();
                        obj.HorarioID = horario.HorarioID;
                        obj.HorarioDescrip = horario.HorarioDescrip;
                        if (listCiclosXHorario.Count > 0)
                        {
                            if (listCiclosXHorario.Any())
                            {
                                for (int i = 0; i < listCiclosXHorario.Count; i++)
                                {
                                    newcontexto.DeleteObject(listCiclosXHorario[i]);
                                    newcontexto.SaveChanges();
                                }
                            }
                            for (int j = 0; j < listaCiclos.Count; j++)
                            {
                                var cicloHorario = new ThrSheduleJornada
                                {
                                    HorarioKey = obj.Horariokey,
                                    HoraInicio = listaCiclos[j].horainicio,
                                    HoraFin = listaCiclos[j].horafin,
                                    TiempoTrabajo = listaCiclos[j].tiempotrabajo,
                                    DuracionJornada = listaCiclos[j].duracionJornada,
                                    TiempoDescanso = listaCiclos[j].tiempodescanso,
                                };
                                newcontexto.AddToThrSheduleJornadas(cicloHorario);
                                newcontexto.SaveChanges();
                            }
                        }

                    }
                    else
                    {
                        var buscar = (from a in newcontexto.ThrShedules
                                      orderby a.Horariokey descending
                                      select a.Horariokey
                                       ).ToList();
                        if (buscar.Any())
                        {
                            horariokey = Convert.ToInt32(buscar.First()) + 1;
                        }
                        else
                        {
                            horariokey = 1;
                        }
                        obj = new ThrShedule();
                        obj.Horariokey = horariokey;
                        obj.HorarioID = horario.HorarioID;
                        obj.HorarioDescrip = horario.HorarioDescrip;
                        newcontexto.AddToThrShedules(obj);
                        newcontexto.SaveChanges();

                        for (int j = 0; j < listaCiclos.Count; j++)
                        {
                            var cicloJornada = new ThrSheduleJornada
                            {
                                HorarioKey = horariokey,
                                HoraInicio = listaCiclos[j].horainicio,
                                HoraFin = listaCiclos[j].horafin,
                                TiempoTrabajo = listaCiclos[j].tiempotrabajo,
                                TiempoDescanso = listaCiclos[j].tiempodescanso,
                                DuracionJornada = listaCiclos[j].duracionJornada,
                            };
                            newcontexto.AddToThrSheduleJornadas(cicloJornada);
                            newcontexto.SaveChanges();
                        }
                        //newcontexto.AddToThrShedules(obj);
                        //newcontexto.SaveChanges();
                    }
                    newcontexto.SaveChanges();
                }
                cont.Complete();
                cont.Dispose();
            }

        }
        public void EliminarHorario(string horarioID)
        {
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    var obj = newcontexto.ThrShedules.Where(d => d.HorarioID == horarioID).FirstOrDefault();
                    var listCiclosHorarios = newcontexto.ThrSheduleJornadas.Where(d => d.HorarioKey == obj.Horariokey).ToList();
                    
                    if (listCiclosHorarios.Any())
                    {
                        for (int i = 0; i < listCiclosHorarios.Count; i++)
                        {
                            newcontexto.DeleteObject(listCiclosHorarios[i]);
                            newcontexto.SaveChanges();
                        }
                    }
                    newcontexto.DeleteObject(obj);
                    newcontexto.SaveChanges();
                }
                cont.Complete();
                cont.Dispose();
            }
            
        }
        public ThrShedule BuscarHorario(int horarioKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var horario = newcontexto.ThrShedules.Where(d => d.Horariokey == horarioKey).FirstOrDefault();
                return horario;
            }
        }
        public ThrSheduleJornada BuscarJornadaHorario(int horarioKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var horariojornada = newcontexto.ThrSheduleJornadas.Where(d => d.HorarioKey == horarioKey).FirstOrDefault();
                return horariojornada;
            }
        }
        public ThrShedule BuscarHorari(string nombre)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var horario = newcontexto.ThrShedules.Where(d => d.HorarioID == nombre).FirstOrDefault();
                return horario;
            }
        }

        public int BuscarDependenciasHorarios(int horarioKey)
        {
             using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
             {
                //////var cantidad = newcontexto.ThrS.Where(d => d.PersonKey == horarioKey).ToList();
                //////return cantidad.Count;
             }
            return 2;
        }
        public List<ThrShedule> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listdata = newcontexto.ThrShedules.ToList();               
                return listdata;
            }
        }
        public List<ThrSheduleJornada> BuscarHorariosJornada(int horariokey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listHorariosJorn = newcontexto.ThrSheduleJornadas.Where(d => d.HorarioKey == horariokey).ToList();                
                return listHorariosJorn;
            }
        }
    }
}
