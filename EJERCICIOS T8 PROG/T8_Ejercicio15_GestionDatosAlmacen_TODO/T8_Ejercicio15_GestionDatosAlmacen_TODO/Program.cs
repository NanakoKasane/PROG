using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T8_Ejercicio15_GestionDatosAlmacen_TODO
{
	class Program
	{
		static void Main(string[] args)
		{
			ListaArticulos lista = new ListaArticulos();
			MenuPrincipal(lista);

		}

		#region MENU
		static void MenuPrincipal(ListaArticulos lista)
		{
			string ruta = "articulos.txt";
			string ruta2 = "articuloImprimir.txt";
			bool error = false;
			int opcion = 0;
			
			do
			{
				error = false;
				Console.Clear();
				Console.WriteLine("M E N Ú    P R I N C I P A L ");
				Console.WriteLine("=============================");
				Console.WriteLine("\n1. Alta de artículos. (No se permiten repeticiones)");
				Console.WriteLine("2. Baja de artículos. ");
				Console.WriteLine("3. Consultar un artículo.");
				Console.WriteLine("4. Modificar un artículo.");
				Console.WriteLine("5. Listar artículos ordenados por código.");
				Console.WriteLine("6. Listar artículos ordenados por nombre.");
				Console.WriteLine("7. Imprimir.");
				Console.WriteLine("8. Generar documento HTML.");
				Console.WriteLine("9. Crear fichero.");
				Console.WriteLine("\n\n0. Salir del programa.");
				Console.Write("\n\tOpción: ");
				try
				{
					opcion = int.Parse(Console.ReadLine());
				}
				catch
				{
					error = true;
				}
				if (opcion < 0 || opcion > 9)
					error = true;

				switch (opcion)
				{
					case 1:
						#region Alta artículos
						Console.Clear();
						Console.WriteLine("ALTA DE ARTÍCULOS");
						Console.WriteLine("=================\n");
						Articulo articulo = PedirDatos();
						if(lista.AltaArticulo(articulo))
							Console.WriteLine("Artículo añadido con éxito");
						else
							Console.WriteLine("No se ha podido añadir");
						Console.ReadLine();
						MenuPrincipal(lista);
						break;
						#endregion 

					case 2:
						#region Baja de artículos
						Console.Clear();

						error = false;
						int codigo = 0;						
						Console.WriteLine("BAJA DE ARTÍCULOS");
						Console.WriteLine("=================\n");
						Console.Write("Código del artículo a eliminar: ");
						try
						{
							codigo = int.Parse(Console.ReadLine());
						}
						catch
						{
							error = true;
						}
						if (!lista.BajaArticulo(codigo))
							Console.WriteLine("\nNo hay un artículo con ese código");
						else
							Console.WriteLine("\nSe ha eliminado el artículo");
						Console.ReadLine();
						MenuPrincipal(lista);
						break;
						#endregion 

					case 3:
						#region Consultar artículo
						Console.Clear();
						Console.WriteLine("CONSULTAR ARTÍCULO");
						Console.WriteLine("==================\n");
						error = false;
						int codigoArt = 0;
						Console.Write("Código del artículo a consultar: ");
						try
						{
							codigoArt = int.Parse(Console.ReadLine());
						}
						catch
						{
							error = true;
						}
						if (!ConsultarArticulo(codigoArt))
							Console.WriteLine("\nNo ha un artículo con ese código");

						Console.ReadLine();
						MenuPrincipal(lista);
						break;
						#endregion 

					case 4:
						#region Modificar artículo
						Console.Clear();
						error = false;
						int codigoMod = 0;
						Console.WriteLine("MODIFICAR ARTÍCULO");
						Console.WriteLine("==================\n");
						Console.Write("Código del artículo a modificar: ");
						try
						{
							codigoMod = int.Parse(Console.ReadLine());
						}
						catch
						{
							error = true;
						}
						if (!ModificarArticulo(codigoMod))
							Console.WriteLine("\nNo hay un artículo con ese código");
						Console.ReadLine();
						MenuPrincipal(lista);
						break;
						#endregion 

					case 5:
						#region Listar por código
						Console.Clear();
						lista.ListarArticulosPorCodigo();
						Console.ReadLine();
						MenuPrincipal(lista);
						break;
						#endregion 

					case 6:
						#region Listar por nombre
						Console.Clear();
						lista.ListarArticulosPorNombre();
						Console.ReadLine();
						MenuPrincipal(lista);
						break;
						#endregion 

					case 7:
						#region Imprimir
						Console.Clear();
						Imprimir(ruta2);
						Console.ReadLine();
						MenuPrincipal(lista);
						break;
						#endregion 

					case 8:
						#region Generar HTML
						Console.Clear();
						GenerarHTML();
						Console.ReadLine();
						MenuPrincipal(lista);
						break;
						#endregion 

					case 9:
						#region Crear Fichero
						Console.Clear();
						CrearFichero(ruta);
						Console.ReadLine();
						MenuPrincipal(lista);
						break;
						#endregion 

					case 0:
						break;
				}

			} while (error);

		}
		#endregion 


		#region PedirDatos
		static Articulo PedirDatos()
		{
			string articulo;
			double precio = 0.0;
			string comentario;
			bool error = false;

			do
			{
				Console.Clear();
				Console.Write("Introduzca el nombre del artículo: ");
				articulo = Console.ReadLine();

				Console.Write("\nIntroduzca su precio: ");
				try
				{
					precio = double.Parse(Console.ReadLine());
				}
				catch
				{
					error = true;
				}

				Console.Write("\nIntroduzca un comentario: ");
				comentario = Console.ReadLine();
			} while (error);


			return new Articulo(articulo, precio, comentario);

			
		}
		#endregion 

		#region Métodos Consultar y Modificar Articulo
		static bool ConsultarArticulo(int codigo)
		{
			for (int i = 0; i < ListaArticulos._listaArticulos.Count; i++)
			{
				if (ListaArticulos._listaArticulos[i].Cod_articulo == codigo)
				{
					Console.WriteLine(ListaArticulos._listaArticulos[i].ToString(true));
					return true;
				}
			}
			return false;
		}

		static bool ModificarArticulo(int codigo)
		{
			ConsoleKeyInfo opcion;
			ListaArticulos lista = new ListaArticulos();
			for (int i = 0; i < ListaArticulos._listaArticulos.Count; i++)
			{
				if (ListaArticulos._listaArticulos[i].Cod_articulo == codigo)
				{
					Console.WriteLine("Artículo a modificar: ");
					Console.WriteLine(ListaArticulos._listaArticulos[i].ToString(true));
					Console.Write("\n¿Seguro que desea modificarlo? S/N: ");
					opcion = Console.ReadKey();
					if (opcion.Key == ConsoleKey.S)
					{
						lista.BajaArticulo(codigo);

						Console.WriteLine("\n\nIntroduzca los nuevos datos a continuación...");
						Console.ReadKey(true);
						Articulo articuloNuevo = PedirDatos();

						lista.AltaArticulo(articuloNuevo);
						Console.WriteLine("\nModificado con éxito: ");
						Console.WriteLine(articuloNuevo.ToString(true));
						return true;
					}
				}
			}
			return false;

		}
		#endregion 

		#region Métodos para Crear e Imprimir fichero
		static void CrearFichero(string ruta)
		{
			ConsoleKeyInfo tecla;

			string contenido = string.Empty;
			for (int i = 0; i < ListaArticulos._listaArticulos.Count; i++)
			{
				contenido += ListaArticulos._listaArticulos[i] + "\r\n";
			}

			if (File.Exists(ruta))
			{
				Console.Write("Los datos que haya en el fichero se van a borrar. ¿Desea continuar? S/N: ");
				tecla = Console.ReadKey();
				if (tecla.KeyChar != 'S')
				{
					return;
				}

			}

				using (StreamWriter escribir = new StreamWriter(ruta))
				{
					escribir.WriteLine(contenido); //YA TE CREAR EL FICHERO SI NO EXISTE
					Console.WriteLine("\nSe ha creado el fichero con los datos con éxito");
				}
			}
		

		//Guarda en un fichero la lista e imprime el contenido por pantalla
		static void Imprimir(string ruta)
		{

			try
			{
				CrearFichero(ruta);

				Console.WriteLine("\nContenido: ");
				Console.WriteLine(File.ReadAllText(ruta));
			}
			catch
			{
			}
		}
		#endregion 

		#region Método para Generar HTML con los datos en una tabla
		static void GenerarHTML()
		{
			string ruta = "articulos.html"; //O pregunto la ruta donde lo quiere guardar
			TextWriter tmp = Console.Out;

			StreamWriter flujo = new StreamWriter(ruta);
			Console.SetOut(flujo);
			Console.WriteLine("<!DOCTYPE html>");
			Console.WriteLine("<html>");
			Console.WriteLine("<head>");
			Console.WriteLine("</head>");
			Console.WriteLine("\n<body>");

			Console.WriteLine("<table border=\"1\">");
			Console.WriteLine("<caption>ARTÍCULOS</caption>");

			Console.WriteLine("\n<tr>");
			Console.WriteLine("<td>Código</td>");
			Console.WriteLine("<td>Nombre</td>");
			Console.WriteLine("<td>Precio</td>");
			Console.WriteLine("<td>Pvp</td>");

			Console.WriteLine("</tr>");

			foreach (Articulo articulo in ListaArticulos._listaArticulos)
			{			
				Console.WriteLine("\n<tr>");
				Console.WriteLine("<td>" + articulo.Cod_articulo + "</td>");
				Console.WriteLine("<td>" + articulo.Nombre_articulo + "</td>");
				Console.WriteLine("<td>" + articulo.Precio + "</td>");
				Console.WriteLine("<td>" + articulo.Pvp + "</td>");

				Console.WriteLine("</tr>");

			}
			Console.WriteLine("</table>");

			Console.WriteLine("</body>");
			Console.WriteLine("</html>");

			Console.SetOut(tmp);
			flujo.Close();
			Console.WriteLine("Se ha generado el HTML con éxito");
		}
		#endregion 
	}
}
