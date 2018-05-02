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

namespace Aplicando_Estilos
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			lblFuentes.ItemsSource = Fonts.SystemFontFamilies;
		}

		private void cbx_negrita_Checked_1(object sender, RoutedEventArgs e)
		{
			if (cbx_cursiva.IsChecked == true)
				tbx_AplicarEstilos.Style = (Style)Resources["NegritaCursiva"];
			else
				tbx_AplicarEstilos.Style = (Style)Resources["Negrita"];
		}

		private void cbx_negrita_Unchecked_1(object sender, RoutedEventArgs e)
		{
			if (cbx_cursiva.IsChecked == false)
				tbx_AplicarEstilos.Style = null;
			else
				tbx_AplicarEstilos.Style = Resources["Cursiva"] as Style;
		}

		private void lblFuentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			tbx_AplicarEstilos.FontFamily = lblFuentes.SelectedItem as FontFamily;
		}

		private void cbx_cursiva_Checked_1(object sender, RoutedEventArgs e)
		{
			if (cbx_negrita.IsChecked == true)
				tbx_AplicarEstilos.Style = Resources["NegritaCursiva"] as Style;
			else
				tbx_AplicarEstilos.Style = Resources["Cursiva"] as Style;
		}

		private void cbx_cursiva_Unchecked_1(object sender, RoutedEventArgs e)
		{
			if (cbx_negrita.IsChecked == false)
				tbx_AplicarEstilos.Style = null;
			else
				tbx_AplicarEstilos.Style = Resources["Negrita"] as Style;
		}

		private void cbx_sobra_Checked_1(object sender, RoutedEventArgs e)
		{
			grd_textBlock.Style = (Style)Resources["Sombreado"];
		}

		private void cbx_sobra_Unchecked_1(object sender, RoutedEventArgs e)
		{
			grd_textBlock.Style = null;
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Propina ventanaPropina = new Propina();
			ventanaPropina.Show();
		}
	}
}
