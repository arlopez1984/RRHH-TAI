using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.General;
using Sage500AppModel;

namespace RRHH.Datamodel
{
    public class DARHSMP001
    {
        public DARHSMP001()
        {
        }
        public List<ThrNacionality> BuscarNacionalidades()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrNacionalities.OrderBy(d => d.NacionalityKey).ToList();
                List<ThrNacionality> listaObj = data;
                return listaObj;
            }
        }
        public ThrNacionality BuscarNacionalidad(int nacionalityKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrNacionalities.Where(d => d.NacionalityKey == nacionalityKey).FirstOrDefault();
                ThrNacionality objnacionalaity = data;
                return objnacionalaity;
            }
        }
        public ThrState BuscarProvincia(int state)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrStates.Where(d => d.Statekey == state).FirstOrDefault();
                ThrState objprovincie = data;
                return objprovincie;
            }
        }
        public ThrOrganizativeUnit BuscarUnidadOrg(int unidad)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitKey == unidad).FirstOrDefault();
                return data;
            }
        }
        public ThrMunicipality BuscarMunicipio(int municipioKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrMunicipalities.Where(d => d.Municipalitykey == municipioKey).FirstOrDefault();
                ThrMunicipality objmunicipe = data;
                return objmunicipe;
            }
        }
        public ThrPosition BuscarCargo(int positionKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrPositions.Where(d => d.PositionKey == positionKey).FirstOrDefault();
                ThrPosition objposition = data;
                return objposition;
            }
        }
        public ThrCulturalLevel BuscarNivelCultural(int culturalkey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrCulturalLevels.Where(d => d.CulturalLevelKey == culturalkey).FirstOrDefault();
                ThrCulturalLevel objCultu = data;
                return objCultu;
            }
        }
        public ThrOcupationalCategory BuscarCategoriaOcupacional(int categKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrOcupationalCategories.Where(d => d.OcupationCategoryKey == categKey).FirstOrDefault();
                ThrOcupationalCategory objCateg = data;
                return objCateg;
            }
        }
        public ThrScientificCategory BuscarCategoriaScientifica( int categKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrScientificCategories.Where(d => d.ScientificCategorykey == categKey).FirstOrDefault();
                ThrScientificCategory objCategScin = data;
                return objCategScin;
            }
        }
        public ThrOcupationClasification BuscarClasificacionOcupacional(int calsifiKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrOcupationClasifications.Where(d => d.OcupationClasificationkey == calsifiKey).FirstOrDefault();
                ThrOcupationClasification objClsifOcupacional = data;
                return objClsifOcupacional;
            }
        }
        public ThrWorkerType BuscarTipoTrabajador(int tipoTrabkey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrWorkerTypes.Where(d => d.WorkerTypekey == tipoTrabkey).FirstOrDefault();
                ThrWorkerType objtipoTrabaj = data;
                return objtipoTrabaj;
            }
        }
        public List<ThrPosition> BuscarCargos()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrPositions.OrderBy(d => d.PositionKey).ToList();
                List<ThrPosition> listaObj = data;
                return listaObj;
            }
        }
        public List<ThrOrganizativeUnit> BuscarAreasAdministrativas(int cargo)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                List<ThrOrganizativeUnit> listaUnidadesXCargo = new List<ThrOrganizativeUnit>();
                var data = newcontexto.ThrOrgUnitPositions.Where(d=> d.PositionKey == cargo).ToList();
                if (data.Any())
                {
                    foreach (ThrOrgUnitPosition item in data)
                    {
                        var unidades = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitKey == item.OrgUnitKey).FirstOrDefault();
                        if (unidades != null)
                        {
                            listaUnidadesXCargo.Add(unidades);
                        }
                    }                   

                }
                return listaUnidadesXCargo;
            }
        }
        public List<ThrOrganizativeUnit> BuscarAreasAdministrativas()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrOrganizativeUnits.ToList();                
                return data;
            }
        }
        public ThrState BuscarProvinciaXName(string name)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrStates.Where(d => d.StateID == name).FirstOrDefault();
                return data;
            }
        }
        public List<ThrState> BuscarProvincias()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrStates.OrderBy(d => d.Statekey).ToList();               
                return data;
            }
        }
        public List<ThrMunicipality> BuscarMunicipios(int idState)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrMunicipalities.Where(d => d.Statekey == idState).ToList();
                List<ThrMunicipality> listaObj = data;
                return listaObj;
            }
        }
        public List<ThrCulturalLevel> BuscarNivelesCulturales()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrCulturalLevels.OrderBy(d => d.CulturalLevelKey).ToList();
                List<ThrCulturalLevel> listaObj = data;
                return listaObj;
            }
        }
        public List<ThrScientificCategory> BuscarCategoriaCientificas()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrScientificCategories.OrderBy(d => d.ScientificCategorykey).ToList();
                List<ThrScientificCategory> listaObj = data;
                return listaObj;
            }
        }
        public List<ThrOcupationalCategory> BuscarCategoriaOcupaionales()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrOcupationalCategories.OrderBy(d => d.OcupationCategoryKey).ToList();
                List<ThrOcupationalCategory> listaObj = data;
                return listaObj;
            }
        }
        public List<ThrWorkerType> BuscarTipoTrabajador()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrWorkerTypes.OrderBy(d => d.WorkerTypekey).ToList();
                List<ThrWorkerType> listaObj = data;
                return listaObj;
            }
        }
        public List<ThrOcupationClasification> BuscarClasificacionesOcupation()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrOcupationClasifications.OrderBy(d => d.OcupationClasificationkey).ToList();
                List<ThrOcupationClasification> listaObj = data;
                return listaObj;
            }
        }
        public ThrPeople BuscarPersona(string CI)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var person = new ThrPeople();
                person = newcontexto.ThrPeople.Where(d => d.CI == CI).FirstOrDefault();
                return person;
            }
           
        }
        public string BuscarUltimoCodigo()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var persona = newcontexto.ThrPeople.ToList();
                if (persona.Count > 0)
                {
                    var ultimoPeople = (from a in newcontexto.ThrPeople
                                        orderby a.PersonKey descending
                                        select a.CodWorker
                                    ).First();
                    return ultimoPeople;
                }
                else
                { return ""; }

            }          

        }
        public bool BuscarPersonaXUnidadAdmin(int UnidadKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {               
                var person = newcontexto.ThrPeople.Where(d => d.OrgUnitKey == UnidadKey).FirstOrDefault();
                if (person != null)
                { return true; }
                else { return false; }                
            }
        }
        public ThrPeople BuscarPersonaxKey(int personKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var person = new ThrPeople();
                person = newcontexto.ThrPeople.Where(d => d.PersonKey == personKey).FirstOrDefault();
                return person;
            }

        }
        public void AdicionarPersona(ThrPeople persona)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrPeople obj = new ThrPeople();
                obj = newcontexto.ThrPeople.Where(d => d.CI == persona.CI).FirstOrDefault();
                if (obj != null)
                {
                    obj.CI = persona.CI;
                    obj.PrimerNombre = persona.PrimerNombre;
                    obj.SegundoNombre = persona.SegundoNombre;
                    obj.PrimerApellido = persona.PrimerApellido;
                    obj.SegundoApellido = persona.SegundoApellido;
                    obj.Sex = persona.Sex;
                    obj.BirthDate = persona.BirthDate;
                    obj.CivilStatuskey = persona.CivilStatuskey;
                    obj.SkinColor = persona.SkinColor;
                    obj.Nacionalitykey = persona.Nacionalitykey;
                    obj.Phone = persona.Phone;
                    obj.Movil = persona.Movil;
                    obj.CodWorker = persona.CodWorker;
                    obj.CodWorkerTecnosime = persona.CodWorkerTecnosime;
                    obj.Email = persona.Email;
                    obj.AddressAve = persona.AddressAve;
                    obj.AddressBulding = persona.AddressBulding;
                    obj.AddressNo = persona.AddressNo;
                    obj.AddressRpto = persona.AddressRpto;
                    obj.AddressBetween = persona.AddressBetween;
                    obj.AddressBetweenLast = persona.AddressBetweenLast;
                    obj.AddressStateKey = persona.AddressStateKey;
                    obj.AddressMunicipalitykey = persona.AddressMunicipalitykey;
                    obj.PositionKey = persona.PositionKey;
                    obj.CultureKey = persona.CultureKey;
                    obj.CientificCategorykey = persona.CientificCategorykey;
                    obj.OrgUnitKey = persona.OrgUnitKey;
                    obj.OcupationalClasificacionKey = persona.OcupationalClasificacionKey;
                    obj.EmploymentRecord = persona.EmploymentRecord;
                    obj.CompanyID = persona.CompanyID;
                    obj.CreateUserID = persona.CreateUserID;
                    obj.EmployRecEmpleadora = persona.EmployRecEmpleadora;
                    obj.WorkerTypekey = persona.WorkerTypekey;
                    obj.NoCuentaMN = persona.NoCuentaMN;
                    obj.Profesion = persona.Profesion;
                    obj.Estatura = persona.Estatura;
                    obj.RasgosDistintivos = persona.RasgosDistintivos;
                    obj.EyesColor = persona.EyesColor;
                    obj.Estato = persona.Estato;
                    obj.Peso = persona.Peso;
                    obj.Edad = persona.Edad;
                    obj.SituacionLaboral = persona.SituacionLaboral;
                    obj.Alias = persona.Alias;
                    obj.Observaciones = persona.Observaciones;
                    obj.UrlPhoto = persona.UrlPhoto;
                    obj.RegistrerDate = DateTime.Now;
                    obj.TurnoKey = persona.TurnoKey;                    
                }
                else
                {
                    newcontexto.AddToThrPeople(persona);                    
                }
                newcontexto.SaveChanges();
            }           

        }
        public void EliminarPersona(string CI)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrPeople.Where(d => d.CI == CI).FirstOrDefault();
                data.Estato = 2; // Baja                
                newcontexto.SaveChanges();
            }                
        }
        public List<ThrPeople> Actualizar(int tipoPerson)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrPeople.Where(d => d.Nacionalitykey == tipoPerson).OrderBy(d => d.PersonKey).ToList();
                var listaObj = data;
                return listaObj;
            }
        }
        public List<ThrPeople> DevolverPersonas()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrPeople.ToList();
                return data;
            }
        }
    }
}
