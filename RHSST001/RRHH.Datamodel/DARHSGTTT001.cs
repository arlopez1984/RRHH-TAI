using Entidades.RHSGTTT001;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RRHH.Datamodel
{
    public class DARHSGTTT001
    {
        public void AdicionarTiempoTrabajado(ThrWorkedTime worktime, List<clsHorasCondiciones> listadoCondicionesHoras, string conex)
        {
            int worktimekey;
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                using (var newcontexto = new Sage500AppEntities(conex.ToString()))
                {
                    var objworktime = newcontexto.ThrWorkedTimes.Where(d => d.Periodkey == worktime.Periodkey && d.PersonKey == worktime.PersonKey).FirstOrDefault();

                    if (objworktime != null)
                    {
                        var listaCondicionAnormHours = newcontexto.ThrWorkedTimeAnormalConditions.Where(d => d.WorkedTimeKey == objworktime.WorkedTimeKey).ToList();

                        objworktime.Periodkey = worktime.Periodkey;
                        objworktime.PersonKey = worktime.PersonKey;
                        objworktime.WorkedHours = worktime.WorkedHours;
                        objworktime.ExtraHours = worktime.ExtraHours;
                        objworktime.HolidayDays = worktime.HolidayDays;
                        newcontexto.SaveChanges();

                        if (listadoCondicionesHoras.Any())
                        {
                            if (listaCondicionAnormHours.Any())
                            {
                                for (int i = 0; i < listaCondicionAnormHours.Count; i++)
                                {
                                    newcontexto.DeleteObject(listaCondicionAnormHours[i]);
                                    newcontexto.SaveChanges();
                                }
                            }
                            for (int j = 0; j < listadoCondicionesHoras.Count; j++)
                            {
                                var conditionAnormalHours = new ThrWorkedTimeAnormalCondition
                                {
                                    WorkedTimeKey = objworktime.WorkedTimeKey,
                                    AnormalConditionkey = listadoCondicionesHoras[j].conditionkey,
                                    WorkAnormalHours = listadoCondicionesHoras[j].CantHoras,
                                };
                                newcontexto.AddToThrWorkedTimeAnormalConditions(conditionAnormalHours);
                                newcontexto.SaveChanges();
                            }
                        }

                    }
                    else
                    {
                        var buscar = (from a in newcontexto.ThrWorkedTimes
                                      orderby a.WorkedTimeKey descending
                                      select a.WorkedTimeKey
                                        ).ToList();
                        if (buscar.Any())
                        {
                            worktimekey = Convert.ToInt32(buscar.First()) + 1;
                        }
                        else
                        {
                            worktimekey = 1;
                        }
                        objworktime = new ThrWorkedTime();
                        objworktime.Periodkey = worktime.Periodkey;
                        objworktime.PersonKey = worktime.PersonKey;
                        objworktime.WorkedHours = worktime.WorkedHours;
                        objworktime.ExtraHours = worktime.ExtraHours;
                        objworktime.HolidayDays = worktime.HolidayDays;
                        newcontexto.AddToThrWorkedTimes(objworktime);
                        newcontexto.SaveChanges();
                        for (int j = 0; j < listadoCondicionesHoras.Count; j++)
                        {
                            var conditionAnormalHours = new ThrWorkedTimeAnormalCondition
                            {
                                WorkedTimeKey = objworktime.WorkedTimeKey,
                                AnormalConditionkey = listadoCondicionesHoras[j].conditionkey,
                                WorkAnormalHours = listadoCondicionesHoras[j].CantHoras,
                            };
                            newcontexto.AddToThrWorkedTimeAnormalConditions(conditionAnormalHours);
                            newcontexto.SaveChanges();
                        }
                    }
                }
                cont.Complete();
                cont.Dispose();
            }
        }
        public ThrWorkedTime TiempoTrabajadoXPersona(int personkey, int periodo, string conection)
        {
            using (var newcontexto = new Sage500AppEntities(conection))
            {
                var datosTiempo = newcontexto.ThrWorkedTimes.Where(d => d.PersonKey == personkey && d.Periodkey == periodo).FirstOrDefault();
                return datosTiempo;
            }

        }
        public decimal TiemposTrabajadosXPersona(int personkey, int periodo, string conection)
        {
            using (var newcontexto = new Sage500AppEntities(conection))
            {
                var listadatosTiempo = newcontexto.ThrWorkedTimes.Where(d => d.PersonKey == personkey && d.Periodkey != periodo).ToList();
                decimal totalHoras = 0;
                foreach (ThrWorkedTime item in listadatosTiempo)
                {                   
                  totalHoras = totalHoras + item.WorkedHours;                   
                }
                return totalHoras;
            }
        }
        public ThrPosition CargoXPersona(int cargokey, string conection)
        {
            using (var newcontexto = new Sage500AppEntities(conection))
            {
                var datosCargo = newcontexto.ThrPositions.Where(d => d.PositionKey == cargokey).FirstOrDefault();
                return datosCargo;
            }

        }
        public List<ThrAnormalCondPosition> CondicionesXCargo(int cargokey, string conection)
        {
            using (var newcontexto = new Sage500AppEntities(conection))
            {
                var Condiciones = newcontexto.ThrAnormalCondPositions.Where(d => d.PositionKey == cargokey).ToList();
                return Condiciones;
            }

        }
        public List<ThrWorkedTimeAnormalCondition> DevolverCondicionesxTrabajador(int workerTiemkey, string conection)
        {
            using (var newcontexto = new Sage500AppEntities(conection))
            {
                var datosCondiciones = newcontexto.ThrWorkedTimeAnormalConditions.Where(d => d.WorkedTimeKey == workerTiemkey).ToList();
                return datosCondiciones;
            }

        }

    }

}

