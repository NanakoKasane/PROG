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

namespace WPF_Ej13_EditorTexto
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			rtb_editor.Focus();
		}

		private void mit_cambiarColor_Click(object sender, RoutedEventArgs e)
		{

		}

		private void mit_cambiarTamanio_Click(object sender, RoutedEventArgs e)
		{
			// Accedo al texto seleccionado
			string TextoSeleccionado = rtb_editor.Selection.Text;

			rtb_editor.AppendText(TextoSeleccionado);
			// rtb_editor.ClearValue(parrafo.ContentStart);
			rtb_editor.FontSize = 50;

		}

		private void rtb_editor_SelectionChanged(object sender, RoutedEventArgs e)
		{

		}

		private void rtb_editor_TextChanged(object sender, TextChangedEventArgs e)
		{
			
		}
	}
}
