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

namespace WPF_Ej9_TiradasDado
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

		static int totalTiradas = 0; // Contador para el total de tiradas que se llevan hechas
		int resultadoTirada; // Variable temporal para guardar el resultado de la tirada antes de añadirlo al diccionario de tiradas

		// Diccionario que va contando cuántos 1, 2, 3, 4, 5, 6 han salido en las tiradas. La clave son los números que salen y el contenido es el contador de veces que salió.
		Dictionary<int, int> contadorTiradas = new Dictionary<int, int>(); 


		#region Eventos para el checkbox "simular"
		private void cbx_ImagenAlea_Checked_1(object sender, RoutedEventArgs e)
		{
			Random rnd = new Random();
			BitmapImage imagenTmp = new BitmapImage(new Uri(string.Format("imagenes/{0}.png", rnd.Next(1, 7)), UriKind.Relative));
		
			img_Dado.Source = imagenTmp;
			img_Dado.Visibility = System.Windows.Visibility.Visible;
		}

		private void cbx_ImagenAlea_Unchecked_1(object sender, RoutedEventArgs e)
		{
			img_Dado.Visibility = System.Windows.Visibility.Hidden;
		}

		#endregion

		#region Eventos click para Tirar los dados (Tirar una vez y Automático)
		private void btn_TirarDado_Click(object sender, RoutedEventArgs e)
		{
			if (totalTiradas < 1000)
				TiradasDado();
			else
				MessageBox.Show("El número de tiradas debe ser entre 0 y 1000");
		}

		private void btn_Automatico_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				int nTiradas = int.Parse(tbx_NTiradas.Text);
				if (nTiradas < 0 || nTiradas > 1000 || totalTiradas > 1000)
					throw new Exception();

				// Si está en el rango, hace las tiradas:
				TiradasDado(nTiradas);
			}

			catch
			{
				MessageBox.Show("El número de tiradas debe estar entre 0 y 1000");
				tbx_NTiradas.Focus();
				tbx_NTiradas.SelectAll();
			}
		}
		#endregion 


		#region Método TiradasDado. Tira un dado, muestra los resultados y las estadísticas
		private void TiradasDado()
		{
			Random rnd = new Random();

			resultadoTirada = rnd.Next(1, 7);
			int contadorDado;

			// Lo añado el resultado salido al diccionario que cuenta el número de veces que sale cada dado
			try
			{
				contadorTiradas.Add(resultadoTirada, 1);
			}
			catch
			{
				contadorTiradas.TryGetValue(resultadoTirada, out contadorDado);
				contadorTiradas[resultadoTirada] = contadorDado + 1;
			}


			// Escribo los Resultados:
			tbl_Resultados.Text += string.Format("{0} -> {1} \n", ++totalTiradas, resultadoTirada);

			// A partir de 10 el scroll baja solo y aumenta por cada tirada. Ya que no cabría en el TextBlock si no:
			if (totalTiradas >= 10)
			{
				tbl_Resultados.Height += 16;
				scroll_Resultados.ScrollToVerticalOffset(tbl_Resultados.Height);
			}

			grb_TotalTiradas.Content = totalTiradas;

			// Muestro las estadísticas:
			Estadisticas();

		}
		#endregion 

		#region Sobrecarga del método TiradasDados para poder pasarle el número de tiradas a realizar
		private void TiradasDado(int nTiradas)
		{
			for (int i = 0; i < nTiradas; i++)
			{
				TiradasDado();
			}

		}
		#endregion 


		#region Método para mostrar las estadísticas
		private void Estadisticas()
		{
			tbl_Estadistica.Text = string.Empty;

			for (int i = 1; i <= 6; i++)
			{
				int contadorDados = 0;
				contadorTiradas.TryGetValue(i, out contadorDados); // Si estaba en el diccionario saca el número de dados. Si no estaba es porque es 0.

				tbl_Estadistica.Text += string.Format("{0} -> {1} -> {2}% \n", i, contadorDados, Math.Round((double)contadorDados / (double)totalTiradas * 100, 2));
			}

		}
		#endregion 

	}
}
