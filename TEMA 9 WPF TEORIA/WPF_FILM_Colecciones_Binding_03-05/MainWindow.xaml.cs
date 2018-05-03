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
using Marina.WPF_Binding_SincronizarDatos_23_04;

namespace WPF_Binding_SincronizarDatos_23_04
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

        private void btnCambiarTitulo_Click(object sender, RoutedEventArgs e)
        {
            // Cambiamos algunas propiedades del objeto film creado como recurso accediento al mismo
            // Cambia el valor de Titulo de la clase film 

            Film film = Resources["film_Infiltrados"] as Film; // Sería como-> Film film = (Film)Resources["film_Infiltrados"];

            if (film != null)
            {
                film.Titulo = "Titanic";
                film.Genero = Genero.Catastrofismo;
                film.Oscar = true;
                film.Calificacion = 4.5;
            }

        }

        private void btn_IrColecciones_Click(object sender, RoutedEventArgs e)
        {
            Win_Colecciones ventana_Colecciones = new Win_Colecciones();
            ventana_Colecciones.ShowDialog();
        }
    }
}
