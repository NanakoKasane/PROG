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

namespace WPF_Ej7_Multiplicar_2ArraysDentados
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//Matriz 01:
		int[][] Matriz01 = new int[3][] { new int[1], new int[1], new int[1] };

		//Matriz 02:
		int[][] Matriz02 = new int[1][] { new int[3] };

		//Matriz 03 (Producto):
		int[][] Matriz03 = new int[3][] { new int[3], new int[3], new int[3] };


		public MainWindow()
		{
			InitializeComponent();
			tbx_M1_00.Focus();

			#region Otra forma de declarar Matrices dentadas
			////Matriz 01:
			//int[][] Matriz02 = new int[3][];
			//Matriz02[0] = new int[1];
			//Matriz02[1] = new int[1];
			//Matriz02[2] = new int[1];

			////Matriz 02:
			//int[][] Matriz01 = new int[1][];
			//Matriz01[0] = new int[3];

			////Matriz 03 (Producto):
			//int[][] Matriz03 = new int[3][];
			//Matriz03[0] = new int[3];
			//Matriz03[1] = new int[3];
			//Matriz03[2] = new int[3];
			#endregion 

		}

		private void btn_Calcular_Click(object sender, RoutedEventArgs e)
		{
			if (RellenarMatrices01_02()) //Solo si no hay fallo muestra el resultado y demás
			{
				CalcularProductoMatrices();
				MostrarMatrizProducto();
			}
		}

		bool RellenarMatrices01_02()
		{
			try
			{
				// Matriz 01:
				Matriz01[0][0] = int.Parse(tbx_M1_00.Text);
				Matriz01[1][0] = int.Parse(tbx_M1_10.Text);
				Matriz01[2][0] = int.Parse(tbx_M1_20.Text);


				// Matriz 02:
				Matriz02[0][0] = int.Parse(tbx_M2_00.Text);
				Matriz02[0][1] = int.Parse(tbx_M2_01.Text);
				Matriz02[0][2] = int.Parse(tbx_M2_02.Text);

				return true;
			}

			catch
			{
				MessageBox.Show("Las matrices tienen que ser de enteros");
				tbx_M1_00.Focus();
				tbx_M1_00.SelectAll();
				return false;
			}


			#region Intento de rellenarlas directamente con bucles
			//for (int i = 0; i < Matriz01.Length; i++) //Filas
			//{
			//	for (int j = 0; j < Matriz01[i].Length; j++) //Columnas 
			//	{
			//		//Matriz01[i][j] = int.Parse(tbx_M1_00.Text);


			//		TextBox tbx = new TextBox(); // No puede ser uno nuevo, tendría que acceder al que existe con ese nombre
			//		tbx.Name = string.Format("tbx_M1_{0}{1}", i, j);
			//		Matriz01[i][j] = int.Parse(tbx.Text);

			//	}
			//}
			#endregion 

		}

		void CalcularProductoMatrices()
		{
			for (int i = 0; i < Matriz03.Length; i++) // Filas de la Matriz producto
			{
				for (int j = 0; j < Matriz03[i].Length; j++) // Columnas de la Matriz producto
				{
					Matriz03[i][j] = Matriz01[i][0] * Matriz02[0][j];

				}
			}
		}

		void MostrarMatrizProducto()
		{
			//Primera fila (0)
			tbx_M3_00.Text = Matriz03[0][0].ToString(); //Columna 0
			tbx_M3_01.Text = Matriz03[0][1].ToString(); //Columna 1
			tbx_M3_02.Text = Matriz03[0][2].ToString(); //Columna 2

			//Segunda fila (1)
			tbx_M3_10.Text = Matriz03[1][0].ToString(); //Columna 0
			tbx_M3_11.Text = Matriz03[1][1].ToString(); //Columna 1
			tbx_M3_12.Text = Matriz03[1][2].ToString(); //Columna 2

			//Tercera fila (2)
			tbx_M3_20.Text = Matriz03[2][0].ToString(); //Columna 0
			tbx_M3_21.Text = Matriz03[2][1].ToString(); //Columna 1
			tbx_M3_22.Text = Matriz03[2][2].ToString(); //Columna 2


		}


	}

	
}
