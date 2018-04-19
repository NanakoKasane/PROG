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

namespace WPF_CompartirInfo_EntreVentanas_19_04
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
            Ventana2 ventana2 = new Ventana2();

            ventana2.OnEnviar += ventana2_OnEnviar;
            ventana2.ShowDialog();
        }

        void ventana2_OnEnviar(string[] datos)
        {
            tblDato1.Text = datos[0];
            tblDato2.Text = datos[1];
        }
    }
}
