using Net4Sage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.General;

namespace RHSGDT001
{   
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SageSession session = new SageSession(args);
            Conection.connectionString = session.GetConnectionString();
            Application.Run(new frmGestionDeducciones(ref session));
        }
        
    }
} 
