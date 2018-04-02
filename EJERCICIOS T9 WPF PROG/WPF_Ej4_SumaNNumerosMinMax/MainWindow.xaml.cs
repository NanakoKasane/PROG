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

namespace WPF_Ej4_SumaNNumerosMinMax
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			tbxN1.Focus();
        }

		private void btnSumar_Click(object sender, RoutedEventArgs e)
		{
			int minimo = 0;
			int maximo = 0;

			try
			{
				minimo = int.Parse(tbxN1.Text);
				maximo = int.Parse(tbxN2.Text);

				if (maximo < minimo)
				{
					MessageBox.Show("El mínimo no puede ser mayor al máximo");
					tbxN1.Focus();
					tbxN1.Clear();
					tbxN2.Clear();
					return;
				}


				//Relleno el resultados
				int resultado = SumaN1aN2Iterativa(minimo, maximo);
				tblResultado.Text = resultado.ToString();
			}
			catch
			{
				MessageBox.Show("Los datos de entrada no son correctos");
			}

			tbxN1.Focus();
			tbxN1.Clear();
			tbxN2.Clear();

		}

		//También funciona el resultado al darle al enter
		private void btnSumar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
				btnSumar_Click(sender, e);
		}


		//Métodos para sumar
		private int SumaN1aN2Recursiva(int minimo, int maximo)
		{
			if (minimo == maximo)
				return minimo;
			else
				return maximo + SumaN1aN2Recursiva(minimo, maximo - 1);
		}

		private int SumaN1aN2Iterativa(int minimo, int maximo)
		{
			int resultado = 0;
			for (int i = minimo; i <= maximo; i++)
			{
				resultado += i;
			}
			return resultado;
		}


		//Métodos para escribir el mínimo y el máximo en el resultado
		private void tbxN1_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				int minimo = int.Parse(tbxN1.Text);
				tblNumero1.Text = minimo.ToString();
			}
			catch
			{
				//MessageBox.Show("Debe introducir un mínimo");
			}
		}

		private void tbxN2_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				int maximo = int.Parse(tbxN2.Text);
				tblNumero2.Text = maximo.ToString();
			}
			catch
			{
			}
		}



    }
}
