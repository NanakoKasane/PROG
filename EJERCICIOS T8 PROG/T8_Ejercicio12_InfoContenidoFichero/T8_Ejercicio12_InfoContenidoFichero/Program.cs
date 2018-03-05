using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------
using System.IO;

namespace T8_Ejercicio12_InfoContenidoFichero
{
	class Program
	{
		static int nPalabras = 0;

		static void Main(string[] args)
		{
			string ruta;
			int tamanio = 0;
			string contenidoFichero;

			Console.WriteLine("Información del contenido del fichero: ".ToUpper());
			Console.WriteLine("======================================");			
			Console.Write("\nIntroduzca la ruta o nombre del fichero: ");
			ruta = Console.ReadLine(); //  "../../../../ficheros/Ej8_alumnos.txt"
			if (!File.Exists(ruta))
				return;

			contenidoFichero = File.ReadAllText(ruta);
			tamanio = contenidoFichero.Length;			
					
			

			//Resultado
			Console.WriteLine("\nAtributos: " + File.GetAttributes(ruta));
			Console.WriteLine("Tamaño (número de caracteres): " + tamanio);
			Console.WriteLine("Número de líneas: " + ContarLineas(ruta));
			Console.WriteLine("Número de palabras: " + ContarPalabras(ruta)); //Debería haber 23. El problema es que al saltar de linea no hay espacio y no se cuenta

			Console.ReadLine();
		}

		/// <summary>
		/// Método que cuenta las líneas de un fichero
		/// </summary>
		/// <param name="ruta">Ruta o nombre del fichero</param>
		/// <returns>Número de líneas</returns>
		static int ContarLineas(string ruta)
		{
			int nLineas = 0;
			string contenidoFichero = File.ReadAllText(ruta);
			int tamanio = contenidoFichero.Length;

			StreamReader leer = new StreamReader(ruta);
			if (tamanio <= 0)
			{
				nLineas = 0;
			}
			do
			{
				leer.ReadLine();
				nLineas++;
				if (nLineas > 1)
					nPalabras++; // Porque cada vez que salta de línea no hay un espacio sino \r\n y eso también hay que contarlo como palabra
				
			} while (!leer.EndOfStream); //Lee líneas y las cuenta hasta que llegue al final del fichero
			leer.Close();

			return nLineas;
		}

		/// <summary>
		/// Método que cuenta las palabras de un fichero
		/// </summary>
		/// <param name="ruta">Ruta o nombre del fichero</param>
		/// <returns>Número de palabras del fichero</returns>
		static int ContarPalabras(string ruta)
		{
			string contenidoFichero = File.ReadAllText(ruta);
			bool espacio = true;
			for (int i = 0; i < contenidoFichero.Length; i++)
			{
				if (contenidoFichero[i] == ' ')
					espacio = true;
				else
				{
					if (espacio)
					{
						nPalabras++;
						espacio = false;
					} 
				}
			}
			return nPalabras;
		}

		
	}


}
