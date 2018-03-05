using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------
using System.IO;

namespace T8_Ejercicio9_LeerFicheros
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 1) //Al menos hay que pasarle 1 fichero
			{
				Console.WriteLine("Debe pasar al menos 1 argumento");
				Console.ReadLine();
				return;
			}

			for (int i = 0; i < args.Length; i++)
			{
				for (int j = 0; j < args.Length; j++)
				{
					if (!File.Exists(args[j])) //Si alguno de los nombre pasados no existe, no se puede leer el fichero.
					{
						Console.WriteLine("Los ficheros tienen que existir");
						Console.ReadLine();
						return;
					}
				}

				Console.WriteLine("=".PadRight(100,'='));
				Console.WriteLine("Contenido del fichero ({0}):", Path.GetFileName(args[i]));
				Console.WriteLine(File.ReadAllText(args[i]));
			}

			Console.ReadLine();

		}
	}
}
