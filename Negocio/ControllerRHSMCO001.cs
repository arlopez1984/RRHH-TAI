using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSMCO001
    {
        DARHSMCO001 dataAccess;
        public ThrOcupationalCategory GetCategoriaOcupacional(string name)
        {
            dataAccess = new DARHSMCO001();
            ThrOcupationalCategory CategOcup = new ThrOcupationalCategory();
            CategOcup = dataAccess.BuscarCategoriaOcupacional(name);
            return CategOcup;
        }
        public void AddCategoriaOcupacional(ThrOcupationalCategory CatOcup)
        {
            dataAccess = new DARHSMCO001();
            dataAccess.AdicionarCategoriaOcupacional(CatOcup);
        }
        public bool DeleteCategoriaOcupacional(string name)
        {
            dataAccess = new DARHSMCO001();
            ThrOcupationalCategory catOcup = dataAccess.BuscarCategoriaOcupacional(name);
            int cantdependencias = dataAccess.BuscarDependenciasCategoriaOcupacionales(catOcup);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarCategoriaOcupacional(name);
                return true;
            }
            return false;
        }
        public List<ThrOcupationalCategory> ActualizarLista()
        {
            dataAccess = new DARHSMCO001();
            List<ThrOcupationalCategory> listCat = dataAccess.Actualizar();
            return listCat;
        }
    }

}
