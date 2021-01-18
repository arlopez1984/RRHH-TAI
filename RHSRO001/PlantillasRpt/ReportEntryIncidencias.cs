using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHSRO001.PlantillasRpt
{
    internal class ReportEntryIncidencias
    {
        public ReportEntryIncidencias()
        {
        }
        public string ParametroNameRpt { get; set; }
        public string ParametroValorRPT { get; set; }

        public string ParametroPeriodo { get; set; }
        public string ParametroValorPeriodo { get; set; }

        public string ParametroExpediente { get; set; }
        public string ParametroValorExpediente { get; set; }

        public string ParametroNombre { get; set; }
        public string ParametroValorNombre { get; set; }       

        public string ParametroTipo { get; set; }
        public string ParametroValorTipo { get; set; }

        public string ParametroFechaInicio { get; set; }
        public string ParametroValorFechaInicio { get; set; }

        public string ParametroFechaFin { get; set; }
        public string ParametroValorFechaFin { get; set; }

        public string ParametroHorasDisfrutadas { get; set; }
        public string ParametroValorHorasDisfrutadas { get; set; }

        public string ParametroNoConsecutivos { get; set; }
        public string ParametroValorNoConsecutivos { get; set; }

        public string ParametroNombreEmpresa { get; set; }
        public string ParametroValorNombreEmpresa { get; set; }

    }
}
