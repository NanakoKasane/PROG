using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----------------------------
using System.IO;

namespace T8_Ejercicio10_TextoAlReves
{
	class Program
	{
		static void Main(string[] args)
		{
			string ruta;
			string contenido;
			string contenidoAlReves = "";

			Console.WriteLine("CONTENIDO AL REVÉS");
			Console.WriteLine("==================");
			Console.Write("\nIntroduzca la ruta o nombre del archivo: ");
			ruta = Console.ReadLine(); //     ../../../../ficheros/Ej8_alumnos.txt

			if (!File.Exists(ruta))
			{
				Console.WriteLine("El fichero debe existir");
				Console.ReadLine();
				return;
			}
			
			contenido = File.ReadAllText(ruta);

			for (int i = contenido.Length -1; i > 0; i--)
			{
				contenidoAlReves += contenido[i];
			}


			Console.WriteLine("\nCONTENIDO:");
			Console.WriteLine(contenido);
			Console.WriteLine("\nCONTENIDO AL REVÉS:");
			Console.WriteLine(contenidoAlReves);
			Console.ReadLine();
		}
	}
}
