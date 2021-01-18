using Entidades.General;
//using Entidades.RHSGVT001;
using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSGDT001
    {
        DARHSGDT001 dataAccess;
        public void AddDeduccionesTrabajador(List<clsDeduccion> listadeducciones, int periodo)
        {            
            dataAccess = new DARHSGDT001();
            ThrPeopleDeduction1 deductionPeople;
            List<ThrPeopleDeduction1> listaDeduccionesXtrabajador = new List<ThrPeopleDeduction1>();
            foreach (clsDeduccion item in listadeducciones)
            {
                deductionPeople = new ThrPeopleDeduction1();
                deductionPeople.DeductionKey = item.deductionkey;
                deductionPeople.PersonKey = item.personKey;
                deductionPeople.FehaInicio = item.fechInicio;
                deductionPeople.FechaRegister = item.FechaRegister;
                deductionPeople.SaldoPendiente = item.saldoPendiente;
                deductionPeople.SaldoTotal = item.saldoTotal;
                deductionPeople.CuotaMensual = item.cuotaMensual;
                deductionPeople.CompanyID = item.CompanyID;
                deductionPeople.CreateUserID = item.CreateUserID;
                listaDeduccionesXtrabajador.Add(deductionPeople);

            }
            dataAccess.AdicionarDeducionesTrabajador(listaDeduccionesXtrabajador, periodo);

        }
        public List<clsDeduccion> GetDeduccionesXTrabajador(int personKey, int periodo)
        {
            dataAccess = new DARHSGDT001();
            List<clsDeduccion> listaDeducciones = new List<clsDeduccion>();
            clsDeduccion objDeduction;
            var DeduccionesXpersona = dataAccess.DeduccionesXPersona(personKey, periodo);
            foreach (ThrPeopleDeduction1 item in DeduccionesXpersona)
            {
                objDeduction = new clsDeduccion();
                objDeduction.deductionkey = item.DeductionKey;
                objDeduction.fechInicio = item.FehaInicio;
                objDeduction.FechaRegister = item.FechaRegister;
                objDeduction.personKey = item.PersonKey;
                objDeduction.cuotaMensual = item.CuotaMensual;
                objDeduction.saldoTotal = item.SaldoTotal;
                objDeduction.saldoPendiente = item.SaldoPendiente;
                listaDeducciones.Add(objDeduction);
            }
            return listaDeducciones;
        }
        public bool EliminarDeduccionesXPersonas(int personKey, int periodo)
        {
            dataAccess = new DARHSGDT001();
            bool resultado = false;
            resultado = dataAccess.EliminarDeduccionesXPersonas(personKey, periodo);
            return resultado;
        }
    }
}
