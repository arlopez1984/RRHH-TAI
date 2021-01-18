using Entidades.General;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSMNC
    {
        public ThrCulturalLevel BuscarNivelCultural(string level)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrCulturalLevel nivel = new ThrCulturalLevel();
                nivel = newcontexto.ThrCulturalLevels.Where(d => d.CulturalID == level).FirstOrDefault();
                return nivel;
            }
        }
        public void AdicionarNivelCultural(ThrCulturalLevel culturallevel)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrCulturalLevel obj = new ThrCulturalLevel();
                obj = newcontexto.ThrCulturalLevels.Where(d => d.CulturalID == culturallevel.CulturalID).FirstOrDefault();
                if (obj != null)
                {
                    obj.CulturalID = culturallevel.CulturalID;
                    obj.CulturalDesc = culturallevel.CulturalDesc;
                }
                else
                {
                    newcontexto.AddToThrCulturalLevels(culturallevel);
                }
                newcontexto.SaveChanges();
            }

        }
        public void EliminarNivelCultural(string level)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                ThrCulturalLevel data;
                data = newcontexto.ThrCulturalLevels.Where(d => d.CulturalID == level).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasNivelCultural(ThrCulturalLevel cultuLevel)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidad = newcontexto.ThrPeople.Where(d => d.CultureKey == cultuLevel.CulturalLevelKey).Count();
                return cantidad;
            }
        }
        public List<ThrCulturalLevel> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrCulturalLevels.OrderBy(d => d.CulturalLevelKey).ToList();                
                return data;
            }
        }
    }
}
