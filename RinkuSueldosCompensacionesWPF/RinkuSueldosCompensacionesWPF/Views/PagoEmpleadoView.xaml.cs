using RinkuSueldosCompensacionesWPF.Model;
using RinkuSueldosCompensacionesWPF.Utilities;
using RinkuSueldosCompensacionesWPF.ViewModel;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace RinkuSueldosCompensacionesWPF.Views
{
    /// <summary>
    /// Lógica de interacción para PagoEmpleadoView.xaml
    /// </summary>
    public partial class PagoEmpleadoView : UserControl
    {
        CLog LOG = GetLog.LOG;
        PagoEmpleadoViewModel pagoEmpleadoViewModelObject;
        public PagoEmpleadoView()
        {
            LOG.escribirLog("[PagoEmpleadoView::PagoEmpleadoView] ###### Inicia Pago Empleado ######");
            InitializeComponent();
        }
        private void OnlyNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void psBtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarPagarEmpleado();
        }

        private void psBtnPagar_Click(object sender, RoutedEventArgs e)
        {
            pagoEmpleadoViewModelObject = new PagoEmpleadoViewModel();
            
            pagoEmpleadoViewModelObject.pagoEmpleado(new PagoEmpleado
            {
                    foliopagar      = Int32.Parse(PagoFolioPago.Text),
                    foliocaptura    = Int32.Parse(PagoFolioCaptura.Text),
                    nombres         = PagoNombres.Text,
                    empleado        = Int32.Parse(PagoNumEmpleado.Text),
                    sueldobase      = Int32.Parse(PagoSueldoBase.Text),
                    bonotrabajo     = Int32.Parse(PagoBono.Text),
                    entregas        = Int32.Parse(PagoEntregas.Text),
                    vales           = decimal.Parse(PagoVales.Text),
                    total           = decimal.Parse(PagoTotal.Text),
                    isr             = decimal.Parse(PagoISR.Text),
                    totalpagar      = decimal.Parse(PagoTotalPagar.Text)
            });
            
            if (pagoEmpleadoViewModelObject.Pagos.ElementAt(0).foliopagar < 0)
            {
                MessageBox.Show(pagoEmpleadoViewModelObject.Pagos.ElementAt(0).nombres, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Pago a Empleado realizado con exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarPagarEmpleado();
            }
        }

        private void psBtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            pagoEmpleadoViewModelObject = new PagoEmpleadoViewModel();
            
            int valor;
            if (PagoNumEmpleado.Text == "")
            { MessageBox.Show("Favor de introducir un numero de empleado", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information); }
            else
            {
                valor = Int32.Parse(PagoNumEmpleado.Text);
                pagoEmpleadoViewModelObject.obtenerPagoEmpleado(valor);

                if (pagoEmpleadoViewModelObject.Pagos.ElementAt(0).foliopagar < 0)
                {
                    MessageBox.Show(pagoEmpleadoViewModelObject.Pagos.ElementAt(0).nombres, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    gridNomina.DataContext= pagoEmpleadoViewModelObject.Pagos;
                    PagoBtnPagar.IsEnabled = true;                    
                }
            }
        }

        private void LimpiarPagarEmpleado()
        {                       
            PagoBono.Text = String.Empty;
            PagoEntregas.Text = String.Empty;
            PagoFolioPago.Text = String.Empty;
            PagoISR.Text = String.Empty;
            PagoNombres.Text = String.Empty;
            PagoNumEmpleado.Text = String.Empty;
            PagoSueldoBase.Text = String.Empty;
            PagoTotal.Text = String.Empty;
            PagoTotalPagar.Text = String.Empty;
            PagoVales.Text = String.Empty;            
        }
    }
}
