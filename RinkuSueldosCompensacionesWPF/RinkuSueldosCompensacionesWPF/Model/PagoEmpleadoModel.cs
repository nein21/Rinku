using RinkuSueldosCompensacionesWPF.AbstractClass;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RinkuSueldosCompensacionesWPF.Model
{
    class PagoEmpleadoModel   {    }

    public class PagoEmpleado : APago, INotifyPropertyChanged
    {
        [Key]
        public int foliopagar
        {
            get { return FolioPagar; }
            set
            {
                if (FolioPagar != value)
                {
                    FolioPagar = value;
                    RaisePropertyChanged("foliopagar");
                }
            }
        }
        public int foliocaptura
        {
            get { return Foliocaptura; }
            set
            {
                if (Foliocaptura != value)
                {
                    Foliocaptura = value;
                    RaisePropertyChanged("foliocaptura");
                }
            }
        }
        public int empleado
        {
            get { return Empleado; }
            set
            {
                if (Empleado != value)
                {
                    Empleado = value;
                    RaisePropertyChanged("empleado");
                }
            }
        }        
        public string nombres
        {
            get { return Nombres; }

            set
            {
                if (Nombres != value)
                {
                    Nombres = value;
                    RaisePropertyChanged("nombres");
                }
            }
        }
        public int sueldobase
        {
            get { return SueldoBase; }

            set
            {
                if (SueldoBase != value)
                {
                    SueldoBase = value;
                    RaisePropertyChanged("sueldobase");
                }
            }
        }
        public int bonotrabajo
        {
            get { return BonoTrabajo; }
            set
            {
                if (BonoTrabajo != value)
                {
                    BonoTrabajo = value;
                    RaisePropertyChanged("bonotrabajo");
                }
            }
        }
        public int entregas
        {
            get { return Entregas; }
            set
            {
                if (Entregas != value)
                {
                    Entregas = value;
                    RaisePropertyChanged("entregas");
                }
            }
        }
        public Decimal vales
        {
            get { return Vales; }
            set
            {
                if (Vales != value)
                {
                    Vales = value;
                    RaisePropertyChanged("vales");
                }
            }
        }
        public Decimal total
        {
            get { return Total; }
            set
            {
                if (Total != value)
                {
                    Total = value;
                    RaisePropertyChanged("total");
                }
            }
        }
        public Decimal isr
        {
            get { return Isr; }
            set
            {
                if (Isr != value)
                {
                    Isr = value;
                    RaisePropertyChanged("isr");
                }
            }
        }
        public Decimal totalpagar
        {
            get { return TotalPagar; }
            set
            {
                if (TotalPagar != value)
                {
                    TotalPagar = value;
                    RaisePropertyChanged("totalpagar");
                }
            }
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
