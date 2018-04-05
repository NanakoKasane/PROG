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

namespace WPF_TabItem_05_04
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

        private void tbcPestanas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            this.Title = tbcPestanas.SelectedIndex.ToString(); // Se muestra en el título la pestaña seleccionada.
            // this.Title = tbItem1.Header.ToString();  // Te saldría el Header de la pestaña no el índice.
 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbcPestanas.SelectedIndex == 0)
                tbItem2.Focus();

            else if (tbcPestanas.SelectedIndex == 1)
                tbItem1.Focus();
        }


    }
}
