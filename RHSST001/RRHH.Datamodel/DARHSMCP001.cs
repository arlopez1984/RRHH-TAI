using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RRHH.Datamodel
{
    public class DARHSMCP001
    {
        public DARHSMCP001()
        {

        }
        public List<ThrCompetencia> BuscarCompetencias(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var competencias = newcontexto.ThrCompetencias.ToList();
                return competencias;
            }

        }
        public ThrCompetencia BuscarCompetenciaKey(string id, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var competencias = newcontexto.ThrCompetencias.Where(d => d.CompetenciaID == id).FirstOrDefault();
                return competencias;
            }

        }
        public ThrCompetencia BuscarCompetencia(int key, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var competencias = newcontexto.ThrCompetencias.Where(d => d.CompetenciaKey == key).FirstOrDefault();
                return competencias;
            }

        }
        public List<ThrCompetenciaCargo> BuscarCompetenciasXCargo(int cargokey, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities( conexion.ToString()))
            {
                var competenciasXCargo = newcontexto.ThrCompetenciaCargos.Where(d=>d.Positionkey == cargokey).ToList();
                return competenciasXCargo;
            }
           
        }
        public void AdicionarCompetencias(List<ThrCompetencia> competencias, string conexion)
        {
            try
            {
                using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
                {
                    using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                    {
                        var listacompeten = newcontexto.ThrCompetencias.ToList();
                        if (listacompeten.Any())
                        {
                            for (int i = 0; i < competencias.Count; i++)
                            {
                                var result = false;
                                for (int j = 0; j < listacompeten.Count; j++)
                                {
                                    if (competencias[i].CompetenciaID == listacompeten[j].CompetenciaID)
                                    {
                                        result = true;
                                    }
                                }
                                if (!result)
                                {
                                    newcontexto.AddToThrCompetencias(competencias[i]);
                                    newcontexto.SaveChanges();
                                }
                            }
                        }
                        else
                        {                           
                            for (int j = 0; j < competencias.Count; j++)
                            {
                            newcontexto.AddToThrCompetencias(competencias[j]);
                            newcontexto.SaveChanges();                       
                            }                               
                        }                           
                        cont.Complete();
                        cont.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public bool DeleteCompetencias(string competenciaID, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var result = false;
                var competencia = newcontexto.ThrCompetencias.Where(d => d.CompetenciaID == competenciaID).FirstOrDefault();
                if (competencia != null)
                {
                    var dependencias = newcontexto.ThrCompetenciaCargos.Where(d => d.Competenciakey == competencia.CompetenciaKey).ToList();
                    if (dependencias.Count > 0)
                    {
                        result = false;
                    }
                    else
                    {
                        newcontexto.DeleteObject(competencia);
                        newcontexto.SaveChanges();
                        result = true;
                    }
                }
                return result;
            }
        }
    }
    
}
