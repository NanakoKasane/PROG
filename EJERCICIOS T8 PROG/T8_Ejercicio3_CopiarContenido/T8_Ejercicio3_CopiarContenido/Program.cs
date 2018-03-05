using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----------------------------
using System.IO;

namespace T8_Ejercicio3_CopiarContenido
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length != 2 )
			{
				Console.WriteLine("Argumentos incorrectos.");
				Console.WriteLine("Debe introducir: FicheroOrigen FicheroDestino");
				Console.ReadLine();
				return;
			}

			string ficheroOrigen = args[0];
			string ficheroDestino = args[1];
				

			Copiar(ficheroOrigen, ficheroDestino);
				
		}

		static void Copiar(string ficheroOrigen, string ficheroDestino)
		{
			try
			{			
				if (File.Exists(ficheroOrigen)) //Tiene que existir en la ruta para que pueda copiarse a otro
				{
					File.Copy(ficheroOrigen, ficheroDestino, true); //true -> lo sobreescribe si ya existía el ficheroDestino
					Console.WriteLine("El fichero se ha copiado"); //Si no se le pasa ruta toma la ruta del directorio en el que estás (del ejecutable)
					Console.ReadLine();
				}
			}
			catch
			{
				Console.WriteLine("El fichero no se puede copiar");			
				Console.ReadLine();
			}
		}
	}
}
