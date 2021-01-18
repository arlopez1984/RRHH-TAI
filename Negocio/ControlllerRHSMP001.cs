using Sage500AppModel;
using System.Collections.Generic;
using RRHH.Datamodel;
using System;

namespace Negocio
{ 
    public class ControlllerRHSMP001
    {  
        DARHSMP001 dataAccess;
        public ControlllerRHSMP001()
        {            
           
        }        
        public ThrPeople GetPersona(string CI)
        {
            dataAccess = new DARHSMP001();
            var person = dataAccess.BuscarPersona(CI);
            return person;
        }
        public bool GetPersonaXUnidadAdministrativa(int unidadAdminKey)
        {
            dataAccess = new DARHSMP001();
            var result = dataAccess.BuscarPersonaXUnidadAdmin(unidadAdminKey);
            return result;
        }
        public string GetPersonaXKey(int personKey)
        {
            dataAccess = new DARHSMP001();
            var person = dataAccess.BuscarPersonaxKey(personKey);
            return person.PrimerNombre + " " + " " + person.SegundoNombre + " " + " " + person.PrimerApellido + " " + " " + person.SegundoApellido;

        }
        public void AddPerson(ThrPeople persona)
        {
            dataAccess = new DARHSMP001();            
            dataAccess.AdicionarPersona(persona);  
        }
        public void DeletePerson(string CI)
        {
            dataAccess = new DARHSMP001();
            dataAccess.EliminarPersona(CI);
        }        
        public List<ThrNacionality> GetaAllsNacionalyties()
        {
            dataAccess = new DARHSMP001();
            List<ThrNacionality> listNacionality = dataAccess.BuscarNacionalidades();
            return listNacionality;
        }
        public string GetNacionality(int nacionalitykey)
        {
            dataAccess = new DARHSMP001();
            ThrNacionality objNacionality = dataAccess.BuscarNacionalidad(nacionalitykey);
            return objNacionality.NacionalityName;
        }
        public string GetProvince(int provinceKey)
        {
            dataAccess = new DARHSMP001();
            ThrState objProvincia = dataAccess.BuscarProvincia(provinceKey);
            return objProvincia.StateID;
        }
        public string GetUnidadAdmin(int unidad)
        {
            dataAccess = new DARHSMP001();
            var objUnidad = dataAccess.BuscarUnidadOrg(unidad);
            return objUnidad.Name;
        }
        public ThrState GetProvinceXName(string name)
        {
            dataAccess = new DARHSMP001();
            var objProvincia = dataAccess.BuscarProvinciaXName(name);
            return objProvincia;
        }
        public string GetMunicipality(int municipality)
        {
            dataAccess = new DARHSMP001();
            var objmunicipip = dataAccess.BuscarMunicipio(municipality);
            return objmunicipip.MunicipalityID;
        }
        public string GetPosition(int cargo)
        {
            dataAccess = new DARHSMP001();
            ThrPosition objposition = dataAccess.BuscarCargo(cargo);
            return objposition.PositionID;
        }
        public string GetCulturalLevel(int culturalLevel)
        {
            dataAccess = new DARHSMP001();
            ThrCulturalLevel objcultu = dataAccess.BuscarNivelCultural(culturalLevel);
            return objcultu.CulturalID;
        }
        public string GetCategoriaOcupacional(int categoria)
        {
            dataAccess = new DARHSMP001();
            ThrOcupationalCategory objCateg = dataAccess.BuscarCategoriaOcupacional(categoria);
            return objCateg.CategoryID;
        }
        public string GetCategoriaScientifica(int categoria)
        {
            dataAccess = new DARHSMP001();
            ThrScientificCategory objCategScient = dataAccess.BuscarCategoriaScientifica(categoria);
            return objCategScient.ScientificCategoryID;
        }
        public string GetClasifOcupacional(int clasifOcup)
        {
            dataAccess = new DARHSMP001();
            ThrOcupationClasification objclasifocup = dataAccess.BuscarClasificacionOcupacional(clasifOcup);
            return objclasifocup.SpecialtyID;
        }
        public string GetWorkerType(int Tipoworkey)
        {
            dataAccess = new DARHSMP001();
            ThrWorkerType objtipoTrab = dataAccess.BuscarTipoTrabajador(Tipoworkey);
            return objtipoTrab.WorkerTypeID;
        }
        public string GetCodWorker()
        {
            var codigofabrica = "TBG";
            dataAccess = new DARHSMP001();
            var codigo = dataAccess.BuscarUltimoCodigo();

            if (codigo != "")
            {
                var result = codigo.Remove(0, 3);
                var conversion = Convert.ToDecimal(result) + 1;
                if (conversion < 100)
                {
                    var variable = Convert.ToDecimal(conversion / 100).ToString();
                    var resultado = variable.Replace(".", "");
                    return codigofabrica + resultado;
                }
                else if (conversion > 100)
                {
                    var variable = Convert.ToDecimal(conversion / 1000).ToString();
                    var resultado = variable.Replace(".", "");
                    return codigofabrica + resultado;
                }
                else { return codigofabrica + conversion; }
            }
            else { return codigofabrica + "001"; }
        }           
        public List<ThrPosition> GetaAllsPositions()
        {
            dataAccess = new DARHSMP001();
            List<ThrPosition> listposition = dataAccess.BuscarCargos();
            return listposition;
        }
        public List<ThrOrganizativeUnit> GetaAllsOrganizativeUnit(int cargo)
        {
            dataAccess = new DARHSMP001();
            var listUnidades = dataAccess.BuscarAreasAdministrativas(cargo);
            return listUnidades;
        }
        public List<ThrOrganizativeUnit> GetaAllsOrganizativeUnit()
        {
            dataAccess = new DARHSMP001();
            var listUnidades = dataAccess.BuscarAreasAdministrativas();
            return listUnidades;
        }
        public List<ThrState> GetaAllsStates()
        {
            dataAccess = new DARHSMP001();
            var liststate = dataAccess.BuscarProvincias();
            return liststate;
        }
        public List<ThrMunicipality> GetaAllsMunicipalyties(int dat)
        {
            dataAccess = new DARHSMP001();
            List<ThrMunicipality> listMunic = dataAccess.BuscarMunicipios(dat);
            return listMunic;
        }
        public List<ThrCulturalLevel> GetaAllsNivelesCulturales()
        {
            dataAccess = new DARHSMP001();
            List<ThrCulturalLevel> listlevelcult = dataAccess.BuscarNivelesCulturales();
            return listlevelcult;           
        }
        public List<ThrScientificCategory> GetaAllsScientifCategories()
        {
            dataAccess = new DARHSMP001();
            List<ThrScientificCategory> listScientifCate = dataAccess.BuscarCategoriaCientificas();
            return listScientifCate;
        }
        public List<ThrOcupationalCategory> GetaAllsOcupationalCategories()
        {
            dataAccess = new DARHSMP001();
            List<ThrOcupationalCategory> listOcupationalCate = dataAccess.BuscarCategoriaOcupaionales();
            return listOcupationalCate;
        }
        public List<ThrWorkerType> GetaAllsWrokerTypes()
        {
            dataAccess = new DARHSMP001();
            List<ThrWorkerType> lisTiposTraba = dataAccess.BuscarTipoTrabajador();
            return lisTiposTraba;
        }
        public List<ThrOcupationClasification> GetaAllsOcupationClasi()
        {
            dataAccess = new DARHSMP001();
            List<ThrOcupationClasification> listOcupacionesClasif = dataAccess.BuscarClasificacionesOcupation();
            return listOcupacionesClasif;
        }
        public List<ThrPeople> ActualizarLista(int tipoPersona)
        {
            dataAccess = new DARHSMP001();
            var lisperson = dataAccess.Actualizar(tipoPersona);
            return lisperson;
        }
        public List<ThrPeople> DevolverTodos()
        {
            dataAccess = new DARHSMP001();
            var lisperson = dataAccess.DevolverPersonas();
            return lisperson;
        }
    }
}
