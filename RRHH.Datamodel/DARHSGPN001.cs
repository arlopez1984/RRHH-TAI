using Entidades.General;
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
        public List<clsDatosNomina> DevolverAllDatosTrabajadores(int periodo)
        {
            List<clsDatosNomina> listaGeneral = new List<clsDatosNomina>();
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
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

        public List<clsDatosNomina> DevolverAllDatosTrabajadoresXUnidad(int periodo, int unidadOrg)
        {
            var listaGeneral = new List<clsDatosNomina>();
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var buscar = newcontexto.ThrDatosRptsTemporals.ToList();
                if (buscar != null)
                {
                    foreach (ThrDatosRptsTemporal item in buscar)
                    {
                        newcontexto.DeleteObject(item);
                        newcontexto.SaveChanges();
                    }
                    var estato = 6;
                    newcontexto.ExecuteStoreCommand("exec spRRHHDatosNomina '" + periodo + "','" + unidadOrg +"','" + estato+ "'");
                    var resultado = newcontexto.ThrDatosRptsTemporals.ToList();
                    if (resultado != null)
                    {                        
                        foreach (ThrDatosRptsTemporal item in resultado)
                        {
                            var unidad = newcontexto.ThrOrganizativeUnits.Where(d=> d.OrgUnitKey == item.UnidadOrg).FirstOrDefault();
                            var datosNomina = new clsDatosNomina();
                            datosNomina.Expediente = item.Expediente;
                            datosNomina.Nombre = item.PrimerNomnbre + " " + item.PrimerApellido + " " + item.SegundoApellido;
                            datosNomina.UnidadOrganizativa = unidad.Name;
                            datosNomina.TiempoAusencia = item.HorasAusencias.ToString();
                            datosNomina.TiempoLicencia = (item.HorasLicencias * 8).ToString();
                            datosNomina.TiempoSubsidio = (item.HorasSubsidios * 8).ToString();
                            datosNomina.TiempoVacaciones = (item.HorasVacaciones).ToString();
                            listaGeneral.Add(datosNomina);
                        }
                    }
                }
                return listaGeneral;
            }
        }
    }
}
