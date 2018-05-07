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

namespace WPF_Recursos_07_05
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush[] brochas = new SolidColorBrush[4];
        int posicionActual = 0;

        public MainWindow()
        {
            InitializeComponent();

            brochas[0] = this.Resources["colorFondo1"] as SolidColorBrush;
            brochas[1] = this.Resources["colorFondo2"] as SolidColorBrush;
            brochas[2] = App.Current.Resources["colorFondo3"] as SolidColorBrush;
            brochas[3] = Application.Current.Resources["colorFondo4"] as SolidColorBrush;

        }

        private void btn_AlternarColor_Click(object sender, RoutedEventArgs e)
        {
            // Alterna el color de fondo usando recursos de color;
            SolidColorBrush brocha1 = Resources["colorFondo1"] as SolidColorBrush;
            SolidColorBrush brocha2 = Resources["colorFondo2"] as SolidColorBrush;
                        
            App aplicasion = Application.Current as App; // Objeto de la aplicación que está corriendo
            SolidColorBrush brocha3 =  aplicasion.Resources["colorFondo3"] as SolidColorBrush;

            if (brocha1 == null || brocha2 == null) // Si hay alguno que no ha podido convertir, sale 
                return;

            // Alterno el color del botón:
            if (btn_AlternarColor.Background == brocha1)
                btn_AlternarColor.Background = brocha2;
            else if (btn_AlternarColor.Background == brocha2)
                btn_AlternarColor.Background = brocha3;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Alterno el color de la ELIPSE usando el ARRAY de SolidColorBrush:
            elp_EliseJgl.Fill = brochas[posicionActual % brochas.Length];
            btn_AlternarColor.Content = brochas[posicionActual % brochas.Length].Color.ToString();
            posicionActual++;
        }
    }
}
