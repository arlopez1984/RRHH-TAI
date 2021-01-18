using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RRHH.Datamodel
{
    public class DARHSMR001
    {
        public List<ThrRisk> BuscarRiesgos(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var riesgos = newcontexto.ThrRisks.ToList();
                return riesgos;
            }
        }
        public ThrRisk BuscarRiesgoKey(string id, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var riesgo = newcontexto.ThrRisks.Where(d => d.RiskID == id).FirstOrDefault();
                return riesgo;
            }

        }
        public ThrRisk BuscarRiesgo(int key, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var riesgo = newcontexto.ThrRisks.Where(d => d.RiskKey == key).FirstOrDefault();
                return riesgo;
            }

        }
        public List<ThrPositionRisk> BuscarRiesgosXCargo(int cargokey, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var riesgosXCargo = newcontexto.ThrPositionRisks.Where(d => d.PositionKey == cargokey).ToList();
                return riesgosXCargo;
            }

        }
        public bool DeleteRiesgosLaborales(string riskID, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var result = false;
                var riesgo = newcontexto.ThrRisks.Where(d => d.RiskID == riskID).FirstOrDefault();
                if (riesgo != null)
                {
                    var dependencias = newcontexto.ThrPositionRisks.Where(d => d.RiskKey == riesgo.RiskKey).ToList();
                    if (dependencias.Count > 0)
                    {
                        result = false;
                    }
                    else
                    {
                        newcontexto.DeleteObject(riesgo);
                        newcontexto.SaveChanges();
                        result = true;
                    }
                }
                return result;
            }
        }
        public void AdicionarRiesgos(List<ThrRisk> riesgos, string conexion)
        {
            try
            {
                using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
                {
                    using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                    {
                        var listariesgos = newcontexto.ThrRisks.ToList();
                        if (listariesgos.Any())
                        {
                            for (int i = 0; i < riesgos.Count; i++)
                            {
                                var result = false;
                                for (int j = 0; j < listariesgos.Count; j++)
                                {
                                    if (riesgos[i].RiskID == listariesgos[j].RiskID)
                                    {
                                        result = true;
                                    }
                                }
                                if (!result)
                                {
                                    newcontexto.AddToThrRisks(riesgos[i]);
                                    newcontexto.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < riesgos.Count; j++)
                            {
                                newcontexto.AddToThrRisks(riesgos[j]);
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
    }
}
