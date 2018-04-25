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

namespace WPF_Ej12_RGB_ConScrolls
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

		/// <summary>
		/// Evento que comparten los 3 ScrollBars y se sincroniza con el valor por el que vaya cada scrollBar
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void scb_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			Color color = Color.FromArgb(255, (byte)scb_Rojo.Value, (byte)scb_Verde.Value, (byte)scb_Azul.Value);

			pnl_Color.Background = new SolidColorBrush(color);

		}
	}
}
