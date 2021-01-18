using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSMTM001
    {
        DARHSMTM001 dataAccess = new DARHSMTM001();
        public ThrMovement GetMoviemiento(string codigo)
        {
            var movement = dataAccess.BuscarMovimiento(codigo);
            return movement;
        }

        public string GetMoviemientoxKey(int movKey)
        {
            var movement = dataAccess.BuscarMovimientoXkey(movKey);
            return movement.MovementName;
        }
        public void AddMovimiento(ThrMovement movement)
        {
            dataAccess.AdicionarMovement(movement);
        }
        public bool DeleteMovimiento(string cod)
        {
            var movement = dataAccess.BuscarMovimiento(cod);
            int cantdependencias = dataAccess.BuscarDependenciasMovement(movement);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarMovimiento(cod);
                return true;
            }
            return false;
        }
        public List<ThrMovement> ActualizarLista()
        {
            var listData = dataAccess.Actualizar();
            return listData;
        }
    }
}
