using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.General;
using RRHH.Datamodel;
using Sage500AppModel;

namespace Negocio
{
    public class ControllerRHSMC001
    {        
        DARHSMC001 dataAccess;        
        public void AddCargo(clsCargo objcargo)
        {
            dataAccess = new DARHSMC001();
            var position = new ThrPosition();
            position.Codigo = objcargo.codigo;
            position.PositionID = objcargo.nombrecargo;
            position.PositionDescription = objcargo.descripcion;
            position.Estado = Convert.ToInt16(objcargo.estado);
            position.EscalaGroupkey = Convert.ToInt16(objcargo.grupoescala);
            position.OcupationCategoryKey = Convert.ToInt16(objcargo.categoriaOcupacional);
            position.HoursExtrasPay = objcargo.horasExtraspagar;
            position.PagoxCargo = objcargo.pagoxcargo;
            position.RegisterDate = objcargo.fechaCreacion;
            position.Mision = objcargo.mision;
            position.ClasificationWorker = Convert.ToInt16(objcargo.clasficacionTrabajador);
            position.FunciResposabilidades = objcargo.funcionesRespons;
            dataAccess.AdicionarCargo(position, objcargo.ListAreasOrganizativas, objcargo.ListCondicionesAnormales, objcargo.ListCompetencias, objcargo.ListaCondicionesLaborales, objcargo.ListaRiesgosLaborales);           
        }
        public ThrPosition GetCargo(string codigo)
        {
            dataAccess = new DARHSMC001();
            ThrPosition datacargo = dataAccess.BuscarCargo(codigo);
            return datacargo;
        }

