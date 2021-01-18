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
        public ThrOcupationalCategory BuscarCategoriaOcupacional(string nom, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                ThrOcupationalCategory categoriaOcup = new ThrOcupationalCategory();
                categoriaOcup = newcontexto.ThrOcupationalCategories.Where(d => d.CategoryID == nom).FirstOrDefault();
                return categoriaOcup;
            }

        }
        public void AdicionarCategoriaOcupacional(ThrOcupationalCategory CategOcup, string conexion)
        {
            try
            {
                using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
                {
                    ThrOcupationalCategory obj = new ThrOcupationalCategory();
                    obj = newcontexto.ThrOcupationalCategories.Where(d => d.CategoryID == CategOcup.CategoryID).FirstOrDefault();
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
            catch (Exception ex)
            {
                throw;
            }
        }
        public void EliminarCategoriaOcupacional(string name, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                ThrOcupationalCategory data;
                data = newcontexto.ThrOcupationalCategories.Where(d => d.CategoryID == name).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasCategoriaOcupacionales(ThrOcupationalCategory catgOcup, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var cantidad = newcontexto.ThrPositions.Where(d => d.OcupationCategoryKey == catgOcup.OcupationCategoryKey).ToList();
                return cantidad.Count;
            }

        }
        public List<ThrOcupationalCategory> Actualizar(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var data = newcontexto.ThrOcupationalCategories.OrderBy(d => d.OcupationCategoryKey).ToList();
                List<ThrOcupationalCategory> listaObj = data;
                return listaObj;
            }
        }

    }
}
