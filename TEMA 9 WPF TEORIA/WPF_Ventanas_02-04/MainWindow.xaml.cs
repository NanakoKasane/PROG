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

namespace WPF_Ventanas_02_04
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Para usar la sobrecarga de MessageBox.Show y que pregunte si quiere salir.
            string titulo = "Abandonar la aplicación"; // Caption
            string mensaje = "¿Seguro que desea salir?";
            MessageBoxButton botones = MessageBoxButton.YesNo;
            MessageBoxImage imagen = MessageBoxImage.Question;


            MessageBoxResult respuesta = MessageBox.Show(mensaje, titulo, botones, imagen);

            if (respuesta == MessageBoxResult.No || respuesta == MessageBoxResult.Cancel)
                e.Cancel = true; // Cancela el cierre de la ventana. No se cerrará.

            if (respuesta == MessageBoxResult.Yes)
                e.Cancel = false; // No cancela el cierre de la ventana. Es decir, sí se cierra.

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Win_Ventana2 _ventana2 = new Win_Ventana2();
            _ventana2.ShowDialog(); // No puedes volver a la ventana padre hasta que la cierres.

        }
    }

    
}
