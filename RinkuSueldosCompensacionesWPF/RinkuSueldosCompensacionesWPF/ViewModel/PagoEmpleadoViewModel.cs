using RinkuSueldosCompensacionesWPF.Interface;
using System;
using RinkuSueldosCompensacionesWPF.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.SqlClient;

namespace RinkuSueldosCompensacionesWPF.ViewModel
{
    class PagoEmpleadoViewModel : IPago
    {
        
        public ObservableCollection<PagoEmpleado> Pagos {   get;    set;    }
        public void buscaPago(int id)
        {
            
        }
        public void obtenerImporteTotal(int id)
        {
            
        }
        public void obtenerPagoEmpleado(int id)
        {            
            //using (var rinku = new RinkuSP())
            using (var rinku = new RinkuEntities())
            {
                ObservableCollection<PagoEmpleado> pago = new ObservableCollection<PagoEmpleado>();                
                var pagoempleado = rinku.Database.SqlQuery<PagoEmpleado>("dbo.OBTENERPAGOEMPLEADO @IdEmpleado", new SqlParameter("@IdEmpleado", id)).ToList();              

                if (pagoempleado != null && pagoempleado.Count > 0)
                {
                    foreach (var f in pagoempleado)
                    {
                        pago.Add(f);
                    }
                }
                else
                {
                    pago.Add(new PagoEmpleado() { foliopagar = -1, nombres = "No se Encontro Registro" });
                }
                Pagos = pago;
            }
        }
        public void pagoEmpleado(PagoEmpleado pe)
        {
            using (var rinku = new RinkuEntities())
            {                
                ObservableCollection<PagoEmpleado> pago = new ObservableCollection<PagoEmpleado>();
                var InsertPagoEmpleado = rinku.rinkuPagoEmpleado.Add(pe);
                int respInsert = rinku.SaveChanges();

                var result = (from cf in rinku.rinkuCapturaFolio
                              where cf.idempleado== pe.empleado
                              where cf.folio == pe.foliocaptura 
                              select cf).ToList().FirstOrDefault();
                result.idpagoempleado = pe.foliopagar;
                int respUpdate = rinku.SaveChanges();
                
                pago.Add(new PagoEmpleado() { foliopagar = respUpdate });
                Pagos = pago;
            }
                
        }
    }
}
