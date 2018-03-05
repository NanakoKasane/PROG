using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-------------------------
using System.IO;

namespace T8_Ejercicio8_CrearListar
{
	class Program
	{
		static void Main(string[] args)
		{
			PedirDatos();

		}

		static void PedirDatos()
		{
			string fichero;
			bool correcto = true;

			do
			{
				try
				{
					Console.Clear();
					Console.WriteLine("FICHEROS: Guardar y leer datos");
					Console.WriteLine("==============================");
					Console.Write("\nIntroduzca el fichero donde se guardarán los datos: ");
					fichero = Console.ReadLine(); //    ../../../../ficheros/Ej8_alumnos.txt

					if (CrearFichero(fichero))
						Console.WriteLine("Se han guardado los datos con éxito");

					Console.WriteLine("\nContenido del fichero: ");
					ListarFichero(fichero);
					correcto = true;
				}
				catch (ArgumentException)
				{
					Console.WriteLine("Debe introducir el nombre del fichero o ruta");
					Console.ReadLine();
					correcto = false;
				}
				catch
				{
					correcto = false;
				}
			} while (!correcto);

			Console.ReadLine();
		}


		static string CrearAlumnos()
		{
			string alumnos;
			Alumnos alumno1 = new Alumnos("Maria", "Villalobos Santos");
			Alumnos alumno2 = new Alumnos("Mónica del mar", "Espinosa Román");
			Alumnos alumno3 = new Alumnos("Carmen", "Pena Galvez");
			ListaAlumnos.AnadirAlumnos(alumno1);
			ListaAlumnos.AnadirAlumnos(alumno2);
			ListaAlumnos.AnadirAlumnos(alumno3);

			alumnos = alumno1.ToString() + alumno2 + alumno3;
			return alumnos;
		}

		static bool CrearFichero(string fi)
		{
			string alumnos = CrearAlumnos();
			//if (!File.Exists(fi))        No hace falta, si no existe el fichero lo crea
			//	return false;

			File.WriteAllText(fi, alumnos);
			return true;
		}

		static bool ListarFichero(string fi)
		{
			Console.Write(File.ReadAllText(fi));
			return true;
		}
	}
}
