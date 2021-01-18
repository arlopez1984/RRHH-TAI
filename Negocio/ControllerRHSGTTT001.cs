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
    public class ControllerRHSGTTT001
    {
        DARHSGTTT001 dataAccess;
        public void AddTiempoTrabajado(clsTiempoTrabajo objdatostiempo)
        {
            dataAccess = new DARHSGTTT001();
            var tiempoTrabajo = new ThrWorkedTime();
            tiempoTrabajo.PersonKey = objdatostiempo.PersonKey;
            tiempoTrabajo.Periodkey = objdatostiempo.periodoActivo;
            tiempoTrabajo.HolidayDays = objdatostiempo.diasFeriados;
            tiempoTrabajo.ExtraHours = objdatostiempo.horasExtras;
            tiempoTrabajo.WorkedHours = objdatostiempo.horasTabajadas;
            dataAccess.AdicionarTiempoTrabajado(tiempoTrabajo, objdatostiempo.listaCondicionesHoras);
        }
        public ThrWorkedTime GetTiempoTrabajado(int personKey, int periodo)
        {
            dataAccess = new DARHSGTTT001();            
            var timepoXpersona = dataAccess.TiempoTrabajadoXPersona(personKey, periodo);
            return timepoXpersona;
        }        
        public ThrPosition GetCargoTrabajador(int cargo)
        {
            dataAccess = new DARHSGTTT001();
            var position = dataAccess.CargoXPersona(cargo);
            return position;
        }
        public List<ThrWorkedTimeAnormalCondition> GetCondicionesAnormalesXTrabajador(int workerTiemkey)
        {
            dataAccess = new DARHSGTTT001();
            var condiciones = dataAccess.DevolverCondicionesxTrabajador(workerTiemkey);
            return condiciones;
        }
        public List<ThrAnormalCondPosition> GetCondicionesXCargo(int cargokey)
        {
            dataAccess = new DARHSGTTT001();
            var condiciones = dataAccess.CondicionesXCargo(cargokey);
            return condiciones;
        }
        
    }
}
