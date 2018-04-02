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
using System.Windows.Shapes;

namespace WPF_Ventanas_02_04
{
    /// <summary>
    /// Lógica de interacción para Win_Ventana2.xaml
    /// </summary>
    public partial class Win_Ventana2 : Window
    {
        public Win_Ventana2()
        {
            InitializeComponent();
        }

        private void btnLista_Click(object sender, RoutedEventArgs e)
        {
            tblTexto.Text = string.Empty;
            string[] lista = new string[] { "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Séis", "Siete", "Ocho", "Nueve", "Diez", "Once", "Doce", "Trece" };

            for (int i = 0; i < lista.Length; i++)
            {
                tblTexto.Text += lista[i] + "\n";
            }

            // Pongo el Scroll en una posición cualquiera:
            scvTexto.ScrollToVerticalOffset(55); // El scroll aparece por medio de la lista. Pero lo suyo es que empieze el scroll al principio (0.0)

        }
    }
}
