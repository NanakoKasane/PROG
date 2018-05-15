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

namespace WPF_Ej18_ClaseJARRA
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{				
		// Creo las Jarras A y B:		
		Jarra JarraA = new Jarra(7, 0);
		Jarra JarraB = new Jarra(5, 0);

		public MainWindow()
		{
			InitializeComponent();

		}

		private void btn_LlenarA_Click(object sender, RoutedEventArgs e)
		{
			JarraA.LlenarJarraEntera();
			pgb_JarraA.Value = JarraA.Capacidad; // = CantidadAgua
			tbx_Estadisticas.Text += "Se ha llenado la Jarra A" + "\n";
		}

		private void btn_VaciarA_Click(object sender, RoutedEventArgs e)
		{
			JarraA.VaciarJarraEntera();
			pgb_JarraA.Value = JarraA.CantidadAgua;
			tbx_Estadisticas.Text += "Se ha vaciado la Jarra A" + "\n";
		}

		private void btn_LlenarB_Click(object sender, RoutedEventArgs e)
		{
			JarraB.LlenarJarraEntera();
			pgb_JarraB.Value = JarraB.Capacidad; // = CantidadAgua
			tbx_Estadisticas.Text += "Se ha llenado la Jarra B" + "\n";
		}

		private void btn_VaciarB_Click(object sender, RoutedEventArgs e)
		{
			JarraB.VaciarJarraEntera();
			pgb_JarraB.Value = JarraB.CantidadAgua;
			tbx_Estadisticas.Text += "Se ha vaciado la Jarra B" + "\n";
		}

		// Reseteo
		private void btnFinalizar_Click(object sender, RoutedEventArgs e)
		{
			JarraA.CantidadAgua = 0;
			JarraB.CantidadAgua = 0;
			pgb_JarraA.Value = 0;
			pgb_JarraB.Value = 0;
			tbx_Estadisticas.Text = string.Empty;
			tbx_Estadisticas.Text += "Se han vaciado las Jarras" + "\n";
		}


		// Llenar con la otra Jarra
		private void btn_LlenarBConA_Click(object sender, RoutedEventArgs e)
		{
			JarraB.LlenarJarraConOtra(JarraA);
			pgb_JarraA.Value = JarraA.CantidadAgua;
			pgb_JarraB.Value = JarraB.CantidadAgua;
			tbx_Estadisticas.Text += "Se vuelca la Jarra A sobre la B" + "\n";
		}

		private void btn_LlenarAConB_Click(object sender, RoutedEventArgs e)
		{
			JarraA.LlenarJarraConOtra(JarraB);
			pgb_JarraA.Value = JarraA.CantidadAgua;
			pgb_JarraB.Value = JarraB.CantidadAgua;
			tbx_Estadisticas.Text += "Se vuelca la Jarra B sobre la A" + "\n";
		}


		// Progreso
		private void pgb_JarraA_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			tbx_progresoA.Text = pgb_JarraA.Value.ToString();
		}

		private void pgb_JarraB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			tbx_progresoB.Text = pgb_JarraB.Value.ToString();
		}

		private void tbx_Estadisticas_TextChanged(object sender, TextChangedEventArgs e)
		{
			int cambio = 17;
			tbx_Estadisticas.Height += cambio;

			Scroll.ScrollToVerticalOffset(cambio);
		}

	}
}
