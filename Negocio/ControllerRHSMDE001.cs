using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSMDE001
    {
        DARHSMDE001 dataAccess = new DARHSMDE001();
        public TsmCompany GetCompaniaExistente(string codigo)
        {
            dataAccess = new DARHSMDE001();
            var comp = dataAccess.BuscarCompanyExistente(codigo);
            return comp;
        }
        public ThrCompany GetCompania(string codigoID)
        {
            dataAccess = new DARHSMDE001();
            var compania = dataAccess.BuscarCompany(codigoID);
            return compania;
        }
        public List<TglSegment> GetSegmentosCuenta(string company)
        {
            dataAccess = new DARHSMDE001();
            var segmentos = dataAccess.BuscarSegmentosCuenta(company);
            return segmentos;
        }
        public void AddDatosEmpresa(ThrCompany company)
        {
            dataAccess.AdicionarDatosEmpresa(company);            
        }
        public bool DeleteDatosEmpresa(string codigoID)
        {
            dataAccess = new DARHSMDE001();
            bool result = dataAccess.EliminarDatosEmpresa(codigoID);
            return result;
           
        }
        public List<TsmCompany> ActualizarLista()
        {
            dataAccess = new DARHSMDE001();
            var compnias = dataAccess.Actualizar();
            return compnias;
        }
    }
}
