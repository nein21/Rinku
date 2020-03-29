
using RinkuSueldosCompensacionesWPF.AbstractClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.ComponentModel.DataAnnotations;

namespace RinkuSueldosCompensacionesWPF.Model
{
    class EmpleadoModel {    }
    
    public class Empleado :AEmpleado, INotifyPropertyChanged
    {
        private int iChofer = 1;
        private int iCargador = 1;
        private int iAuxiliar = 1;
        private MementoEmpleado memento;
        

        [Key]
        public int idempleado
        {
            get{    return IdEmpleado;  }

            set
            {
                if (IdEmpleado != value)
                {
                    IdEmpleado = value;
                    RaisePropertyChanged("idempleado");
                }
            }
        }
        public string nombre
        {
            get{ return Nombre; }            
            set
            {
                if (Nombre != value)
                {
                    Nombre = value;
                    RaisePropertyChanged("nombre");
                }
            }
        }
        public string apaterno
        {
            get { return aPaterno; }
            set
            {
                if (aPaterno != value)
                {
                    aPaterno = value;
                    RaisePropertyChanged("apaterno");
                }
            }
        }
        public string amaterno
        {
            get { return aMaterno; }
            set
            {
                if (aMaterno != value)
                {
                    aMaterno = value;
                    RaisePropertyChanged("amaterno");
                }
            }
        }
        public int tipo
        {
            get { return Tipo; }
            set
            {
                if (Tipo != value)
                {
                    Tipo = value;
                    switch (Tipo)
                    {
                        case 1: RaisePropertyChanged("Interno"); break;
                        case 2: RaisePropertyChanged("Externo"); break;
                    }
                }
            }
        }
        public int rol
        {
            get { return Rol; }
            set
            {
                if (Rol != value)
                {
                    Rol = value;
                    switch (Rol)
                    {
                        case 1: RaisePropertyChanged("Chofer"); break;
                        case 2: RaisePropertyChanged("Cargador"); break;
                        case 3: RaisePropertyChanged("Auxiliar"); break;
                    }

                }
            }
        }


        public bool Interno
        { get { return tipo.Equals(1); } }
        public bool Externo
        { get { return tipo.Equals(2); ; } }
        public int Chofer
        { get { return iChofer; } }
        public int Cargador
        { get { return iCargador; } }
        public int Auxiliar
        { get { return iAuxiliar; } }

      

        public void makeMemento()
        {
            memento = new MementoEmpleado((Empleado)this.MemberwiseClone());
        }
        public void getMemento()
        {
            Empleado emp = memento.RecoveryEmpleado();
            this.idempleado =   emp.idempleado;
            this.nombre     =   emp.nombre;
            this.apaterno   =   emp.apaterno;
            this.amaterno   =   emp.amaterno;
            this.tipo       =   emp.tipo;
            this.rol        =   emp.rol;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}

