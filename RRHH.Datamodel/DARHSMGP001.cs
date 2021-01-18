using Entidades.General;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace RRHH.Datamodel
{
    public class DARHSMGP001
    {
        public ThrOperationsPeriod BuscarPeriodoActivo()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var objPeriodo = newcontexto.ThrOperationsPeriods.Where(d => d.PeriodEstado == 1).FirstOrDefault();
                return objPeriodo;
            }
        }
        public bool EliminarPeriodoActivo(ThrOperationsPeriod operac)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var objPeriodo = newcontexto.ThrOperationsPeriods.Where(d => d.PeriodFechaInicio == operac.PeriodFechaInicio && d.PeriodFechaFin == operac.PeriodFechaFin).FirstOrDefault();
                if (objPeriodo != null)
                {
                    var personGesTiempo = newcontexto.ThrWorkedTimes.Where(d => d.Periodkey == objPeriodo.Periodkey).ToList();
                    if (personGesTiempo.Count == 0)
                    {
                        newcontexto.DeleteObject(objPeriodo);
                        newcontexto.SaveChanges();
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
        }
        public bool AgregarOperacionPeriodo(ThrOperationsPeriod operac)
        {           
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {           
                newcontexto.AddToThrOperationsPeriods(operac);
                newcontexto.SaveChanges();
                return true;                
            }
        }
        public bool CerrarOperacionPeriodo()
        {
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                bool cerrar = false;
                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    var objPeriodo = newcontexto.ThrOperationsPeriods.Where(d => d.PeriodEstado == 1).FirstOrDefault();
                    if (objPeriodo != null)
                    {
                        var listperson = newcontexto.ThrPeople.Where(d => d.Estato == 6).ToList();
                        var personGesTiempo = newcontexto.ThrWorkedTimes.Where(d => d.Periodkey == objPeriodo.Periodkey).ToList();
                        if (listperson.Count > personGesTiempo.Count)
                        {
                            DialogResult resul = MessageBox.Show("Hay personas a las que no se le ha gestionado su Tiempo Trabajado. Desea continuar?.", "Sage MAS 500", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (resul == DialogResult.Yes)
                            {
                                foreach (ThrPeople item in listperson)
                                {
                                    var personRetention = newcontexto.ThrPeopleRetentions.Where(d => d.PersonKey == item.PersonKey).ToList();
                                    if (personRetention.Count > 0)
                                    {
                                        foreach (ThrPeopleRetention personR in personRetention)
                                        {
                                            if (personR.SaldoPendiente > 0)
                                            {
                                                personR.SaldoPendiente = personR.SaldoPendiente - personR.SaldoMensual;
                                                newcontexto.SaveChanges();
                                            }
                                        }
                                    }
                                    var personDeduction = newcontexto.ThrPeopleDeduction1s.Where(d => d.PersonKey == item.PersonKey).ToList();
                                    if (personDeduction.Count > 0)
                                    {
                                        for (int i = 0; i < personDeduction.Count; i++)
                                        {
                                            if (personDeduction[i].SaldoPendiente > 0)
                                            {
                                                personDeduction[i].SaldoPendiente = personDeduction[i].SaldoPendiente - ((personDeduction[i].SaldoTotal * personDeduction[i].CuotaMensual) / 100);
                                                newcontexto.SaveChanges();
                                            }

                                        }
                                    }
                                    var personWork = newcontexto.ThrWorkedTimes.Where(d => d.PersonKey == item.PersonKey).FirstOrDefault();
                                    if (personWork != null)
                                    {
                                        var persona = newcontexto.ThrPeople.Where(d => d.PersonKey == item.PersonKey).FirstOrDefault();
                                        if (persona != null)
                                        {
                                            var valor = 0.0909;
                                            persona.AcumuladoVacations = Convert.ToInt32((Convert.ToDecimal(persona.AcumuladoVacations) + (personWork.WorkedHours * Convert.ToDecimal(valor))));
                                            newcontexto.SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        var TiempoGestionado = new ThrWorkedTime();
                                        {
                                            TiempoGestionado.Periodkey = objPeriodo.Periodkey;
                                            TiempoGestionado.ExtraHours = 0;
                                            TiempoGestionado.HolidayDays = 0;
                                            TiempoGestionado.PersonKey = item.PersonKey;
                                            TiempoGestionado.WorkedHours = Convert.ToDecimal(190.6);
                                            newcontexto.AddToThrWorkedTimes(TiempoGestionado);
                                            newcontexto.SaveChanges();
                                        }
                                        var persona = newcontexto.ThrPeople.Where(d => d.PersonKey == item.PersonKey).FirstOrDefault();
                                        if (persona != null)
                                        {
                                            var valor = 0.0909;
                                            var valorMax = 190.6;
                                            persona.AcumuladoVacations = Convert.ToInt32((Convert.ToDecimal(persona.AcumuladoVacations) + (Convert.ToDecimal(valorMax) * Convert.ToDecimal(valor))));
                                            newcontexto.SaveChanges();
                                        }
                                    }
                                }
                                objPeriodo.PeriodEstado = 0;
                                newcontexto.SaveChanges();
                                cerrar = true;
                            }
                            else { cerrar = false; }
                        }
                        else
                        {
                            foreach (ThrPeople item in listperson)
                            {
                                var personRetention = newcontexto.ThrPeopleRetentions.Where(d => d.PersonKey == item.PersonKey).ToList();
                                if (personRetention.Count > 0)
                                {
                                    foreach (ThrPeopleRetention personR in personRetention)
                                    {
                                        if (personR.SaldoPendiente > 0)
                                        {
                                            personR.SaldoPendiente = personR.SaldoPendiente - personR.SaldoMensual;
                                            newcontexto.SaveChanges();
                                        }
                                    }
                                }
                                //var personDeduction = newcontexto.ThrPeopleDeductions.Where(d => d.PersonKey == item.PersonKey).ToList();
                                //if (personDeduction.Count > 0)
                                //{
                                //    foreach (ThrDeduction personD in personDeduction)
                                //    {
                                //        if (personD.SaldoPendiente > 0)
                                //        {
                                //            personD.SaldoPendiente = personD.SaldoPendiente - personR.SaldoMensual;
                                //            newcontexto.SaveChanges();
                                //        }
                                //    }
                                //}
                                var personWork = newcontexto.ThrWorkedTimes.Where(d => d.PersonKey == item.PersonKey).FirstOrDefault();
                                if (personWork != null)
                                {
                                    var persona = newcontexto.ThrPeople.Where(d => d.PersonKey == item.PersonKey).FirstOrDefault();
                                    if (persona != null)
                                    {
                                        var valor = 0.0909;
                                        persona.AcumuladoVacations = Convert.ToInt32((Convert.ToDecimal(persona.AcumuladoVacations) + (personWork.WorkedHours * Convert.ToDecimal(valor))));
                                        newcontexto.SaveChanges();
                                    }
                                }
                                else
                                {
                                    var TiempoGestionado = new ThrWorkedTime();
                                    {
                                        TiempoGestionado.Periodkey = objPeriodo.Periodkey;
                                        TiempoGestionado.ExtraHours = 0;
                                        TiempoGestionado.HolidayDays = 0;
                                        TiempoGestionado.PersonKey = item.PersonKey;
                                        TiempoGestionado.WorkedHours = Convert.ToDecimal(190.6);
                                        newcontexto.AddToThrWorkedTimes(TiempoGestionado);
                                        newcontexto.SaveChanges();
                                    }
                                    var persona = newcontexto.ThrPeople.Where(d => d.PersonKey == item.PersonKey).FirstOrDefault();
                                    if (persona != null)
                                    {
                                        var valor = 0.0909;
                                        var valorMax = 190.6;
                                        persona.AcumuladoVacations = Convert.ToInt32((Convert.ToDecimal(persona.AcumuladoVacations) + (Convert.ToDecimal(valorMax) * Convert.ToDecimal(valor))));
                                        newcontexto.SaveChanges();
                                    }

                                }
                            }
                            objPeriodo.PeriodEstado = 0;
                            newcontexto.SaveChanges();
                            cerrar = true;
                        }
                    }
                    else
                    {
                        cerrar = false;
                    }
                }
                cont.Complete();
                cont.Dispose();
                return cerrar;
            }
        }
        public List<ThrOperationsPeriod> BuscarPeriodos()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listaobjPeriodo = newcontexto.ThrOperationsPeriods.ToList();
                return listaobjPeriodo;
            }
        }

    }
}
