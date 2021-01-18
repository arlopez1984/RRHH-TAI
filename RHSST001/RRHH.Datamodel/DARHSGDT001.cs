using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RRHH.Datamodel
{
    public class DARHSGDT001
    {
        public void AdicionarDeducionesTrabajador(List<ThrPeopleDeduction1> listadoDeduccionesXPersona, int periodo, string conex)
        {
            int deductionkey;
            ThrPeopleDeduction1 deduction = listadoDeduccionesXPersona[0];
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                using (var newcontexto = new Sage500AppEntities(conex.ToString()))
                {
                    var listaDeducciones = newcontexto.ThrPeopleDeduction1s.Where(d => d.Periodkey == periodo && d.PersonKey == deduction.PersonKey).ToList();

                    if (listaDeducciones.Count > 0)
                    {
                        for (int i = 0; i < listaDeducciones.Count; i++)
                        {
                            newcontexto.DeleteObject(listaDeducciones[i]);
                            newcontexto.SaveChanges();
                        }
                        for (int j = 0; j < listadoDeduccionesXPersona.Count; j++)
                        {
                            listadoDeduccionesXPersona[j].Periodkey = periodo;
                            newcontexto.AddToThrPeopleDeduction1s(listadoDeduccionesXPersona[j]);
                            newcontexto.SaveChanges();
                        }

                    }
                    else
                    {
                        for (int j = 0; j < listadoDeduccionesXPersona.Count; j++)
                        {                           
                            listadoDeduccionesXPersona[j].Periodkey = periodo;                            
                            newcontexto.AddToThrPeopleDeduction1s(listadoDeduccionesXPersona[j]);
                            newcontexto.SaveChanges();
                        }

                    }
                }
                cont.Complete();
                cont.Dispose();
            }
        }
        public List<ThrPeopleDeduction1> DeduccionesXPersona(int personkey, int periodo, string conection)
        {
            using (var newcontexto = new Sage500AppEntities(conection))
            {
                var datosDeducciones = newcontexto.ThrPeopleDeduction1s.Where(d => d.PersonKey == personkey && d.Periodkey == periodo).ToList();
                return datosDeducciones;
            }
        }
        public bool EliminarDeduccionesXPersonas(int personkey, int periodo, string conection)
        {
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                bool dato = false;
                using (var newcontexto = new Sage500AppEntities(conection))
                {
                    var datosdeducciones = newcontexto.ThrPeopleDeduction1s.Where(d => d.PersonKey == personkey && d.Periodkey == periodo).ToList();
                    if (datosdeducciones.Count > 0)
                    {
                        for (int i = 0; i < datosdeducciones.Count; i++)
                        {
                            newcontexto.DeleteObject(datosdeducciones[i]);
                            newcontexto.SaveChanges();
                        }
                        dato = true;
                    }

                }
                cont.Complete();
                cont.Dispose();
                return dato;

            }
        }

    }
}
