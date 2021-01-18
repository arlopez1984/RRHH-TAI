using Entidades.Rpt;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSGPN001
    {
        public List<clsDatosNomina> DevolverAllDatosTrabajadores(int periodo, string conection)
        {
            List<clsDatosNomina> listaGeneral = new List<clsDatosNomina>();
            using (var newcontexto = new Sage500AppEntities(conection))
            {
                
                var buscar = (from p in newcontexto.ThrPeople
                              join u in newcontexto.ThrOrganizativeUnits on p.OrgUnitKey equals u.OrgUnitKey                               
                              join a in newcontexto.ThrPeopleAbsences on p.PersonKey equals a.PersonKey into personaAusencias
                              from perauce in personaAusencias.DefaultIfEmpty()
                              join l in newcontexto.ThrPeopleLicences on p.PersonKey equals l.PersonKey into personaLicencias
                              from perLicen in personaLicencias.DefaultIfEmpty()
                              join s in newcontexto.ThrPeopleSubsidies on p.PersonKey equals s.PersonKey into personaSubsidios
                              from perSubsi in personaSubsidios.DefaultIfEmpty()
                              join v in newcontexto.ThrPeopleVacations on p.PersonKey equals v.Personkey into personaVacation
                              from perVacations in personaVacation.DefaultIfEmpty()
                              where p.Estato == 6 || perauce.Periodkey == periodo || perLicen.Periodkey == periodo 
                              || perSubsi.Periodkey == periodo || perVacations.PeriodKey == periodo

                              //                              t.WorkCenterDesc == lkuLinea.Text && a.ResourceID == lkuRecurso.Text && a.FechaInicio >= dateTimePicker1.Value && a.FechaInicio <= dateTimePicker2.Value
                              //&& h.OperationType == "L" && h.ProgressStep == "Y"

                              select new
                              {
                                  Expediente = p.EmploymentRecord,
                                  NombreApellidos = p.PrimerNombre + " " + " " + p.SegundoNombre + " " + " " + p.PrimerApellido + " "+ " " + p.SegundoApellido,
                                  U_Organizativa =  u.Name,                                 
                                  FechaInicioAusencia = (perauce == null) ? null : (DateTime?)perauce.AbsenceFechaInicio,
                                  FechaFinAusencia = (perauce == null) ? null : (DateTime?)perauce.AbsenceFechaFin,
                                  FechaInicioLicence = (perLicen == null) ? null : (DateTime?)perLicen.LicenceFechaInicio,
                                  FechaFinLicence = (perLicen == null) ? null : (DateTime?)perLicen.LicenceFechaFin,
                                  FechaInicioSubsidio = (perSubsi == null) ? null : (DateTime?)perSubsi.SubsidyFechaInicio,
                                  FechaFinSubsidio = (perSubsi == null) ? null : (DateTime?)perSubsi.SubsidyFechaFin,
                                  FechaInicioVacaciones = (perVacations == null) ? null : (DateTime?)perVacations.VacationFechaInicio,
                                  FechaFinVacaciones = (perVacations == null) ? null : (DateTime?)perVacations.VacationFechaFin,

                              }).ToList();

                if (buscar.Any())
                {
                    clsDatosNomina datoNomina;
                    //listaGeneral = new List<clsDatosNomina>();
                    for (int j = 0; j < buscar.Count; j++)
                    {
                        datoNomina = new clsDatosNomina();
                        datoNomina.Expediente = buscar[j].Expediente.ToString();
                        datoNomina.Nombre = buscar[j].NombreApellidos;
                        //datoNomina.Periodo = buscar[j].period;
                        datoNomina.UnidadOrganizativa = buscar[j].U_Organizativa.ToString();
                        if (buscar[j].FechaFinVacaciones != null)
                        {
                            var fechainiVa = Convert.ToDateTime(buscar[j].FechaInicioVacaciones);
                            var fechaFin = Convert.ToDateTime(buscar[j].FechaFinVacaciones);
                            TimeSpan resultVacaciones = fechaFin.Subtract(fechainiVa);
                            datoNomina.TiempoVacaciones = resultVacaciones.TotalMinutes.ToString();
                        }
                        else { datoNomina.TiempoVacaciones = "0.00"; }
                        if (buscar[j].FechaFinAusencia != null)
                        {
                            var fechainiAusencia = Convert.ToDateTime(buscar[j].FechaInicioAusencia);
                            var fechaFinAusencias = Convert.ToDateTime(buscar[j].FechaFinAusencia);
                            TimeSpan resultAusencias = fechaFinAusencias.Subtract(fechainiAusencia);
                            datoNomina.TiempoAusencia = resultAusencias.TotalMinutes.ToString();
                        }
                        else { datoNomina.TiempoAusencia = "0.00"; }
                        if (buscar[j].FechaFinAusencia != null)
                        {
                            var fechainilicence = Convert.ToDateTime(buscar[j].FechaInicioLicence);
                            var fechaFinLicence = Convert.ToDateTime(buscar[j].FechaFinLicence);
                            TimeSpan resultlicencia = fechaFinLicence.Subtract(fechainilicence);
                            datoNomina.TiempoLicencia = resultlicencia.TotalMinutes.ToString();
                        }
                        else { datoNomina.TiempoLicencia = "0.00"; }
                        if (buscar[j].FechaFinSubsidio != null)
                        {
                            var fechainiSubsidio = Convert.ToDateTime(buscar[j].FechaInicioSubsidio);
                            var fechaFinSubsidio = Convert.ToDateTime(buscar[j].FechaFinSubsidio);
                            TimeSpan resultSubsidy = fechaFinSubsidio.Subtract(fechainiSubsidio);
                            datoNomina.TiempoSubsidio = resultSubsidy.TotalMinutes.ToString();
                        }
                        else { datoNomina.TiempoSubsidio = "0.00"; }
                        listaGeneral.Add(datoNomina);
                    }                    
                } 
            }
            return listaGeneral;            
        }

        public List<clsDatosNomina> DevolverAllDatosTrabajadoresXUnidad(int periodo, int unidadOrg, string conection)
        {
            List<clsDatosNomina> listaGeneral = new List<clsDatosNomina>();
            using (var newcontexto = new Sage500AppEntities(conection))
            {
                var buscar = (from p in newcontexto.ThrPeople
                              join u in newcontexto.ThrOrganizativeUnits on p.OrgUnitKey equals u.OrgUnitKey
                              from a in newcontexto.ThrPeopleAbsences.Where(a => p.PersonKey == a.PersonKey).DefaultIfEmpty()                               
                              from l in newcontexto.ThrPeopleLicences.Where(l => p.PersonKey == l.PersonKey).DefaultIfEmpty()
                              from s in newcontexto.ThrPeopleSubsidies.Where(s => p.PersonKey == s.PersonKey).DefaultIfEmpty()
                              from i in newcontexto.ThrPeopleIncidences.Where(i => p.PersonKey == i.PersonKey).DefaultIfEmpty()
                              from v in newcontexto.ThrPeopleVacations.Where(v => p.PersonKey == v.Personkey).DefaultIfEmpty()
                              where p.OrgUnitKey == unidadOrg /*&& a.Periodkey == periodo  &&  p.Estato == 6  && 
                              l.Periodkey == periodo && s.Periodkey == periodo && v.PeriodKey==periodo*/
                              select new
                              {
                                  Expediente = p.EmploymentRecord,
                                  NombreApellidos = p.PrimerNombre + " " + " " + p.SegundoNombre + " " + " " + p.PrimerApellido + " " + " " + p.SegundoApellido,
                                  U_Organizativa = u.Name,
                                  FechaInicioAusencia = (DateTime?)a.AbsenceFechaInicio, // (perauce == null) ? null : (DateTime?)perauce.AbsenceFechaInicio,
                                  FechaFinAusencia = (DateTime?)a.AbsenceFechaFin,//(perauce == null) ? null : (DateTime?)perauce.AbsenceFechaFin,
                                  FechaInicioLicence = (DateTime?)l.LicenceFechaInicio,
                                  FechaFinLicence = (DateTime?)l.LicenceFechaFin,
                                  FechaInicioSubsidio = (DateTime?)s.SubsidyFechaInicio,
                                  FechaFinSubsidio = (DateTime?)s.SubsidyFechaFin,
                                  FechaInicioVacaciones = (DateTime?)v.VacationFechaInicio,
                                  FechaFinVacaciones = (DateTime?)v.VacationFechaFin,

                              }).ToList();

                if (buscar.Any())
                {
                    listaGeneral = new List<clsDatosNomina>();
                    for (int j = 0; j < buscar.Count; j++)
                    {
                        var datoNomina = new clsDatosNomina();
                        datoNomina.Expediente = buscar[j].Expediente.ToString();
                        datoNomina.Nombre = buscar[j].NombreApellidos;
                        //datoNomina.Periodo = buscar[j].period;
                        datoNomina.UnidadOrganizativa = buscar[j].U_Organizativa.ToString();
                        if (buscar[j].FechaFinVacaciones != null)
                        {
                            var fechainiVa = Convert.ToDateTime(buscar[j].FechaInicioVacaciones);
                            var fechaFin = Convert.ToDateTime(buscar[j].FechaFinVacaciones);
                            TimeSpan resultVacaciones = fechaFin.Subtract(fechainiVa);
                            datoNomina.TiempoVacaciones = resultVacaciones.TotalMinutes.ToString();
                        }
                        else { datoNomina.TiempoVacaciones = "0.00"; }
                        if (buscar[j].FechaFinAusencia != null)
                        {
                            var fechainiAusencia = Convert.ToDateTime(buscar[j].FechaInicioAusencia);
                            var fechaFinAusencias = Convert.ToDateTime(buscar[j].FechaFinAusencia);
                            TimeSpan resultAusencias = fechaFinAusencias.Subtract(fechainiAusencia);
                            datoNomina.TiempoAusencia = resultAusencias.TotalMinutes.ToString();
                        }
                        else { datoNomina.TiempoAusencia = "0.00"; }
                        if (buscar[j].FechaFinAusencia != null)
                        {
                            var fechainilicence = Convert.ToDateTime(buscar[j].FechaInicioLicence);
                            var fechaFinLicence = Convert.ToDateTime(buscar[j].FechaFinLicence);
                            TimeSpan resultlicencia = fechaFinLicence.Subtract(fechainilicence);
                            datoNomina.TiempoLicencia = resultlicencia.TotalMinutes.ToString();
                        }
                        else { datoNomina.TiempoLicencia = "0.00"; }
                        if (buscar[j].FechaFinSubsidio != null)
                        {
                            var fechainiSubsidio = Convert.ToDateTime(buscar[j].FechaInicioSubsidio);
                            var fechaFinSubsidio = Convert.ToDateTime(buscar[j].FechaFinSubsidio);
                            TimeSpan resultSubsidy = fechaFinSubsidio.Subtract(fechainiSubsidio);
                            datoNomina.TiempoSubsidio = resultSubsidy.TotalMinutes.ToString();
                        }
                        else { datoNomina.TiempoSubsidio = "0.00"; }
                        listaGeneral.Add(datoNomina);
                    }
                }
                return listaGeneral;
            }
        }  
    }
}
