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

namespace WPF_Ej11_CambiarAspectoColor_Label
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

		List<Brush> colores = new List<Brush>(new Brush[] { Brushes.Yellow, Brushes.Red, Brushes.Purple, Brushes.Orange });

		public int tamanioAntes = 0;
		public int tamanioDespues = 0;

		public Brush colorAntes = Brushes.White;
		public Brush colorDespues = Brushes.White;


		// Cambios de los label cuando el ratón pase por encima
		private void lbl1_MouseEnter(object sender, MouseEventArgs e)
		{
			Random rnd = new Random();
			Label label = (Label)sender;
			int numRandom;

			if (tamanioDespues == 0) // Si no se le ha configurado tamaño, se pondrá uno random
				label.FontSize = rnd.Next(10, 50);

			else
				label.FontSize = tamanioDespues;

			// Color random si no se ha configurado uno (no se ha configurado uno si está a blanco):
			if (colorDespues == Brushes.White)
			{
				numRandom = rnd.Next(0, 4);
				label.Foreground = colores[numRandom];

				//if (numRandom == 1)
				//	label.Foreground = Brushes.Red;
				//if (numRandom == 2)
				//	label.Foreground = Brushes.Purple;
				//if (numRandom == 3)
				//	label.Foreground = Brushes.Yellow;
				//if (numRandom == 4)
				//	label.Foreground = Brushes.Orange;				
			}

			// Color configurado si no:
			else
			{
				label.Foreground = colorDespues;
			}

		}

		// Vuelve a los valores que tenía del principio o los elegidos en la configuración
		private void lbl1_MouseLeave(object sender, MouseEventArgs e)
		{
			Label label = (Label)sender;

			if (tamanioAntes == 0) // Solo puede ser 0 si no se le ha dado valor aún
				label.FontSize = 20;
			else
				label.FontSize = tamanioAntes;

			if (colorAntes == Brushes.White) // Si aún no se ha configurado otro valor (por defecto está a blanco)
				label.Foreground = Brushes.Black;
			else
			{
				label.Foreground = colorAntes;
			}
		}


		#region Eventos para configurar los cambios de los label
		private void Mit_confRaton_Click(object sender, RoutedEventArgs e)
		{
			Ventana2 v2 = new Ventana2();
			v2.onEnviar += v2_onEnviarRaton;
			v2.ShowDialog();
		}

		private void v2_onEnviarRaton(int tamanio, Brush color)
		{
			tamanioDespues = tamanio;
			colorDespues = color;
		}


		private void Mit_confAntes_Click(object sender, RoutedEventArgs e)
		{
			Ventana2 v2 = new Ventana2();
			v2.onEnviar += v2_onEnviarAntes;
			v2.ShowDialog();
		}
		void v2_onEnviarAntes(int tamanio, Brush color)
		{
			colorAntes = color;
			tamanioAntes = tamanio;

			// Y los pongo a mano de ese color porque si solo están en MouseLeave tiene que pasar antes el ratón por encima para aplicarse y no vale
			RellenarLabels(lbl1);
			RellenarLabels(lbl2);
			RellenarLabels(lbl3);
		}

		private void RellenarLabels(Label label)
		{
			label.FontSize = tamanioAntes;
			label.Foreground = colorAntes;
		}

		#endregion

	}
}
