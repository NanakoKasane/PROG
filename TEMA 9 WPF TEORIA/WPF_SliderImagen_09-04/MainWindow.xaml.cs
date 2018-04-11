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

namespace WPF_SliderImagen_09_04
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            imgImagen.Width = 30;
            imgImagen.Height = 40;

            sldVertical.Value = imgImagen.Height;
            sldHorizontal.Value = imgImagen.Width;

        }

        private void sldVertical_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            imgImagen.Height = sldVertical.Value * 10;
        }


        private void sldHorizontal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            imgImagen.Width = sldHorizontal.Value * 10;
        }

        private void sldOpacidad_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            imgImagen.Opacity = sldOpacidad.Value / 100;

        }
    }
}
