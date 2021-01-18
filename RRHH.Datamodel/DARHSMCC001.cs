using Entidades.General;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSMCC001
    {

        public ThrScientificCategory BuscarCategoriaScientifica(string nom)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var catgscientifica = newcontexto.ThrScientificCategories.Where(d => d.ScientificCategoryID == nom).FirstOrDefault();
                return catgscientifica;
            }

        }
        public void AdicionarCategoriaScientifica(ThrScientificCategory categScient)
        {
            try
            {
                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    var objcatg = newcontexto.ThrScientificCategories.Where(d => d.ScientificCategoryID == categScient.ScientificCategoryID).FirstOrDefault();
                    if (objcatg != null)
                    {
                        objcatg.ScientificCategoryID = categScient.ScientificCategoryID;                       
                        objcatg.ScientificCategoryDescripcion = categScient.ScientificCategoryDescripcion;
                    }
                    else
                    {
                        newcontexto.AddToThrScientificCategories(categScient);
                    }
                    newcontexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void EliminarCategoriaScientfica(string name)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {                
                var data = newcontexto.ThrScientificCategories.Where(d => d.ScientificCategoryID == name).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasCategoriaScientiifica(ThrScientificCategory catgScientif)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidad = newcontexto.ThrPeople.Where(d => d.CientificCategorykey == catgScientif.ScientificCategorykey).ToList();
                return cantidad.Count;
            }

        }
        public List<ThrScientificCategory> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrScientificCategories.OrderBy(d => d.ScientificCategorykey).ToList();             
                return data;
            }
        }
    }
}
