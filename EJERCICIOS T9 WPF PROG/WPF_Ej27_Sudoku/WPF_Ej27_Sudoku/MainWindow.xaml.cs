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
//----------------------------
using System.IO;
using System.Text.RegularExpressions;


namespace WPF_Ej27_Sudoku
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		const int nFilas = 9;
		const int nColumnas = 9;

		List<int[,]> sudokusInicial = new List<int[,]>();
		List<int[,]> sudokusSolucion = new List<int[,]>();

		string rutaFicheroIni = @"../../../sudokus_Ini.txt";
		string rutaFicheroSoluciones = @"../../../sudokus_Sol.txt";		

		Random rnd = new Random();
		int numSudokuRandom = 0;


		public MainWindow()
		{
			InitializeComponent();

			CargarSudokusAlmacenados(rutaFicheroIni, sudokusInicial);
			CargarSudokusAlmacenados(rutaFicheroSoluciones, sudokusSolucion);

			numSudokuRandom = rnd.Next(sudokusInicial.Count); // Random para saber qué sudoku coger aleatorio

			RellenarRejillaJuego(sudokusInicial);
			
		}

		#region Cargar sudokus de los ficheros
		/// <summary>
		/// Método que carga un sudoku en un fichero a una lista
		/// </summary>
		/// <param name="rutaFichero">Fichero donde está el sudoku a cargar</param>
		/// <param name="listaSudokus">Lista donde se almacenará el sudoku</param>
		private void CargarSudokusAlmacenados(string rutaFichero, List<int[,]> listaSudokus)
		{
			listaSudokus.Clear();

			using (StreamReader lector = new StreamReader(rutaFichero))
			{
				while (!lector.EndOfStream)
				{
					string lineaSudoku = lector.ReadLine();
					int[,] numerosSudokuTmp = new int[nFilas, nColumnas];
					int contador = 0;

					for (int i = 0; i < nFilas; i++)
					{
						for (int j = 0; j < nColumnas; j++)
						{
							numerosSudokuTmp[i, j] = int.Parse(lineaSudoku[contador].ToString());
							contador++;
						}
					}
					listaSudokus.Add(numerosSudokuTmp);

				}
			}
		}
		#endregion 

		#region Rellenar la rejilla (Grid)
		private void RellenarRejillaJuego(List<int[,]> listaSudokus)
		{
			DefinirFilasColumnas();

			for (int i = 0; i < nFilas; i++)
			{
				for (int j = 0; j < nColumnas; j++)
				{
					TextBox tbxTmp = new TextBox();
					tbxTmp.Foreground = new SolidColorBrush(Colors.Red);

					#region Bordes de separación
					if (j == 2 || j == 5)
						tbxTmp.BorderThickness = new Thickness(1, 1, 5, 1);
					if (i == 2 || i == 5)
						tbxTmp.BorderThickness = new Thickness(1, 1, 1, 5);

					if ((i == 2 && j == 2) || (i == 5 && j == 5) || (i==2 && j == 5) || (i == 5 && j == 2))
						tbxTmp.BorderThickness = new Thickness(1, 1, 5, 5);

					tbxTmp.BorderBrush = new SolidColorBrush(Colors.Black);
					#endregion 

					// Añado los datos del sudoku inicial
					if (listaSudokus[numSudokuRandom][i, j] != 0) // Si es 0 es porque no hay dato en esa casilla
					{
						tbxTmp.Text = listaSudokus[numSudokuRandom][i, j].ToString();
						tbxTmp.IsReadOnly = true;
						tbxTmp.Foreground = new SolidColorBrush(Colors.Black);
					}

					tbxTmp.PreviewTextInput += tbxTmp_PreviewTextInput;

					Grid.SetRow(tbxTmp, i);
					Grid.SetColumn(tbxTmp, j);					
					grd_RejillaPrinciJuego.Children.Add(tbxTmp);

				}
			}
		}
		#endregion 

		#region Evento para controlar el texto que entra en el TextBox y si es correcto o no
		// Controlar que se introduzca solo una cifra del 1 al 9
		void tbxTmp_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			TextBox tbxTmp = sender as TextBox;
			Regex regla = new Regex("[1-9]");

			if (!regla.IsMatch(e.Text) || tbxTmp.Text.Length >= 1)
				e.Handled = true;


			// Compruebo si el resultado introducido es correcto
			int filaActual = Grid.GetRow(tbxTmp);
			int columnaActual = Grid.GetColumn(tbxTmp);
			if (sudokusSolucion[numSudokuRandom][filaActual, columnaActual].ToString() != e.Text)
			{
				MessageBox.Show("El número no es correcto");
				e.Handled = true;
			}
		}
		#endregion 

		#region Definir columnas y filas del Grid
		private void DefinirFilasColumnas()
		{
			grd_RejillaPrinciJuego.RowDefinitions.Clear();
			grd_RejillaPrinciJuego.ColumnDefinitions.Clear();

			for (int i = 0; i < nFilas; i++)
			{
				grd_RejillaPrinciJuego.RowDefinitions.Add(new RowDefinition());
			}

			for (int i = 0; i < nColumnas; i++)
			{
				grd_RejillaPrinciJuego.ColumnDefinitions.Add(new ColumnDefinition());
			}
		}
		#endregion 

		#region Eventos de click en los botones "Nuevo" y "Solucion"
		private void btn_Nuevo_Click(object sender, RoutedEventArgs e)
		{
			grd_RejillaPrinciJuego.Children.Clear();

			// Cambio el random porque será un nuevo sudoku:
			numSudokuRandom = rnd.Next(sudokusInicial.Count);

			RellenarRejillaJuego(sudokusInicial);

		}

		private void btn_Solucion_Click(object sender, RoutedEventArgs e)
		{
			grd_RejillaPrinciJuego.Children.Clear();
			RellenarRejillaJuego(sudokusSolucion);
		}
		#endregion 


	}
}
