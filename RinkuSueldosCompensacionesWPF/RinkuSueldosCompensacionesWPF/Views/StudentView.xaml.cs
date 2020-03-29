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

namespace RinkuSueldosCompensacionesWPF.Views
{
    /// <summary>
    /// Lógica de interacción para StudentView.xaml
    /// </summary>
    public partial class StudentView : UserControl
    {
        public StudentView()
        {
            InitializeComponent();
        }
        private void btnNuevoEmp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminarEmp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnModificarEmp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuscarEmp_Click(object sender, RoutedEventArgs e)
        {
            StudentViewModel studentViewModelObject = new StudentViewModel();
            studentViewModelObject.LoadStudents();            
            dgBuscar.ItemsSource = studentViewModelObject.Students;
            dgBuscar.Visibility = Visibility.Visible;
        }

        private void rbInterno_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbExterno_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbChofer_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbCargadpr_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbAuxiliar_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuardarN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLimpiarN_Click(object sender, RoutedEventArgs e)
        {

        }
        private void rbTipoModificaEmpleado_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnGuardarE_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLimpiarE_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuscarE_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
