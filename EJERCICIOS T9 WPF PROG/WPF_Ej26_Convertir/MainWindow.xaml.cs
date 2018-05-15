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

using System.Windows.Threading;

namespace WPF_Ej26_Convertir
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		DispatcherTimer cronometro = new DispatcherTimer();
		Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();

			//Empiezo por una pieza en concreto
			Ajedrez ajedrez = new Ajedrez(piezas.caballo, DateTime.Now);
            stp_Datos.DataContext = ajedrez;


			// Y cada segundo va apareciendo otra pieza aleatoria
			cronometro.Tick += cronometro_Tick;
			cronometro.Interval = new TimeSpan(0, 0, 1);
			cronometro.Start();			
			
        }

		void cronometro_Tick(object sender, EventArgs e)
		{
			//string[] nombrePiezas = Enum.GetNames(typeof(piezas));
			//int random = rnd.Next(nombrePiezas.Length);

			// Esto sería lo único necesario para obtener un random de una Enum:
			Array array = Enum.GetValues(typeof(piezas));
			int random = rnd.Next(array.Length);
			piezas valorPiezaRandom = (piezas)array.GetValue(random);

			Ajedrez ajedrez = new Ajedrez(valorPiezaRandom, DateTime.Now);
			stp_Datos.DataContext = ajedrez;

		}
    }
}
