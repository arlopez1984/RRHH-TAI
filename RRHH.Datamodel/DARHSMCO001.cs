using Entidades.General;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSMCO001
    {
        public ThrOcupationalCategory BuscarCategoriaOcupacional(string nom)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var categoriaOcup = newcontexto.ThrOcupationalCategories.Where(d => d.CategoryID == nom).FirstOrDefault();
                return categoriaOcup;
            }

        }
        public void AdicionarCategoriaOcupacional(ThrOcupationalCategory CategOcup)
        {
            try
            {
                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    var obj = newcontexto.ThrOcupationalCategories.Where(d => d.CategoryID == CategOcup.CategoryID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.CategoryID = CategOcup.CategoryID;
                        obj.CategoryPay = CategOcup.CategoryPay;
                        obj.CategoryPerfeccion = CategOcup.CategoryPerfeccion;
                        obj.CategoryDescripcion = CategOcup.CategoryDescripcion;
                    }
                    else
                    {
                        newcontexto.AddToThrOcupationalCategories(CategOcup);
                    }
                    newcontexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void EliminarCategoriaOcupacional(string name)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrOcupationalCategories.Where(d => d.CategoryID == name).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasCategoriaOcupacionales(ThrOcupationalCategory catgOcup)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidad = newcontexto.ThrPositions.Where(d => d.OcupationCategoryKey == catgOcup.OcupationCategoryKey).ToList();
                return cantidad.Count;
            }

        }
        public List<ThrOcupationalCategory> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrOcupationalCategories.OrderBy(d => d.OcupationCategoryKey).ToList();
                return data;
            }
        }

    }
}
