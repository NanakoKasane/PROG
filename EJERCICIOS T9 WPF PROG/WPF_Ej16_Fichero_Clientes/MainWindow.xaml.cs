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
//---------------------------
using System.IO;
using Microsoft.Win32;

namespace WPF_Ej16_Fichero_Clientes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Ruta donde se creará por defecto:
        string rutaFichero = @"C:\basura\clientes.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_CrearFichero_Click(object sender, RoutedEventArgs e)
        {
            // Si no existe el fichero lo crea
			if (!File.Exists(rutaFichero))
			{
				File.Create(rutaFichero);
				MessageBox.Show(string.Format("Se ha creado el fichero en {0}", rutaFichero));
			}
			else
				MessageBox.Show("El fichero ya está creado");
        }

        private void btn_AbrirFichero_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Ficheros de texto|*.txt";

            bool? seAbrio = abrir.ShowDialog();
            if (seAbrio == true)
                rutaFichero = abrir.FileName;

        }

        private void btn_VerListado_Click(object sender, RoutedEventArgs e)
        {
            Win_ListadoClientes win_listadoClientes = new Win_ListadoClientes();
			ListaClientes listaCli = CargarContenidoDelFichero();

			win_listadoClientes.stp_ListadoClientes.DataContext = listaCli; // Contexto de datos será la lista de Clientes sacada del fichero
			win_listadoClientes.ShowDialog();
		}

		#region Métodos para interactuar con el Fichero (Añadir cliente al fichero, cargar contenido en la Lista del fichero...)
		private bool AnadirListaAFichero(ListaClientes lista)
		{
			if (!File.Exists(rutaFichero))
				return false;

			else
			{
				using (FileStream flujo = new FileStream(rutaFichero, FileMode.Append))
				{
					using (StreamWriter escritor = new StreamWriter(flujo))
					{
						for (int i = 0; i < lista.ListaDeClientes.Count; i++)
						{
							escritor.Write(lista.ListaDeClientes[i].Dni + ";"); // Dni
							escritor.Write(lista.ListaDeClientes[i].Edad + ";"); // Edad
							escritor.Write(lista.ListaDeClientes[i].Sueldo + ";"); // Sueldo
							escritor.Write(lista.ListaDeClientes[i].Apellidos + ";"); // Apellidos
							escritor.Write(lista.ListaDeClientes[i].Nombre + ";"); // Nombre
							escritor.WriteLine();
						}
					}

				}
			}
			return true;
		}

		public bool AnadirClienteAFichero(Cliente cliente)
		{
			if (!File.Exists(rutaFichero))
				return false;

			else
			{
				using (FileStream flujo = new FileStream(rutaFichero, FileMode.Append))
				{
					using (StreamWriter escritor = new StreamWriter(flujo))
					{
							escritor.Write(cliente.Dni + ";"); // Dni
							escritor.Write(cliente.Edad + ";"); // Edad
							escritor.Write(cliente.Sueldo + ";"); // Sueldo
							escritor.Write(cliente.Apellidos + ";"); // Apellidos
							escritor.Write(cliente.Nombre + ";"); // Nombre
							escritor.WriteLine();
					}
				}

			}			
			return true;
			
		}

		public ListaClientes CargarContenidoDelFichero()
		{
			ListaClientes listaCli = new ListaClientes();
			char[] separadores = { ';' }; // En el fichero cada línea tiene un cliente con los campos separados por ';'

			if (!File.Exists(rutaFichero))
				return null;
			else
			{
				using (FileStream flujo = new FileStream(rutaFichero, FileMode.Open))
				{
					using (StreamReader lector = new StreamReader(flujo))
					{
						string linea;
						string[] campos;

						do
						{
							if (lector.EndOfStream) // No hay nada que leer
								return null;

							linea = lector.ReadLine();
							campos = linea.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
							try
							{
								Cliente clienteTmp = new Cliente(campos[0], int.Parse(campos[1]), double.Parse(campos[2]), campos[3], campos[4]);
								listaCli.ListaDeClientes.Add(clienteTmp); // Relleno la lista con el cliente del fichero
							}
							catch
							{
							}

						} while (!lector.EndOfStream);
					}
				}
				return listaCli;
			}

		}

		public bool BorrarClienteDeFichero(Cliente cliente, int nCliente)
		{
			if (!File.Exists(rutaFichero))
				return false;

			// Cargo el contenido del fichero, borro el cliente y vuelvo a añadir la lista (con el cliente borrado) al fichero
			ListaClientes lista = CargarContenidoDelFichero();
			lista.ListaDeClientes.RemoveAt(nCliente);

			// Borro lo que hubiera en el fichero para añadirlo de nuevo bien:
			//File.Delete(rutaFichero);
			//File.Create(rutaFichero);
			// AnadirListaAFichero(lista);

			return true;
		}

		#endregion 

		private void btn_EditarFicha_Click(object sender, RoutedEventArgs e)
		{

			Win_EditarFicha win_editarFicha = new Win_EditarFicha();
			win_editarFicha.ShowDialog();
		}

    }
}


// Lunes 21 BD 9:15
// Martes 22 ENDE 9:15
// Miércoles 23 LM 8:15
// Jueves 23 PROG 8:15
// Viernes 25 SINF ?

// SOLO VENIR A LOS EXAMENES esa semana
