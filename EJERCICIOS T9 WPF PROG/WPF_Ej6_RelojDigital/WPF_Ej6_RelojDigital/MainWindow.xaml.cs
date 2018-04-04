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
        TimeSpan horaActual;

		Dictionary<TimeSpan, DateTime> Alarmas = new Dictionary<TimeSpan, DateTime>();  // Diccionario de alarmas
		// Sería mejor una lista con la hora y justo a continuación su fecha y recorrerla para comprobar si el TICK actual es ese, si lo es, suena.


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

		// Inicio el reloj con la hora actual. EVENTO QUE CAMBIA CADA SEGUNDO QUE PASA aumentando un segundo.
		void hora_Tick(object sender, EventArgs e)
		{
			// MOSTRAR RELOJ:
			DateTime horaNow = DateTime.Now;
			lblHora.Content = string.Format("{0:D2}:{1:D2}:{2:D2}", horaNow.Hour, horaNow.Minute, horaNow.Second);

			// Guardo la hora actual (tick actual) y la fecha actual
            horaActual = TimeSpan.Parse(lblHora.Content.ToString());
			DateTime fechaAlarma = DateTime.Parse(tblFechaAhora.Text);
			
			// Comprueba si en el diccionario de alarmas está la hora y fecha actual juntas como alarma:
			if (Alarmas.TryGetValue(horaActual, out fechaAlarma)) 
			{
				Console.Beep();
				MessageBox.Show("¡¡¡ALARMA!!!");
			}
							

			// Sin diccionario comprobando una habría sido:
			// if (horaActual == horaAlarma && fechaAlarma.Date == DateTime.Parse(tblFechaAhora.Text)) { Console.Beep(); }
            // (Compruebo si el Tick actual coincide con el de la alarma, y si coincide, suena el Beep)

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

				// Añado la alarma a un diccionario para poder establecer varias alarmas
				try
				{
					Alarmas.Add(horaAlarma, fechaAlarma);
				}
				catch
				{
					// Si se repite la hora, la primera alarma es la que vale y dirá que la nueva no es válida
					throw new Exception(); // Propago la excepción
				}

				// Confirmación de que se ha establecido la alarma (Si ha habido éxito):
				string mensaje = string.Format("Ha establecido una alarma el día {0} a las {1}",
					fechaAlarma.ToShortDateString(), horaAlarma.ToString());
				MessageBox.Show(mensaje);
			}

			catch
			{
				MessageBox.Show("La fecha/hora introducida no es válida");
				tbx_HoraAlarma.Focus();
				tbx_HoraAlarma.SelectAll();
			}

		}

	}
}
