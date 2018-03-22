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

namespace WPF_PanelCanvas_21_03
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
            //Creo un rectángulo
            Rectangle rectangulo = new Rectangle(); 
            rectangulo.Width = 50;
            rectangulo.Height = 50;
            rectangulo.Fill = new SolidColorBrush(Colors.Red); //Fill rellena su contenido, en vez de Background, para el rectángulo es fill. Y hay que pintar con una brocha sólida.

            //Posición en la que estará el rectángulo
            Canvas.SetTop(rectangulo, 80);
            Canvas.SetLeft(rectangulo, 20); //Propiedad de dependencia. Adquiere su valor dependiendo de otras propiedades (Del canvas en este caso).

            //Añadir el rectángulo a la colección Children del Canvas
            cnvPanel.Children.Add(rectangulo);
            
        }

        void Mover()
        {

        }

    }
}
