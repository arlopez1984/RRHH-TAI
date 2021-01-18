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
        public ThrMovement BuscarMovimiento(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var movement = newcontexto.ThrMovements.Where(d => d.MovementID == cod).FirstOrDefault();
                return movement;
            }
        }
        public ThrMovement BuscarMovimientoXkey(int movementKey, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var movement = newcontexto.ThrMovements.Where(d => d.Movementkey == movementKey).FirstOrDefault();
                return movement;
            }
        }
        public void AdicionarMovement(ThrMovement mov, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
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
        public void EliminarMovimiento(string cod, string conex)
        {
            using (var newcontexto = new Sage500AppEntities(conex.ToString()))
            {
                var data = newcontexto.ThrMovements.Where(d => d.MovementID == cod).FirstOrDefault();
                newcontexto.DeleteObject(data);
                newcontexto.SaveChanges();
            }
        }
        public int BuscarDependenciasMovement(ThrMovement mov, string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                //var cantidad = newcontexto.ThrPeople.Where(d => d.Subsidykey == subsi.SubsidyKey).ToList();
                //return cantidad.Count;
                return 2;
            }
        }
        public List<ThrMovement> Actualizar(string conexion)
        {
            using (var newcontexto = new Sage500AppEntities(conexion.ToString()))
            {
                var listdata = newcontexto.ThrMovements.ToList();
                return listdata;
            }
        }
    }
}
