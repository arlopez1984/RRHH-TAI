using Entidades.General;
using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSGI001
    {
        DARHSGI001 dataAccess;
        public List<ThrPeople> BuscarPersonasxUnidad(int unitkey)
        {
            dataAccess = new DARHSGI001();
            var listData = dataAccess.GetPersonasXUnidad(unitkey);
            return listData;
        }
        public List<ThrOrganizativeUnit> GetaAllsUnidadesAdministrativas()
        {
            dataAccess = new DARHSGI001();
            var listaUnidades = dataAccess.BuscarOrgUnidades();
            return listaUnidades;
        }
        public List<ThrAbsence> GetaAllsAusencias()
        {
            dataAccess = new DARHSGI001();
            var listaAusencias = dataAccess.BuscartiposAusencias();
            return listaAusencias;
        }
        public ThrAbsence GetAusenciaKey(string name)
        {
            dataAccess = new DARHSGI001();
            var absence = dataAccess.BuscarAusenciaKey(name);
            return absence;
        }        
        public List<ThrPeopleAbsence> GetaAllsAusenciasxPersona(int personKey,int periodo)
        {
            dataAccess = new DARHSGI001();
            var listaAusencias = dataAccess.BuscartiposAusenciasXPersonas(personKey,periodo);
            return listaAusencias;
        }
        public List<ThrPeopleLicence> GetaAllsLicenciasxPersona(int personKey,int periodo)
        {
            dataAccess = new DARHSGI001();
            var listaLicencias = dataAccess.BuscartiposLicenciasXPersonas(personKey,periodo);
            return listaLicencias;
        }
        public List<ThrPeopleIncidence> GetaAllsOtrasIncidenciasxPersona(int personKey,int periodo)
        {
            dataAccess = new DARHSGI001();
            var listaOtrasIncidencias = dataAccess.BuscartiposOtrasIncidenciasXPersonas(personKey,periodo);
            return listaOtrasIncidencias;
        }
        public List<ThrPeopleSubsidy> GetaAllsSubsidiosxPersona(int personKey,int periodo)
        {
            dataAccess = new DARHSGI001();
            var listasubsidys = dataAccess.BuscartiposSubsidiosXPersonas(personKey,periodo);
            return listasubsidys;
        }
        public List<ThrIncidence> GetaAllsOtrasIncidencias()
        {
            dataAccess = new DARHSGI001();
            var listaOtrasIncidencias = dataAccess.BuscartiposOtrasIncidence();
            return listaOtrasIncidencias;
        }
        public List<ThrSubsidy> GetaAllsSubsidios()
        {
            dataAccess = new DARHSGI001();
            var listaSub = dataAccess.BuscartiposSubsidios();
            return listaSub;
        }
        public List<ThrLicence> GetaAllsLicencias()
        {
            dataAccess = new DARHSGI001();
            var listaLic = dataAccess.BuscartiposLicencias();
            return listaLic;
        }
        public ThrPeople GetPersona(int unitkey, string CI)
        {
            dataAccess = new DARHSGI001();
            var persona = dataAccess.GetPerson(unitkey, CI);
            return persona;
        }
        public ThrAbsence GetAusencia(int absencekey)
        {
            dataAccess = new DARHSGI001();
            var absence = dataAccess.BuscarAusencia(absencekey);
            return absence;
        }
        public ThrIncidence GetOtraIncidencia(int incidencekey)
        {
            dataAccess = new DARHSGI001();
            var incidence = dataAccess.BuscarOtraIncidencia(incidencekey);
            return incidence;
        }
        public ThrLicence GetLicence(int Licencekey)
        {
            dataAccess = new DARHSGI001();
            var licence = dataAccess.BuscarLicencia(Licencekey);
            return licence;
        }
        public ThrSubsidy GetSubsidio(int subsidyKey)
        {
            dataAccess = new DARHSGI001();
            var subsidy = dataAccess.BuscarSubsidio(subsidyKey);
            return subsidy;
        }
        public ThrSubsidy GetSubsidioKey(string name)
        {
            dataAccess = new DARHSGI001();
            var subsidy = dataAccess.BuscarSubsidyKey(name);
            return subsidy;
        }
        public ThrIncidence GetIncidenciaKey(string name)
        {
            dataAccess = new DARHSGI001();
            var incidence = dataAccess.BuscarIncidenciaKey(name);
            return incidence;
        }
        public ThrLicence GetLicenciaKey(string name)
        {
            dataAccess = new DARHSGI001();
            var licence = dataAccess.BuscarLicenceKey(name);
            return licence;
        }  
       // public void LimpiarDatos
        public void AddIncidencias(List<ThrPeople> personas, List<clsAusencia> listaAusencias, List<clsSubsidios> listaSubsidios, List<clsOtraIncidencia> listOtrasIncidencias, List<clsLicencia> listalicencias , int periodo, string CompanyID, string CreateUserID)
        {
            dataAccess = new DARHSGI001();
            var listAusenciaPersonas = new List<ThrPeopleAbsence>();
            var listLicenciaPersonas = new List<ThrPeopleLicence>();
            var listOIncidenciasPersonas = new List<ThrPeopleIncidence>();
            var listSubsidiosPersonas = new List<ThrPeopleSubsidy>();
            if (listaAusencias.Count > 0)
            {
                foreach (clsAusencia item in listaAusencias)
                {
                    foreach (ThrPeople itemPerson in personas)
                    {
                        var absence = dataAccess.BuscarAusencia(item.tipoAusencia);
                        var peopleAbsence = new ThrPeopleAbsence();
                        peopleAbsence.AbsenceKey = absence.Absencekey;
                        peopleAbsence.PersonKey = itemPerson.PersonKey;
                        peopleAbsence.AbsenceFechaInicio = item.fechInicio;
                        peopleAbsence.AbsenceFechaFin = item.fechaFin;
                        peopleAbsence.Periodkey = periodo;
                        peopleAbsence.HoursDifrutadas = Convert.ToDecimal(item.HorasDisfrutadas.ToString());
                        peopleAbsence.CompanyID = CompanyID;
                        peopleAbsence.CreateUserID = CreateUserID;
                        listAusenciaPersonas.Add(peopleAbsence);
                    }
                }
            } 
            if (listaSubsidios.Count > 0)
            {
                //listSubsidiosPersonas = new List<ThrPeopleSubsidy>();
                foreach (clsSubsidios item in listaSubsidios)
                {
                    foreach (ThrPeople itemPerson in personas)
                    {
                        var subsidy = dataAccess.BuscarSubsidio(item.tipoSubsidio);

                        ThrPeopleSubsidy peopleSubsidy = new ThrPeopleSubsidy();
                        peopleSubsidy.SubsidyKey = subsidy.SubsidyKey;
                        peopleSubsidy.PersonKey = itemPerson.PersonKey;
                        peopleSubsidy.SubsidyFechaInicio = item.fechInicio;
                        peopleSubsidy.SubsidyFechaFin = item.fechaFin;
                        peopleSubsidy.SubsidyInicio = item.Subsidioinicio;
                        peopleSubsidy.SubsidyHospitalizado = item.hospitalizado;
                        peopleSubsidy.Periodkey = periodo;
                        peopleSubsidy.HoursDifrutadas = Convert.ToInt32(item.Horas);
                        peopleSubsidy.CompanyID = CompanyID;
                        peopleSubsidy.CreateUserID = CreateUserID;
                        listSubsidiosPersonas.Add(peopleSubsidy);
                    }

                }
            }
            if (listalicencias.Count > 0)
            {
                //listLicenciaPersonas = new List<ThrPeopleLicence>();
                foreach (clsLicencia item in listalicencias)
                {
                    foreach (ThrPeople itemPerson in personas)
                    {
                        var licence = dataAccess.BuscarLicencia(item.tipoLicencia);

                        ThrPeopleLicence peopleLicence = new ThrPeopleLicence();
                        peopleLicence.LicenceKey = licence.Licencekey;
                        peopleLicence.PersonKey = itemPerson.PersonKey;
                        peopleLicence.LicenceFechaInicio = item.fechInicio;
                        peopleLicence.LicenceFechaFin = item.fechaFin;
                        peopleLicence.Periodkey = periodo;
                        peopleLicence.HoursDifrutadas = Convert.ToInt32(item.Horas);
                        peopleLicence.CompanyID = CompanyID;
                        peopleLicence.CreateUserID = CreateUserID;
                        listLicenciaPersonas.Add(peopleLicence);
                    }
                }
            }
            if (listOtrasIncidencias.Count > 0)
            {
                //listOIncidenciasPersonas = new List<ThrPeopleIncidence>();
                foreach (clsOtraIncidencia item in listOtrasIncidencias)
                {
                    foreach (ThrPeople itemPerson in personas)
                    {
                        var otraIncidencia = dataAccess.BuscarOtraIncidencia(item.tipoOtraIncidencia);
                        ThrPeopleIncidence peopleIncidence = new ThrPeopleIncidence();
                        peopleIncidence.IncidenceKey = otraIncidencia.Incidencekey;
                        peopleIncidence.PersonKey = itemPerson.PersonKey;
                        peopleIncidence.IncidenceFechaInicio = item.fechInicio;
                        peopleIncidence.IncidenceFechaFin = item.fechaFin;
                        peopleIncidence.Periodkey = periodo;
                        peopleIncidence.HoursDifrutadas = Convert.ToInt32(item.Horas);
                        peopleIncidence.CompanyID = CompanyID;
                        peopleIncidence.CreateUserID = CreateUserID;
                        listOIncidenciasPersonas.Add(peopleIncidence);
                    }
                }
            }
            dataAccess.AdicionarIncidencias(personas[0], listAusenciaPersonas, listSubsidiosPersonas,listOIncidenciasPersonas , listLicenciaPersonas);
        }


    }
}
