using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------
using System.IO;

namespace T8_Ejercicio11_LeerLineas
{
	class Program
	{
		static void Main(string[] args)
		{
			string texto;
			string textoFinal = "";
			string ruta = @"..\..\..\..\ficheros\Ej11_lineas.txt";

			if (!File.Exists(ruta))
				return;			
			do
			{				
				texto = Console.ReadLine();			
				textoFinal += texto + "\r\n";				
				StreamWriter escribir = new StreamWriter(ruta);
				escribir.WriteLine(textoFinal);
				escribir.Close();
			} while (texto != "");




		}
	}
}
