using Entidades.Rpt;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSRO001
    {
        public List<clsAusencias> BuscarAusenciasXPeriodo(int periodo, string conexion)
        {
            List<clsAusencias> listaGeneralAusencias = new List<clsAusencias>();
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var buscar = (from p in newcontexto.ThrPeople
                              join a in newcontexto.ThrPeopleAbsences on p.PersonKey equals a.PersonKey into personaAusencias
                              from perauce in personaAusencias.DefaultIfEmpty()
                              join ab in newcontexto.ThrAbsences on perauce.AbsenceKey equals ab.Absencekey
                              where p.Estato == 6 && perauce.Periodkey == periodo

                              select new
                              {
                                  Expediente = p.EmploymentRecord,
                                  NombreApellidos = p.PrimerNombre + " " + " " + p.SegundoNombre + " " + " " + p.PrimerApellido + " " + " " + p.SegundoApellido,
                                  FechaInicio = (perauce == null) ? null : (DateTime?)perauce.AbsenceFechaInicio,
                                  FechaFin = (perauce == null) ? null : (DateTime?)perauce.AbsenceFechaFin,
                                  Tipo = ab.AbsenceName
                              }).ToList();

                if (buscar.Any())
                {
                    clsAusencias ausencias;
                    for (int j = 0; j < buscar.Count; j++)
                    {
                        ausencias = new clsAusencias();
                        ausencias.Expediente = buscar[j].Expediente.ToString();
                        ausencias.Nombre = buscar[j].NombreApellidos;
                        ausencias.Tipo = buscar[j].Tipo;
                        ausencias.FechaFin = buscar[j].FechaFin.ToString();
                        ausencias.FechaInicio = buscar[j].FechaInicio.ToString();
                        var fechainiVa = Convert.ToDateTime(buscar[j].FechaInicio);
                        var fechaFin = Convert.ToDateTime(buscar[j].FechaFin);
                        TimeSpan result = fechaFin.Subtract(fechainiVa);
                        ausencias.HorasDisfrutadas = result.TotalMinutes.ToString();
                        listaGeneralAusencias.Add(ausencias);
                    }
                }
            }
            return listaGeneralAusencias;
        }

        public List<clsLicencias> BuscarLicenciasXPeriodo(int periodo, string conexion)
        {
            List<clsLicencias> listaGeneralLicencias = new List<clsLicencias>();
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var buscar = (from p in newcontexto.ThrPeople
                              join a in newcontexto.ThrPeopleLicences on p.PersonKey equals a.PersonKey into personalicencias
                              from perLice in personalicencias.DefaultIfEmpty()
                              join li in newcontexto.ThrLicences on perLice.LicenceKey equals li.Licencekey
                              where p.Estato == 6 && perLice.Periodkey == periodo

                              select new
                              {
                                  Expediente = p.EmploymentRecord,
                                  NombreApellidos = p.PrimerNombre + " " + " " + p.SegundoNombre + " " + " " + p.PrimerApellido + " " + " " + p.SegundoApellido,
                                  FechaInicioLicencia = (perLice == null) ? null : (DateTime?) perLice.LicenceFechaInicio,
                                  FechaFinLicencia = (perLice == null) ? null : (DateTime?)perLice.LicenceFechaFin,
                                  TipoLicencias = li.LicenceName
                              }).ToList();

                if (buscar.Any())
                {
                    clsLicencias licencias;
                    for (int j = 0; j < buscar.Count; j++)
                    {
                        licencias = new clsLicencias();
                        licencias.Expediente = buscar[j].Expediente.ToString();
                        licencias.Nombre = buscar[j].NombreApellidos;
                        licencias.Tipo = buscar[j].TipoLicencias;                       
                        licencias.FechaInicio = buscar[j].FechaInicioLicencia.ToString();
                        licencias.FechaFin = buscar[j].FechaFinLicencia.ToString();
                        var fechainiVa = Convert.ToDateTime(buscar[j].FechaInicioLicencia);
                        var fechaFin = Convert.ToDateTime(buscar[j].FechaFinLicencia);
                        TimeSpan result = fechaFin.Subtract(fechainiVa);
                        licencias.HorasDisfrutadas = result.TotalMinutes.ToString();
                        listaGeneralLicencias.Add(licencias);
                    }
                }
            }
            return listaGeneralLicencias;
        }

        public List<clsSubsidios> BuscarSubsidiosXPeriodo(int periodo, string conexion)
        {
            List<clsSubsidios> listaGeneralsubsidios = new List<clsSubsidios>();
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var buscar = (from p in newcontexto.ThrPeople
                              join a in newcontexto.ThrPeopleSubsidies on p.PersonKey equals a.PersonKey into personaSubsidios
                              from perSub in personaSubsidios.DefaultIfEmpty()
                              join Sub in newcontexto.ThrSubsidies on perSub.SubsidyKey equals Sub.SubsidyKey
                              where p.Estato == 6 && perSub.Periodkey == periodo

                              select new
                              {
                                  Expediente = p.EmploymentRecord,
                                  NombreApellidos = p.PrimerNombre + " " + " " + p.SegundoNombre + " " + " " + p.PrimerApellido + " " + " " + p.SegundoApellido,
                                  FechaInicio = (perSub == null) ? null : (DateTime?)perSub.SubsidyFechaInicio,
                                  FechaFin = (perSub == null) ? null : (DateTime?)perSub.SubsidyFechaFin,
                                  Tipo = Sub.SubsidyName
                              }).ToList();

                if (buscar.Any())
                {
                    clsSubsidios subsidios;
                    for (int j = 0; j < buscar.Count; j++)
                    {
                        subsidios = new clsSubsidios();
                        subsidios.Expediente = buscar[j].Expediente.ToString();
                        subsidios.Nombre = buscar[j].NombreApellidos;
                        subsidios.Tipo = buscar[j].Tipo;
                        subsidios.FechaInicio = buscar[j].FechaInicio.ToString();
                        subsidios.FechaFin = buscar[j].FechaFin.ToString();                       
                        var fechainiVa = Convert.ToDateTime(buscar[j].FechaInicio);
                        var fechaFin = Convert.ToDateTime(buscar[j].FechaFin);
                        TimeSpan result = fechaFin.Subtract(fechainiVa);
                        subsidios.HorasDisfrutadas = result.TotalMinutes.ToString();
                        listaGeneralsubsidios.Add(subsidios);
                    }
                }
            }
            return listaGeneralsubsidios;
        }

        public List<clsVacaciones> BuscarVacacionesXPeriodo(int periodo, string conexion)
        {
            List<clsVacaciones> listaGeneralVacaciones = new List<clsVacaciones>();
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var buscar = (from p in newcontexto.ThrPeople
                              join a in newcontexto.ThrPeopleVacations on p.PersonKey equals a.Personkey into personaVacations
                              from perVac in personaVacations.DefaultIfEmpty()
                              join Vac in newcontexto.ThrPeopleVacations on perVac.VacationKey equals Vac.VacationKey
                              where p.Estato == 6 && perVac.PeriodKey == periodo

                              select new
                              {
                                  Expediente = p.EmploymentRecord,
                                  NombreApellidos = p.PrimerNombre + " " + " " + p.SegundoNombre + " " + " " + p.PrimerApellido + " " + " " + p.SegundoApellido,
                                  FechaInicioVac = (perVac == null) ? null : (DateTime?)perVac.VacationFechaInicio,
                                  FechaFinVac = (perVac == null) ? null : (DateTime?)perVac.VacationFechaFin,
                                  Tipo = "",
                              }).ToList();

                if (buscar.Any())
                {
                    clsVacaciones vacaciones;
                    for (int j = 0; j < buscar.Count; j++)
                    {
                        vacaciones = new clsVacaciones();
                        vacaciones.Expediente = buscar[j].Expediente.ToString();
                        vacaciones.Nombre = buscar[j].NombreApellidos;
                        vacaciones.Tipo = "";
                        vacaciones.FechaInicio = buscar[j].FechaInicioVac.ToString();
                        vacaciones.FechaFin = buscar[j].FechaFinVac.ToString();                       
                        var fechainiVa = Convert.ToDateTime(buscar[j].FechaInicioVac);
                        var fechaFin = Convert.ToDateTime(buscar[j].FechaFinVac);
                        TimeSpan result = fechaFin.Subtract(fechainiVa);
                        vacaciones.HorasDisfrutadas = result.TotalMinutes.ToString();
                        listaGeneralVacaciones.Add(vacaciones);
                    }
                }
            }
            return listaGeneralVacaciones;
        }

        public List<clsSubsidios> BuscarSubsidiosCertificadosAccidentesXPeriodo(int periodo, string conexion)
        {
            List<clsSubsidios> listaGeneralsubsidios = new List<clsSubsidios>();
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var buscar = (from p in newcontexto.ThrPeople
                              join a in newcontexto.ThrPeopleSubsidies on p.PersonKey equals a.PersonKey into personaSubsidios
                              from perSub in personaSubsidios.DefaultIfEmpty()
                              join Sub in newcontexto.ThrSubsidies on perSub.SubsidyKey equals Sub.SubsidyKey
                              where p.Estato == 6 && perSub.Periodkey == periodo && Sub.SubsidyName.Contains("Accidente")

                              select new
                              {
                                  Expediente = p.EmploymentRecord,
                                  NombreApellidos = p.PrimerNombre + " " + " " + p.SegundoNombre + " " + " " + p.PrimerApellido + " " + " " + p.SegundoApellido,
                                  FechaInicio = (perSub == null) ? null : (DateTime?)perSub.SubsidyFechaInicio,
                                  FechaFin = (perSub == null) ? null : (DateTime?)perSub.SubsidyFechaFin,
                                  Tipo = Sub.SubsidyName
                              }).ToList();

                if (buscar.Any())
                {
                    clsSubsidios subsidios;
                    for (int j = 0; j < buscar.Count; j++)
                    {
                        subsidios = new clsSubsidios();
                        subsidios.Expediente = buscar[j].Expediente.ToString();
                        subsidios.Nombre = buscar[j].NombreApellidos;
                        subsidios.Tipo = buscar[j].Tipo;
                        subsidios.FechaInicio = buscar[j].FechaInicio.ToString();
                        subsidios.FechaFin = buscar[j].FechaFin.ToString();
                        var fechainiVa = Convert.ToDateTime(buscar[j].FechaInicio);
                        var fechaFin = Convert.ToDateTime(buscar[j].FechaFin);
                        TimeSpan result = fechaFin.Subtract(fechainiVa);
                        subsidios.HorasDisfrutadas = result.TotalMinutes.ToString();
                        listaGeneralsubsidios.Add(subsidios);
                    }
                }
            }
            return listaGeneralsubsidios;
        }
    }
}

