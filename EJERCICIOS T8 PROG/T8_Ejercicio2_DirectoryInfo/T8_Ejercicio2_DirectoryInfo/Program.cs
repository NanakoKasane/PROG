using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------
using System.IO;

namespace T8_Ejercicio2_DirectoryInfo
{
	class Program
	{
		static void Main(string[] args)
		{
			string ruta = @"..\..\..\..\T8_Ejercicio1_ClasePath"; //Ruta relativa al Ejercicio 1 de la relación.
			//Son 4 saltos hacia atrás en la ruta porque se tiene en cuenta el inicio de esta ejecución, que está en carpeta\carpeta\bin\debug
			DirectoryInfo directorio = new DirectoryInfo(ruta);

			if (!directorio.Exists)
			{
				Console.WriteLine("El directorio no existe");
				Console.ReadLine();
				return;
			}
			else
				Informacion(directorio);

		}

		static void InformacionGeneral(DirectoryInfo directorio)
		{
			Console.WriteLine("			 I N F O R M A C I O N    G E N E R A L");
			Console.WriteLine("\n		           Nombre: {0}", directorio.FullName);
			Console.WriteLine("                        Atributos: {0}", directorio.Attributes);
			Console.WriteLine("                Fecha de Creación: {0}", directorio.CreationTime);
			Console.WriteLine("           Última fecha de Acceso: {0}", directorio.LastAccessTime);
			Console.WriteLine("     Última fecha de Modificación: {0}", directorio.LastWriteTime);
			Console.WriteLine("                 Directorio Padre: {0}", directorio.Parent);
			Console.WriteLine("                             Raiz: {0}", directorio.Root);

		}

		static void InformacionContenido(DirectoryInfo directorio)
		{
			DirectoryInfo[] directoriosContiene = directorio.GetDirectories();
			FileInfo[] archivosContiene = directorio.GetFiles();

			Console.WriteLine("\n\nD i r e c t o r i o s   q u e   c o n t i e n e: ".ToUpper());
			foreach (DirectoryInfo dTmp in directoriosContiene)
			{
				Console.WriteLine(dTmp);
			}

			Console.WriteLine("\nA r c h i v o s   q u e   c o n t i e n e: ".ToUpper());
			foreach (FileInfo fTmp in archivosContiene)
			{
				Console.WriteLine(fTmp);
			}

		}

		static void Informacion(DirectoryInfo directorio)
		{			
			InformacionGeneral(directorio);
			InformacionContenido(directorio);
			Console.ReadLine();
		}
	}
}
