using Entidades.General;
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
        public List<ThrCompetencia> BuscarCompetencias()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var competencias = newcontexto.ThrCompetencias.ToList();
                return competencias;
            }

        }
        public ThrCompetencia BuscarCompetenciaKey(string id)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var competencias = newcontexto.ThrCompetencias.Where(d => d.CompetenciaID == id).FirstOrDefault();
                return competencias;
            }

        }
        public ThrCompetencia BuscarCompetencia(int key)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var competencias = newcontexto.ThrCompetencias.Where(d => d.CompetenciaKey == key).FirstOrDefault();
                return competencias;
            }

        }
        public List<ThrCompetenciaCargo> BuscarCompetenciasXCargo(int cargokey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var competenciasXCargo = newcontexto.ThrCompetenciaCargos.Where(d=>d.Positionkey == cargokey).ToList();
                return competenciasXCargo;
            }
           
        }
        public void AdicionarCompetencias(List<ThrCompetencia> competencias)
        {
            try
            {
                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
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
            catch (Exception)
            {
                throw;
            }

        }
        public bool DeleteCompetencias(string competenciaID)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
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
