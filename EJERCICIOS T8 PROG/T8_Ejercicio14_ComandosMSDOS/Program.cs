using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T8_Ejercicio14_ComandosMSDOS
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] unidad = DriveInfo.GetDrives();
            string ruta = unidad[0].ToString() + "Midos"; // = "c" + Path.VolumeSeparatorChar.ToString() + Path.DirectorySeparatorChar.ToString() + "Midos";



			//COMANDOS
            if (args[0].ToUpper() == "help".ToUpper() && args.Length == 1)
                ComandoHelp();
            else if (args[0].ToUpper() == "help".ToUpper())
                Error();

            if (args[0].ToUpper() == "dir".ToUpper() && (args.Length == 1 || args.Length == 2))
                ComandoDir(args, ruta);
            else if (args[0].ToUpper() == "dir".ToUpper())
                Error();

            if (args[0].ToUpper() == "copy".ToUpper() && (args.Length > 2))
                ComandoCopy(args);
            else if (args[0].ToUpper() == "copy".ToUpper())
                Error();

            if (args[0].ToUpper() == "type".ToUpper() && (args.Length == 2))
                ComandoType(args);
            else if (args[0].ToUpper() == "type".ToUpper())
                Error();

            if (args[0].ToUpper() == "find".ToUpper() && (args.Length >= 3))
                ComandoFind(args);
            else if (args[0].ToUpper() == "find".ToUpper())
                Error();

			if (args[0].ToUpper() == "delete".ToUpper() && args.Length == 2)
				ComandoDelete(args);
			else if (args[0].ToUpper() == "delete".ToUpper())
				Error();



        }

		/// <summary>
		/// Mensaje de error si se introduce mal algún comando
		/// </summary>
        static void Error()
        {
            Console.WriteLine("Algunos argumentos no son válidos");
            Console.ReadKey(true);
        }

		#region comando HELP 
        static void ComandoHelp()
        {
                //Comandos:
                Console.WriteLine("\nHELP                              Proporciona información de ayuda sobre los comandos");
                Console.WriteLine("\nDIR [ruta]                        Muestra los directorios y ficheros de la ruta.\n\t\t\t\t  Si no se especifica ruta, toma la actual");
                Console.WriteLine("\nCOPY (fichero/sOrigen) (destino)  Copia uno o varios ficheros a otra ruta");
                Console.WriteLine("\nTYPE (rutaArchivo)                Muestra por pantalla el contenido de un archivo de texto");
                Console.WriteLine("\nFIND \"cadena\" (archivo/s)         Busca una cadena de texto en uno/más archivos");
				Console.WriteLine("\nDELETE (ruta)                     Elimina el directorio o fichero de la ruta especificada.");
                //Recuerda poner .toUpper en los comandos para poder escribir en mayúscula o minúscula        
                Console.ReadKey(true);

                //Hay que bucar los comandos en la ruta nuestra. Añadiendo ";" y ruta a PATH. Ponerlo antes
                //O en Windows --> Sistema y seguridad -> Sistema -> Configuración avanzada del sistema -> Variable de entorno -> Buscar "Path" -> Editar... Y subirla/ponerla la primera la nueva ruta
        }
		#endregion 

		#region Comando DIR
		static void ComandoDir(string[] argumentos, string ruta)
        {
            string rutaArchivo = "";
            if (argumentos.Length == 1)
            {
                rutaArchivo = ruta;
            }            

            //Si sí le pasas la ruta (Es decir, si argumentos.Length == 2):
            if (argumentos.Length == 2)
                 rutaArchivo = argumentos[1];
            string[] archivos;
            string[] directorios;

            if (!Directory.Exists(rutaArchivo))
                return;
            archivos = Directory.GetFiles(rutaArchivo);
            directorios = Directory.GetDirectories(rutaArchivo);

            if (archivos.Length > 0)
            {
                Console.WriteLine("ARCHIVOS: ");
                foreach (string tmp in archivos)
                {
                    Console.WriteLine(tmp);
                }
            }
            if (directorios.Length > 0)
            {
                Console.WriteLine("\nDIRECTORIOS: ");
                foreach (string tmp in directorios)
                {
                    Console.WriteLine(tmp);
                }
            }
            Console.ReadKey(true);
        }
		#endregion 

		#region Comando COPY 
		static void ComandoCopy(string[] argumentos)
        {
            for (int i = 1; i < argumentos.Length - 1; i++)
            {
                if (!File.Exists(argumentos[i]))
                {
                    Console.WriteLine("Alguna ruta no existe");
                    Console.ReadLine();
                    return;
                }
            }

			if (!Directory.Exists(Path.GetDirectoryName(argumentos[argumentos.Length - 1])))
			{
				Console.WriteLine("Alguna ruta no existe");
				Console.ReadLine();
				return;
			}

            for (int i = 1; i < argumentos.Length -1; i++)//El último es al que vamos a copiar los archivos. Último parámetro-> rutaDestino
            {
				string contenido = File.ReadAllText(argumentos[i]);
				File.AppendAllText(argumentos[argumentos.Length - 1], contenido);
            }
			
        }
		#endregion 

		#region Comando TYPE
		static void ComandoType(string[] argumentos)
        {
            string rutaArchivo = argumentos[1];
			if (!File.Exists(rutaArchivo))
				return;
            string contenido = File.ReadAllText(rutaArchivo, Encoding.Default);
            Console.WriteLine(contenido);
            Console.ReadLine();

        }
		#endregion 

		#region Comando FIND
		static void ComandoFind(string[] argumentos)
        {
            string cadena = argumentos[1];

            for (int i = 2; i < argumentos.Length; i++)
            {
                if (!File.Exists(argumentos[i]))
                {
                    Console.WriteLine("Alguno de los archivos no existe");
                    Console.ReadLine();
                    return;
                }
            }

            for (int i = 2; i < argumentos.Length; i++)
            {
                string contenido = File.ReadAllText(argumentos[i]);
                if (contenido.Contains(cadena))
                {
                    Console.WriteLine("La cadena de texto se ha encontrado en el archivo: {0}", argumentos[i]);
                }
            }
            Console.ReadLine();
		}
		#endregion 

		#region Comando DELETE
		static void ComandoDelete(string[] argumentos)
		{
			string ruta = argumentos[1];
			if (File.Exists(ruta))
			{
				File.Delete(ruta);
				Console.WriteLine("Fichero borrado");
				Console.ReadLine();
			}


			if (Directory.Exists(ruta))
			{
				Directory.Delete(ruta, false);
				Console.WriteLine("Directorio borrado");
				Console.ReadLine();
			}
		}
		#endregion 

	}
}
