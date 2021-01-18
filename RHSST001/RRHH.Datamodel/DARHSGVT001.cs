using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RRHH.Datamodel
{
    public class DARHSGVT001
    {
        public void AdicionarVacacionesTrabajador (List<ThrPeopleVacation> listadoVacacionesXPersona, int periodo, string conex)
        {
           
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                using (var newcontexto = new Sage500AppEntities(conex.ToString()))
                {                   
                    foreach (ThrPeopleVacation item in listadoVacacionesXPersona)
                    {
                        int sumaTotal = 0;
                        int vacationkey;
                        var persona = newcontexto.ThrPeople.Where(d => d.PersonKey == item.Personkey).FirstOrDefault();
                        var vacationXPersona = newcontexto.ThrPeopleVacations.Where(d => d.PeriodKey == periodo && d.Personkey == item.Personkey && d.VacationFechaInicio == item.VacationFechaInicio && d.VacationFechaFin == item.VacationFechaFin).FirstOrDefault();

                        if (vacationXPersona == null)
                        {
                            vacationXPersona = new ThrPeopleVacation();
                            var buscar = (from a in newcontexto.ThrPeopleVacations
                                          orderby a.VacationKey descending
                                          select a.VacationKey
                                                 ).ToList();
                            if (buscar.Any())
                            {
                                vacationkey = Convert.ToInt32(buscar.First()) + 1;
                            }
                            else
                            {
                                vacationkey = 1;
                            }
                            vacationXPersona.PeriodKey = periodo;
                            vacationXPersona.Personkey = item.Personkey;
                            vacationXPersona.VacationKey = vacationkey;
                            vacationXPersona.VacationFechaFin = item.VacationFechaFin;
                            vacationXPersona.VacationFechaInicio= item.VacationFechaInicio;
                            vacationXPersona.FechaRegister = item.FechaRegister;
                            vacationXPersona.HoursDifrutadas = item.HoursDifrutadas;
                            sumaTotal = sumaTotal + item.HoursDifrutadas;
                            newcontexto.AddToThrPeopleVacations(vacationXPersona);
                            newcontexto.SaveChanges();
                            if (persona != null)
                            {
                                var acumulado = persona.AcumuladoVacations;
                                persona.AcumuladoVacations = acumulado - sumaTotal;
                            }                            
                        }
                    }
                    newcontexto.SaveChanges();
                }
                cont.Complete();
                cont.Dispose();
            }
        }
        public List<ThrPeopleVacation> VacacionesXPersona(int personkey, int periodo, string conection)
        {
            using (var newcontexto = new Sage500AppEntities(conection))
            {
                var datosVacaciones = newcontexto.ThrPeopleVacations.Where(d => d.Personkey == personkey && d.PeriodKey == periodo).ToList();
                return datosVacaciones;
            }
        }
        public bool EliminarVacacionesXPersonas(int personkey, DateTime fechaInicio, DateTime fechaFin,  int periodo, string conection)
        {
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                bool dato = false;
                using (var newcontexto = new Sage500AppEntities(conection))
                { 
                    var datosVacaciones = newcontexto.ThrPeopleVacations.Where(d => d.Personkey == personkey && d.PeriodKey == periodo && d.VacationFechaInicio == fechaInicio && d.VacationFechaFin == fechaFin).FirstOrDefault();
                    if (datosVacaciones != null)
                    {
                        var persona = newcontexto.ThrPeople.Where(d => d.PersonKey == personkey).FirstOrDefault();
                        if (persona != null)
                        {
                            persona.AcumuladoVacations = persona.AcumuladoVacations + datosVacaciones.HoursDifrutadas;
                            newcontexto.SaveChanges();
                        }
                        newcontexto.DeleteObject(datosVacaciones);
                        newcontexto.SaveChanges();
                        dato = true;
                    }
                    else
                    { return false; }
                }
                cont.Complete();
                cont.Dispose();
                return dato;                         

            }
        }
    }
}
