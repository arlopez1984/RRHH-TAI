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
    public class DARHSGRT001
    {
        public void AdicionarRetencionesTrabajador(List<ThrPeopleRetention> listadoRetencionesXPersona, int periodo)
        {
            ThrPeopleRetention retention = listadoRetencionesXPersona[0];
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    var listaRetenciones = newcontexto.ThrPeopleRetentions.Where(d => d.Periodkey == periodo && d.PersonKey == retention.PersonKey).ToList();

                    if (listaRetenciones.Count > 0)
                    {
                        for (int i = 0; i < listaRetenciones.Count; i++)
                        {
                            newcontexto.DeleteObject(listaRetenciones[i]);
                            newcontexto.SaveChanges();
                        }
                        for (int j = 0; j < listadoRetencionesXPersona.Count; j++)
                        {
                            listadoRetencionesXPersona[j].Periodkey = periodo;
                            newcontexto.AddToThrPeopleRetentions(listadoRetencionesXPersona[j]);
                            newcontexto.SaveChanges();
                        }

                    }
                    else
                    {
                        for (int j = 0; j < listadoRetencionesXPersona.Count; j++)
                        {
                            listadoRetencionesXPersona[j].Periodkey = periodo;
                            newcontexto.AddToThrPeopleRetentions(listadoRetencionesXPersona[j]);
                            newcontexto.SaveChanges();
                        }

                    }
                }
                cont.Complete();
                cont.Dispose();
            }
        }
        public List<ThrPeopleRetention> RetencionesXPersona(int personkey, int periodo)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var datosretenciones = newcontexto.ThrPeopleRetentions.Where(d => d.PersonKey == personkey && d.Periodkey == periodo).ToList();
                return datosretenciones;
            }
        }
        public bool EliminarRetencionesXPersonas(int personkey, int periodo)
        {
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                bool dato = false;
                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    var datosretenciones = newcontexto.ThrPeopleRetentions.Where(d => d.PersonKey == personkey && d.Periodkey == periodo).ToList();
                    if (datosretenciones.Count > 0)
                    {
                        for (int i = 0; i < datosretenciones.Count; i++)
                        {
                            newcontexto.DeleteObject(datosretenciones[i]);
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
