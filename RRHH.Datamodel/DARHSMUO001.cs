using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.General;
using Sage500AppModel;

namespace RRHH.Datamodel
{
    public class DARHSMUO001
    {
        public ThrOrganizativeUnit BuscarUnidadOrganiza(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var unidadOrg = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitID == cod).FirstOrDefault();
                return unidadOrg;
            }
        }
        public List<ThrOrganizativeUnit> BuscarUnidadXCompania (string company)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var unidadOrg = newcontexto.ThrOrganizativeUnits.Where(d => d.CompanyID == company).ToList();
                return unidadOrg;
            }
        }
        public ThrOrganizativeUnit BuscarUnidadOrganizaName(string name)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var unidadOrg = newcontexto.ThrOrganizativeUnits.Where(d => d.Name == name).FirstOrDefault();
                return unidadOrg;
            }
        }
        public ThrOrganizativeUnit BuscarUnidadOrganizaXKey(int unitKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var unidadOrg = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitKey == unitKey).FirstOrDefault();
                return unidadOrg;
            }
        }
        public ThrOrganizativeUnit BuscarUnidadOrganizativaID(string ID)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var unidadOrg = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitID == ID).FirstOrDefault();
                return unidadOrg;
            }
        }
        public TglSegment BuscarSegmento(int acctseg)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.TglSegments.Where(d => d.AcctSegID == acctseg).FirstOrDefault();                
                return data;
            }
        }
        public TglSegmentCode BuscarSegmentoKey(string acctseg)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var seg = newcontexto.TglSegmentCodes.Where(d => d.AcctSegValue == acctseg).FirstOrDefault();
                return seg;
            }
        }
        public List<TglSegmentCode> BuscarCentroCosto(int segmento)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.TglSegmentCodes.Where(d => d.SegmentKey == segmento).ToList();                
                return data;
            }
        }
        public TglSegmentCode BuscarCentro(string acctsegvalue, int segmento)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.TglSegmentCodes.Where(d => d.AcctSegValue == acctsegvalue && d.SegmentKey == segmento).FirstOrDefault();
                return data;
            }
        }
        public ThrCompany BuscarCompany(string companyname)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrCompanies.Where(d => d.CodigoCompany == companyname).FirstOrDefault();
                return data;
            }
        }
        public bool BuscarDependencias(ThrOrganizativeUnit unidadOrganizat)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                bool dato = false;
                var obj = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitID == unidadOrganizat.OrgUnitID).FirstOrDefault();
                if (obj != null)
                {
                    var listaTurnos = newcontexto.ThrUnitTurnos.Where(x => x.OrgUnitKey == obj.OrgUnitKey).ToList();
                    if (listaTurnos.Count > 0)
                    {
                        foreach (ThrUnitTurno item in listaTurnos)
                        {
                            var resultado = newcontexto.ThrPeople.Where(x => x.TurnoKey == item.TurnoKey).FirstOrDefault();
                            if (resultado != null)
                            {
                               dato = true;
                            }
                        }
                    }
                    else { dato = false; }
                }
                else { dato = false; }
                return dato;
            }

        }
        public List<ThrUnitTurno> BuscarTurnosXUnidad(int unidadKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var lista = newcontexto.ThrUnitTurnos.Where(x => x.OrgUnitKey == unidadKey).ToList();
                return lista;
            }
        }
        public void AdicionarUnidadOrganizativa(ThrOrganizativeUnit unidadOrganizat, List<clsTurnoHorario> lista)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {               
                var obj = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitID == unidadOrganizat.OrgUnitID).FirstOrDefault();
                if (obj != null)
                {
                    bool resultado = this.BuscarDependencias(unidadOrganizat);
                    if (!resultado)
                    {
                        var listaTurnos = newcontexto.ThrUnitTurnos.Where(x => x.OrgUnitKey == obj.OrgUnitKey).ToList();
                        obj.OrgUnitID = unidadOrganizat.OrgUnitID;
                        obj.Name = unidadOrganizat.Name;
                        obj.CostCenter = unidadOrganizat.CostCenter;
                        obj.Description = unidadOrganizat.Description;
                        obj.Horariokey = unidadOrganizat.Horariokey;
                        foreach (ThrUnitTurno item in listaTurnos)
                        {
                            newcontexto.DeleteObject(item);
                        }                        
                        foreach (clsTurnoHorario item in lista)
                        {
                            var unidadTurno = new ThrUnitTurno();
                            unidadTurno.OrgUnitKey = obj.OrgUnitKey;
                            unidadTurno.TurnoName = item.turnoName;
                            unidadTurno.TurnoHorarioKey = item.horarioKey;
                            newcontexto.AddToThrUnitTurnos(unidadTurno);
                        }
                    }
                }
                else
                {                   
                    newcontexto.AddToThrOrganizativeUnits(unidadOrganizat);
                    newcontexto.SaveChanges();
                    var unidad = newcontexto.ThrOrganizativeUnits.Where(x => x.OrgUnitID == unidadOrganizat.OrgUnitID).FirstOrDefault();
                    foreach (clsTurnoHorario item in lista)
                    {
                        var unidadTurno = new ThrUnitTurno();                       
                        unidadTurno.OrgUnitKey = unidad.OrgUnitKey;
                        unidadTurno.TurnoName = item.turnoName;
                        unidadTurno.TurnoHorarioKey = item.horarioKey;
                        newcontexto.AddToThrUnitTurnos(unidadTurno);
                    }                  
                }
                newcontexto.SaveChanges();

            }           

        }
        public void EliminarUnidadOrganizativa(string cod, List<ThrUnitTurno> listadoturnos)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrOrganizativeUnit data;
                data = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitID == cod).FirstOrDefault();
                foreach (ThrUnitTurno item in listadoturnos)
                {
                    var unitTurno = newcontexto.ThrUnitTurnos.Where(d => d.TurnoKey == item.TurnoKey).FirstOrDefault();
                    newcontexto.DeleteObject(unitTurno);
                }
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public bool BuscarDependenciasUnidadOrganizativa(ThrOrganizativeUnit unidadOrg)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidad = newcontexto.ThrOrgUnitPositions.Where(d => d.OrgUnitKey == unidadOrg.OrgUnitKey).ToList();
                if(cantidad.Any())
                { return true; }
                else { return false; }               
            }
        }
        public List<ThrOrganizativeUnit> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrOrganizativeUnits.ToList();
                List<ThrOrganizativeUnit> listaObj = data;
                return listaObj;
            }
        }
        public ThrOrganizativeUnit BuscarUnidadOrganizKey(int unitKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrOrganizativeUnit unidadOrg = new ThrOrganizativeUnit();
                unidadOrg = newcontexto.ThrOrganizativeUnits.Where(d => d.OrgUnitKey == unitKey).FirstOrDefault();
                return unidadOrg;
            }
        }
        public ThrUnitTurno BuscarTurnoKey(int unitKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var turno = newcontexto.ThrUnitTurnos.Where(d => d.TurnoKey == unitKey).FirstOrDefault();
                return turno;
            }
        }
        public ThrUnitTurno BuscarTurnoName(string turnoID)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var turno = newcontexto.ThrUnitTurnos.Where(d => d.TurnoName == turnoID).FirstOrDefault();
                return turno;
            }
        }
        public List<ThrUnitTurno> BuscarTurnos()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var turnos = newcontexto.ThrUnitTurnos.ToList();
                return turnos;
            }
        }

    }
}
