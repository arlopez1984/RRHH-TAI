using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSMTD001
    {
        DARHSMTD001 dataAccess;
        public ThrDeduction GetDeduction(string nameID)
        {
            dataAccess = new DARHSMTD001();
            var deduccion = dataAccess.BuscarDeduccion(nameID);
            return deduccion;
        }
        public ThrDeduction GetDeductionKey(int deductionKey)
        {
            dataAccess = new DARHSMTD001();
            var deduccion = dataAccess.BuscarDeduccionKey(deductionKey);
            return deduccion;
        }
        public ThrDeduction GetDeductionName(string name)
        {
            dataAccess = new DARHSMTD001();
            var deduccion = dataAccess.BuscarDeduccionName(name);
            return deduccion;
        }
        public void AddDeduction(ThrDeduction deduct)
        {
            dataAccess = new DARHSMTD001();
            dataAccess.AdicionarDeducciones(deduct);
        }
        public bool DeleteDeduction(string cod)
        {
            dataAccess = new DARHSMTD001();
            var deducc = dataAccess.BuscarDeduccion(cod);
            int cantdependencias = dataAccess.BuscarDependenciasDeducciones(deducc);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarDeduccion(cod);
                return true;
            }
            return false;
        }
        public List<ThrDeduction> ActualizarLista()
        {
            dataAccess = new DARHSMTD001();
            var listData = dataAccess.Actualizar();
            return listData;
        }
    }
}
