using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------
using System.IO;

namespace T8_Ejercicio4_CopiarMenosCaracter
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length != 3)
			{
				Console.WriteLine("Argumentos incorrectos.");
				Console.WriteLine("Debe introducir: FicheroDestino FicheroFuente Caracter");
				Console.ReadLine();
				return;
			}

			string ficheroDestino = args[0];
			string ficheroFuente = args[1];

			try
			{
				char caracter = char.Parse(args[2]); //La conversión de char a string puede fallar por eso lo metemos en el try.

				if (!File.Exists(ficheroFuente) || !File.Exists(ficheroDestino))
				{
					Console.WriteLine("El fichero no existe");
					Console.ReadLine();
					return;
				}

				StreamReader leer = new StreamReader(ficheroFuente);
				string contenidoFichero = leer.ReadToEnd(); //Contenido del fichero fuente
				string contenidoSinChar = ""; //Contenido a copiar sin el char que le pases

				for (int i = 0; i < contenidoFichero.Length; i++)
				{
					if (contenidoFichero[i] != caracter)
						contenidoSinChar += contenidoFichero[i];
				}
				leer.Close();

				StreamWriter escribir = new StreamWriter(ficheroDestino);
				escribir.Write(contenidoSinChar); //Si ya tenía algo escrito se sobreescribe
				//Si no quisieramos que se sobreescribiera-> File.AppendAllText(ficheroDestino, contenidoSinChar);
				escribir.Close();
			}
			catch (FormatException)
			{
				Console.WriteLine("El formato introducido no es correcto. El tercer argumento debe ser un carácter");
				Console.ReadLine();
				return;
			}
			catch
			{
			}

			Console.WriteLine("El contenido del fichero se ha copiado sin el caracter especificado");
			Console.ReadLine();
		}
	}
}
