using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSMNC001
    {
        DARHSMNC dataAccess;
        public ThrCulturalLevel GetNivelCultural(string level)
        {
            dataAccess = new DARHSMNC();
            ThrCulturalLevel levelCult = dataAccess.BuscarNivelCultural(level);
            return levelCult;
        }
        public void AddNivelCultural(ThrCulturalLevel level)
        {
            dataAccess = new DARHSMNC();
            dataAccess.AdicionarNivelCultural(level);
        }
        public bool DeleteNivelCultural(string level)
        {
            dataAccess = new DARHSMNC();
            ThrCulturalLevel nivel = dataAccess.BuscarNivelCultural(level);
            int cantdependencias = dataAccess.BuscarDependenciasNivelCultural(nivel);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarNivelCultural(level);
                return true;
            }
            return false;
        }
        public List<ThrCulturalLevel> ActualizarLista()
        {
        dataAccess = new DARHSMNC();
        List<ThrCulturalLevel> level = dataAccess.Actualizar();
        return level;
        }

    }
}
