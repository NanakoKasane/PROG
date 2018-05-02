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
//----------------------------
using Marina.WPF_DataContext_Personas_02_05;

namespace WPF_DataContext_Personas_02_05
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Creo una Lista de personas:
        ListaPersonas _listaPersonas = new ListaPersonas();
        Persona personaTmp = null;
        int posActual = -1;

        public MainWindow()
        {
            InitializeComponent();

            // Muestro una persona genérica
            Persona unaP = new Persona();
            stp_datos.DataContext = (object)unaP;
        }

        private void btn_Anterior_Click(object sender, RoutedEventArgs e)
        {
            if (posActual <= 0)
            {
                posActual = _listaPersonas.Count;
            }

            personaTmp = _listaPersonas[--posActual]; // Se resta antes porque no hemos puesto Count - 1. Así que nunca llega a Count
            stp_datos.DataContext = personaTmp;


        }

        private void btn_Siguiente_Click(object sender, RoutedEventArgs e)
        {
            if (posActual == _listaPersonas.Count -1)
                posActual = -1; // Se incrementa antes y ya valdrá 0

            personaTmp = _listaPersonas[++posActual]; //  % _listaPersonas.Count
            stp_datos.DataContext = personaTmp;
        }
    }
}
