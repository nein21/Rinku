using RinkuSueldosCompensacionesWPF.AbstractClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinkuSueldosCompensacionesWPF.Model
{
    class CapturaFolioModel { }
    public class CapturaFolio : AFolio, INotifyPropertyChanged
    {
        private int iCubrioTruno = 1;

        [Key]
        public int folio
        {
            get
            {
                return Folio;
            }

            set
            {
                if (Folio != value)
                {
                    Folio = value;
                    RaisePropertyChanged("folio");
                }
            }
        }
        public int idempleado
        {
            get
            {
                return IdEmpleado;
            }

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
            get
            {
                return Nombre;
            }

            set
            {
                if (Nombre != value)
                {
                    Nombre = value;
                    RaisePropertyChanged("Nombre");
                }
            }
        }     
        public int cantidad
        {
            get
            {
                return Cantidad;
            }

            set
            {
                if (Cantidad != value)
                {
                    Cantidad = value;
                    RaisePropertyChanged("cantidad");
                }
            }
        }
        public int turno
        {
            get
            {
                return Turno;
            }

            set
            {
                if (Turno != value)
                {
                    Turno = value;
                    RaisePropertyChanged("turno");
                }
            }
        }
        public DateTime fecha
        {
            get
            {
                return Fecha;
            }
            set
            {
                if (Fecha != value)
                {
                    Fecha = value;
                    RaisePropertyChanged("fecha");
                }
            }
        }
        public int idpagoempleado
        {
            get
            {
                return IdPagoempleado;
            }
            set
            {
                if (IdPagoempleado != value)
                {
                    IdPagoempleado = value;                    
                }
            }
        }
        public int CubrioTruno
        { get { return iCubrioTruno; } }

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
