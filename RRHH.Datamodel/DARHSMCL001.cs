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
    public class DARHSMCL001
    {
        public List<ThrLaboralCondition> BuscarCondicioneslaborales()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var coditionlaboral = newcontexto.ThrLaboralConditions.ToList();
                return coditionlaboral;
            }
        }
        public void AdicionarCondicionLaboral(List<ThrLaboralCondition> condiciones)
        {
            try
            {
                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                    {
                        var listacondiciones = newcontexto.ThrLaboralConditions.ToList();
                        if (listacondiciones.Any())
                        {
                            for (int i = 0; i < condiciones.Count; i++)
                            {
                                var result = false;
                                for (int j = 0; j < listacondiciones.Count; j++)
                                {
                                    if (condiciones[i].ConditionlabID == listacondiciones[j].ConditionlabID)
                                    {
                                        result = true;
                                    }
                                }
                                if (!result)
                                {
                                    newcontexto.AddToThrLaboralConditions(condiciones[i]);
                                    newcontexto.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < condiciones.Count; j++)
                            {
                                newcontexto.AddToThrLaboralConditions(condiciones[j]);
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
        public bool DeleteCondicionesLaborales(string condicionLabID)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var result = false;
                var condicion = newcontexto.ThrLaboralConditions.Where(d => d.ConditionlabID == condicionLabID).FirstOrDefault();
                if (condicion != null)
                {
                    var dependencias = newcontexto.ThrPositionConditionLabs.Where(d => d.ConditionLabKey == condicion.ConditionLabkey).ToList();
                    if (dependencias.Count > 0)
                    {
                        result = false;
                    }
                    else
                    {
                        newcontexto.DeleteObject(condicion);
                        newcontexto.SaveChanges();
                        result = true;
                    }
                }
                return result;
            }
        }
        public List<ThrPositionConditionLab> BuscarCondicionesPosition(int PositionKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listaCondicionesLabCargo = newcontexto.ThrPositionConditionLabs.Where(d => d.PositionKey == PositionKey).ToList();
                return listaCondicionesLabCargo;
            }

        }
        public void EliminarCompetencias(int tipo)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listacondition = newcontexto.ThrLaboralConditions.Where(d => d.TipoConditionLab == tipo).ToList();
                if (listacondition.Any())
                {
                    for (int i = 0; i < listacondition.Count; i++)
                    {
                        newcontexto.DeleteObject(listacondition[i]);
                        newcontexto.SaveChanges();
                    }
                }
            }
        }
        public List<ThrPositionConditionLab> BuscarCondocionesLaboralesXCargo(int cargokey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var condicionesXCargo = newcontexto.ThrPositionConditionLabs.Where(d => d.PositionKey == cargokey).ToList();
                return condicionesXCargo;
            }
           
        }
        public ThrLaboralCondition BuscarConditionlaboralKey(string id)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var condition = newcontexto.ThrLaboralConditions.Where(d => d.ConditionlabID == id).FirstOrDefault();
                return condition;
            }

        }
        public ThrLaboralCondition BuscarConditionlaboral(int key)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var condicionLab = newcontexto.ThrLaboralConditions.Where(d => d.ConditionLabkey == key).FirstOrDefault();
                return condicionLab;
            }

        }
    }
    
}
