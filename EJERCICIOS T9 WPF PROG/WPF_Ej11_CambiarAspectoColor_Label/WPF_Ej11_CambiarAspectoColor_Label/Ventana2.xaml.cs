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
using System.Windows.Shapes;

namespace WPF_Ej11_CambiarAspectoColor_Label
{
	/// <summary>
	/// Lógica de interacción para Ventana2.xaml
	/// </summary>
	public partial class Ventana2 : Window
	{
		public delegate void MiDelegado(int tamanio, Brush color);
		public event MiDelegado onEnviar;

		public Ventana2()
		{
			InitializeComponent();
			tbxTamanoLetra.Focus();
		}

		private void btnAceptar_Click(object sender, RoutedEventArgs e)
		{
			int tamanio = 20;
			Brush color = Brushes.Black;

			// Guardo el tamaño del textBox:
			try
			{
				tamanio = int.Parse(tbxTamanoLetra.Text);
				if (tamanio < 10 || tamanio > 50)
					throw new Exception();
			}
			catch
			{
				MessageBox.Show("Debe introducir un tamaño de letra entre 10 y 50");
				tbxTamanoLetra.Focus();
				tbxTamanoLetra.SelectAll();
			}

			// Guardo el color del checkbox:
			if (cbxColores.SelectedIndex == -1) // Es negativo si no hay ninguno elegido
			{
				MessageBox.Show("Debe introducir un color");
				cbxColores.Focus();
			}

			else
			{
				if (cbxColores.Text == "Rojo")
					color = Brushes.Red;
				if (cbxColores.Text == "Amarillo")
					color = Brushes.Yellow;
				if (cbxColores.Text == "Violeta")
					color = Brushes.Purple;
				if (cbxColores.Text == "Naranja")
					color = Brushes.Orange;
			}
			

			// Lanzar el evento para pasarle a MainWindow los datos del tamaño y del color
			if (onEnviar != null)
				onEnviar(tamanio, color);

			// Y finalmente se cierra para aplicar los cambios a la ventana principal si está todo correcto
			if (tamanio >= 10 && tamanio <= 50 && cbxColores.SelectedIndex != -1)
				this.Close();

		}

		private void btnCancelar_Click(object sender, RoutedEventArgs e)
		{
			this.Close(); // Se cierra, cancelando sin aplicar ningún cambio a la configuración
		}
	}
}
