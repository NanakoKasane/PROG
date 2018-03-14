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
//Cuando acabes --> Click derecho en System. o using --> Organizar using --> Quitar instrucciones using no usadas

namespace WPF_Boton_14_03
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window //partial --> Quiere decir que la clase pública está repartida en varios ficheros. Que hay parte de esta clase que está en otro sitio.
    {
        bool color = true;

        public MainWindow() //Constructor
        {
            InitializeComponent(); //Inicializa los componentes necesarios. Los prepara ya el sistema.
        }

        //CONTROLADOR/MANEJADOR DE EVENTO (del evento click del botón, añadido por nosotros):
        private void Button_Click2(object sender, RoutedEventArgs e) //sender -> objeto que lanza el evento (el botón).  e --> objeto RoutedEvent.. trae información del evento
        {
            //Código que cambiará de color el botón:
            if (color)
            {
                MiBoton.Background = Brushes.Aqua; //La clase que pinta de un color se llama brocha (Brushes)
            }
            else
            {
                MiBoton.Background = Brushes.Red;
            }
            color = !color; //Si era true ahora será false.
        }

        //Este evento lo hemos creado dando doble click en la ventana de propiedades (eventos) al evento KeyDown
        private void MiBoton_KeyDown(object sender, KeyEventArgs e) //Tiene que estar el foco en el botón para que se ejecute.
        {
            if (e.Key == Key.Escape) //Se ejecutará cuando se haya pulsado la tecla Escape. e -> tiene la información de la tecla pulsada
            {
                MessageBox.Show("Has pulsado ESCAPE"); //Esto es como el nuevo Console.Write(" ");
                //Te muestra una ventana de texto con el mensaje
                //Se llaman ventanas modales/Cuadro de diálogo --> Se muestran y no se pueden ejecutar lo que hay detrás hasta que no se cierre.
            }
        }
    }

    //El elemento típico de un botón es el click. DANDOLE DOBLE CLICK AL BOTÓN SE CREA EL EVENTO onlick (que es el por defecto en este caso).

    //Para crear eventos hay que ponerle un atributo con el nombre del evento y cuyo valor sea el método que se va a ejecutar cuando se produzca el evento
}
