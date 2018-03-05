using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------
using System.IO;

namespace T8_Ejercicio7_ConcatenarFicheros
{
	class Program
	{
		static void Main(string[] args)
		{
			PedirDatos();
		}

		private static void PedirDatos()
		{
			string rutaFichero1;
			string rutaFichero2;
			bool correcto = true;

			do
			{
				try
				{
					Console.Clear();
					Console.WriteLine("CONCATENAR FICHEROS");
					Console.WriteLine("===================\n");
					Console.Write("Introduzca el primer fichero: ");
					rutaFichero1 = Console.ReadLine(); //  ../../../../ficheros/Ej7_Concat1.txt
					Console.Write("\nIntroduzca el segundo fichero: ");
					rutaFichero2 = Console.ReadLine(); //  ../../../../ficheros/Ej7_Concat2.txt

					if (ConcatenarFicheros(rutaFichero1, rutaFichero2))
					{					
						correcto = true;
						Console.WriteLine("\nSe ha concatenado con éxito");
					}
					else
					{
						Console.WriteLine("\nNo se han podido concatenar los ficheros");
						correcto = false;
					}
				}
				catch
				{
					correcto = false;
				}
			} while (!correcto);
			Console.ReadLine();
		}

		
		/// <summary>
		/// Concatena 2 ficheros dejando el resultado sobre el primero
		/// </summary>
		/// <param name="rutaFichero1">Fichero sobre el que se escribirá la concatenación de los 2 ficheros (este con el segundo)</param>
		/// <param name="rutaFichero2">Fichero a concatenar junto al primero</param>
		/// <returns>True si se ha podido concatenar. False si no se ha podido, porque no existan los ficheros</returns>
		static bool ConcatenarFicheros(string rutaFichero1, string rutaFichero2)
		{
			if (!File.Exists(rutaFichero1) || !File.Exists(rutaFichero2))
				return false;

			StreamReader leerFichero1 = new StreamReader(rutaFichero1);
			StreamReader leerFichero2 = new StreamReader(rutaFichero2);
			string contenidoFichero1 = leerFichero1.ReadToEnd();
			string contenidoFichero2 = leerFichero2.ReadToEnd();
			string concatenado = contenidoFichero1 + contenidoFichero2;
			leerFichero1.Close(); //Cierro los ficheros
			leerFichero2.Close();

			StreamWriter escribirFichero1 = new StreamWriter(rutaFichero1);
			escribirFichero1.Write(concatenado);
			escribirFichero1.Close();
			return true;

		}
	}
}
