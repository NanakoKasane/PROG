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

namespace WPF_Menus_11_04
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

        private void MnuHerramientas_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Herramientas");
        }

        private void MnuAyuda_Click(object sender, RoutedEventArgs e)
        {
            Win_AcercaDe ventanaAcercaDe = new Win_AcercaDe();
            ventanaAcercaDe.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Menu Contextual Window.Click, opcion copiar
            MessageBox.Show("Copiando...");
        }
    }
}
