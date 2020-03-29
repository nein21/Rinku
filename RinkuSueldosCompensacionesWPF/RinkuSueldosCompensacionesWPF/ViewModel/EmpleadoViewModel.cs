using RinkuSueldosCompensacionesWPF.Interface;
using RinkuSueldosCompensacionesWPF.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace RinkuSueldosCompensacionesWPF.ViewModel
{
    public class EmpleadoViewModel : IEmpleado
    {        
        public ObservableCollection<Empleado> Empleados {   get;    set;    }
        
        public void UltimoEmpleado()
        {
            
            using (var rinku = new RinkuEntities())
            {
                Empleado e = new Empleado();
                ObservableCollection<Empleado> empleados = new ObservableCollection<Empleado>();
                var lastEmpleado = rinku.Database.SqlQuery<int>("select ISNULL(max(idempleado),0) as idempleado from empleado").FirstOrDefault();                    
                e.idempleado = (lastEmpleado + 1);              
                empleados.Add(e);
                Empleados = empleados;
            }            
        }
        public void agregaEmpleado(Empleado e)
        {
            using (var rinku = new RinkuEntities())
            {
                ObservableCollection<Empleado> empleados = new ObservableCollection<Empleado>();
                var InsertEmpleado = rinku.rinkuEmpleados.Add(e);
                int resp = rinku.SaveChanges();                
                empleados.Add(new Empleado() {idempleado = resp });
                Empleados = empleados;
            }            
        }
        public void buscaEmpleado(int id)
        {
            string sqlString = "";
            if (id != 0)
            {
                sqlString = "where idempleado = " + id;
            }
            using (var rinku = new RinkuEntities())
            {
                ObservableCollection<Empleado> empleados = new ObservableCollection<Empleado>();
                var lastEmpleado = rinku.Database.SqlQuery<Empleado>("select idempleado, nombre, apaterno, amaterno, tipo, rol from Empleado "+ sqlString).ToList();

                if (lastEmpleado != null && lastEmpleado.Count >0)
                {
                    foreach (var e in lastEmpleado)
                    {
                        empleados.Add(e);
                    }
                }
                else
                {
                    empleados.Add(new Empleado() {idempleado=-1,nombre="No se Encontro Registro" });
                }               
                Empleados = empleados;
            }            
        }        
        public void modificaEmpleado(Empleado e)
        {
            using (var rinku = new RinkuEntities())
            {
                ObservableCollection<Empleado> empleados = new ObservableCollection<Empleado>();
                var result = (from emp in rinku.rinkuEmpleados
                              where emp.idempleado == e.idempleado
                              select emp).ToList();

                foreach (Empleado res in result)
                {                    
                    res.nombre = e.nombre;
                    res.apaterno = e.apaterno;
                    res.amaterno = e.amaterno;
                    res.tipo = e.tipo;
                    res.rol = e.rol;
                }
                
                int resp = rinku.SaveChanges();
                empleados.Add(new Empleado() { idempleado = resp });
                Empleados = empleados;
            }
        }
        public void eliminaEmpleado(int id)
        {
            using (var rinku = new RinkuEntities())
            {
                ObservableCollection<Empleado> empleados = new ObservableCollection<Empleado>();
                var result = (from emp in rinku.rinkuEmpleados
                              where emp.idempleado == id
                              select emp).FirstOrDefault<Empleado>();

                var renove = rinku.rinkuEmpleados.Remove(result);
                int resp = rinku.SaveChanges();

                empleados.Add(new Empleado() { idempleado = resp });
                Empleados = empleados;
            }
        }        
    }
}
