using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2T_EjercicioExamen_LOGINUserPass
{
	class Program
	{
		static Dictionary<string, string> diccionario = new Dictionary<string, string>();
		static void Main(string[] args)
		{
			//Al final al quedarme solo con el .exe, el fichero estará en la misma ruta que el .exe, solo necesario poner el nombre del fichero
			string ruta = @"login.txt"; //.\..\..\..\
			if (!File.Exists(ruta))
			{
				Console.WriteLine("No existe el fichero en la ruta");
				Console.ReadLine();
				return;
			}

			StreamReader fichero = new StreamReader(ruta, Encoding.Default);
			
			//Los campos están del siguiente modo en el fichero-> usuario contraseña; usuario contraseña; usuario contraseña; ...
			string contenido = fichero.ReadToEnd();
			char[] separador = {';'};
			char[] separadorIni = {' '};
			string[] campos = contenido.Split(separador); //Lo separo primero por ';'

			string contenidov2 ="";
			for (int i = 0; i < campos.Length; i++)
			{
				contenidov2 += campos[i];
			}
			
			string[] camposv2 = contenidov2.Split(separadorIni); //Finalmente lo separo por ' ' el usuario de la contraseña


			//Ahora añado al diccionario los campos, siendo la clave el usuario (no hay repetidos) y el contenido la contraseña
			for (int i = 0; i < camposv2.Length; i++)
			{
				try
				{
					diccionario.Add(camposv2[i].TrimStart(separadorIni), camposv2[++i].TrimStart(separadorIni)); //Trim por si hay espacios en la separación de campos
				}
				catch
				{
					//NO ES NECESARIO REALIZAR NADA, si la clave es duplicada, no se añade y ya está, entra al catch y no añade. Pasa al siguiente

					//No puede haber usuarios repetidos, el primero que haya creado la cuenta es el que vale.
				}
			}

			fichero.Close();

			Login();

		}

		static void Login()
		{
			string usuario;
			string contrasenia = "";
			string valor;
			ConsoleKeyInfo tecla;

			Console.WriteLine("INICIO DE SESIÓN: ");
			Console.Write("\nIntroduzca su usuario: ");
			usuario = Console.ReadLine();


			//La contraseña no se verá y se verán solo "****"
			Console.Write("\nIntroduzca su contraseña: ");
			do
			{
				tecla = Console.ReadKey(true);
				if (tecla.Key != ConsoleKey.Enter)
				{
					Console.Write("*");
					try
					{
						Console.CursorLeft++;
					}
					catch
					{ //Si llega al final, vuelve al inicio en la siguiente linea
					}
					
					contrasenia += tecla.KeyChar;

				}
			} while (tecla.Key != ConsoleKey.Enter);

			try
			{
				if (diccionario.ContainsKey(usuario) && diccionario.TryGetValue(usuario, out valor))
				{
					if (valor == contrasenia)
					{
						Console.WriteLine("\nHA INICIADO SESIÓN CON ÉXITO A LAS {0:D2}:{1:D2}", DateTime.Now.Hour, DateTime.Now.Minute);
						Console.ReadLine();
					}
					else
					{
						Console.WriteLine("\nEl usuario o contraseña no son correctos");
						Console.ReadLine();
					}
				}
				else
				{
					Console.WriteLine("\nEl usuario o contraseña no son correctos");
					Console.ReadLine();
				}
			}
			catch
			{
				Console.WriteLine("Error...");
				Console.ReadLine();
			}
			
		}
	}
}
