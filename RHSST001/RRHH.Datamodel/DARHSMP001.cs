using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sage500AppModel;

namespace RRHH.Datamodel
{
    public class DARHSMP001
    {
        //string conexion;
        public DARHSMP001()
        {
        }
        public List<ThrNacionality> BuscarNacionalidades(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrNacionalities.OrderBy(d => d.NacionalityKey).ToList();
                List<ThrNacionality> listaObj = data;
                return listaObj;
            }
        }
        public ThrNacionality BuscarNacionalidad(string conexion, int nacionalityKey)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrNacionalities.Where(d => d.NacionalityKey == nacionalityKey).FirstOrDefault();
                ThrNacionality objnacionalaity = data;
                return objnacionalaity;
            }
        }
        public ThrState BuscarProvincia(string conexion, int state)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrStates.Where(d => d.Statekey == state).FirstOrDefault();
                ThrState objprovincie = data;
                return objprovincie;
            }
        }
        public ThrOrganizativeUnit BuscarUnidadOrg(string conexion, int unidad)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitKey == unidad).FirstOrDefault();
                return data;
            }
        }
        public ThrMunicipality BuscarMunicipio(string conexion, int municipioKey)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrMunicipalities.Where(d => d.Municipalitykey == municipioKey).FirstOrDefault();
                ThrMunicipality objmunicipe = data;
                return objmunicipe;
            }
        }
        public ThrPosition BuscarCargo(string conexion, int positionKey)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrPositions.Where(d => d.PositionKey == positionKey).FirstOrDefault();
                ThrPosition objposition = data;
                return objposition;
            }
        }
        public ThrCulturalLevel BuscarNivelCultural(string conexion, int culturalkey)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrCulturalLevels.Where(d => d.CulturalLevelKey == culturalkey).FirstOrDefault();
                ThrCulturalLevel objCultu = data;
                return objCultu;
            }
        }
        public ThrOcupationalCategory BuscarCategoriaOcupacional(string conexion, int categKey)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrOcupationalCategories.Where(d => d.OcupationCategoryKey == categKey).FirstOrDefault();
                ThrOcupationalCategory objCateg = data;
                return objCateg;
            }
        }
        public ThrScientificCategory BuscarCategoriaScientifica(string conexion, int categKey)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrScientificCategories.Where(d => d.ScientificCategorykey == categKey).FirstOrDefault();
                ThrScientificCategory objCategScin = data;
                return objCategScin;
            }
        }
        public ThrOcupationClasification BuscarClasificacionOcupacional(string conexion, int calsifiKey)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrOcupationClasifications.Where(d => d.OcupationClasificationkey == calsifiKey).FirstOrDefault();
                ThrOcupationClasification objClsifOcupacional = data;
                return objClsifOcupacional;
            }
        }
        public ThrWorkerType BuscarTipoTrabajador(string conexion, int tipoTrabkey)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrWorkerTypes.Where(d => d.WorkerTypekey == tipoTrabkey).FirstOrDefault();
                ThrWorkerType objtipoTrabaj = data;
                return objtipoTrabaj;
            }
        }
        public List<ThrPosition> BuscarCargos(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrPositions.OrderBy(d => d.PositionKey).ToList();
                List<ThrPosition> listaObj = data;
                return listaObj;
            }
        }
        public List<ThrOrganizativeUnit> BuscarAreasAdministrativas(int cargo, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
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
        public ThrState BuscarProvinciaXName(string name, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrStates.Where(d => d.StateID == name).FirstOrDefault();
                return data;
            }
        }
        public List<ThrState> BuscarProvincias(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrStates.OrderBy(d => d.Statekey).ToList();               
                return data;
            }
        }
        public List<ThrMunicipality> BuscarMunicipios(int idState, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrMunicipalities.Where(d => d.Statekey == idState).ToList();
                List<ThrMunicipality> listaObj = data;
                return listaObj;
            }
        }
        public List<ThrCulturalLevel> BuscarNivelesCulturales(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrCulturalLevels.OrderBy(d => d.CulturalLevelKey).ToList();
                List<ThrCulturalLevel> listaObj = data;
                return listaObj;
            }
        }
        public List<ThrScientificCategory> BuscarCategoriaCientificas(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrScientificCategories.OrderBy(d => d.ScientificCategorykey).ToList();
                List<ThrScientificCategory> listaObj = data;
                return listaObj;
            }
        }
        public List<ThrOcupationalCategory> BuscarCategoriaOcupaionales(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrOcupationalCategories.OrderBy(d => d.OcupationCategoryKey).ToList();
                List<ThrOcupationalCategory> listaObj = data;
                return listaObj;
            }
        }
        public List<ThrWorkerType> BuscarTipoTrabajador(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrWorkerTypes.OrderBy(d => d.WorkerTypekey).ToList();
                List<ThrWorkerType> listaObj = data;
                return listaObj;
            }
        }
        public List<ThrOcupationClasification> BuscarClasificacionesOcupation(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrOcupationClasifications.OrderBy(d => d.OcupationClasificationkey).ToList();
                List<ThrOcupationClasification> listaObj = data;
                return listaObj;
            }
        }
        public ThrPeople BuscarPersona(string CI, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var person = new ThrPeople();
                person = newcontexto.ThrPeople.Where(d => d.CI == CI).FirstOrDefault();
                return person;
            }
           
        }
        public bool BuscarPersonaXUnidadAdmin(int UnidadKey, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {               
                var person = newcontexto.ThrPeople.Where(d => d.OrgUnitKey == UnidadKey).FirstOrDefault();
                if (person != null)
                { return true; }
                else { return false; }                
            }
        }
        public ThrPeople BuscarPersonaxKey(int personKey, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var person = new ThrPeople();
                person = newcontexto.ThrPeople.Where(d => d.PersonKey == personKey).FirstOrDefault();
                return person;
            }

        }
        public void AdicionarPersona(ThrPeople persona, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
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
                    obj.OcupationalCategoriakey = persona.OcupationalCategoriakey;
                    obj.CientificCategorykey = persona.CientificCategorykey;
                    obj.OrgUnitKey = persona.OrgUnitKey;
                    obj.OcupationalClasificacionKey = persona.OcupationalClasificacionKey;
                    obj.EmploymentRecord = persona.EmploymentRecord;
                    obj.WorkerTypekey = persona.WorkerTypekey;
                    obj.NoCuentaMN = persona.NoCuentaMN;
                    obj.NoCuentaCUC = persona.NoCuentaCUC;
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
                }
                else
                {
                    newcontexto.AddToThrPeople(persona);                    
                }
                newcontexto.SaveChanges();
            }           

        }
        public void EliminarPersona(string CI, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrPeople.Where(d => d.CI == CI).FirstOrDefault();
                data.Estato = 2; // Baja                
                newcontexto.SaveChanges();
            }                
        }
        public List<ThrPeople> Actualizar(string conexion, int tipoPerson)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrPeople.Where(d => d.Nacionalitykey == tipoPerson).OrderBy(d => d.PersonKey).ToList();
                var listaObj = data;
                return listaObj;
            }
        }
        public List<ThrPeople> DevolverPersonas(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrPeople.ToList();
                return data;
            }
        }
    }
}
