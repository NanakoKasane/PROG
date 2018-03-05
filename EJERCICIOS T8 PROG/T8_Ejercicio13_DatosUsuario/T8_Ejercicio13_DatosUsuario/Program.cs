using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------
using System.IO;
using System.Diagnostics;

namespace T8_Ejercicio13_DatosUsuario
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Variables
			string fichero = "../../../../ficheros/Ej13_Datos.txt"; //Ej13_Datos.txt
			string contenido = "";
			string usuario = "";
			ConsoleKeyInfo tecla;
			bool salir = false;

			DateTime ahoraFecha = DateTime.Now.Date;
			string ahoraHora = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

			Stopwatch tiempo = new Stopwatch();
			#endregion 

			#region Pedir Usuario
			tiempo.Start();					
			Console.Write("Introduzca su nombre de usuario (máx 20 caracteres): ");
			do
			{
				tecla = Console.ReadKey();
				usuario += tecla.KeyChar;
				if (tecla.Key == ConsoleKey.Enter)
					salir = true;
				if (usuario.Length >= 20)
					salir = true;
				
			} while (!salir);
			tiempo.Stop();
			#endregion 

			#region Guardar contenido
			contenido += "Usuario: ".PadLeft(3) + usuario.PadRight(20) + "| Fecha: " + ahoraFecha.ToShortDateString().PadRight(15) + "| Hora: " + 
				ahoraHora.ToString().PadRight(10) + "| Tiempo transcurrido (milisegundos): " + tiempo.ElapsedMilliseconds.ToString().PadRight(20) + "\r\n";
			#endregion 

			try
			{
				File.AppendAllText(fichero, contenido);
			}
			catch
			{
			}

			//Console.WriteLine("\n\nContenido del fichero: ".ToUpper() + "\n");
			//Console.Write(File.ReadAllText(fichero));

			Console.ReadLine();
			

		}


	}
}
