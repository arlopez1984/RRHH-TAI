using RRHH.Datamodel;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControllerRHSMCC001
    {
        DARHSMCC001 dataAccess;
        public ThrScientificCategory GetCategoriaScientifica(string name)
        {
            dataAccess = new DARHSMCC001();
            var CategSci = dataAccess.BuscarCategoriaScientifica(name);
            return CategSci;
        }
        public void AddCategoriaScientifica(ThrScientificCategory catgScientif)
        {
            dataAccess = new DARHSMCC001();
            dataAccess.AdicionarCategoriaScientifica(catgScientif);
        }
        public bool DeleteCategoriaScientifica(string name)
        {
            dataAccess = new DARHSMCC001();
            var catScientifica = dataAccess.BuscarCategoriaScientifica(name);
            int cantdependencias = dataAccess.BuscarDependenciasCategoriaScientiifica(catScientifica);
            if (cantdependencias == 0)
            {
                dataAccess.EliminarCategoriaScientfica(name);
                return true;
            }
            return false;
        }
        public List<ThrScientificCategory> ActualizarLista()
        {
            dataAccess = new DARHSMCC001();
            var data = dataAccess.Actualizar();
            return data;
        }
    }
}
