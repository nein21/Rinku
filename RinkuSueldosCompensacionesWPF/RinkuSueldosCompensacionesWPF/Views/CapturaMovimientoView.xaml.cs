using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para CapturaMovimientoView.xaml
    /// </summary>
    public partial class CapturaMovimientoView : UserControl
    {
        public CapturaMovimientoView()
        {
            InitializeComponent();
        }

        private void btnBuscarE_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuscarN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chCubrioTurno_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuardarN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLimpiarN_Click(object sender, RoutedEventArgs e)
        {            
            
                
        }

        private void OnlyNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void OnlyText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");            
            e.Handled = regex.IsMatch(e.Text);            
        }

        private void btnBuscarB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmBtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cmTbMaterno.Text = String.Empty;
            cmTbNombres.Text = String.Empty;
            cmTbNumEmpleado.Text = String.Empty;
            cmTbPaterno.Text = String.Empty;
            cmCbRol.SelectedItem = null;
            cmCbTipo.SelectedItem = null;
            cmTbCantidad.Text = "0";
            cmDpFecha.Text = String.Empty;
            cmChCubrioTurno.IsChecked = false;            
            


            //foreach (Control c in )
            //{
            //    if (c is TextBox)
            //    {
            //        c.Text = "";
            //        //Enfoco en el primer TextBox                    
            //    }
            //}

        }

        private void ceBtnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ceBtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            ceTbMaterno.Text = String.Empty;
            ceTbNombres.Text = String.Empty;
            ceTbNumEmpleado.Text = String.Empty;
            ceTbPaterno.Text = String.Empty;
            ceTbRol.Text = String.Empty;
            ceTbTipo.Text = String.Empty;
            ceTbCantidad.Text = "0";
            cetbFecha.Text = String.Empty;
            ceChCubrioTurno.IsChecked = false;
        }

        private void ceBtnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cnBtnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cnBtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cnTbMaterno.Text = String.Empty;
            cnTbNombre.Text = String.Empty;
            cnTbNumEmpleado.Text = String.Empty;
            cnTbPaterno.Text = String.Empty;
            cnTbRol.Text = String.Empty;
            cnTbTipo.Text = String.Empty;
            cnTbCantidad.Text = "0";
            cnDpFecha.Text = String.Empty;
            cnChCubrioTurno.IsChecked = false;
        }

        private void cnBtnMenos1_Click(object sender, RoutedEventArgs e)
        {
            int iCantidad = Int32.Parse(cnTbCantidad.Text);
            if (iCantidad>0)
            {
                cnTbCantidad.Text = "" + (iCantidad - 1);
            }
            
        }

        private void cnBtnMas1_Click(object sender, RoutedEventArgs e)
        {
            cnTbCantidad.Text = "" + (Int32.Parse(cnTbCantidad.Text) + 1);
        }

        private void cmBtnMas1_Click(object sender, RoutedEventArgs e)
        {
            cmTbCantidad.Text = "" + (Int32.Parse(cmTbCantidad.Text) + 1);
        }

        private void cmBtnMenos1_Click(object sender, RoutedEventArgs e)
        {
            int iCantidad = Int32.Parse(cmTbCantidad.Text);
            if (iCantidad > 0)
            {
                cmTbCantidad.Text = "" + (iCantidad - 1);
            }
        }
    }
}
