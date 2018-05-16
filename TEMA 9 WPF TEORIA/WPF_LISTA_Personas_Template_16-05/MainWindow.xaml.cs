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

namespace WPF_Personas_Template_Lista_10_05
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Creo una Lista de personas:
        ListaPersonas _listaPersonas = new ListaPersonas();

        public MainWindow()
        {
            InitializeComponent();

            lbl_listaPersonas.DataContext = new ListaPersonas();
        }


        // Lo muestro en una ventana a parte
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Win_Lista ventanaLista = new Win_Lista();
            ventanaLista.lbl_listaPersonas.DataContext = new ListaPersonas();
            ventanaLista.ShowDialog();
        }

    }
}
