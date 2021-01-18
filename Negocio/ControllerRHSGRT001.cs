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
    public class ControllerRHSGRT001
    {
        DARHSGRT001 dataAccess;
        public void AddRetencionesTrabajador(List<clsRetencion> listaretenciones, int periodo)
        {
            dataAccess = new DARHSGRT001();
            ThrPeopleRetention retentionPeople;
            List<ThrPeopleRetention> listaRetencionesXtrabajador = new List<ThrPeopleRetention>();
            foreach (clsRetencion item in listaretenciones)
            {
                retentionPeople = new ThrPeopleRetention();
                retentionPeople.Retentionkey = item.retentionkey;
                retentionPeople.PersonKey = item.personKey;
                retentionPeople.FechaInicio = item.fechInicio;
                retentionPeople.FechaRegister = item.FechaRegister;
                retentionPeople.SaldoPendiente = item.saldoPendiente;
                retentionPeople.SaldoTotal = item.saldoTotal;
                retentionPeople.SaldoMensual = item.saldoMensual;
                retentionPeople.Causa = item.causa;
                retentionPeople.CreateUserID = item.CreateUserID;
                retentionPeople.CompanyID = item.CompanyID;
                listaRetencionesXtrabajador.Add(retentionPeople);
            }
            dataAccess.AdicionarRetencionesTrabajador(listaRetencionesXtrabajador, periodo);

        }
        public List<clsRetencion> GetRetencionesXTrabajador(int personKey, int periodo)
        {
            dataAccess = new DARHSGRT001();
            List<clsRetencion> listaRetenciones = new List<clsRetencion>();
            clsRetencion objRetention;
            var RetencionesXpersona = dataAccess.RetencionesXPersona(personKey, periodo);
            foreach (ThrPeopleRetention item in RetencionesXpersona)
            {
                objRetention = new clsRetencion();
                objRetention.retentionkey = item.Retentionkey;
                objRetention.fechInicio = item.FechaInicio;
                objRetention.FechaRegister = item.FechaRegister;
                objRetention.personKey = item.PersonKey;
                objRetention.saldoMensual = item.SaldoMensual;
                objRetention.saldoTotal = item.SaldoTotal;
                objRetention.saldoPendiente = item.SaldoPendiente;
                objRetention.causa = item.Causa;
                listaRetenciones.Add(objRetention);
            }
            return listaRetenciones;
        }
        public bool EliminarDeduccionesXPersonas(int personKey, int periodo)
        {
            dataAccess = new DARHSGRT001();
            bool resultado = false;
            resultado = dataAccess.EliminarRetencionesXPersonas(personKey, periodo);
            return resultado;
        }
    }
}
