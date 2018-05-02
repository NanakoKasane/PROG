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
//-------------------------
using Microsoft.Win32;
using System.IO;

namespace WPF_Ej14_Fichero
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public string _rutaFichero;

		public MainWindow()
		{
			InitializeComponent();
			tbx_Ruta.Focus();
		}

		private void btn_SelectFichero_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog abrirFichero = new OpenFileDialog();
			abrirFichero.Filter = "Ficheros de Texto|*.txt";

			bool? seAbrio = abrirFichero.ShowDialog();

			if (seAbrio == true)
			{
				
				_rutaFichero = abrirFichero.FileName;
				tbx_Ruta.Text = _rutaFichero;
			}

		}

		

		private void btn_VerResult_Click(object sender, RoutedEventArgs e)
		{
			Win_Resultados ventana2 = new Win_Resultados();

			// Número de líneas:
			ventana2.lbl_nLineas.Content = "Número de líneas: " + ContarLineas();

			// Número de palabras:
			TextBlock tbx_nPalabras = new TextBlock();
			tbx_nPalabras.Text = "Número de palabras: " + ContarNPalabras().ToString();
			ventana2.grd_Rejilla.Children.Add(tbx_nPalabras);
			Thickness t = new Thickness(50, 20, 10, 10);
			tbx_nPalabras.Margin = t;

			// Tamaño:
			if (File.Exists(_rutaFichero))
			{
				TextBlock tbx_tamano = new TextBlock();
				tbx_tamano.Text = "Tamaño del fichero: " + File.ReadAllBytes(_rutaFichero).Length;
				ventana2.grd_Rejilla.Children.Add(tbx_tamano);
				t = new Thickness(50, 100, 10, 10);
				tbx_tamano.Margin = t;
			}

			// Atributos:
			if (File.Exists(_rutaFichero))
			{
				TextBlock tbx_atributos = new TextBlock();
				tbx_atributos.Text = "Atributos del fichero: " + File.GetAttributes(_rutaFichero);
				ventana2.grd_Rejilla.Children.Add(tbx_atributos);
				t = new Thickness(50, 140, 10, 10);
				tbx_atributos.Margin = t;

			}

			// Mostrar la nueva ventana 
			if (File.Exists(_rutaFichero))
			ventana2.Show();
		}


		public int ContarLineas()
		{
			int nLineas = 0;

			if (!File.Exists(_rutaFichero))
				MessageBox.Show("La ruta no es válida");

			else
				using (FileStream flujo = new FileStream(_rutaFichero, FileMode.Open))
				{
					using (StreamReader lector = new StreamReader(flujo))
					{
						try
						{
							do
							{
								lector.ReadLine();
								++nLineas;
							} while (!lector.EndOfStream);
						}
						catch
						{
						}
					}
				}

			return nLineas;

		}

		private int ContarNPalabras()
		{
			int nPalabras = 0;
			char[] separadores = { '\r', '\n', ' ' };
			string contenidoFichero;

			if (File.Exists(_rutaFichero))
			{

				using (FileStream flujo = new FileStream(_rutaFichero, FileMode.Open))
				{
					using (StreamReader lector = new StreamReader(flujo))
					{
						contenidoFichero = lector.ReadToEnd();
						string[] palabras = contenidoFichero.Split(separadores, StringSplitOptions.RemoveEmptyEntries);

						nPalabras = palabras.Length;
					}
				}
			}

			return nPalabras;
		}

	}
}
