using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RRHH.Datamodel
{
    public class DARHSGI001
    {
        public DARHSGI001()
        { }
            

        public List<ThrPeople> GetPersonasXUnidad(int unitkey, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                ThrPeople nuevo;
                List<ThrPeople> lista = new List<ThrPeople>();
                 var buscar = (from a in newcontexto.ThrPeople
                                             //join w in newcontexto.ThrPositions on a.PositionKey equals w.PositionKey
                                             //join b in newcontexto.ThrOrgUnitPositions on w.PositionKey equals b.PositionKey                                             
                                             where
                                              a.OrgUnitKey == unitkey && a.Estato == 6
                                            select new
                                             {
                                                 CI= a.CI,
                                                 Nombre = a.PrimerNombre,
                                                 Segundo_Nombre = a.SegundoNombre,
                                                 Primer_Apellido = a.PrimerApellido,
                                                 Segundo_Apellido = a.SegundoApellido,
                                                 AcumuladoVacaciones = a.AcumuladoVacations,
                                                 PersonKey = a.PersonKey,
                                             }).ToList();


                for (int i = 0; i < buscar.Count; i++)
                {
                    nuevo = new ThrPeople();
                    nuevo.CI = buscar[i].CI;
                    nuevo.PrimerNombre = buscar[i].Nombre;
                    nuevo.SegundoNombre = buscar[i].Segundo_Nombre;
                    nuevo.PrimerApellido = buscar[i].Primer_Apellido;
                    nuevo.SegundoApellido = buscar[i].Segundo_Apellido;
                    nuevo.AcumuladoVacations = buscar[i].AcumuladoVacaciones;
                    nuevo.PersonKey = buscar[i].PersonKey;
                    lista.Add(nuevo);
                }                
                return lista;
            }
        }
        public ThrPeople GetPerson(int unitkey, string Carnet, string conexion)
        {
            ThrPeople nuevo;
            var lista = new List<ThrPeople>();
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {               
                
                var buscar = (from a in newcontexto.ThrPeople
                              //join w in newcontexto.ThrPositions on a.PositionKey equals w.PositionKey
                              //join b in newcontexto.ThrOrgUnitPositions on w.PositionKey equals b.PositionKey
                              where
                               a.OrgUnitKey == unitkey && a.CI == Carnet
                              select new
                              {
                                  Key = a.PersonKey,
                                  PositionKey = a.PositionKey,
                                  CarnetIdent = a.CI,
                                  Nombre = a.PrimerNombre,
                                  Segundo_Nombre = a.SegundoNombre,
                                  Primer_Apellido = a.PrimerApellido,
                                  Segundo_Apellido = a.SegundoApellido,
                                  AcumuladoVacaciones = a.AcumuladoVacations,
                              }).ToList();

                for (int i = 0; i < buscar.Count; i++)
                {
                    nuevo = new ThrPeople();
                    nuevo.PersonKey = buscar[i].Key;
                    nuevo.PositionKey = buscar[i].PositionKey;
                    nuevo.CI = buscar[i].CarnetIdent;
                    nuevo.PrimerNombre = buscar[i].Nombre;
                    nuevo.SegundoNombre = buscar[i].Segundo_Nombre;
                    nuevo.PrimerApellido = buscar[i].Primer_Apellido;
                    nuevo.SegundoApellido = buscar[i].Segundo_Apellido;
                    nuevo.AcumuladoVacations = buscar[i].AcumuladoVacaciones;
                    lista.Add(nuevo);
                }
            }
            if (lista.Count > 0)
            {
                return lista[0];
            }
            else
            { return null; }
        }
        public List<ThrOrganizativeUnit> BuscarOrgUnidades(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listOrgUnidades = newcontexto.ThrOrganizativeUnits.ToList();
                return listOrgUnidades;
            }
        }
        public List<ThrAbsence> BuscartiposAusencias(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listaAusencias = newcontexto.ThrAbsences.ToList();
                return listaAusencias;
            }
        }
        public List<ThrPeopleAbsence> BuscartiposAusenciasXPersonas(int personKey,int period, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listaAusenciasXPersona = newcontexto.ThrPeopleAbsences.Where(d => d.PersonKey == personKey && d.Periodkey == period).ToList();
                return listaAusenciasXPersona;
            }
        }
        public List<ThrPeopleLicence> BuscartiposLicenciasXPersonas(int personKey,int period, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listaLicenciasXPersona = newcontexto.ThrPeopleLicences.Where(d => d.PersonKey == personKey && d.Periodkey == period).ToList();
                return listaLicenciasXPersona;
            }
        }
        public List<ThrPeopleIncidence> BuscartiposOtrasIncidenciasXPersonas(int personKey,int period, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listaOtrasIncidenciasXPersona = newcontexto.ThrPeopleIncidences.Where(d => d.PersonKey == personKey && d.Periodkey == period).ToList();
                return listaOtrasIncidenciasXPersona;
            }
        }
        public List<ThrPeopleSubsidy> BuscartiposSubsidiosXPersonas(int personKey,int period, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listasubsidiosXPersona = newcontexto.ThrPeopleSubsidies.Where(d => d.PersonKey == personKey && d.Periodkey == period).ToList();
                return listasubsidiosXPersona;
            }
        }
        public List<ThrSubsidy> BuscartiposSubsidios(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listaTipoSubsidios = newcontexto.ThrSubsidies.ToList();
                return listaTipoSubsidios;
            }
        }
        public List<ThrLicence> BuscartiposLicencias(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listaTiposLicencias = newcontexto.ThrLicences.ToList();
                return listaTiposLicencias;
            }
        }
        public List<ThrIncidence> BuscartiposOtrasIncidence(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listaTiposOtrasIncidencias = newcontexto.ThrIncidences.ToList();
                return listaTiposOtrasIncidencias;
            }
        }
        public ThrAbsence BuscarAusencia(int absencekey, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var objabsence = newcontexto.ThrAbsences.Where(d => d.Absencekey == absencekey).FirstOrDefault();
                return objabsence;
            }
        }
        public ThrIncidence BuscarOtraIncidencia(int incidenceKey, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var objincidence = newcontexto.ThrIncidences.Where(d => d.Incidencekey == incidenceKey).FirstOrDefault();
                return objincidence;
            }
        }
        public ThrSubsidy BuscarSubsidio(int subsidyKey, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var objsubsidio = newcontexto.ThrSubsidies.Where(d => d.SubsidyKey == subsidyKey).FirstOrDefault();
                return objsubsidio;
            }
        }
        public ThrLicence BuscarLicencia(int licenciaKey, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var objlicencia = newcontexto.ThrLicences.Where(d => d.Licencekey == licenciaKey).FirstOrDefault();
                return objlicencia;
            }
        }
        public ThrSubsidy BuscarSubsidyKey(string subsadyname, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var objsubsady = newcontexto.ThrSubsidies.Where(d => d.SubsidyName == subsadyname).FirstOrDefault();
                return objsubsady;
            }
        }
        public ThrIncidence BuscarIncidenciaKey(string incidencename, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var objincidence = newcontexto.ThrIncidences.Where(d => d.IncidenceID == incidencename).FirstOrDefault();
                return objincidence;
            }
        }
        public ThrLicence BuscarLicenceKey(string licencename, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var objLic = newcontexto.ThrLicences.Where(d => d.LicenceName == licencename).FirstOrDefault();
                return objLic;
            }
        }
        public ThrAbsence BuscarAusenciaKey(string absenceName, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var objabsence = newcontexto.ThrAbsences.Where(d => d.AbsenceName == absenceName).FirstOrDefault();
                return objabsence;
            }
        }
        public void AdicionarIncidencias(ThrPeople persona, List<ThrPeopleAbsence> listaAusenciasXpersonas, List<ThrPeopleSubsidy> listadoSubsidiosXpersonas, List<ThrPeopleIncidence> listadoOtrasIncidenciasXpersonas, List<ThrPeopleLicence> listadolicenciasXpersonas, string conex)
        {
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                using (var newcontexto = new Sage500AppEntities(conex.ToString()))
                {
                    if (listaAusenciasXpersonas.Count > 0)
                    {
                        for (int i = 0; i < listaAusenciasXpersonas.Count; i++)
                        {
                            int personkey = listaAusenciasXpersonas[i].PersonKey;
                            var listPoepleAbsence = newcontexto.ThrPeopleAbsences.Where(d => d.PersonKey == personkey).ToList();
                            if (listPoepleAbsence.Count > 0)
                            {
                                for (int j = 0; j < listPoepleAbsence.Count; j++)
                                {
                                    newcontexto.ThrPeopleAbsences.DeleteObject(listPoepleAbsence[j]);
                                    newcontexto.SaveChanges();
                                }
                                for (int j = 0; j < listaAusenciasXpersonas.Count; j++)
                                {
                                    newcontexto.AddToThrPeopleAbsences(listaAusenciasXpersonas[j]);
                                    newcontexto.SaveChanges();
                                }
                            }
                            else
                            {
                                for (int j = 0; j < listaAusenciasXpersonas.Count; j++)
                                {
                                    newcontexto.AddToThrPeopleAbsences(listaAusenciasXpersonas[j]);
                                    newcontexto.SaveChanges();
                                }
                            }
                        }                        
                    }
                    else
                    {
                        var listPoepleAbsence = newcontexto.ThrPeopleAbsences.Where(d => d.PersonKey == persona.PersonKey).ToList();
                        if (listPoepleAbsence.Count > 0)
                        {                           
                            for (int j = 0; j < listPoepleAbsence.Count; j++)
                            {
                                newcontexto.ThrPeopleAbsences.DeleteObject(listPoepleAbsence[j]);
                                newcontexto.SaveChanges();
                            }
                        }
                    }                      
                    
                    if (listadoSubsidiosXpersonas.Count > 0)
                    {
                        for (int i = 0; i < listadoSubsidiosXpersonas.Count; i++)
                        {
                            int personkey = listadoSubsidiosXpersonas[i].PersonKey;
                            var listPoepleSubsidy = newcontexto.ThrPeopleSubsidies.Where(d => d.PersonKey == personkey).ToList();
                            if (listPoepleSubsidy.Count > 0)
                            {
                                for (int j = 0; j < listPoepleSubsidy.Count; j++)
                                {
                                    newcontexto.ThrPeopleSubsidies.DeleteObject(listPoepleSubsidy[j]);
                                    newcontexto.SaveChanges();
                                }
                                for (int j = 0; j < listadoSubsidiosXpersonas.Count; j++)
                                {
                                    newcontexto.AddToThrPeopleSubsidies(listadoSubsidiosXpersonas[j]);
                                    newcontexto.SaveChanges();
                                }
                            }
                            else
                            {
                                for (int j = 0; j < listadoSubsidiosXpersonas.Count; j++)
                                {
                                    newcontexto.AddToThrPeopleSubsidies(listadoSubsidiosXpersonas[j]);
                                    newcontexto.SaveChanges();
                                }
                            }
                        }
                    }
                    else
                    {
                        var listPoepleSubsidios = newcontexto.ThrPeopleSubsidies.Where(d => d.PersonKey == persona.PersonKey).ToList();                           
                        if (listPoepleSubsidios.Count > 0)
                        {
                            for (int j = 0; j < listPoepleSubsidios.Count; j++)
                            {
                                newcontexto.ThrPeopleSubsidies.DeleteObject(listPoepleSubsidios[j]);
                                newcontexto.SaveChanges();
                            }
                        }                       
                    }
                    if (listadolicenciasXpersonas.Count > 0)
                    {
                        for (int f = 0; f < listadolicenciasXpersonas.Count; f++)
                        {
                            int personkey = listadolicenciasXpersonas[f].PersonKey;
                            var listPoepleLicence = newcontexto.ThrPeopleLicences.Where(d => d.PersonKey == personkey).ToList();
                            if (listPoepleLicence.Count > 0)
                            {
                                for (int i = 0; i < listPoepleLicence.Count; i++)
                                {
                                    newcontexto.ThrPeopleLicences.DeleteObject(listPoepleLicence[i]);
                                    newcontexto.SaveChanges();
                                }
                                for (int i = 0; i < listadolicenciasXpersonas.Count; i++)
                                {
                                    newcontexto.AddToThrPeopleLicences(listadolicenciasXpersonas[i]);
                                    newcontexto.SaveChanges();
                                }
                            }
                            else
                            {
                                for (int i = 0; i < listadolicenciasXpersonas.Count; i++)
                                {
                                    newcontexto.AddToThrPeopleLicences(listadolicenciasXpersonas[i]);
                                    newcontexto.SaveChanges();
                                }
                            }
                        }
                    }
                    else
                    {
                        var listPoepleLicence = newcontexto.ThrPeopleLicences.Where(d => d.PersonKey == persona.PersonKey).ToList();
                        if (listPoepleLicence.Count > 0)
                        {
                            for (int i = 0; i < listPoepleLicence.Count; i++)
                            {
                                newcontexto.ThrPeopleLicences.DeleteObject(listPoepleLicence[i]);
                                newcontexto.SaveChanges();
                            }
                        }
                       
                    }
                    if (listadoOtrasIncidenciasXpersonas.Count > 0)
                    {
                        for (int f = 0; f < listadoOtrasIncidenciasXpersonas.Count; f++)
                        {
                            int personkey = listadoOtrasIncidenciasXpersonas[0].PersonKey;
                            var listPoepleIncidencias = newcontexto.ThrPeopleIncidences.Where(d => d.PersonKey == personkey).ToList();
                            if (listPoepleIncidencias.Count > 0)
                            {
                                for (int i = 0; i < listPoepleIncidencias.Count; i++)
                                {
                                    newcontexto.ThrPeopleIncidences.DeleteObject(listPoepleIncidencias[i]);
                                    newcontexto.SaveChanges();
                                }
                                for (int i = 0; i < listadoOtrasIncidenciasXpersonas.Count; i++)
                                {
                                    newcontexto.AddToThrPeopleIncidences(listadoOtrasIncidenciasXpersonas[i]);
                                    newcontexto.SaveChanges();
                                }
                            }
                            else
                            {
                                for (int i = 0; i < listadoOtrasIncidenciasXpersonas.Count; i++)
                                {
                                    newcontexto.AddToThrPeopleIncidences(listadoOtrasIncidenciasXpersonas[i]);
                                    newcontexto.SaveChanges();
                                }
                            }
                        }
                    }
                    else
                    {
                        var listPoepleIncidencias = newcontexto.ThrPeopleIncidences.Where(d => d.PersonKey == persona.PersonKey).ToList();
                        if (listPoepleIncidencias.Count > 0)
                        {
                            for (int i = 0; i < listPoepleIncidencias.Count; i++)
                            {
                                newcontexto.ThrPeopleIncidences.DeleteObject(listPoepleIncidencias[i]);
                                newcontexto.SaveChanges();
                            }
                        }                      
                    }
                    newcontexto.SaveChanges();
                }
                cont.Complete();
                cont.Dispose();
            }
        }
    }
}
