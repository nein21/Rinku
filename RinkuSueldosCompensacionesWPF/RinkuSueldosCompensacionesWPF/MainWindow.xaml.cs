using RinkuSueldosCompensacionesWPF.Utilities;
using RinkuSueldosCompensacionesWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RinkuSueldosCompensacionesWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CLog LOG = GetLog.LOG;
        public MainWindow()
        {
            LOG.escribirLog("[MainWindow::MainWindow] ================== Inicia Rinku Sueldos y Compensaciones ================== ");
            InitializeComponent();
        }
        
    

        private void Empleado_Click(object sender, RoutedEventArgs e)
        {
            EmpleadViewControl.Visibility = Visibility.Visible;
            PagoEmpleadoViewControl.Visibility = Visibility.Hidden;
            CapturaMovimientoViewControl.Visibility = Visibility.Hidden;
        }
        private void CapMov_Click(object sender, RoutedEventArgs e)
        {
            EmpleadViewControl.Visibility = Visibility.Hidden;
            PagoEmpleadoViewControl.Visibility = Visibility.Hidden;
            CapturaMovimientoViewControl.Visibility = Visibility.Visible;
        }
        private void Pagar_Click(object sender, RoutedEventArgs e)
        {
            EmpleadViewControl.Visibility = Visibility.Hidden;
            CapturaMovimientoViewControl.Visibility = Visibility.Hidden;
            PagoEmpleadoViewControl.Visibility = Visibility.Visible;
        }
    

      
    }
}
