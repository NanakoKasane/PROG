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

namespace WPF_Ej8_Palindromo_Y_Primos
{
	/// <summary>
	/// Lógica de interacción para Win_ListaPrimos.xaml
	/// </summary>
	public partial class Win_ListaPrimos : Window
	{
		public Win_ListaPrimos()
		{
			InitializeComponent();

		}

		private void Grid_Loaded_1(object sender, RoutedEventArgs e)
		{
			MainWindow ventanaPrinci = new MainWindow();
			lblTitulo.Content += ventanaPrinci.tbx_MaximoPrimo.Text;

			List<int> listaPrimos = ventanaPrinci.ListaPrimosHastaN();

			for (int i = 0; i < listaPrimos.Count ; i++)
			{
				TextBlock tbxTmp = new TextBlock();
				tbxTmp.Text = listaPrimos[i].ToString();
				grd_Primos.Children.Add(tbxTmp);
			}
		}
	}
}
