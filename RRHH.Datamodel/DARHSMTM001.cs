using Entidades.General;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSMTM001
    {
        public ThrMovement BuscarMovimiento(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var movement = newcontexto.ThrMovements.Where(d => d.MovementID == cod).FirstOrDefault();
                return movement;
            }
        }
        public ThrMovement BuscarMovimientoXkey(int movementKey)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var movement = newcontexto.ThrMovements.Where(d => d.Movementkey == movementKey).FirstOrDefault();
                return movement;
            }
        }
        public void AdicionarMovement(ThrMovement mov)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var obj = newcontexto.ThrMovements.Where(d => d.MovementID == mov.MovementID).FirstOrDefault();
                if (obj != null)
                {
                    obj.MovementID = mov.MovementID;
                    obj.MovementName = mov.MovementName;
                    obj.MovementDescrip = mov.MovementDescrip;
                }
                else
                {
                    newcontexto.AddToThrMovements(mov);
                }
                newcontexto.SaveChanges();
            }

        }
        public void EliminarMovimiento(string cod)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.ThrMovements.Where(d => d.MovementID == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasMovement(ThrMovement mov)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var cantidad = newcontexto.ThrPeopleMovements.Where(d => d.Movementkey == mov.Movementkey).ToList();
                return cantidad.Count;                
            }
        }
        public List<ThrMovement> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var listdata = newcontexto.ThrMovements.ToList();
                return listdata;
            }
        }
    }
}
