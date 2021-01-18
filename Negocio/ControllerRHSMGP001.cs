using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSMGP001
    {
        DARHSMGP001 dataAccess = new DARHSMGP001();
        public ThrOperationsPeriod GetPeriodoActivo()
        {
            dataAccess = new DARHSMGP001();
            var periodo = dataAccess.BuscarPeriodoActivo();
            return periodo;
        }
        public bool AddPeriodoActivo(ThrOperationsPeriod Operationperiodo)
        {
            var fechaInicioNow = Operationperiodo.PeriodFechaInicio.Date;
            var fechaFinNow = Operationperiodo.PeriodFechaFin.Date;
            bool resultado = true;
            var dataPeriodos = dataAccess.BuscarPeriodos();
            var periodoActivo = dataAccess.BuscarPeriodoActivo();
            if (dataPeriodos.Count > 0)
            {
                foreach (ThrOperationsPeriod item in dataPeriodos)
                {

                    if ((Operationperiodo.PeriodFechaInicio.Date <= item.PeriodFechaInicio.Date && Operationperiodo.PeriodFechaFin.Date >= item.PeriodFechaFin.Date)  // 2 por fuera extremos
                    || (Operationperiodo.PeriodFechaInicio.Date >= item.PeriodFechaInicio.Date && Operationperiodo.PeriodFechaFin.Date <= item.PeriodFechaFin.Date)
                    || (Operationperiodo.PeriodFechaInicio.Date <= item.PeriodFechaFin.Date && Operationperiodo.PeriodFechaFin.Date >= item.PeriodFechaFin.Date) // dentro de los dos
                    || (Operationperiodo.PeriodFechaInicio.Date <= item.PeriodFechaInicio.Date && Operationperiodo.PeriodFechaFin.Date >= item.PeriodFechaInicio.Date))
                    {
                        resultado = false;
                    }
                }                
            }
            if(periodoActivo != null)
            {
                resultado = false;                
            }
            if(resultado)
            {
                dataAccess.AgregarOperacionPeriodo(Operationperiodo);             
            }
            return resultado;
        }
        public bool CerrarPeriodoActivo()
        {
            bool result = dataAccess.CerrarOperacionPeriodo();
            return result;
        }
        public bool EliminarPeriodoActivo(ThrOperationsPeriod periodo)
        {
            bool result = dataAccess.EliminarPeriodoActivo(periodo);
            return result;
        }

        public List<ThrOperationsPeriod> GetPeriodos()
        {
            var listaPeriodos = dataAccess.BuscarPeriodos();
            return listaPeriodos;
        }
    }
}
