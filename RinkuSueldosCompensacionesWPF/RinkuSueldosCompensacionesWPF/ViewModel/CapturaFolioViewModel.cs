using RinkuSueldosCompensacionesWPF.Interface;
using System;
using System.Linq;
using RinkuSueldosCompensacionesWPF.Model;
using System.Collections.ObjectModel;


namespace RinkuSueldosCompensacionesWPF.ViewModel
{
    class CapturaFolioViewModel : IFolio
    {
        
        public ObservableCollection<CapturaFolio> Folios    {   get;    set;    }

        public void obtieneUltimoFolio(int id)
        {
            using (var rinku = new RinkuEntities())
            {
                ObservableCollection<CapturaFolio> folio = new ObservableCollection<CapturaFolio>();
                var resultEmpleado = (from emp in rinku.rinkuEmpleados
                                      where emp.idempleado == id
                                      select emp).FirstOrDefault<Empleado>();

                var lastFolio = rinku.Database.SqlQuery<int>("select ISNULL(max(folio),0) as folio from CapturaFolio").FirstOrDefault();

                folio.Add(new CapturaFolio() { folio=(lastFolio + 1),nombre =(resultEmpleado.nombre + " " + resultEmpleado.apaterno + " " + resultEmpleado.amaterno ) });
                Folios = folio;
            }
        }
        public void agregaFolio(CapturaFolio f)
        {            
            using (var rinku = new RinkuEntities())
            {
                ObservableCollection<CapturaFolio> folio = new ObservableCollection<CapturaFolio>();
                var InsertCapturaFolio = rinku.rinkuCapturaFolio.Add(f);
                int resp = rinku.SaveChanges();
                folio.Add(new CapturaFolio() { folio = resp });
                Folios = folio;
            }
        }

        public void buscaFolio(int id)
        {
            string sqlString = "";
            if (id != 0)
            {
                sqlString = "where folio = " + id;
            }
            using (var rinku = new RinkuEntities())
            {
                ObservableCollection<CapturaFolio> folio = new ObservableCollection<CapturaFolio>();
                var lastFolio = rinku.Database.SqlQuery<CapturaFolio>("select folio,idempleado,nombre,cantidad,turno,fecha,idpagoempleado from capturafolio " + sqlString).ToList();

                if (lastFolio != null && lastFolio.Count > 0)
                {
                    foreach (var f in lastFolio)
                    {
                        folio.Add(f);
                    }
                }
                else
                {
                    
                    folio.Add(new CapturaFolio() { folio = -1, nombre="No se Encontro Registro" });
                }
                Folios = folio;
            }            
        }

        public void eliminaFolio(int id)
        {
            using (var rinku = new RinkuEntities())
            {
                ObservableCollection<CapturaFolio> folio = new ObservableCollection<CapturaFolio>();
                var result = (from f in rinku.rinkuCapturaFolio
                              where f.folio == id
                              select f).FirstOrDefault<CapturaFolio>();

                var renove = rinku.rinkuCapturaFolio.Remove(result);
                int resp = rinku.SaveChanges();
                
                folio.Add(new CapturaFolio() { folio = resp });
                Folios = folio;
            }
        }

        public void modificaFolio(CapturaFolio f)
        {           
            using (var rinku = new RinkuEntities())
            {
                ObservableCollection<CapturaFolio> folio = new ObservableCollection<CapturaFolio>();
                var result = (from cf in rinku.rinkuCapturaFolio
                              where cf.folio == f.folio
                              select cf).ToList();

                foreach (CapturaFolio res in result)
                {
                    res.folio       = f.folio;
                    res.nombre      = f.nombre;
                    res.idempleado  = f.idempleado;
                    res.cantidad    = f.cantidad;
                    res.turno       = f.turno;
                    res.fecha       = f.fecha;
                }

                int resp = rinku.SaveChanges();
                folio.Add(new CapturaFolio() { folio = resp });
                Folios = folio;
            }
        }        
    }
}
