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

namespace WPF_Ej6_RelojDigital
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		System.Windows.Threading.DispatcherTimer reloj = new System.Windows.Threading.DispatcherTimer();
		TimeSpan horaAlarma;
		DateTime fechaAlarma;
		TimeSpan horaActual = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);


		public MainWindow()
		{
			InitializeComponent();

			//Se inicia el reloj con la hora actual
			reloj.Tick += hora_Tick; 
			reloj.Start();
			btnMarcha.IsEnabled = false;

			//El foco en la alarma
			tbx_HoraAlarma.Focus();
			tbx_HoraAlarma.SelectAll();

		}

		//Inicio el reloj con la hora actual:
		void hora_Tick(object sender, EventArgs e)
		{
			DateTime horaActual = DateTime.Now;
			lblHora.Content = string.Format("{0:D2}:{1:D2}:{2:D2}", horaActual.Hour, horaActual.Minute, horaActual.Second);
		}

		/// <summary>
		/// Evento Click del botón "Paro"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnParo_Click(object sender, RoutedEventArgs e)
		{
			reloj.Stop();
			btnMarcha.IsEnabled = true;
			btnParo.IsEnabled = false;
		}

		/// <summary>
		/// Evento Click del botón "Marcha"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMarcha_Click(object sender, RoutedEventArgs e)
		{
			reloj.Start();
			btnParo.IsEnabled = true;
			btnMarcha.IsEnabled = false;

			//Tiempo parado:
			//MessageBox.Show(reloj.Interval.TotalSeconds.ToString());
			
		
		}

		private void btnSalir_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void stbFechaAhora_Initialized(object sender, EventArgs e)
		{
			tblFechaAhora.Text = DateTime.Now.ToLongDateString();
		}


		/// <summary>
		/// Evento para establecer la alarma
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAlarma_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				horaAlarma = TimeSpan.Parse(tbx_HoraAlarma.Text);
				fechaAlarma = DateTime.Parse(dpk_FechaAlarma.Text);
			}

			catch
			{
				MessageBox.Show("La fecha/hora introducida no es válida");
				tbx_HoraAlarma.Focus();
				tbx_HoraAlarma.SelectAll();
			}

		}


		//Evento que se inicie siempre y compruebe si la hora actual es la de la alarma, y si lo es, suena la alarma
		private void lblHora_Siempre()
		{
			if (horaActual == horaAlarma && fechaAlarma == DateTime.Parse(tblFechaAhora.Text))
			{
				Console.Beep(33, 1000);
			}

		}

	}
}
