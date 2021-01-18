using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Sage500AppModel;
using Entidades;
using Entidades.General;

namespace Entidades.General
{
    public class clsCargo
    {
        public string codigo { get; set; }
        public string nombrecargo { get; set; }
        public string descripcion { get; set; }
        public int grupoescala { get; set; }
        public int clasficacionTrabajador { get; set; }
        public int estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int categoriaOcupacional { get; set; }
        public decimal horasExtraspagar { get; set; }
        public decimal estimulacionCuc { get; set; }
        public decimal pagoxcargo { get; set; }
        public string funcionesRespons { get; set; }
        public string mision { get; set; }
        public List<clsCondicionesAnormales> ListCondicionesAnormales { get; set; }
        public List<clsUnidadesOrganizativas> ListAreasOrganizativas { get; set; }
        public List<clsCompetencias> ListCompetencias { get; set; }
        public List<clsCondicionLaboral> ListaCondicionesLaborales { get; set; }
        public List<clsRiesgo> ListaRiesgosLaborales { get; set; }
    }
}