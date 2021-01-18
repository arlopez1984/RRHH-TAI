using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.General
{
    public class clsVacaciones
    {
        public int vacationkey { get; set; }
        public int personKey { get; set; }
        public DateTime fechInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public decimal horasDisfrutadas { get; set; }
        public DateTime FechaRegister { get; set; }
        public string CreateUserID { get; set; }
        public string CompanyID { get; set; }
    }
}
