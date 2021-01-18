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
        public List<ThrLaboralCondition> BuscarCondicioneslaborales(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var coditionlaboral = newcontexto.ThrLaboralConditions.ToList();
                return coditionlaboral;
            }
        }
        public void AdicionarCondicionLaboral(List<ThrLaboralCondition> condiciones, string conexion)
        {
            try
            {
                using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
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
            catch (Exception ex)
            {
                throw;
            }         

        }
        public bool DeleteCondicionesLaborales(string condicionLabID, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
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
        public List<ThrPositionConditionLab> BuscarCondicionesPosition(int PositionKey, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listaCondicionesLabCargo = newcontexto.ThrPositionConditionLabs.Where(d => d.PositionKey == PositionKey).ToList();
                return listaCondicionesLabCargo;
            }

        }
        public void EliminarCompetencias(int tipo, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
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
        public List<ThrPositionConditionLab> BuscarCondocionesLaboralesXCargo(int cargokey, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var condicionesXCargo = newcontexto.ThrPositionConditionLabs.Where(d => d.PositionKey == cargokey).ToList();
                return condicionesXCargo;
            }
           
        }
        public ThrLaboralCondition BuscarConditionlaboralKey(string id, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var condition = newcontexto.ThrLaboralConditions.Where(d => d.ConditionlabID == id).FirstOrDefault();
                return condition;
            }

        }
        public ThrLaboralCondition BuscarConditionlaboral(int key, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var condicionLab = newcontexto.ThrLaboralConditions.Where(d => d.ConditionLabkey == key).FirstOrDefault();
                return condicionLab;
            }

        }
    }
    
}
