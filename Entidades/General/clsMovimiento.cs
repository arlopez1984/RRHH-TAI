using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.General
{
    public class clsMovimiento
    {
        public int movementkey { get; set; }
        public int personKey { get; set; }
        public DateTime fechaMovement { get; set; }        
        public int positionKey { get; set; }
        public int unidadOrgKey { get; set; }
        public int unidadOrgKeyDestino { get; set; }
        public int positionKeyDestino { get; set; }
        public string causa { get; set; }
        public int periodo { get; set; }
        public string CreateUserID { get; set; }
        public string CompanyID { get; set; }


    }
}
