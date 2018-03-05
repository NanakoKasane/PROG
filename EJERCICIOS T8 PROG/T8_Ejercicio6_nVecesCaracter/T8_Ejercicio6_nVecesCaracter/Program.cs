using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------
using System.IO;

namespace T8_Ejercicio6_nVecesCaracter
{
	class Program
	{
		static void Main(string[] args)
		{
			PedirInformacion();
		}

		static void PedirInformacion()
		{
			bool error = false;
			char caracter;
			string rutaFchero;
			int contador;

			
				do
				{
					try
					{
						Console.Clear();
						Console.WriteLine("CONTADOR DE CARACTER");
						Console.WriteLine("====================\n");
						Console.WriteLine();
						Console.Write("Introduzca el caracter a contar: ");
						caracter = char.Parse(Console.ReadLine());
						Console.Write("\nIntroduzca la ruta del archivo: "); //Lo pruebo -> ../../../../ficheros/Ej6_ficheroContarChar.txt
						rutaFchero = Console.ReadLine();
						error = false;				
						contador = ContadorChar(caracter, rutaFchero);
						if (contador < 0)
							Console.WriteLine("\nNo se ha podido contar. El fichero no existe.");
						else
							Console.WriteLine("\n\nEl carácter aparece en el fichero {0} veces", contador);
						
					}
					catch
					{				
						error = true;
						Console.WriteLine("\nERROR");
					}

				} while (error);

			
			Console.ReadLine();
			
		}

		/// <summary>
		/// Método que cuenta un carácter en un determinado fichero 
		/// </summary>
		/// <param name="caracter">Caracter a contar en el fichero</param>
		/// <param name="rutaFichero">Ruta del fichero en el que quieres contar el carácter</param>
		/// <returns>Devuelve -1 si no se ha podido contar (no exista el fichero, etc)</returns>
		static int ContadorChar(char caracter, string rutaFichero)
		{
			if (!File.Exists(rutaFichero))
			{
				return -1;
			}

			int contador = 0;			
			StreamReader leer = new StreamReader(rutaFichero);
			string contenidoFichero = leer.ReadToEnd();
			for (int i = 0; i < contenidoFichero.Length; i++)
			{
				if (contenidoFichero[i] == caracter)
					contador++;
			}
			return contador;

		}
	}
}
