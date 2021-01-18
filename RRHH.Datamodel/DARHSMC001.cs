using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Entidades.General;
using System.Transactions;

namespace RRHH.Datamodel
{

    public class DARHSMC001
    {        
        //List<clsCompetencias> lista;
        public ThrPosition BuscarCargo(string cargo)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrPosition position = new ThrPosition();
                position = newcontexto.ThrPositions.Where(d => d.Codigo == cargo).FirstOrDefault();
                return position;
            }
        }
        public ThrPosition BuscarCargoName(string cargoName)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrPosition position = new ThrPosition();
                position = newcontexto.ThrPositions.Where(d => d.PositionID == cargoName).FirstOrDefault();
                return position;
            }
        }
        public ThrPosition BuscarCargoXkey(int cargoKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrPosition position = new ThrPosition();
                position = newcontexto.ThrPositions.Where(d => d.PositionKey == cargoKey).FirstOrDefault();
                return position;
            }
        }
        public List<ThrPosition> BuscarCargosXUnidad(int unidadOrgKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrPosition nuevo;
                List<ThrPosition> lista = new List<ThrPosition>();
                var buscar = (from a in newcontexto.ThrPositions
                              join w in newcontexto.ThrOrgUnitPositions on a.PositionKey equals w.PositionKey
                              where
                               w.OrgUnitKey == unidadOrgKey
                              select new
                              {
                                  positionKey = a.PositionKey,
                                  positionID = a.PositionID,                                  
                              }).ToList();


                for (int i = 0; i < buscar.Count; i++)
                {
                    nuevo = new ThrPosition();
                    nuevo.PositionKey = buscar[i].positionKey;
                    nuevo.PositionID = buscar[i].positionID;                   
                    lista.Add(nuevo);
                }
                return lista;
            }
        }
        public void EliminarCargo(ThrPosition cargo)
        {
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    var listOrgUnitPosition = newcontexto.ThrOrgUnitPositions.Where(d => d.PositionKey == cargo.PositionKey).ToList();
                    var listaCondicionAnorm = newcontexto.ThrAnormalCondPositions.Where(d => d.PositionKey == cargo.PositionKey).ToList();
                    var listaCompetenciasXCargo = newcontexto.ThrCompetenciaCargos.Where(d => d.Positionkey == cargo.PositionKey).ToList();
                    var listaCondicionLaborales = newcontexto.ThrPositionConditionLabs.Where(d => d.PositionKey == cargo.PositionKey).ToList();
                    var listaRiesgosLaborales = newcontexto.ThrPositionRisks.Where(d => d.PositionKey == cargo.PositionKey).ToList();

                    if (listOrgUnitPosition.Any())
                    {
                        for (int i = 0; i < listOrgUnitPosition.Count; i++)
                        {
                            newcontexto.DeleteObject(listOrgUnitPosition[i]);
                            newcontexto.SaveChanges();
                        }
                    }
                    if (listaCondicionAnorm.Any())
                    {
                        for (int i = 0; i < listaCondicionAnorm.Count; i++)
                        {
                            newcontexto.DeleteObject(listaCondicionAnorm[i]);
                            newcontexto.SaveChanges();

                        }
                    }
                    if (listaCompetenciasXCargo.Any())
                    {
                        for (int i = 0; i < listaCompetenciasXCargo.Count; i++)
                        {
                            newcontexto.DeleteObject(listaCompetenciasXCargo[i]);
                            newcontexto.SaveChanges();
                        }
                    }
                   
                    if (listaCondicionLaborales.Any())
                    {
                        for (int i = 0; i < listaCondicionLaborales.Count; i++)
                        {
                            newcontexto.DeleteObject(listaCondicionLaborales[i]);
                            newcontexto.SaveChanges();
                        }
                    }
                    if (listaRiesgosLaborales.Any())
                    {
                        for (int i = 0; i < listaRiesgosLaborales.Count; i++)
                        {
                            newcontexto.DeleteObject(listaRiesgosLaborales[i]);
                            newcontexto.SaveChanges();
                        }
                    }
                    var cargoEliminar = newcontexto.ThrPositions.Where(d => d.PositionKey == cargo.PositionKey).FirstOrDefault();
                    newcontexto.DeleteObject(cargoEliminar);
                    newcontexto.SaveChanges();
                }               
                cont.Complete();
                cont.Dispose();
            }
        }
        public void AdicionarCargo(ThrPosition cargo, List<clsUnidadesOrganizativas> listadoUnidadesOrg, List<clsCondicionesAnormales> listadoCondiciones, List<clsCompetencias> listadoCompetencias, List<clsCondicionLaboral> listadoCondicionesLab, List<clsRiesgo> listadoRiegosLab)
        {
            int positionkey;
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {

                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    ThrPosition objPosition = newcontexto.ThrPositions.Where(d => d.Codigo == cargo.Codigo).FirstOrDefault();
                    if (objPosition != null)
                    {
                        var listOrgUnitPosition = newcontexto.ThrOrgUnitPositions.Where(d => d.PositionKey == objPosition.PositionKey).ToList();
                        var listaCondicionAnorm = newcontexto.ThrAnormalCondPositions.Where(d => d.PositionKey == objPosition.PositionKey).ToList();
                        var listaCompetencias = newcontexto.ThrCompetenciaCargos.Where(d => d.Positionkey == objPosition.PositionKey).ToList();
                        var listaCondicionesLab = newcontexto.ThrPositionConditionLabs.Where(d => d.PositionKey == objPosition.PositionKey).ToList();
                        var listaRiesgosLab = newcontexto.ThrPositionRisks.Where(d => d.PositionKey == objPosition.PositionKey).ToList();

                        
                        objPosition.Codigo = cargo.Codigo;
                        objPosition.PositionID = cargo.PositionID;
                        objPosition.PositionDescription = cargo.PositionDescription;
                        objPosition.EscalaGroupkey = cargo.EscalaGroupkey;
                        objPosition.OcupationCategoryKey = cargo.OcupationCategoryKey;
                        objPosition.PagoxCargo = cargo.PagoxCargo;
                        objPosition.HoursExtrasPay = cargo.HoursExtrasPay;
                        objPosition.Estado = cargo.Estado;
                        objPosition.Mision = cargo.Mision;
                        objPosition.ClasificationWorker = cargo.ClasificationWorker;
                        objPosition.FunciResposabilidades = cargo.FunciResposabilidades;
                        if (listadoUnidadesOrg.Any())
                        {
                            if (listOrgUnitPosition.Any())
                            {
                                for (int i = 0; i < listOrgUnitPosition.Count; i++)
                                {
                                    newcontexto.DeleteObject(listOrgUnitPosition[i]);
                                    newcontexto.SaveChanges();
                                }
                            }
                            for (int j = 0; j < listadoUnidadesOrg.Count; j++)
                            {
                                var unitPosition = new ThrOrgUnitPosition
                                {
                                    PositionKey = objPosition.PositionKey,
                                    OrgUnitKey = listadoUnidadesOrg[j].OrgUnitKey,
                                };
                                newcontexto.AddToThrOrgUnitPositions(unitPosition);
                                newcontexto.SaveChanges();
                            }                        
                        }
                        if (listadoCondicionesLab.Any())
                        {
                            if (listaCondicionesLab.Any())
                            {
                                for (int i = 0; i < listaCondicionesLab.Count; i++)
                                {
                                    newcontexto.DeleteObject(listaCondicionesLab[i]);
                                    newcontexto.SaveChanges();
                                }
                            }
                            for (int j = 0; j < listadoCondicionesLab.Count; j++)
                            {
                                var CondPosition = new ThrPositionConditionLab
                                {
                                    PositionKey = objPosition.PositionKey,
                                    ConditionLabKey = listadoCondicionesLab[j].codicionLaboralKey,
                                };
                                newcontexto.AddToThrPositionConditionLabs(CondPosition);
                                newcontexto.SaveChanges();
                            }
                            
                        }
                        if (listadoCompetencias.Any())
                        {
                            if (listaCompetencias.Any())
                            {
                                for (int i = 0; i < listaCompetencias.Count; i++)
                                {
                                    newcontexto.DeleteObject(listaCompetencias[i]);
                                    newcontexto.SaveChanges();
                                }
                            }
                            for (int f = 0; f < listadoCompetencias.Count; f++)
                            {
                                var requerido = 0;
                                if (listadoCompetencias[f].requerido)
                                { requerido = 1; }
                                var CompetenciaPosition = new ThrCompetenciaCargo
                                {
                                    Competenciakey = listadoCompetencias[f].competenciakey,
                                    Positionkey = objPosition.PositionKey,
                                    Required = (SByte)requerido,
                                    Idnivel = listadoCompetencias[f].niveles,
                                };
                                newcontexto.AddToThrCompetenciaCargos(CompetenciaPosition);
                                newcontexto.SaveChanges();
                            }

                        }
                        if (listadoRiegosLab.Any())
                        {
                            if (listaRiesgosLab.Any())
                            {
                                for (int i = 0; i < listaRiesgosLab.Count; i++)
                                {
                                    newcontexto.DeleteObject(listaRiesgosLab[i]);
                                    newcontexto.SaveChanges();
                                }
                            }
                            for (int j = 0; j < listadoRiegosLab.Count; j++)
                            {
                                var objriesgoLab = new ThrPositionRisk
                                {
                                    PositionKey = objPosition.PositionKey,
                                    RiskKey = (SByte)listadoRiegosLab[j].riesgokey,
                                    Idnivel = listadoRiegosLab[j].nivel,
                                };
                                newcontexto.AddToThrPositionRisks(objriesgoLab);
                                newcontexto.SaveChanges();
                            }

                        }                       
                        if (listaCondicionAnorm.Any())
                        {
                            for (int i = 0; i < listaCondicionAnorm.Count; i++)
                            {
                                newcontexto.DeleteObject(listaCondicionAnorm[i]);
                                newcontexto.SaveChanges();
                            }
                        }
                        for (int j = 0; j < listadoCondiciones.Count; j++)
                        {
                            var unitPosition = new ThrAnormalCondPosition
                            {
                                PositionKey = objPosition.PositionKey,
                                AnormalConditionKey = (SByte)listadoCondiciones[j].AnormalConditionkey,
                            };
                            newcontexto.AddToThrAnormalCondPositions(unitPosition);
                            newcontexto.SaveChanges();
                        }
                        
                    }
                    else
                    {
                        //using (var contexto = new Sage500AppEntities(conex))
                        //{
                        var buscar = (from a in newcontexto.ThrPositions
                                      orderby a.PositionKey descending
                                      select a.PositionKey
                                        ).ToList();
                        if (buscar.Any())
                        {
                            positionkey = Convert.ToInt32(buscar.First()) + 1;
                        }
                        else
                        {
                            positionkey = 1;
                        }
                        objPosition = new ThrPosition();
                        objPosition.PositionKey = Convert.ToInt16(positionkey);
                        objPosition.Codigo = cargo.Codigo;
                        objPosition.PositionID = cargo.PositionID;
                        objPosition.ClasificationWorker = cargo.ClasificationWorker;
                        objPosition.Estado = cargo.Estado;
                        objPosition.EscalaGroupkey = cargo.EscalaGroupkey;
                        objPosition.OcupationCategoryKey = cargo.OcupationCategoryKey;
                        objPosition.PagoxCargo = cargo.PagoxCargo;
                        objPosition.HoursExtrasPay = cargo.HoursExtrasPay;
                        objPosition.PositionDescription = cargo.PositionDescription;
                        objPosition.Mision = cargo.Mision;
                        objPosition.FunciResposabilidades = cargo.FunciResposabilidades;
                        objPosition.RegisterDate = cargo.RegisterDate;
                        newcontexto.AddToThrPositions(objPosition);
                        newcontexto.SaveChanges();
                        for (int j = 0; j < listadoUnidadesOrg.Count; j++)
                        {
                            var unitPosition = new ThrOrgUnitPosition
                            {
                                PositionKey = Convert.ToInt16(positionkey),
                                OrgUnitKey = listadoUnidadesOrg[j].OrgUnitKey,
                            };
                            newcontexto.AddToThrOrgUnitPositions(unitPosition);
                        }
                        for (int f = 0; f < listadoCondiciones.Count; f++)
                        {
                            var condPosition = new ThrAnormalCondPosition
                            {
                                PositionKey = Convert.ToInt16(positionkey),
                                AnormalConditionKey = (SByte)listadoCondiciones[f].AnormalConditionkey,
                            };
                            newcontexto.AddToThrAnormalCondPositions(condPosition);
                        }
                        for (int i = 0; i < listadoCompetencias.Count; i++)
                        {
                            var requerid = listadoCompetencias[i].requerido;
                            int result = 0;
                            if (requerid)
                            {
                                result = 1;
                            }
                            else { result = 0; }

                            var competenciaCargo = new ThrCompetenciaCargo
                            {
                                Positionkey = Convert.ToInt16(positionkey),
                                Competenciakey = listadoCompetencias[i].competenciakey,
                                Required = (SByte)result,
                                Idnivel = listadoCompetencias[i].niveles,
                            };
                            newcontexto.AddToThrCompetenciaCargos(competenciaCargo);
                        }
                        for (int h = 0; h < listadoRiegosLab.Count; h++)
                        {
                            var objPositionRiesgo = new ThrPositionRisk
                            {
                                PositionKey = objPosition.PositionKey,
                                RiskKey = (SByte)listadoRiegosLab[h].riesgokey,
                                Idnivel = listadoRiegosLab[h].nivel,
                            };
                            newcontexto.AddToThrPositionRisks(objPositionRiesgo);
                        }
                        newcontexto.SaveChanges();
                        for (int h = 0; h < listadoCondicionesLab.Count; h++)
                        {
                            var condPosition = new ThrPositionConditionLab
                            {
                                PositionKey = Convert.ToInt16(positionkey),
                                ConditionLabKey = listadoCondicionesLab[h].codicionLaboralKey,
                            };
                            newcontexto.AddToThrPositionConditionLabs(condPosition);
                        }
                        newcontexto.SaveChanges();

                    }
                }
                cont.Complete();
                cont.Dispose();
            }
        }       
        public int BuscarDependenciasConCargo(int cargokey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidadUniPosition = newcontexto.ThrPeople.Where(d => d.PositionKey == cargokey).Count();               
                return cantidadUniPosition;
            }
           
        }
        public List<ThrPosition> Actualizar(int unidadKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cargos = newcontexto.ThrOrgUnitPositions.Where(d => d.OrgUnitKey == unidadKey).ToList();
                List<ThrPosition> listaActualizada = new List<ThrPosition>();
                foreach (ThrOrgUnitPosition item in cargos)
                {
                    var cargo = newcontexto.ThrPositions.Where(d => d.PositionKey == item.PositionKey).FirstOrDefault();
                    listaActualizada.Add(cargo);
                }
                return listaActualizada;
            }
        }
        public List<ThrOrgUnitPosition> BuscarOrgUnidadesPosition(int positionKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listOrgUnitPosition = newcontexto.ThrOrgUnitPositions.Where(d => d.PositionKey == positionKey).ToList();                
                return listOrgUnitPosition;
            }
        } 
        public ThrEscalaGroup BuscarGroupEscala(int groupescalagKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrEscalaGroups.Where(d => d.EscalaGroupkey == groupescalagKey).FirstOrDefault();                
                return data;
            }
        }
        public List<ThrAnormalCondPosition> BuscarAnormalCondPosition(int positionKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listAnormaOrgUnitPosition = newcontexto.ThrAnormalCondPositions.Where(d => d.PositionKey == positionKey).ToList();
                return listAnormaOrgUnitPosition;
            }
        }
    }
}
