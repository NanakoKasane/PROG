using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------
using System.IO;

namespace T8_Ejercicio5_ContenidoFichero
{
	class Program
	{
		static void Main(string[] args)
		{

			if (args.Length != 1)
			{
				Console.WriteLine("Argumentos incorrectos");
				Console.WriteLine("Debe introducir: " + @"[Unidad:\Ruta\]Fichero_de_Texto");
				Console.ReadLine();
				return;
			}

			string ruta = args[0];


			ContenidoFichero(ruta);

		}

		/// <summary>
		/// Método que si existe el fichero en la ruta, muestra por pantalla su contenido
		/// </summary>
		/// <param name="ruta">Ruta al fichero</param>
		static void ContenidoFichero(string ruta)
		{
			if (!File.Exists(ruta))
			{
				Console.WriteLine("El fichero no existe");
				Console.ReadLine();
				return;
			}

			string texto = File.ReadAllText(ruta); //Los ficheros hay que guardarlos en UTF-8, por defecto está en ANSI y las tildes no saldrán

			Console.WriteLine("Contenido del fichero:".ToUpper());
			Console.WriteLine(texto);
			Console.ReadLine();
		}
	}
}
