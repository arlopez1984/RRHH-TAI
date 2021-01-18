using Entidades.General;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.Datamodel
{
    public class DARHSMDE001
    {
        public TsmCompany BuscarCompanyExistente(string nomID)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var compa = newcontexto.TsmCompanies.Where(d => d.CompanyID == nomID).FirstOrDefault();
                return compa;
            }
        }
        public ThrCompany BuscarCompany(string codigo)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var compa = newcontexto.ThrCompanies.Where(d => d.CodigoCompany == codigo).FirstOrDefault();
                return compa;
            }
        }
        public List<TglSegment> BuscarSegmentosCuenta(string company)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var segementos = newcontexto.TglSegments.Where(d =>d.CompanyID == company).ToList();
                return segementos;
            }
        }
        public void AdicionarDatosEmpresa(ThrCompany compania)
        {
            try
            {
                using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
                {
                    var obj = newcontexto.ThrCompanies.Where(d => d.CodigoCompany == compania.CodigoCompany).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.CodigoCompany = compania.CodigoCompany;
                        obj.Sector = compania.Sector;
                        obj.ContraEstipendioAlimenticio = compania.ContraEstipendioAlimenticio;
                        obj.ContraValoPägoCuc = compania.ContraValoPägoCuc;
                        obj.CuentaBancaria = compania.CuentaBancaria;
                        obj.NoSegmentoCentro = compania.NoSegmentoCentro;
                        obj.Province = compania.Province;
                        obj.Municipy = compania.Municipy;
                    }
                    else
                    {
                        newcontexto.AddToThrCompanies(compania);
                    }
                    newcontexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }


        }
        public bool EliminarDatosEmpresa(string name)
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var unidadOrg = newcontexto.ThrOrganizativeUnits.ToList();
                if (unidadOrg.Count > 0)
                { return false; }
                else
                {
                    var data = newcontexto.ThrCompanies.Where(d => d.CodigoCompany == name).FirstOrDefault();
                    if (data != null)
                    {
                        newcontexto.DeleteObject(data);
                        newcontexto.SaveChanges();                        
                    }
                    return true;
                }
            }
          
        }
        public List<TsmCompany> Actualizar()
        {
            using (var newcontexto = new Sage500AppEntities(Conection.connectionString))
            {
                var data = newcontexto.TsmCompanies.ToList();
                return data;
            }
        }
    }
}

