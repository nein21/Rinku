using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinkuSueldosCompensacionesWPF.Model
{
    class MementoEmpleado
    {
        private Empleado memento;

        public MementoEmpleado(Empleado emp)
        {
            this.memento = emp;
        }
        public Empleado RecoveryEmpleado()
        {
            return memento;
        }
    }
}
