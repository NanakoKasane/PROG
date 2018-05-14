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

namespace WPF_Ej19_Matriz2DBotones
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			RellenarComboBox(cbx_nFilas);
			RellenarComboBox(cbx_nColumnas);
		}

		private void RellenarComboBox(ComboBox cbx)
		{
			for (int i = 1; i <= 20; i++)
			{
				cbx.Items.Add(i);
			}
		}

		private void btnCrearMatriz_Click(object sender, RoutedEventArgs e)
		{
			grd_botones.Children.Clear(); // Si hubiera alguna matriz, la limpio, para poder crear otra nueva
			this.Height = 120; // Alto inicial
			this.Width = 525; // Ancho inicial
			CBotones matrizBotones = null;

			try
			{
				matrizBotones = new CBotones(int.Parse(cbx_nFilas.Text), int.Parse(cbx_nColumnas.Text));			
			}
			catch { }

			// Relleno la rejilla y expando la ventana según las filas y columnas que haya
			if (matrizBotones != null)
			{
				matrizBotones.RellenarRejilla();

				grd_botones.Children.Add(matrizBotones.Rejilla);
				this.Height += matrizBotones.NFilas * (matrizBotones.HEIGHTBOTON + matrizBotones.MARGINBOTON);
				this.Width += matrizBotones.NColumnas * (matrizBotones.WIDTHBOTON + matrizBotones.MARGINBOTON);

			}


		}

	}
}
