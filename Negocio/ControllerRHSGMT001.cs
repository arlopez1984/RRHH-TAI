using Entidades.General;
using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSGMT001
    {
        DARHSGMT001 dataAccess = new DARHSGMT001();
        public List<ThrMovement> GetTiposMovimientos()
        {
            var listaMovement = dataAccess.BuscarTiposMovimientos();
            return listaMovement;
        }
        public void AddMovementTrasladoReubicacion(clsMovimiento movimiento)
        {
            var movement = new ThrPeopleMovement();
            {
                movement.Causa = movimiento.causa;
                movement.FechaMovimiento = Convert.ToDateTime(movimiento.fechaMovement);
                movement.PersonKey = movimiento.personKey;
                movement.Movementkey = movimiento.movementkey;
                movement.PositionKey = movimiento.positionKey;
                movement.PeriodKey = movimiento.periodo;
                movement.PositionKeyNext = Convert.ToInt32(movimiento.positionKeyDestino);                               
                movement.OrgUnitKey = movimiento.unidadOrgKey;               
                movement.UnidadKeyNext = movimiento.unidadOrgKeyDestino;
                movement.CreateUserID = movimiento.CreateUserID;
                movement.CompanyID = movimiento.CompanyID;
            }
            dataAccess.RegistrarMovimientoTrasladoReubicacion(movement);
        }       
        public void AddMovementAltaBaja(clsMovimiento movimiento)
        {
            var movement = new ThrPeopleMovement();
            {
                movement.Causa = movimiento.causa;
                movement.FechaMovimiento = Convert.ToDateTime(movimiento.fechaMovement);
                movement.PersonKey = movimiento.personKey;
                movement.Movementkey = movimiento.movementkey;
                movement.PositionKey = movimiento.positionKey;
                movement.PeriodKey = movimiento.periodo;
                movement.PositionKeyNext = null; 
                movement.OrgUnitKey = movimiento.unidadOrgKey;
                movement.UnidadKeyNext = null;
                movement.Causa = null;
                movement.CreateUserID = movimiento.CreateUserID;
                movement.CompanyID = movimiento.CompanyID;
            }
            dataAccess.RegistrarMovimientoAltaBaja(movement);
        }
        public List<clsMovimiento> GetMovimientosTrabajador(ThrPeople persona, int periodo)
        {
            clsMovimiento mov;
            List<clsMovimiento> listaMovimientos = new List<clsMovimiento>();
           var movimientos =  dataAccess.BuscarMovimientosTrabajador(persona.PersonKey, periodo);
            foreach (ThrPeopleMovement item in movimientos)
            {
                mov = new clsMovimiento();
                mov.personKey = item.PersonKey;
                mov.movementkey = item.Movementkey;
                mov.positionKey = item.PositionKey;
                mov.positionKeyDestino = Convert.ToInt32(item.PositionKeyNext);
                mov.unidadOrgKey = item.OrgUnitKey;
                mov.unidadOrgKeyDestino = Convert.ToInt32(item.UnidadKeyNext);
                mov.causa = item.Causa;
                mov.fechaMovement = item.FechaMovimiento;
                mov.CreateUserID = item.CreateUserID;
                mov.CompanyID = item.CompanyID;
                listaMovimientos.Add(mov);
            }
            return listaMovimientos;
        }
        public clsMovimiento GetMovimiento(int persona, DateTime fecha)
        {
            clsMovimiento mov;           
            var movimiento = dataAccess.BuscarMovimiento(persona, fecha);            
            mov = new clsMovimiento();
            mov.personKey = movimiento.PersonKey;
            mov.movementkey = movimiento.Movementkey;
            mov.positionKey = movimiento.PositionKey;
            mov.positionKeyDestino = Convert.ToInt32(movimiento.PositionKeyNext);
            mov.unidadOrgKey = movimiento.OrgUnitKey;
            mov.unidadOrgKeyDestino = Convert.ToInt32(movimiento.UnidadKeyNext);
            mov.causa = movimiento.Causa;
            mov.CreateUserID = movimiento.CreateUserID;
            mov.CompanyID = movimiento.CompanyID;
            mov.fechaMovement = movimiento.FechaMovimiento;            
            return mov;
        }
        public bool EliminarMovimiento(clsMovimiento movimiento)
        {            
            dataAccess = new DARHSGMT001();
            bool resultado = false;
            var movement = new ThrPeopleMovement();
            movement.FechaMovimiento = Convert.ToDateTime(movimiento.fechaMovement);
            movement.Movementkey = movimiento.movementkey;          
            movement.PeriodKey = movimiento.periodo; 
            resultado = dataAccess.EliminarMovimiento(movement);
            return resultado;
        }
    }
}
