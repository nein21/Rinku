
using System;

namespace RinkuSueldosCompensacionesWPF.AbstractClass
{
   public abstract class AFolio
    {
        protected int       Folio;
        protected int       IdEmpleado;
        protected string    Nombre;  
        protected int       Cantidad;
        protected int       Turno;
        protected DateTime  Fecha;
        protected int       IdPagoempleado;
    }
}
