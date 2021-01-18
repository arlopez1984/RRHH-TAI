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
    public class ControllerRHSMH001
    {
        DARHSMH001 dataAccess = new DARHSMH001();
        public ThrShedule GetHorario(string nombre)
        {
            var unidadOrg = dataAccess.BuscarHorari(nombre);
            return unidadOrg;
        }
        public ThrSheduleJornada GetJornadaHorario(int horario)
        {
            var unidadOrg = dataAccess.BuscarJornadaHorario(horario);
            return unidadOrg;
        }
        public clsHorario GetHorari(string nombre)
        {
            clsHorario objhor = new clsHorario();
            var horario = dataAccess.BuscarHorari(nombre);
            objhor.nombrehorario = horario.HorarioID;
            objhor.descripcionhorario = horario.HorarioDescrip;
            objhor.horarioKey = horario.Horariokey;
            return objhor;
        }
        public ThrShedule GetHorarioKey(int sheduleKey)
        {  
            var horario = dataAccess.BuscarHorario(sheduleKey);            
            return horario;
        }       
        public void AddHorario(clsHorario horario)
        {
            var hor = new ThrShedule();
            hor.HorarioID = horario.nombrehorario;
            hor.HorarioDescrip = horario.descripcionhorario;
            dataAccess.AdicionarHorario(hor, horario.listaCiclos);
        }
        public clsHorario CargarDatosObjHorario(string horarioID)
        {
            var objHorario = new clsHorario();
            
            var dataHorario = dataAccess.BuscarHorari(horarioID);
            var listHorariosJornada = dataAccess.BuscarHorariosJornada(dataHorario.Horariokey);

            objHorario.nombrehorario = dataHorario.HorarioID;
            objHorario.descripcionhorario = dataHorario.HorarioDescrip;            

            var listHorariosJOrnadas = new List<clsCicloHorario>();
            clsCicloHorario objcicloHorario;

            for (int i = 0; i < listHorariosJornada.Count; i++)
            {
                objcicloHorario = new clsCicloHorario();
                objcicloHorario.horainicio = listHorariosJornada[i].HoraInicio;
                objcicloHorario.horafin = listHorariosJornada[i].HoraFin;
                objcicloHorario.tiempotrabajo = listHorariosJornada[i].TiempoTrabajo;
                objcicloHorario.tiempodescanso = listHorariosJornada[i].TiempoDescanso;
                objcicloHorario.duracionJornada = listHorariosJornada[i].DuracionJornada;
                listHorariosJOrnadas.Add(objcicloHorario);
            }
            objHorario.listaCiclos = listHorariosJOrnadas;            
            return objHorario;
        }
        public List<ThrShedule> ActualizarLista()
        {
            List<ThrShedule> listunidadOrg = dataAccess.Actualizar();
            return listunidadOrg;
        }
        public bool DeleteHorario(string nombre)
        {
            ThrShedule horario = dataAccess.BuscarHorari(nombre);
            int cantdependencias = dataAccess.BuscarDependenciasHorarios(horario.Horariokey);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarHorario(nombre);
                return true;
            }
            return false;
        }
       
    }
}
