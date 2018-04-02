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

namespace WPF_Ej5_EncriptarCesar
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//Valor del desplazamiento. 
		//(Tal vez sería mejor quitar esta variable y solo usar el valor que hay en tbxNumeroDesplazamiento.Text)
		static public int nDesplazamiento = 9;

		public MainWindow()
		{
			InitializeComponent();
			tbxFrase.Focus();

			//Empieza en 9 el desplazamiento (por defecto):
			tbxNumeroDesplazamiento.Text = nDesplazamiento.ToString();
			scbDesplazar.Minimum = -1;
			scbDesplazar.Maximum = 11;

		}

		//Y para añadir la opción de encriptar/desencriptar en un fichero sería:
		private void ExaminarFichero()
		{
			
		}


		#region Evento Click del botón Encriptar
		private void btnEncriptar_Click(object sender, RoutedEventArgs e)
		{
			string frase = tbxFrase.Text;
			string fraseEncriptada = Encriptar(frase);
			string fraseDesencriptada = Desencriptar(fraseEncriptada);

			lblOriginal.Content = frase;
			lblEncriptada.Content = fraseEncriptada;
			lblDesencriptada.Content = fraseDesencriptada;
		}
		#endregion 

		#region Métodos Encriptar y Desencriptar
		private string Encriptar(string frase)
		{
			string fraseEncriptada = string.Empty;
			int rangoLetras = 'Z' - 'A' + 1;

			for (int i = 0; i < frase.Length; i++)
			{

				//Si es mayúscula:
				if (frase[i] >= 'A' && frase[i] <= 'Z')
				{
					fraseEncriptada += (char)((frase[i] + nDesplazamiento - 'A') % rangoLetras + 'A');
				}

				//Si es minúscula:
				else if (frase[i] >= 'a' && frase[i] <= 'z')
				{
					fraseEncriptada += (char)((frase[i] + nDesplazamiento - 'a') % rangoLetras + 'a');
				}
				
				//Si no es una letra, se quedará igual. Tiene que ser una letra entre A-Z o entre a-z para encriptar
				else
					fraseEncriptada += frase[i];

			}
			return fraseEncriptada;
		}

		private string Desencriptar(string frase)
		{
			string fraseDesencriptada = string.Empty;
			int rangoLetras = 'Z' - 'A' + 1;

			for (int i = 0; i < frase.Length; i++)
			{

				//Si es mayúscula:
				if (frase[i] >= 'A' && frase[i] <= 'Z')
				{
					fraseDesencriptada += (char)((frase[i] - 'A' - nDesplazamiento + rangoLetras) % rangoLetras + 'A');
				}

				//Si es minúscula:
				else if (frase[i] >= 'a' && frase[i] <= 'z')
				{
					fraseDesencriptada += (char)((frase[i] - 'a' - nDesplazamiento + rangoLetras) % rangoLetras + 'a');
				}

				//Si no es una letra entre a-z o A-Z se quedará igual
				else
					fraseDesencriptada += frase[i];

			}
			return fraseDesencriptada;

		}

		#endregion 
		

		#region Evento Scroll del ScrollBar (Para cambiar el desplazamiento con el Scroll)
		private void scbDesplazar_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
		{

			//Pongo un límite al desplazamiento, no será negativo 
			if (nDesplazamiento <= 0)
			{
				MessageBox.Show("El desplazamiento tiene que ser un valor entre 0 y 20");
				tbxNumeroDesplazamiento.Text = (++nDesplazamiento).ToString();
				scbDesplazar.Value++;
				return;
			}

			//Límite al desplazamiento, no será mayor que 10
			if (nDesplazamiento >= 20)
			{
				MessageBox.Show("El desplazamiento tiene que ser un valor entre 0 y 20");
				tbxNumeroDesplazamiento.Text = (--nDesplazamiento).ToString();
				scbDesplazar.Value--;
				return;
			}

			//Cuando se le da a la flechita para abajo (SmallInccrement), el valor del desplazamiento disminuye
			if (e.ScrollEventType == System.Windows.Controls.Primitives.ScrollEventType.SmallIncrement)
			{
				tbxNumeroDesplazamiento.Text = (--nDesplazamiento).ToString();
				scbDesplazar.Value--;
			}

			//Y cuando se le da a la flechita para arriba (SmallDecrement), el valor del desplazamiento aumenta
			if (e.ScrollEventType == System.Windows.Controls.Primitives.ScrollEventType.SmallDecrement)
			{
				tbxNumeroDesplazamiento.Text = (++nDesplazamiento).ToString();
				scbDesplazar.Value++;
			}
			


		}
		#endregion 

		#region Evento LostFocus de TextBox Desplazamiento (Para poder cambiar el desplazamiento a mano)
		//Dejo cambiar a mano el desplazamiento. 
		//Controlo que no se introduzca a mano en el TextBox un desplazamiento menor que 0 o mayor que 10
		private void tbxNumeroDesplazamiento_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{			
				//Límite al desplazamiento, no será menor que 0
				if (int.Parse(tbxNumeroDesplazamiento.Text) <= 0)
				{
					MessageBox.Show("El desplazamiento tiene que ser un valor entre 0 y 20");
					tbxNumeroDesplazamiento.Text = (nDesplazamiento).ToString();
					return;
				}

				//Límite al desplazamiento, no será mayor que 10
				if (int.Parse(tbxNumeroDesplazamiento.Text) >= 20)
				{
					MessageBox.Show("El desplazamiento tiene que ser un valor entre 0 y 20");
					tbxNumeroDesplazamiento.Text = (nDesplazamiento).ToString();
					return;
				}


				//Deja cambiarlo a mano si está entre los límites
				else
				{
					nDesplazamiento = int.Parse(tbxNumeroDesplazamiento.Text);
					
				}
			}

			catch
			{
				MessageBox.Show("Valor no válido para el desplazamiento");
				tbxNumeroDesplazamiento.Text = nDesplazamiento.ToString();
			}
		}
		#endregion 



	}
}
