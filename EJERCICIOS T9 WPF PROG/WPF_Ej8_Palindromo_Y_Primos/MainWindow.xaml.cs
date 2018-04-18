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

namespace WPF_Ej8_Palindromo_Y_Primos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tbx_FraseIntroducir.Focus();
        }

		#region Métodos para comprobar las frases palíndromos
		/// <summary>
        /// Método que comprueba si una frase es palíndromo. Es decir, si se escribe igual al revés que al derecho. No discrimina las mayúsculas. No tiene en cuenta los espacios
        /// </summary>
        /// <param name="frase"></param>
        /// <returns>False si no es palíndromo. True si la frase es palíndromo.</returns>
        private bool Palindromo(string frase)
        {
            // Para que no tenga en cuenta los espacios, guardo el string de entrada sin espacios:
            string[] palabras = frase.Split(new char[] { ' ' });
            string fraseSinEspacios = string.Empty;

            for (int i = 0; i < palabras.Length; i++)
			{
                fraseSinEspacios += palabras[i];
			}

            // Relleno la frase al revés
            string fraseAlReves = string.Empty;

            for (int i = fraseSinEspacios.Length - 1; i >= 0; i--)
            {
                fraseAlReves += fraseSinEspacios[i];
            }   


            // Compruebo si la frase al derecho coincide con la frase al revés, sin discriminar mayus de minúscula ni tener en cuenta los espacios:
            for (int i = 0; i < fraseSinEspacios.Length; i++)
            {
                if (fraseSinEspacios[i].ToString().ToUpper() != fraseAlReves[i].ToString().ToUpper()) // Comparo las mayúsculas para que no distrimine mayus de minúscula y pueda empezar por mayus.
                    return false; // Si alguna no coincide, es que no es palíndromo
            }

            // Si ha llegado aquí es porque son iguales, es decir, la frase es palíndroma
            return true;

        }

        private void btnComprobarPalindromo_Click(object sender, RoutedEventArgs e)
        {
            if (Palindromo(tbx_FraseIntroducir.Text))
                MessageBox.Show("La frase es palíndroma");
            else
                MessageBox.Show("La frase no es palíndroma");

			tbx_FraseIntroducir.Focus();
			tbx_FraseIntroducir.SelectAll();
        }

        private void cbx_FrasesPalindromas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbxTmp = (ComboBox)sender;

            for (int i = 0; i < cbxTmp.Items.Count; i++)
			{
                ComboBoxItem itemTmp = (ComboBoxItem)cbxTmp.Items[i];

                if (cbxTmp.SelectedIndex == i)
                    tbx_FraseIntroducir.Text = itemTmp.Content.ToString();
			}

        }

		#endregion 


		#region Métodos para la Lista de Números Primos
		/// <summary>
        /// Método que comprueba si un número es o no primo
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>True si es primo. False si no lo es</returns>
        private bool EsPrimo(int numero)
        {
            // Casos especiales, el 0 y 1 no se consideran primos.
            if (numero == 0 || numero == 1)
                return false;

            for (int i = 2; i < numero; i++) // i -> es el divisor y empieza en 2
            {
                if (numero % i == 0)
                    return false;
            }
            return true;
        }

		private void btn_MostarListaPrimos_Click(object sender, RoutedEventArgs e)
		{
			Win_ListaPrimos ventana = new Win_ListaPrimos();

			try
			{
				int numeroMaximo = int.Parse(tbx_MaximoPrimo.Text);
				if (numeroMaximo < 0 || numeroMaximo > 100)
					throw new Exception("El número debe estar entre el rango de 0 y 100");

				MostrarListaPrimos();

			}

			catch
			{
				MessageBox.Show("Debe introducir un número válido, entre el 0 y el 100");
				tbx_MaximoPrimo.Focus();
				tbx_MaximoPrimo.SelectAll();
			}

		}

		private void MostrarListaPrimos()
		{

			List<int> listaPrimos = ListaPrimosHastaN();
			string primos = string.Empty;

			for (int i = 0; i < listaPrimos.Count; i++)
			{
				primos += listaPrimos[i].ToString() + "\n";
			}

			MessageBox.Show(primos, string.Format("Lista de primos menores que {0}", tbx_MaximoPrimo.Text), MessageBoxButton.OK);
		}

		private void tbx_MaximoPrimo_GotFocus(object sender, RoutedEventArgs e)
		{
			tbx_MaximoPrimo.SelectAll();
			btn_MostarListaPrimos.IsEnabled = true;
		}

		public List<int> ListaPrimosHastaN()
		{
			List<int> listaPrimos = new List<int>();
			int maximo = 0;

			try
			{
				maximo = int.Parse(tbx_MaximoPrimo.Text);
			}

			catch
			{
			}

			for (int i = 0; i < maximo; i++)
			{
				if (EsPrimo(i))
					listaPrimos.Add(i);
			}

			return listaPrimos;

		}

		#endregion 

	}
}