        public ThrPosition GetCargoXKey(int positionKey)
        {
            dataAccess = new DARHSMC001();
            ThrPosition datacargo = dataAccess.BuscarCargoXkey(positionKey);
            return datacargo;
        }
        public ThrPosition GetCargoName(string name)
        {
            dataAccess = new DARHSMC001();
            ThrPosition datacargo = dataAccess.BuscarCargoName(name);
            return datacargo;
        }
        public List<ThrPosition> GetAllCargosxUnidad(int unit)
        {
            dataAccess = new DARHSMC001();
            var datacargo = dataAccess.BuscarCargosXUnidad(unit);
            return datacargo;
        }
        public clsCargo CargarDatosObjCargo(string cargo)
        {
            DARHSMUO001 access = new DARHSMUO001();
            DARHSMCA001 dataccess = new DARHSMCA001();
            DARHSMCL001 dataacces = new DARHSMCL001();
            DARHSMCP001 data = new DARHSMCP001();
            DARHSMR001 acceso = new DARHSMR001();
            clsCargo objCargo = new clsCargo();          
            dataAccess = new DARHSMC001();
            ThrPosition datacargo = dataAccess.BuscarCargo(cargo);
            var listOrgUnitPosition = dataAccess.BuscarOrgUnidadesPosition(datacargo.PositionKey);
            var listAnormCondPosition = dataAccess.BuscarAnormalCondPosition(datacargo.PositionKey);
            var listCompetencias = data.BuscarCompetenciasXCargo(datacargo.PositionKey);
            var listCondLaboralesXCargo = dataacces.BuscarCondicionesPosition(datacargo.PositionKey);
            var listRiesgosLaboralesXCargo = acceso.BuscarRiesgosXCargo(datacargo.PositionKey);

            objCargo.codigo = datacargo.Codigo;
            objCargo.nombrecargo = datacargo.PositionID;
            objCargo.horasExtraspagar = Convert.ToInt32(datacargo.HoursExtrasPay);
            objCargo.pagoxcargo = Convert.ToDecimal(datacargo.PagoxCargo);
            objCargo.descripcion = datacargo.PositionDescription;
            objCargo.categoriaOcupacional = datacargo.OcupationCategoryKey;
            objCargo.grupoescala = datacargo.EscalaGroupkey;
            objCargo.mision = datacargo.Mision;
            objCargo.funcionesRespons = datacargo.FunciResposabilidades;
            objCargo.fechaCreacion = datacargo.RegisterDate;
            objCargo.estado = datacargo.Estado;

            List<clsUnidadesOrganizativas> listunidades = new List<clsUnidadesOrganizativas>();
            List<clsCondicionesAnormales> listacondanormales = new List<clsCondicionesAnormales>();
            List<clsCompetencias> listacompetencias = new List<clsCompetencias>();
            List <clsCondicionLaboral> listacondicionesLab = new List<clsCondicionLaboral>();
            List<clsRiesgo> listaRiesgosLab = new List<clsRiesgo>();
            for (int i = 0; i < listOrgUnitPosition.Count; i++)
            {
                var area = access.BuscarUnidadOrganizKey(listOrgUnitPosition[i].OrgUnitKey);
                clsUnidadesOrganizativas objunidades = new clsUnidadesOrganizativas();
                objunidades.name = area.Name;
                objunidades.unidadOrgID = area.OrgUnitID;
                objunidades.descripcion = area.Description;
                objunidades.costCenter = area.CostCenter;
                listunidades.Add(objunidades);                
            }
            objCargo.ListAreasOrganizativas = listunidades;

            for (int i = 0; i < listCompetencias.Count; i++)
            {
                var comp = data.BuscarCompetencia(listCompetencias[i].Competenciakey);
                clsCompetencias objcomp = new clsCompetencias();
                objcomp.nombre = comp.CompetenciaID;
                objcomp.descripcion = comp.CompetenciaDescrip;
                objcomp.tipo = comp.TipoCompetencia;
                objcomp.niveles = listCompetencias[i].Idnivel;
                if (listCompetencias[i].Required == 1)
                {
                    objcomp.requerido = true;
                }
                else { objcomp.requerido = false; }                
                listacompetencias.Add(objcomp);
            }
            objCargo.ListCompetencias = listacompetencias;
            for (int i = 0; i < listAnormCondPosition.Count; i++)
            {
                var anormalCondicion = dataccess.BuscarCondicionAnormalKey(listAnormCondPosition[i].AnormalConditionKey);              
                clsCondicionesAnormales objcondiciones = new clsCondicionesAnormales();
                objcondiciones.anormalconditionID = anormalCondicion.AnormalCondID;
                objcondiciones.amormalname = anormalCondicion.AnormalName;
                objcondiciones.anormalresolution = anormalCondicion.AnormalResolution;
                listacondanormales.Add(objcondiciones);               
            }
            objCargo.ListCondicionesAnormales = listacondanormales;
            for (int f = 0; f < listCondLaboralesXCargo.Count; f++)
            {
                var conditionLab = dataacces.BuscarConditionlaboral(listCondLaboralesXCargo[f].ConditionLabKey);
                clsCondicionLaboral objcondicionesLab = new clsCondicionLaboral();
                objcondicionesLab.codicionLaboralID = conditionLab.ConditionlabID;
                objcondicionesLab.codicionLaboralDescrip = conditionLab.ConditionLabDescription;
                listacondicionesLab.Add(objcondicionesLab);
            }
            objCargo.ListaCondicionesLaborales = listacondicionesLab;
            for (int f = 0; f < listRiesgosLaboralesXCargo.Count; f++)
            {
                var RiesgoLab = acceso.BuscarRiesgo(listRiesgosLaboralesXCargo[f].RiskKey);
                var objRiesgoLab = new clsRiesgo();
                objRiesgoLab.nombreRiesgo = RiesgoLab.RiskID;
                objRiesgoLab.descripcionRiesgo = RiesgoLab.RiskDescription;
                objRiesgoLab.nivel = listRiesgosLaboralesXCargo[f].Idnivel;
                objRiesgoLab.tipo = RiesgoLab.RiskType;
                listaRiesgosLab.Add(objRiesgoLab);
            }
            objCargo.ListaRiesgosLaborales = listaRiesgosLab;
            return objCargo; 
        }
        public List<ThrPosition> ActualizarLista( int unidadKey)
        {
            dataAccess = new DARHSMC001();
            var positions = dataAccess.Actualizar(unidadKey);
            return positions;
        }
        public string GetGroupEscala(int grupoescalaKey)
        {
            DARHSMC001 dataAccess = new DARHSMC001();
            ThrEscalaGroup objCateg = dataAccess.BuscarGroupEscala(grupoescalaKey);
            return objCateg.EscalaGroupID;
        }
        public void DeleteCargo(ThrPosition cargo)
        {
            dataAccess = new DARHSMC001();
            dataAccess.EliminarCargo(cargo);          
        }
        public bool BuscarDependenciasCargo(int positionkey)
        {
            dataAccess = new DARHSMC001();
            int depend = dataAccess.BuscarDependenciasConCargo(positionkey);
            if (depend > 0) { return true; }
            return false;            
        }
    }
}
