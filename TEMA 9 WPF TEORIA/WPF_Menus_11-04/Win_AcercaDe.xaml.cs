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

namespace WPF_Menus_11_04
{
    /// <summary>
    /// Lógica de interacción para Win_AcercaDe.xaml
    /// </summary>
    public partial class Win_AcercaDe : Window
    {
        public Win_AcercaDe()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
