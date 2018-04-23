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
//---------------------------
using Microsoft.Win32;

namespace WPF_CuadrosDialogo_23_04
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mensaje = "Soy el mensaje del cuadro de diálogo";
            string titulo = "Soy el título...";
            MessageBoxResult botonPulsado = new MessageBoxResult(); // Recoge el resultado del botón pulsado. 
            MessageBoxButton botones = MessageBoxButton.YesNoCancel;
            MessageBoxImage icono = MessageBoxImage.Question;

            botonPulsado = MessageBox.Show(mensaje, titulo, botones, icono);
            if (botonPulsado == MessageBoxResult.Yes)
            {
                MessageBox.Show("Pulsaste sí");
            }
            else
                this.Title = botonPulsado.ToString();

        }

        private void btnAbrirArchivo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdAbrir = new OpenFileDialog();
            ofdAbrir.InitialDirectory = @"C:\basura";
            ofdAbrir.FileName = "Nombre_Fichero_Defecto"; // FileName -> Guarda el nombre de la ruta elegida.
            ofdAbrir.DefaultExt = ".txt"; // Extensiones que muestra para elegir por defecto
            ofdAbrir.Filter = "Textos|*.txt|Imagenes|*.jpg;*.png"; // Solo mostrará los .txt y .jpg o .png para poder elegirlos. Lo primero es la palabra que ves y lo siguiente el filtro que aplicas

            Nullable<bool> resultado = ofdAbrir.ShowDialog(); // Devuelve true si se ha elegido una ruta válida
            if (resultado == true)
            {
                this.Title = ofdAbrir.FileName;
            }

        }

        private void btnGuardarArchivo_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfdGuardar = new SaveFileDialog();
            sfdGuardar.InitialDirectory = "C:\\basura";
            sfdGuardar.FileName = "fichero_mio";
            sfdGuardar.DefaultExt = "*.mio";

            Nullable<bool> resultado = sfdGuardar.ShowDialog();
            if (resultado == true)
            {
                this.Title = sfdGuardar.FileName;
            }
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dlgPrint = new PrintDialog();

            Nullable<bool> resultado = dlgPrint.ShowDialog();
            if (resultado == true)
            {
                this.Title = "Imprimiendo...";
            }

        }
    }
}
