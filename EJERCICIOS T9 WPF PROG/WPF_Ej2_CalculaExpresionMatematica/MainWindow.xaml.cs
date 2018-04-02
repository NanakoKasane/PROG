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

namespace WPF_Ej2_CalculaExpresionMatematica
{
	public class ExpresionMalFormadaException : Exception { };

    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtExpresion.Focus();
			
        }

		private void btnCalcular_Click(object sender, RoutedEventArgs e)
		{
			string expresion = txtExpresion.Text;
			Calcular calculo = new Calcular();
			string[] numeros = expresion.Split(calculo.operadores, StringSplitOptions.RemoveEmptyEntries);


			//Calcular la expresión
			double resultado = calculo.Calcula(expresion);

			//Mostrar el resultado SOLO si la expresión es válida
			if (calculo.Comprobar(numeros, expresion))
				lblResultado.Content = resultado;
			else
			{
				MessageBox.Show("La expresión no es correcta");
				txtExpresion.Focus();
				txtExpresion.SelectAll();
				txtExpresion.Clear();
			}

		}
		
    }

    public class Calcular 
    {	
		public char[] operadores = { '+', '-', '*', '/' };
		char[] numerosPosibles = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


		public double Calcula(string expresion)
		{
			double resultado = 0;

			string[] numeros = expresion.Split(operadores, StringSplitOptions.RemoveEmptyEntries);
			string[] simbolos = expresion.Split(numerosPosibles, StringSplitOptions.RemoveEmptyEntries); // new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' } 

			try // Realmente no es necesario el try catch si el método Comprobar() controla todas las posibilidades
			{
				Comprobar(numeros, expresion);

				// El primer valor se introduce tal cual y a partir de ahí se le suma/resta/multiplica/divide
				resultado = double.Parse(numeros[0]);

				for (int i = 1; i < numeros.Length; i++)
				{
					switch (simbolos[i - 1])
					{
						case "+":
							resultado += int.Parse(numeros[i].ToString());
							break;

						case "-":
							resultado -= int.Parse(numeros[i].ToString());
							break;

						case "*":
							resultado *= int.Parse(numeros[i].ToString());
							break;

						case "/":
							resultado /= int.Parse(numeros[i].ToString());
							break;

						default:
							throw new ExpresionMalFormadaException();
					}
				}
			}
			catch
			{
			}

			return resultado;
		}


		#region Métodos para comprobar la expresión
		public void ComprobarNumeros(string[] numeros)
		{
			//Compruebo que sean números			
			int tmp = 0;

			for (int i = 0; i < numeros.Length; i++)
			{
				if (!int.TryParse(numeros[i], out tmp))
					throw new ExpresionMalFormadaException();
			}
		}

		public void ComprobarDecimales(string expresion)
		{
			//Compruebo los decimales (separados por ',' en vez de por '.')
			for (int i = 0; i < expresion.Length; i++)
			{
				if (expresion[i] == '.')
					throw new ExpresionMalFormadaException();
			}
		}

		public void ComprobarOperadores(string expresion)
		{
			//Compruebo que no empiece por un operador. Tiene que empezar por un número
			for (int i = 0; i < operadores.Length; i++)
			{
				if (expresion[0] == operadores[i])
					throw new ExpresionMalFormadaException();
			}
		}
		#endregion 

		//Devuelve true si es correcta la expresión 
		public bool Comprobar(string[] numeros, string expresion)
		{
			try
			{
				//Compruebo que sean números
				ComprobarNumeros(numeros);

				//Compruebo los decimales (separados por ',' en vez de por '.')
				ComprobarDecimales(expresion);

				//Compruebo que no empiece por un operador. Tiene que empezar por un número
				ComprobarOperadores(expresion);
			}
			catch
			{
				return false;
			}

			return true;
		}


    }


}
