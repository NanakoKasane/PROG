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

namespace Eventos_18_04
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

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            // Evento que se lanza cada vez que se mueve el ratón
            this.Title = "(" + e.GetPosition(this).X + " , " + e.GetPosition(this).Y + ") ";
            this.Title += e.Source.GetType().Name; // Nombre del elemento que está lanzando el evento en realidad. Se está capturando en la ventana porque la ventana es la raíz y se propaga.
            
        }

        private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Con esto evitas que este evento se propague a la raíz. Ahora no se lanzará Window_MouseMove si el ratón está en la elipse. Si está en el rectángulo o los demás si, se propagan.
        }
    }
}
