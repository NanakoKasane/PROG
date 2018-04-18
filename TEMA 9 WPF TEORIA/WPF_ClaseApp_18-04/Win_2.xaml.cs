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

namespace ClaseApp_18_04
{
    /// <summary>
    /// Lógica de interacción para Win_2.xaml
    /// </summary>
    public partial class Win_2 : Window
    {
        public Win_2()
        {
            InitializeComponent();
        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            App objetoApp = Application.Current as App; 
            if (objetoApp != null)
            {
                tbx.Text = objetoApp.Compartir;
            }
        }
    }
}
