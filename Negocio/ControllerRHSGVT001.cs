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
    public class ControllerRHSGVT001
    {
        DARHSGVT001 dataAccess;
        public void AddVacacionesTrabajador(List<clsVacaciones> listaVacaciones, int periodo)
        {
            dataAccess = new DARHSGVT001();
            ThrPeopleVacation vacationPeople;
            List<ThrPeopleVacation> listaVacacionesXtrabajador = new List<ThrPeopleVacation>();
            foreach (clsVacaciones item in listaVacaciones)
            {
                vacationPeople = new ThrPeopleVacation();
                vacationPeople.HoursDifrutadas = Convert.ToInt32(item.horasDisfrutadas);
                vacationPeople.FechaRegister = item.FechaRegister;
                vacationPeople.VacationFechaFin = item.fechaFin;
                vacationPeople.VacationFechaInicio = item.fechInicio;
                vacationPeople.Personkey = item.personKey;
                vacationPeople.VacationFechaInicio = item.fechInicio;
                vacationPeople.CreateUserID = item.CreateUserID;
                vacationPeople.CompanyID = item.CompanyID;
                listaVacacionesXtrabajador.Add(vacationPeople);
            }            
            dataAccess.AdicionarVacacionesTrabajador(listaVacacionesXtrabajador, periodo);
        }
        public List<clsVacaciones> GetVacacionesXTrabajados(int personKey, int periodo)
        {
            dataAccess = new DARHSGVT001();
            List<clsVacaciones> listaVacaciones = new List<clsVacaciones>();
            clsVacaciones objVacation;
            var vacacionesXpersona = dataAccess.VacacionesXPersona(personKey, periodo);
            foreach (ThrPeopleVacation item in vacacionesXpersona)
            {
                objVacation = new clsVacaciones();
                objVacation.fechaFin = item.VacationFechaFin;
                objVacation.fechInicio = item.VacationFechaInicio;
                objVacation.FechaRegister = item.FechaRegister;
                objVacation.personKey = item.Personkey;
                objVacation.horasDisfrutadas = item.HoursDifrutadas;
                listaVacaciones.Add(objVacation);
            }
            return listaVacaciones;
        }
        public bool EliminarVacacionesXPersonas(int personKey,  DateTime fechaInicio, DateTime fechaFin, int periodo)
        {
            dataAccess = new DARHSGVT001();
            bool resultado = false;
            resultado = dataAccess.EliminarVacacionesXPersonas(personKey, fechaInicio,fechaFin, periodo);
            return resultado;
        }
    }
}
