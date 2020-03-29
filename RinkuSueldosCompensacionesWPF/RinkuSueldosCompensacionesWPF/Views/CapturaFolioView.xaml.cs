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
    /// Lógica de interacción para CapturaFolioView.xaml
    /// </summary>
    public partial class CapturaFolioView : UserControl
    {
        CLog LOG = GetLog.LOG;
        CapturaFolioViewModel capturaFolioViewModelObject;
        private int iTurno = 0;
        private int iNewTurno = 0;
        private int iModTurno = 0;
        public CapturaFolioView()
        {
            LOG.escribirLog("[CapturaFolioView::CapturaFolioView] ###### Inicia Caputra Folio ######");
            InitializeComponent();
        }
        #region EVENTOS BOTONES BUSCAR
        private void BuscarFolio_Click(object sender, RoutedEventArgs e)
        {
            int valor;
            Button btn = (Button)sender;
            capturaFolioViewModelObject = new CapturaFolioViewModel();

            switch (btn.Name)
            {
                case "BuscarBtnBuscar":
                    valor = BuscarNumFolio.Text == "" ? 0 : Int32.Parse(BuscarNumFolio.Text);
                    capturaFolioViewModelObject.buscaFolio(valor);
                    if (capturaFolioViewModelObject.Folios.ElementAt(0).folio == -1)
                    {
                        MessageBox.Show(capturaFolioViewModelObject.Folios.ElementAt(0).nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        dgBuscar.ItemsSource = capturaFolioViewModelObject.Folios;                        
                    }
                    break;
                case "ModificaBuscar":
                    if (ModificaNumFolio.Text == "")
                    { MessageBox.Show("Favor de introducir un numero de folio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information); }
                    else
                    {
                        valor = Int32.Parse(ModificaNumFolio.Text);
                        capturaFolioViewModelObject.buscaFolio(valor);

                        if (capturaFolioViewModelObject.Folios.ElementAt(0).folio == -1)
                        {
                            MessageBox.Show(capturaFolioViewModelObject.Folios.ElementAt(0).nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            ModificaFolio.DataContext = capturaFolioViewModelObject.Folios;
                            ModificaGuardar.IsEnabled = true;
                        }
                    }
                    break;
                case "EliminarBuscar":
                    if (EliminarNumFolio.Text == "")
                    { MessageBox.Show("Favor de introducir un numero de folio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information); }
                    else
                    {
                        valor = Int32.Parse(EliminarNumFolio.Text);
                        capturaFolioViewModelObject.buscaFolio(valor);
                        if (capturaFolioViewModelObject.Folios.ElementAt(0).folio == -1)
                        {
                            MessageBox.Show(capturaFolioViewModelObject.Folios.ElementAt(0).nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            EliminaFolio.DataContext = capturaFolioViewModelObject.Folios;
                            EliminarBtnEliminar.IsEnabled = true;
                        }
                    }
                    break;
            }
            //MessageBox.Show("btn.Name::::" + btn.Name);
        }

        private void NuevoBuscar_Click(object sender, RoutedEventArgs e)
        {
            int valor;
            capturaFolioViewModelObject = new CapturaFolioViewModel();

            if (NuevoNumEmpleado.Text == "")
            {
                MessageBox.Show("Favor de introducir un numero de empleado", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                valor = Int32.Parse(NuevoNumEmpleado.Text);
                capturaFolioViewModelObject.obtieneUltimoFolio(valor);

                if (capturaFolioViewModelObject.Folios.ElementAt(0).folio == -1)
                {
                    MessageBox.Show(capturaFolioViewModelObject.Folios.ElementAt(0).nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    NuevoFolio.DataContext = capturaFolioViewModelObject.Folios;
                    NuevonGuardar.IsEnabled = true;
                }
            }
        }


        #endregion

        private void CubrioTurno_Click(object sender, RoutedEventArgs e)
        {
           CheckBox ch = (CheckBox)sender;
            if (ch.IsChecked == true)
            { iTurno = 1; }
            else
            { iTurno = 0; }

            switch (ch.Name)
            {
                case "NuevoCubrioTurno":
                    iNewTurno = iTurno;
                    break;
                case "ModificaTurno":
                    iModTurno = iTurno;
                    break;
            }
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

        private void EliminarBtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int valor;
            capturaFolioViewModelObject = new CapturaFolioViewModel();

            if (EliminarNumFolio.Text == "")
            { MessageBox.Show("Favor de introducir un numero de folio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information); }
            else
            {
                valor = Int32.Parse(EliminarNumFolio.Text);
                capturaFolioViewModelObject.eliminaFolio(valor);
                if (capturaFolioViewModelObject.Folios.ElementAt(0).folio == -1)
                {
                    MessageBox.Show(capturaFolioViewModelObject.Folios.ElementAt(0).nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Folio Borrado Con Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiaEliminaFolio();

                }
            }
        }     

      
        private void ModificaGuardar_Click(object sender, RoutedEventArgs e)
        {
            int valor;
            capturaFolioViewModelObject = new CapturaFolioViewModel();

            if (ModificaNumFolio.Text == "")
            { MessageBox.Show("Favor de introducir un numero de folio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information); }
            else
            {
                valor = Int32.Parse(ModificaNumFolio.Text);
                string sFecha = ModificaDpFecha.Text;
                
                string[] arrFecha = sFecha.Split('/');
                capturaFolioViewModelObject.modificaFolio(new CapturaFolio { folio = valor,nombre = ModificaNombre.Text ,idempleado = Int32.Parse(ModificaNumEmpleado.Text),
                                                          fecha =new DateTime(Int32.Parse( arrFecha[2]) , Int32.Parse(arrFecha[1]) , Int32.Parse(arrFecha[0])),
                                                            cantidad = Int32.Parse(ModificaCantidad.Text), turno = iModTurno });
                if (capturaFolioViewModelObject.Folios.ElementAt(0).folio == 1)
                {                    

                    MessageBox.Show("Folio Modificado Con Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiaModificaFolio();
                }
                else
                {
                    MessageBox.Show(capturaFolioViewModelObject.Folios.ElementAt(0).nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void NuevonGuardar_Click(object sender, RoutedEventArgs e)
        {
            int valor;
            capturaFolioViewModelObject = new CapturaFolioViewModel();

            if (NuevoNumFolio.Text == "")
            { MessageBox.Show("Favor de introducir un numero de folio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information); }
            else
            {
                valor = Int32.Parse(NuevoNumFolio.Text);
                string sFecha = NuevoDpFecha.Text;
                string[] arrFecha = sFecha.Split('/');
                capturaFolioViewModelObject.agregaFolio(new CapturaFolio { folio = valor,nombre = NuevoNombre.Text, idempleado = Int32.Parse(NuevoNumEmpleado.Text),
                                                        fecha = new DateTime(Int32.Parse(arrFecha[2]), Int32.Parse(arrFecha[1]), Int32.Parse(arrFecha[0])),
                                                        cantidad = Int32.Parse(NuevoCantidad.Text), turno = iNewTurno });
                if (capturaFolioViewModelObject.Folios.ElementAt(0).folio == -1)
                {
                    MessageBox.Show(capturaFolioViewModelObject.Folios.ElementAt(0).nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Folio Agregado Con Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiaNuevoFolio();

                }
            }
        }



        #region EVENTO BOTONES + Y -

        private void NuevoMenos1_Click(object sender, RoutedEventArgs e)
        {
            int iCantidad = Int32.Parse(NuevoCantidad.Text);
            if (iCantidad > 0)
            {
                NuevoCantidad.Text = "" + (iCantidad - 1);
            }
        }

        private void NuevoMas1_Click(object sender, RoutedEventArgs e)
        {
            NuevoCantidad.Text = "" + (Int32.Parse(NuevoCantidad.Text) + 1);
        }

        private void ModificaMenos1_Click(object sender, RoutedEventArgs e)
        {
            ModificaCantidad.Text = "" + (Int32.Parse(ModificaCantidad.Text) - 1);
        }

        private void ModificaMas1_Click(object sender, RoutedEventArgs e)
        {
            int iCantidad = Int32.Parse(ModificaCantidad.Text);
            if (iCantidad > 0)
            {
                ModificaCantidad.Text = "" + (iCantidad + 1);
            }
        }
       
    #endregion

    #region EVENTO BOTONES LIMPIAR        
        private void NuevoLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiaNuevoFolio();
        }

        private void ModificaLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiaModificaFolio();
        }        
        private void EliminarLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiaEliminaFolio();
        }
        private void LimpiaNuevoFolio()
        {
            NuevoNombre.Text = String.Empty;
            NuevoNumEmpleado.Text = String.Empty;
            NuevoCantidad.Text = "0";
            NuevoDpFecha.Text = String.Empty;
            NuevoCubrioTurno.IsChecked = false;
        }//Termina LimpiaNuevoFolio()

        private void LimpiaModificaFolio()
        {
            ModificaNombre.Text = String.Empty;
            ModificaNumFolio.Text = String.Empty;
            ModificaCantidad.Text = String.Empty;           
            ModificaDpFecha.Text = String.Empty;
            ModificaTurno.IsChecked = false;
        }//Termina LimpiaModificaFolio()

        private void LimpiaEliminaFolio()
        {
            EliminarNumFolio.Text = String.Empty;
            EliminarNumEmpleado.Text = String.Empty;
            EliminarNombres.Text = String.Empty;
            EliminarCantidad.Text = String.Empty;
            EliminarFecha.Text = String.Empty;
            EliminarCubrioTurno.IsChecked = false;
        }//Termina LimpiaEliminaFolio()
        #endregion





      
    }
}
