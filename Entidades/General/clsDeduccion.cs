using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.General
{
    public class clsDeduccion
    {
        public int deductionkey { get; set; }
        public int personKey { get; set; }
        public DateTime fechInicio { get; set; } 
        public DateTime FechaRegister { get; set; }
        public decimal saldoTotal { get; set; }
        public decimal cuotaMensual { get; set; }
        public decimal saldoPendiente { get; set; }
        public string CreateUserID { get; set; }
        public string CompanyID { get; set; }



    }
}
