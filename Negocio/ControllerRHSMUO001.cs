using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.Datamodel;
using Entidades.General;

namespace Negocio
{
    public class ControllerRHSMUO001
    {
        DARHSMUO001 dataAccess;
        public clsUnidadesOrganizativas GetUnidadOrganizativa(string codigo)
        {
            dataAccess = new DARHSMUO001();
            var UnidadOrganizativa = new clsUnidadesOrganizativas();
            var unidadOrg = dataAccess.BuscarUnidadOrganiza(codigo);
            if (unidadOrg != null)
            {
                UnidadOrganizativa.OrgUnitKey = unidadOrg.OrgUnitKey;
                UnidadOrganizativa.descripcion = unidadOrg.OrgUnitID;
                UnidadOrganizativa.name = unidadOrg.Name;
                UnidadOrganizativa.costCenter = unidadOrg.CostCenter;
            }
            return UnidadOrganizativa;
        }
        public clsUnidadesOrganizativas GetUnidadOrganizativaName(string name)
        {
            dataAccess = new DARHSMUO001();
            var UnidadOrganizativa = new clsUnidadesOrganizativas();
            var unidadOrg = dataAccess.BuscarUnidadOrganizaName(name);
            if (unidadOrg != null)
            {
                UnidadOrganizativa.OrgUnitKey = unidadOrg.OrgUnitKey;
                UnidadOrganizativa.descripcion = unidadOrg.OrgUnitID;
                UnidadOrganizativa.name = unidadOrg.Name;
                UnidadOrganizativa.costCenter = unidadOrg.CostCenter;               
            }
            return UnidadOrganizativa;
        }
        public ThrOrganizativeUnit GetUnidadOrganizativ(string codigo)
        {
            dataAccess = new DARHSMUO001();
            var unidadOrg = dataAccess.BuscarUnidadOrganiza(codigo);
            return unidadOrg;
        }
        public List<ThrOrganizativeUnit> GetUnidadOrgaXCompania(string company)
        {
            dataAccess = new DARHSMUO001();
            var unidadOrg = dataAccess.BuscarUnidadXCompania(company);
            return unidadOrg;
        }
        public ThrOrganizativeUnit GetUnidadOrganizativaKey(int unidadkey)
        {
            dataAccess = new DARHSMUO001();
            var unidadOrg = dataAccess.BuscarUnidadOrganizaXKey(unidadkey);
            return unidadOrg;
        }
        public void AddUnidadOrganizativa(ThrOrganizativeUnit unitOrg, List<clsTurnoHorario> lista)
        {
            dataAccess = new DARHSMUO001();
            dataAccess.AdicionarUnidadOrganizativa(unitOrg, lista);
        }
        public bool DeleteUnidadOrganizativa(string cod, List<clsTurnoHorario> listaTurnos)
        {
            dataAccess = new DARHSMUO001();
            var unidadOrg = dataAccess.BuscarUnidadOrganiza(cod);
            bool dependenciasTurnos = dataAccess.BuscarDependencias(unidadOrg);
            bool dependenciasCargo = dataAccess.BuscarDependenciasUnidadOrganizativa(unidadOrg);           
            if (!dependenciasCargo)
            {
                if (!dependenciasTurnos)
                {
                    List<ThrUnitTurno> listado = new List<ThrUnitTurno>();
                    foreach (clsTurnoHorario item in listaTurnos)
                    {
                        var obj = dataAccess.BuscarTurnoName(item.turnoName);
                        listado.Add(obj);
                    }
                    dataAccess.EliminarUnidadOrganizativa(cod, listado);
                    return true;
                }              
            }
            return false;
        }
        public bool BuscarDependencias(ThrOrganizativeUnit unidadOrganizat)
        {
            dataAccess = new DARHSMUO001();
            var resultado = dataAccess.BuscarDependencias(unidadOrganizat);
            return resultado;
        }
        public List<ThrUnitTurno> BuscarTurnosXUnidad(int unidadOrganizatKey)
        {
            dataAccess = new DARHSMUO001();
            var listaTurnos = dataAccess.BuscarTurnosXUnidad(unidadOrganizatKey);
            return listaTurnos;
        }
        public List<ThrUnitTurno> BuscarTurnos()
        {
            dataAccess = new DARHSMUO001();
            var listaTurnos = dataAccess.BuscarTurnos();
            return listaTurnos;
        }
        public ThrUnitTurno BuscarTurno(int turnoKey)
        {
            dataAccess = new DARHSMUO001();
            var turno = dataAccess.BuscarTurnoKey(turnoKey);
            return turno;
        }
        public ThrUnitTurno BuscarTurnoName(string turnoname)
        {
            dataAccess = new DARHSMUO001();
            var turno = dataAccess.BuscarTurnoName(turnoname);
            return turno;
        }
        public List<ThrOrganizativeUnit> ActualizarLista()
        {
            dataAccess = new DARHSMUO001();
            List<ThrOrganizativeUnit> listunidadOrg = dataAccess.Actualizar();
            return listunidadOrg;
        }
        public List<TglSegmentCode> GetCentroCosto(int segmento)
        {
            dataAccess = new DARHSMUO001();
            var listobjCenter = dataAccess.BuscarCentroCosto(segmento);
            return listobjCenter;
        }        
        public TglSegment DevolverSegmento(int acctSegID)
        {
            dataAccess = new DARHSMUO001();
            var segmento = dataAccess.BuscarSegmento(acctSegID);
            return segmento;
        }
        public TglSegmentCode DevolverSegmentoKey(string acctSegID)
        {
            dataAccess = new DARHSMUO001();
            var segmentokey = dataAccess.BuscarSegmentoKey(acctSegID);
            return segmentokey;
        }
        public int BuscarNoSeg(string nameCompany)
        {
            dataAccess = new DARHSMUO001();
            var company = dataAccess.BuscarCompany(nameCompany);
            if (company != null)
            {
                return company.NoSegmentoCentro;
            }
            else
            { return 0; }
        }
        public TglSegmentCode BuscarCentro(string acctsegvalue,int segmentokey)
        {
            dataAccess = new DARHSMUO001();
            var centro = dataAccess.BuscarCentro(acctsegvalue, segmentokey);
            return centro;
        }
    }   
}
