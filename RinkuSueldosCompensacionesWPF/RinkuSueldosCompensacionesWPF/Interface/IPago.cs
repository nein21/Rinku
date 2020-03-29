using RinkuSueldosCompensacionesWPF.Model;

namespace RinkuSueldosCompensacionesWPF.Interface
{
    interface IPago
    {
        void obtenerPagoEmpleado(int id);
        void obtenerImporteTotal(int id);
        void pagoEmpleado(PagoEmpleado pe);
        void buscaPago(int id );        
    }
}
