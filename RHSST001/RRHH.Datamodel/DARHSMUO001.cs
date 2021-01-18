using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sage500AppModel;

namespace RRHH.Datamodel
{
    public class DARHSMUO001
    {
        public ThrOrganizativeUnit BuscarUnidadOrganiza(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var unidadOrg = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitID == cod).FirstOrDefault();
                return unidadOrg;
            }
        }
        public List<ThrOrganizativeUnit> BuscarUnidadXCompania (string company, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var unidadOrg = newcontexto.ThrOrganizativeUnits.Where(d => d.CompanyID == company).ToList();
                return unidadOrg;
            }
        }
        public ThrOrganizativeUnit BuscarUnidadOrganizaName(string name, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var unidadOrg = newcontexto.ThrOrganizativeUnits.Where(d => d.Name == name).FirstOrDefault();
                return unidadOrg;
            }
        }
        public ThrOrganizativeUnit BuscarUnidadOrganizaXKey(int unitKey, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var unidadOrg = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitKey == unitKey).FirstOrDefault();
                return unidadOrg;
            }
        }
        public ThrOrganizativeUnit BuscarUnidadOrganizativaID(string ID, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var unidadOrg = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitID == ID).FirstOrDefault();
                return unidadOrg;
            }
        }
        public TglSegment BuscarSegmento(int acctseg, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.TglSegments.Where(d => d.AcctSegID == acctseg).FirstOrDefault();                
                return data;
            }
        }
        public TglSegmentCode BuscarSegmentoKey(string acctseg, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var seg = newcontexto.TglSegmentCodes.Where(d => d.AcctSegValue == acctseg).FirstOrDefault();
                return seg;
            }
        }
        public List<TglSegmentCode> BuscarCentroCosto(string conexion, int segmento)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.TglSegmentCodes.Where(d => d.SegmentKey == segmento).ToList();                
                return data;
            }
        }
        public TglSegmentCode BuscarCentro(string conexion, string acctsegvalue, int segmento)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.TglSegmentCodes.Where(d => d.AcctSegValue == acctsegvalue && d.SegmentKey == segmento).FirstOrDefault();
                return data;
            }
        }
        public ThrCompany BuscarCompany(string conexion, string companyname)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrCompanies.Where(d => d.CodigoCompany == companyname).FirstOrDefault();
                return data;
            }
        }       
        public void AdicionarUnidadOrganizativa(ThrOrganizativeUnit unidadOrganizat, string conex)
        {
            try
            {
                using (var newcontexto = new Sage500AppEntities(conex.ToString()))
                {
                    ThrOrganizativeUnit obj = new ThrOrganizativeUnit();
                    obj = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitID == unidadOrganizat.OrgUnitID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.OrgUnitID = unidadOrganizat.OrgUnitID;
                        obj.Name = unidadOrganizat.Name;                        
                        obj.CostCenter = unidadOrganizat.CostCenter;
                        obj.Description = unidadOrganizat.Description;

                    }
                    else
                    {
                        newcontexto.AddToThrOrganizativeUnits(unidadOrganizat);
                    }
                    newcontexto.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
           

        }
        public void EliminarUnidadOrganizativa(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                ThrOrganizativeUnit data;
                data = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitID == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasUnidadOrganizativa(ThrOrganizativeUnit unidadOrg, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var cantidad = newcontexto.ThrOrgUnitPositions.Where(d => d.OrgUnitKey == unidadOrg.OrgUnitKey).ToList();
                return cantidad.Count;
            }
        }
        public List<ThrOrganizativeUnit> Actualizar(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrOrganizativeUnits.ToList();
                List<ThrOrganizativeUnit> listaObj = data;
                return listaObj;
            }
        }
        public ThrOrganizativeUnit BuscarUnidadOrganizKey(int unitKey, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                ThrOrganizativeUnit unidadOrg = new ThrOrganizativeUnit();
                unidadOrg = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitKey == unitKey).FirstOrDefault();
                return unidadOrg;
            }
        }

    }
}
