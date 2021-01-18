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
    public class DARHSRO001
    {
        public List<clsAusencias> BuscarAusenciasXPeriodo(int periodo)
        {
            List<clsAusencias> listaGeneralAusencias = new List<clsAusencias>();
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var buscar = (/*from p in newcontexto.ThrPeople
                              join a in newcontexto.ThrPeopleAbsences on p.PersonKey equals a.PersonKey into personaAusencias
                              from perauce in personaAusencias.DefaultIfEmpty()
                              join ab in newcontexto.ThrAbsences on perauce.AbsenceKey equals ab.Absencekey
                              where p.Estato == 6 && perauce.Periodkey == periodo*/
                              from p in newcontexto.ThrPeople
                              join a in newcontexto.ThrPeopleAbsences on p.PersonKey equals a.PersonKey
                              where p.Estato == 6 && a.Periodkey == periodo

                              select new
                              {
                                  Expediente = p.EmploymentRecord,
                                  NombreApellidos = p.PrimerNombre + " " + " " + p.SegundoNombre + " " + " " + p.PrimerApellido + " " + " " + p.SegundoApellido,
                                  FechaInicio = a.AbsenceFechaInicio,
                                  FechaFin = a.AbsenceFechaFin,
                                  Horas = a.HoursDifrutadas,
                                  //FechaInicio = (perauce == null) ? null : (DateTime?)perauce.AbsenceFechaInicio,
                                  //FechaFin = (perauce == null) ? null : (DateTime?)perauce.AbsenceFechaFin,
                                  Tipo = a.AbsenceKey,
                              }).ToList();

                if (buscar.Any())
                {
                    DARHSMTA001 dataacces = new DARHSMTA001();
                    clsAusencias ausencias;
                    for (int j = 0; j < buscar.Count; j++)
                    {
                        ausencias = new clsAusencias();
                        ausencias.Expediente = buscar[j].Expediente.ToString();
                        ausencias.Nombre = buscar[j].NombreApellidos;
                        var aux = buscar[j];
                        var tipoausencia = newcontexto.ThrAbsences.Where(d => d.Absencekey == aux.Tipo).FirstOrDefault();
                        ausencias.Tipo = tipoausencia.AbsenceName;
                        ausencias.FechaFin = buscar[j].FechaFin.ToString();
                        ausencias.FechaInicio = buscar[j].FechaInicio.ToString();                        
                        ausencias.HorasDisfrutadas = buscar[j].Horas.ToString();
                        listaGeneralAusencias.Add(ausencias);
                    }
                }
            }
            return listaGeneralAusencias;
        }

        public List<clsLicencias> BuscarLicenciasXPeriodo(int periodo)
        {
            List<clsLicencias> listaGeneralLicencias = new List<clsLicencias>();
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var buscar = (/*from p in newcontexto.ThrPeople
                              join a in newcontexto.ThrPeopleLicences on p.PersonKey equals a.PersonKey into personalicencias
                              from perLice in personalicencias.DefaultIfEmpty()
                              join li in newcontexto.ThrLicences on perLice.LicenceKey equals li.Licencekey*/
                              from p in newcontexto.ThrPeople
                              join a in newcontexto.ThrPeopleLicences on p.PersonKey equals a.PersonKey
                              where p.Estato == 6 && a.Periodkey == periodo                           

                              select new
                              {
                                  Expediente = p.EmploymentRecord,
                                  NombreApellidos = p.PrimerNombre + " " + " " + p.SegundoNombre + " " + " " + p.PrimerApellido + " " + " " + p.SegundoApellido,
                                  FechaInicioLicencia = a.LicenceFechaInicio,
                                  FechaFinLicencia = a.LicenceFechaFin,
                                  Horas = a.HoursDifrutadas,
                                  Tipo = a.LicenceKey,
                              }).ToList();

                if (buscar.Any())
                {
                    clsLicencias licencias;
                    for (int j = 0; j < buscar.Count; j++)
                    {
                        licencias = new clsLicencias();
                        licencias.Expediente = buscar[j].Expediente.ToString();
                        licencias.Nombre = buscar[j].NombreApellidos;
                        var aux = buscar[j];
                        var tipoLicencia = newcontexto.ThrLicences.Where(d => d.Licencekey == aux.Tipo).FirstOrDefault();
                        licencias.Tipo = tipoLicencia.LicenceName;
                        licencias.FechaInicio = buscar[j].FechaInicioLicencia.ToString();
                        licencias.FechaFin = buscar[j].FechaFinLicencia.ToString();                        
                        licencias.HorasDisfrutadas = buscar[j].Horas.ToString();
                        listaGeneralLicencias.Add(licencias);
                    }
                }
            }
            return listaGeneralLicencias;
        }

        public List<Entidades.Rpt.clsSubsidios> BuscarSubsidiosXPeriodo(int periodo)
        {
            List<Entidades.Rpt.clsSubsidios> listaGeneralsubsidios = new List<Entidades.Rpt.clsSubsidios>();
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var buscar = (from p in newcontexto.ThrPeople
                              join a in newcontexto.ThrPeopleSubsidies on p.PersonKey equals a.PersonKey
                              where p.Estato == 6 && a.Periodkey == periodo

                              select new
                              {
                                  Expediente = p.EmploymentRecord,
                                  NombreApellidos = p.PrimerNombre + " " + " " + p.SegundoNombre + " " + " " + p.PrimerApellido + " " + " " + p.SegundoApellido,
                                  FechaInicioSubsidy = a.SubsidyFechaInicio,
                                  FechaFinSubsidy = a.SubsidyFechaFin,
                                  Horas = a.HoursDifrutadas,
                                  Tipo = a.SubsidyKey,
                              }).ToList();

                if (buscar.Any())
                {
                    Entidades.Rpt.clsSubsidios subsidios;
                    for (int j = 0; j < buscar.Count; j++)
                    {
                        subsidios = new Entidades.Rpt.clsSubsidios();
                        subsidios.Expediente = buscar[j].Expediente.ToString();
                        subsidios.Nombre = buscar[j].NombreApellidos;
                        var aux = buscar[j];
                        var tipoSubsidio = newcontexto.ThrSubsidies.Where(d => d.SubsidyKey == aux.Tipo).FirstOrDefault();
                        subsidios.Tipo = tipoSubsidio.SubsidyName;
                        subsidios.FechaInicio = buscar[j].FechaInicioSubsidy.ToString();
                        subsidios.FechaFin = buscar[j].FechaFinSubsidy.ToString();
                        subsidios.HorasDisfrutadas = buscar[j].Horas.ToString();
                        listaGeneralsubsidios.Add(subsidios);
                    }
                }
            }
            return listaGeneralsubsidios;
        }

        public List<Entidades.Rpt.clsVacaciones> BuscarVacacionesXPeriodo(int periodo)
        {
            List<Entidades.Rpt.clsVacaciones> listaGeneralVacaciones = new List<Entidades.Rpt.clsVacaciones>();
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var buscar = (from p in newcontexto.ThrPeople
                              join a in newcontexto.ThrPeopleVacations on p.PersonKey equals a.Personkey
                              where p.Estato == 6 && a.PeriodKey == periodo

                              select new
                              {
                                  Expediente = p.EmploymentRecord,
                                  NombreApellidos = p.PrimerNombre + " " + " " + p.SegundoNombre + " " + " " + p.PrimerApellido + " " + " " + p.SegundoApellido,
                                  FechaInicioVac = a.VacationFechaInicio,
                                  FechaFinVac = a.VacationFechaFin,
                                  horas = a.HoursDifrutadas,
                                 // Tipo = "",
                              }).ToList();

                if (buscar.Any())
                {
                    Entidades.Rpt.clsVacaciones vacaciones;
                    for (int j = 0; j < buscar.Count; j++)
                    {
                        vacaciones = new Entidades.Rpt.clsVacaciones();
                        vacaciones.Expediente = buscar[j].Expediente.ToString();
                        vacaciones.Nombre = buscar[j].NombreApellidos;
                        vacaciones.Tipo = "";
                        vacaciones.FechaInicio = buscar[j].FechaInicioVac.ToString();
                        vacaciones.FechaFin = buscar[j].FechaFinVac.ToString();
                        vacaciones.HorasDisfrutadas = buscar[j].horas.ToString();
                        listaGeneralVacaciones.Add(vacaciones);
                    }
                }
            }
            return listaGeneralVacaciones;
        }

        public List<Entidades.Rpt.clsSubsidios> BuscarSubsidiosCertificadosAccidentesXPeriodo(int periodo)
        {
            List<Entidades.Rpt.clsSubsidios> listaGeneralsubsidios = new List<Entidades.Rpt.clsSubsidios>();
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var buscar = (/*from p in newcontexto.ThrPeople
                              join a in newcontexto.ThrPeopleSubsidies on p.PersonKey equals a.PersonKey into personaSubsidios
                              from perSub in personaSubsidios.DefaultIfEmpty()
                              join Sub in newcontexto.ThrSubsidies on perSub.SubsidyKey equals Sub.SubsidyKey
                              where p.Estato == 6 && perSub.Periodkey == periodo && Sub.SubsidyName.Contains("Accidente")*/
                              from p in newcontexto.ThrPeople
                              join a in newcontexto.ThrPeopleSubsidies on p.PersonKey equals a.PersonKey
                              join b in newcontexto.ThrSubsidies on a.SubsidyKey equals b.SubsidyKey
                              where p.Estato == 6 && a.Periodkey == periodo && b.SubsidyName.Contains("Accidente")


                              select new
                              {
                                  Expediente = p.EmploymentRecord,
                                  NombreApellidos = p.PrimerNombre + " " + " " + p.SegundoNombre + " " + " " + p.PrimerApellido + " " + " " + p.SegundoApellido,
                                  FechaInicio = a.SubsidyFechaInicio,
                                  FechaFin = a.SubsidyFechaFin,
                                  Tipo = a.SubsidyKey,
                                  Horas = a.HoursDifrutadas,
                              }).ToList();

                if (buscar.Any())
                {
                    Entidades.Rpt.clsSubsidios subsidios;
                    for (int j = 0; j < buscar.Count; j++)
                    {
                        subsidios = new Entidades.Rpt.clsSubsidios();
                        subsidios.Expediente = buscar[j].Expediente.ToString();
                        subsidios.Nombre = buscar[j].NombreApellidos;
                        var aux = buscar[j];
                        var tipoSubsidio = newcontexto.ThrSubsidies.Where(d => d.SubsidyKey == aux.Tipo).FirstOrDefault();
                        subsidios.Tipo = tipoSubsidio.SubsidyName;
                        subsidios.FechaInicio = buscar[j].FechaInicio.ToString();
                        subsidios.FechaFin = buscar[j].FechaFin.ToString();                      
                        subsidios.HorasDisfrutadas = buscar[j].Horas.ToString();
                        listaGeneralsubsidios.Add(subsidios);
                    }
                }
            }
            return listaGeneralsubsidios;
        }
    }
}

