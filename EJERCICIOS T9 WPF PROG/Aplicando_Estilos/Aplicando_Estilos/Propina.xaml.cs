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
using System.Windows.Shapes;
//----------------------------
using System.Text.RegularExpressions;

namespace Aplicando_Estilos
{
	/// <summary>
	/// Lógica de interacción para Propina.xaml
	/// </summary>
	public partial class Propina : Window
	{
		public Propina()
		{
			InitializeComponent();
			tbx_importeFactura.Focus();
		}

		private void rbn_bueno_Checked_1(object sender, RoutedEventArgs e)
		{
			CalcularImportes(10);
		}

		private void rbn_muyBueno_Checked_1(object sender, RoutedEventArgs e)
		{
			CalcularImportes(15);
		}

		private void rbn_excelente_Checked_1(object sender, RoutedEventArgs e)
		{
			CalcularImportes(20);
		}

		private void CalcularImportes(double porcentaje)
		{
			double propina = 0;
			double totalPagar = 0;

			try
			{
				propina = Math.Round(double.Parse(tbx_importeFactura.Text) * (porcentaje/100), 2);
				totalPagar = propina + double.Parse(tbx_importeFactura.Text);
			}
			catch
			{
				MessageBox.Show("Importe de la factura inválido");
				tbx_importeFactura.Focus();
				tbx_importeFactura.SelectAll();
			}

			EstablecerImportes(propina, totalPagar);
		}

		private void EstablecerImportes(double propina, double totalPagar)
		{

			tbl_propina.Text = propina.ToString();
			tbl_totalPagar.Text = totalPagar.ToString();
		}

		private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
		{
			MessageBoxResult resultado = MessageBox.Show("¿Seguro que quiere salir?", "SALIR", MessageBoxButton.YesNo, MessageBoxImage.Question);

			if (resultado == MessageBoxResult.No) // Si no quiere salir, cancelas la salida
			{
				e.Cancel = true;
			}
		}

		private void tbx_importeFactura_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			Regex regla = new Regex("[0-9,]");

			if (!regla.IsMatch(e.Text))
				e.Handled = true;
		}

	}
}
