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
using System.Text.RegularExpressions;

namespace WPF_Ej16_Fichero_Clientes
{
	/// <summary>
	/// Lógica de interacción para Win_EditarFicha.xaml
	/// </summary>
	public partial class Win_EditarFicha : Window
	{
		public Win_EditarFicha()
		{
			InitializeComponent();
			tbx_DniEditar.Focus();
		}
		int nCliente;

		private void btn_Editar_Click(object sender, RoutedEventArgs e)
		{
			MainWindow ventanaPrinci = new MainWindow(); // Para acceder a su método de cargar el contenido del fichero en una Lista de Clientes
			ListaClientes listaClientes = ventanaPrinci.CargarContenidoDelFichero();

			for (int i = 0; i < listaClientes.ListaDeClientes.Count; i++)
			{
				if (listaClientes.ListaDeClientes[i].Dni == tbx_DniEditar.Text) // Si el DNI es válido y está en el fichero
				{
					// Habilito poder editar
					tbxDni.IsEnabled = true;
					tbxEdad.IsEnabled = true;
					tbxSueldo.IsEnabled = true;
					tbxNombre.IsEnabled = true;
					tbxApellidos.IsEnabled = true;

					// Cargo el cliente en el entorno:
					stp_datosEditar.DataContext = listaClientes.ListaDeClientes[i];
					nCliente = i;
				}

				else if (i == listaClientes.ListaDeClientes.Count - 1 && stp_datosEditar.DataContext == null) // Si llega al final sin encontrar el dni
					MessageBox.Show("No hay un cliente con este DNI en el fichero");
			}


		}

		private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
		{
			MainWindow ventanaPrinci = new MainWindow();
			ListaClientes listaClientes = ventanaPrinci.CargarContenidoDelFichero();

			try
			{
				Cliente cliente = new Cliente(tbxDni.Text, int.Parse(tbxEdad.Text), double.Parse(tbxSueldo.Text), tbxApellidos.Text, tbxNombre.Text);

				if (ventanaPrinci.AnadirClienteAFichero(cliente)) // Si se añade con éxito el cliente
				{
					ventanaPrinci.BorrarClienteDeFichero(listaClientes.ListaDeClientes[nCliente], nCliente);
					MessageBox.Show("Se han aplicado los cambios");
				}

				else
					MessageBox.Show("No se han podido aplicar los cambios");
			}
			catch
			{
				MessageBox.Show("Datos no válidos para introducir");
			}
			
			this.Close();
		}
			
		
		// Solo admitir números
		private void tbxEdad_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			Regex regla = new Regex("[0-9]");

			if (!regla.IsMatch(e.Text))
			{
				e.Handled = true;
			}
		}
	}
}
