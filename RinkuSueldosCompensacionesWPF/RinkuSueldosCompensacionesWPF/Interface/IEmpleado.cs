using RinkuSueldosCompensacionesWPF.Model;

namespace RinkuSueldosCompensacionesWPF.Interface
{
    interface IEmpleado
    {
        void UltimoEmpleado();
        void agregaEmpleado(Empleado e);
        void buscaEmpleado(int id);        
        void modificaEmpleado(Empleado e);
        void eliminaEmpleado(int id);
    }
}
