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

namespace WPF_TiposBotones_22_03
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush brocha = null; //brocha compartida.

        public MainWindow()
        {
            InitializeComponent();
            imgFoto.Opacity = sldCambiar.Value; // Actualiza la opacidad de la imagen con el valor del slider.

        }

        //Usaremos el mismo evento para los 3 colores (Compartido por los 3 RADIOBUTTON)
        //Los 3 botones de radio llaman al mismo evento con este nombre:
        private void Click_Color(object sender, RoutedEventArgs e)
        {
            RadioButton rbtTmp = (RadioButton)sender; //Datos de quien lanza el evento.

            if (rbtTmp.Name == rbtBlanco.Name) //Comparas los nombres (preguntas qué botón es)
            {
                brocha = new SolidColorBrush(Colors.White);
                grdColor.Background = brocha;
            }

            if (rbtTmp.Name == rbtAzul.Name)
            {
                brocha = new SolidColorBrush(Colors.Blue);
                grdColor.Background = brocha;
            }

            if (rbtTmp.Name == rbtRojo.Name)
            {
                brocha = new SolidColorBrush(Colors.Red);
                grdColor.Background = brocha;
            }

        }


        //Eventos para el Checkbox
        private void cbxColor_Checked(object sender, RoutedEventArgs e)
        {
            recPanel.Fill = new SolidColorBrush(Colors.Red);

        }

        private void cbxColor_Unchecked(object sender, RoutedEventArgs e)
        {
            recPanel.Fill = new SolidColorBrush(Colors.White);
        }


        //Eventos para el Button Púlsame
        private void btnAccion_MouseEnter(object sender, MouseEventArgs e) // Evento cuando el ratón esté encima del botón (no llega a pulsar, solo cuando pasa el botón por la zona)
        {
            //MessageBox.Show("El ratón entró... ");
            tblInfo.Visibility = System.Windows.Visibility.Visible;
            
        }

        private void btnAccion_MouseLeave(object sender, MouseEventArgs e) //Evento cuando el ratón salga de encima del botón.
        {
            tblInfo.Visibility = System.Windows.Visibility.Hidden;
        }

        private void sldCambiar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            imgFoto.Opacity = sldCambiar.Value /100; // Actualiza la opacidad de la imagen con el valor del slider.
            tblValorSlider.Text = sldCambiar.Value.ToString("00:00");

        }
    }
}
