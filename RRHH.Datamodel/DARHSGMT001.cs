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
    public class DARHSGMT001
    {
        public List<ThrMovement> BuscarTiposMovimientos()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrMovements.ToList();
                return data;
            }
        }
        public void RegistrarMovimientoTrasladoReubicacion(ThrPeopleMovement movement)
        {
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {               
                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    var movimiento = newcontexto.ThrPeopleMovements.Where(d => d.PersonKey == movement.PersonKey && d.FechaMovimiento == movement.FechaMovimiento).FirstOrDefault();
                    var persona = newcontexto.ThrPeople.Where(d => d.PersonKey == movement.PersonKey).FirstOrDefault();
                    if (movimiento == null)
                    {
                        newcontexto.AddToThrPeopleMovements(movement);                       
                        persona.PositionKey = Convert.ToInt32(movement.PositionKeyNext);
                        persona.OrgUnitKey = Convert.ToInt32(movement.UnidadKeyNext);
                        persona.Estato = 6;

                    }   
                    else
                    {
                        movimiento.FechaMovimiento = movement.FechaMovimiento;
                        movimiento.Causa = movement.Causa;
                        movimiento.UnidadKeyNext = movement.UnidadKeyNext;
                        movimiento.PositionKeyNext = movement.PositionKeyNext;
                        persona.PositionKey = Convert.ToInt32(movement.PositionKeyNext);
                        persona.OrgUnitKey = Convert.ToInt32(movement.UnidadKeyNext);
                        persona.Estato = 6;
                    }
                   newcontexto.SaveChanges();
                }
                cont.Complete();
                cont.Dispose();
            }
           
        }
        public void RegistrarMovimientoAltaBaja(ThrPeopleMovement movement)
        {
            using (var cont = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    var movimiento = newcontexto.ThrPeopleMovements.Where(d => d.PersonKey == movement.PersonKey && d.FechaMovimiento == movement.FechaMovimiento).FirstOrDefault();
                    var persona = newcontexto.ThrPeople.Where(d => d.PersonKey == movement.PersonKey).FirstOrDefault();
                    if (movimiento != null)
                    {
                        movimiento.FechaMovimiento = movement.FechaMovimiento;
                        movimiento.PeriodKey = movement.PeriodKey;
                        movimiento.PositionKey = movement.PositionKey;
                        movimiento.PositionKeyNext = movement.PositionKeyNext;
                        movimiento.UnidadKeyNext = movement.UnidadKeyNext;
                        movimiento.OrgUnitKey = movement.OrgUnitKey;
                        movimiento.PersonKey = movement.PersonKey;
                        movimiento.Movementkey = movement.Movementkey;
                        movimiento.Causa = movement.Causa;
                    }
                    else
                    {
                        newcontexto.AddToThrPeopleMovements(movement);
                    }
                    newcontexto.SaveChanges();
                    if (movement.Movementkey == 4)
                    {
                        if (persona != null)
                        {
                            persona.Estato = 2;                          
                        }
                    }
                    if (movement.Movementkey == 3)
                    {
                        if (persona != null)
                        {
                            persona.Estato = 6;
                        }
                    }                   
                    newcontexto.SaveChanges();

                }
                cont.Complete();
                cont.Dispose();
            }
        }
        public List<ThrPeopleMovement> BuscarMovimientosTrabajador(int personKey, int periodo)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var movimientos = newcontexto.ThrPeopleMovements.Where(d => d.PersonKey == personKey && d.PeriodKey == periodo).ToList();
                return movimientos;
            }

        }
        public ThrPeopleMovement BuscarMovimiento(int personKey, DateTime fecha)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var movimiento = newcontexto.ThrPeopleMovements.Where(d => d.PersonKey == personKey && d.FechaMovimiento == fecha).FirstOrDefault();
                return movimiento;
            }

        }
        public bool EliminarMovimiento(ThrPeopleMovement movement)
        {
            bool dato = false;
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var movimiento = newcontexto.ThrPeopleMovements.Where(d => d.PeriodKey == movement.PeriodKey && d.FechaMovimiento == movement.FechaMovimiento).FirstOrDefault();
                if (movimiento != null)
                {                    
                    newcontexto.DeleteObject(movimiento);
                    newcontexto.SaveChanges();                       
                    dato = true;
                }
            }
            return dato;               
        }

    }
}
