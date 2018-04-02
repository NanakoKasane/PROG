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

namespace WPF_Ej3_AdivinaNumero
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		static int contador = 1;

		public MainWindow()
		{
			InitializeComponent();

			//Al principio, hasta que se genere un número, el botón probar está deshabilitado y ver el número también
			cbxVerNumero.IsEnabled = false;
			btnProbar.IsEnabled = false;
		}

		private void btnGenerar_Click(object sender, RoutedEventArgs e)
		{
			Random rnd = new Random();
			int numeroAlea = rnd.Next(0, 101); //Se genera un número aleatorio del 0 al 100.
			btnProbar.IsEnabled = true;
			cbxVerNumero.IsEnabled = true; //Se ha generado un número aleatorio así que ya se puede ver cuál


			//Ya no se puede volver a generar un número nuevo hasta que se acierte el número
			btnGenerar.IsEnabled = false;

			//Guardo el número aleatorio:
			lblVerNumero.Content = numeroAlea;
			lblVerNumero.Visibility = System.Windows.Visibility.Hidden; //De momento no se verá

			tbxNumero.Focus();
			tbxNumero.SelectAll();
			
		}

		private void btnProbar_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				int numeroProbando = int.Parse(tbxNumero.Text);
				int numeroAlea = (int)lblVerNumero.Content;

				if (numeroAlea == numeroProbando)
				{
					lblResultado.Content = string.Empty;
					MessageBox.Show(string.Format("¡Has acertado el número en {0} intentos!", contador));

					// Lo reinicio todo ya que se ha acertado:
					contador = 1;
					btnProbar.IsEnabled = false;
					btnGenerar.IsEnabled = true;

					cbxVerNumero.IsEnabled = false; // Lo deshabilito
					lblVerNumero.Content = string.Empty; // Si estaba el número desaparece 
					cbxVerNumero.IsChecked = false; // Y si estaba marcado, se desmarca
				}

				else
				{
					lblResultado.Content = "NO, el número buscado es "; 
					lblResultado.Content += (numeroAlea > numeroProbando) ? "MAYOR" : "MENOR";
					contador++;
					tbxNumero.Focus();
					tbxNumero.SelectAll();
				}


			}
			catch
			{
				MessageBox.Show("Debe introducir un número");
				tbxNumero.Focus();
				tbxNumero.SelectAll();
			}
			
		}

		//Muestro el número aleatorio si se marca el checkbox
		private void cbxVerNumero_Checked(object sender, RoutedEventArgs e)
		{
			lblVerNumero.Visibility = System.Windows.Visibility.Visible;
		}

		private void cbxVerNumero_Unchecked(object sender, RoutedEventArgs e)
		{
			lblVerNumero.Visibility = System.Windows.Visibility.Hidden;
		}
	}
}
