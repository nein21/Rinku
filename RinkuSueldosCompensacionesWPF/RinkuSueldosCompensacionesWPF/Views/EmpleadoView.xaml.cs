using RinkuSueldosCompensacionesWPF.Model;
using RinkuSueldosCompensacionesWPF.Utilities;
using RinkuSueldosCompensacionesWPF.ViewModel;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RinkuSueldosCompensacionesWPF.Views
{
    /// <summary>
    /// Lógica de interacción para StudentView.xaml
    /// </summary>
    public partial class EmpleadoView : UserControl
    {
        CLog LOG = GetLog.LOG;
        EmpleadoViewModel empleadoViewModelObject;
        EmpleadoViewModel ModifcaEmpleadoViewModelObject;
        Empleado modEmp;
        private int iTipo = 0;
        private int iNewTipo = 0;
        private int iModTipo = 0;
        private int iRol = 0;
        private int iNewRol = 0;
        private int iModRol = 0;
        
        public EmpleadoView()
        {
            LOG.escribirLog("[EmpleadoView::EmpleadoView] ###### Inicia Empleados ######");
            InitializeComponent();
        }
#region EVENTOS BOTONES BUSCAR
        private void BuscarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            int valor;
            Button btn = (Button)sender;            
            empleadoViewModelObject = new EmpleadoViewModel();
            

            switch (btn.Name)
            {
                case "ebBtnBuscar":
                        valor = ebTbNumero.Text == "" ? 0 : Int32.Parse(ebTbNumero.Text);
                        empleadoViewModelObject.buscaEmpleado(valor);
                        if (empleadoViewModelObject.Empleados.ElementAt(0).idempleado == -1)
                        {
                            MessageBox.Show(empleadoViewModelObject.Empleados.ElementAt(0).nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            dgBuscar.ItemsSource = empleadoViewModelObject.Empleados;

                        }                    
                    break;
                case "emBtnBuscar":
                        if (emTbNumero.Text == "")
                        { MessageBox.Show("Favor de introducir un numero de empleado", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information); }
                        else
                        {
                            ModifcaEmpleadoViewModelObject = new EmpleadoViewModel();
                            valor = Int32.Parse(emTbNumero.Text);
                            ModifcaEmpleadoViewModelObject.buscaEmpleado(valor);
                            if (ModifcaEmpleadoViewModelObject.Empleados.ElementAt(0).idempleado == -1)
                            {
                                MessageBox.Show(ModifcaEmpleadoViewModelObject.Empleados.ElementAt(0).nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                
                                ModifcaEmpleadoViewModelObject.Empleados.ElementAt(0).makeMemento();                                
                                ModificarEmpleado.DataContext = ModifcaEmpleadoViewModelObject.Empleados;
                                switch (ModifcaEmpleadoViewModelObject.Empleados.ElementAt(0).tipo)
                                {
                                    case 1: emRbInterno.IsChecked = true; break;
                                    case 2: emRbExterno.IsChecked = true; break;
                                }
                                switch (ModifcaEmpleadoViewModelObject.Empleados.ElementAt(0).rol)
                                {
                                    case 1: emRbChofer.IsChecked = true; break;
                                    case 2: emRbCargador.IsChecked = true; break;
                                    case 3: emRbAuxiliar.IsChecked = true; break;
                                }
                                emBtnGuardar.IsEnabled = true;
                                emTbNumero.IsReadOnly = true;
                                var bc = new BrushConverter();
                                emTbNumero.Background = (Brush)bc.ConvertFrom("#eae9e9");
                            }
                        }                        
                    break;
                case "eeBtnBuscar":
                        if (eeTbNumero.Text == "")
                        { MessageBox.Show("Favor de introducir un numero de empleado", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information); }
                        else
                        {
                            valor = Int32.Parse(eeTbNumero.Text);
                            empleadoViewModelObject.buscaEmpleado(valor);
                            
                          if (empleadoViewModelObject.Empleados.ElementAt(0).idempleado == -1)
                            {
                                MessageBox.Show(empleadoViewModelObject.Empleados.ElementAt(0).nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                ElminarEmpleado.DataContext = empleadoViewModelObject.Empleados;
                                switch (empleadoViewModelObject.Empleados.ElementAt(0).tipo)
                                {
                                    case 1: eeRbInterno.IsChecked = true; break;
                                    case 2: eeRbExterno.IsChecked = true; break;
                                }
                                switch (empleadoViewModelObject.Empleados.ElementAt(0).rol)
                                {
                                    case 1: eeRbChofer.IsChecked = true; break;
                                    case 2: eeRbCargador.IsChecked = true; break;
                                    case 3: eeRbAuxiliar.IsChecked = true; break;
                                }
                                eeBtnEliminar.IsEnabled = true;                                
                                eeTbNumero.IsReadOnly = true;
                                var bc = new BrushConverter();
                                eeTbNumero.Background = (Brush)bc.ConvertFrom("#eae9e9");
                            }
                        }
                    break;
            }
            //MessageBox.Show("btn.Name::::" + btn.Name);
        }
#endregion

#region EVENTO BOTONES GUARDAR
        private void enBtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            empleadoViewModelObject = new EmpleadoViewModel();
            int valor;
            
            
            //if (enTbNumero.Text == "")
            //{ MessageBox.Show("Favor de introducir un numero de Empleado", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information); }
            //else
            //{
                if (revisaCamposNuevoEmpleado())
                {
                    //valor = Int32.Parse(enTbNumero.Text);
                    empleadoViewModelObject.agregaEmpleado(new Empleado { idempleado = Int32.Parse(enTbNumero.Text), nombre = enTbNombres.Text, apaterno = enTbPaterno.Text, amaterno = enTbMaterno.Text, rol = iNewRol, tipo = iNewTipo });
                    //empleadoViewModelObject.agregaEmpleado(new Empleado {nombre = enTbNombres.Text, apaterno = enTbPaterno.Text, amaterno = enTbMaterno.Text, rol = iNewRol, tipo = iNewTipo });
                    if (empleadoViewModelObject.Empleados.ElementAt(0).idempleado == -1)
                    {
                        MessageBox.Show(empleadoViewModelObject.Empleados.ElementAt(0).nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("Empleado Guardado Con Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
            //}
        }

        private void emBtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            empleadoViewModelObject = new EmpleadoViewModel();
            int valor;           
            
            if (emTbNumero.Text == "")
            { MessageBox.Show("Favor de introducir un numero de Empleado", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information); }
            else
            {
                valor = Int32.Parse(emTbNumero.Text);
                var result = MessageBox.Show("Se va a Moficar un Empleado. ¿Desea continuar? ", "Modificar", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    empleadoViewModelObject.modificaEmpleado(new Empleado { idempleado = Int32.Parse(emTbNumero.Text), nombre = emTbNombres.Text, apaterno = emTbPaterno.Text, amaterno = emTbMaterno.Text, rol = iModRol, tipo = iModTipo });
                    if (empleadoViewModelObject.Empleados.ElementAt(0).idempleado == -1)
                    {
                        MessageBox.Show(empleadoViewModelObject.Empleados.ElementAt(0).nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("Empleado Modificado Con Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
        #endregion

#region EVENTO BOTONES LIMPIAR
        private void enBtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            empleadoViewModelObject = new EmpleadoViewModel();
            LimpiaNuevoEmpleado();
            empleadoViewModelObject.UltimoEmpleado();
            enTbNumero.Text = empleadoViewModelObject.Empleados.ElementAt(0).idempleado.ToString();

        }
        private void emBtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiaModificaEmpleado();
        }
        private void eeBtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiaEliminaEmpleado();
        }

        private void LimpiaNuevoEmpleado()
        {
            enTbMaterno.Text = "";
            enTbNombres.Text = "";
            enTbNumero.Text = "";
            enTbPaterno.Text = "";
            enRbAuxiliar.IsChecked = false;
            enRbCargador.IsChecked = false;
            enRbChofer.IsChecked = false;
            enRbExterno.IsChecked = false;
            enRbInterno.IsChecked = false;
        }
        private void LimpiaModificaEmpleado()
        {
            emTbMaterno.Text = "";
            emTbNombres.Text = "";
            emTbNumero.Text = "";
            emTbPaterno.Text = "";
            emTbNumero.IsReadOnly = false;
            emRbAuxiliar.IsChecked = false;
            emRbCargador.IsChecked = false;
            emRbChofer.IsChecked = false;
            emRbExterno.IsChecked = false;
            emRbInterno.IsChecked = false;
        }
        private void LimpiaEliminaEmpleado()
        {
            eeTbMaterno.Text = "";
            eeTbNombres.Text = "";
            eeTbNumero.Text = "";
            eeTbPaterno.Text = "";
            eeTbNumero.IsReadOnly = false;
            eeRbAuxiliar.IsChecked = false;
            eeRbCargador.IsChecked = false;
            eeRbChofer.IsChecked = false;
            eeRbExterno.IsChecked = false;
            eeRbInterno.IsChecked = false;
        }
        #endregion

        #region EVENTO VALIDACION DE TEXTBOX
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
        #endregion
#region EVENTO RADIO BUTTONS
        private void enRol_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.IsChecked == true)
            { iRol = 1; }
            else
            { iRol = 0; }

            switch (rb.Name)
            {                              
                case "enRbChofer":      iNewRol = 1;
                    break;
                case "enRbCargador":    iNewRol = 2;
                    break;
                case "enRbAuxiliar":    iNewRol = 3;
                    break;
                case "emRbChofer":      iModRol = 1;
                    break;
                case "emRbCargador":    iModRol = 2;
                    break;
                case "emRbAuxiliar":    iModRol = 3;
                    break;
            }
        }

        private void enTipo_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.IsChecked == true)
            {                iTipo = 1;            }
            else
            {                iTipo = 0;            }

            switch (rb.Name)
            {

                case "enRbInterno": iNewTipo = 1;
                    break;
                case "enRbExterno": iNewTipo = 2;
                    break;
                case "emRbInterno": iModTipo = 1;
                    break;
                case "emRbExterno": iModTipo = 2;
                    break;
            }
        }
#endregion
        private void eeBtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int valor;
            empleadoViewModelObject = new EmpleadoViewModel();

            if (eeTbNumero.Text == "")
            { MessageBox.Show("Favor de introducir un numero de empleado", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information); }
            else
            {
                valor = Int32.Parse(eeTbNumero.Text);
                DialogResultConverter dialogo = new DialogResultConverter();
                var result = MessageBox.Show("Se va a Eliminar un Empleado. ¿Desea continuar? ", "ELIMINAR", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    empleadoViewModelObject.eliminaEmpleado(valor);
                    if (empleadoViewModelObject.Empleados.ElementAt(0).idempleado == -1)
                    {
                        MessageBox.Show(empleadoViewModelObject.Empleados.ElementAt(0).nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("Empleado Borrado Con Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }                
                
            }
        }

        private bool revisaCamposNuevoEmpleado()
        {
            bool b = false;
            if (enTbNombres.Text == "")
            {
                MessageBox.Show("Campo Nombre Vacio, Favor de ingresar la informacion correspondiente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (enTbPaterno.Text == "")
            {
                MessageBox.Show("Campo Apellido patero Vacio, Favor de ingresar la informacion correspondiente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (enTbMaterno.Text == "")
            {
                MessageBox.Show("Campo Apellido materno Vacio, Favor de ingresar la informacion correspondiente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (enRbExterno.IsChecked == false && enRbInterno.IsChecked == false)
            {
                MessageBox.Show("No se selecciono Tipo de trabajador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (enRbAuxiliar.IsChecked == false && enRbCargador.IsChecked == false && enRbChofer.IsChecked == false)
            {
                MessageBox.Show("No se selecciono Rol de trabajador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                b = true;
            }

            return b;
        }

        private void emBtnRestablecer_Click(object sender, RoutedEventArgs e)
        {

            ModifcaEmpleadoViewModelObject.Empleados.ElementAt(0).getMemento();            
            var dato = ModificarEmpleado.DataContext;
            ModificarEmpleado.DataContext = ModifcaEmpleadoViewModelObject.Empleados;
            //LimpiaModificaEmpleado();

            switch (ModifcaEmpleadoViewModelObject.Empleados.ElementAt(0).tipo)
            {
                case 1: emRbInterno.IsChecked = true; break;
                case 2: emRbExterno.IsChecked = true; break;
            }
            switch (ModifcaEmpleadoViewModelObject.Empleados.ElementAt(0).rol)
            {
                case 1: emRbChofer.IsChecked = true; break;
                case 2: emRbCargador.IsChecked = true; break;
                case 3: emRbAuxiliar.IsChecked = true; break;
            }
        }
    }//Termina Clase
}//Termina NameSpace

