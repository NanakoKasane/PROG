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

namespace ClaseApp_18_04
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
            App objetoApp = Application.Current as App; // Compruebas que es un App con -> as App. Si no fuera un objeto App, falla la conversión y valdrá null. 
            // Es como casting pero en vez de una excepción si falla vale null. As es un operador por referencia y comprueba si son tipos compatibles

            if (objetoApp != null)
            {
                tbxOrigen.Text = objetoApp.Compartir;
            }

        }
    }
}
