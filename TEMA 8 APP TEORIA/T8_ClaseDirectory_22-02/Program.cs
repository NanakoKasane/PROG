using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------
using System.IO;

namespace T8_ClaseDirectory_22_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string rutaDirectorio = @"c:\ficheros"; //En la ruta es lo mismo poner "\" que "/", lo coge por igual.
            string filtro = "*.txt";  // * -> Comodín que significa todo. Es decir, que tenga lo que sea delante pero acabe en .txt
            // Comodín "?" -> Representaría solo 1 carácter.

            if (!Directory.Exists(rutaDirectorio)) //Controlar que exista la ruta antes para no tener que controlar excepciones. Sería lo mismo que try/catch, pero es mejor controlarlo antes.
                return;

            Directory.CreateDirectory(rutaDirectorio + @"\directorioPepito"); //Crear un directorio.
            string[] directorios = Directory.GetDirectories(rutaDirectorio);

            string[] ficheros = Directory.GetFiles(rutaDirectorio, filtro); // Solo obtiene los que acaban en .txt (por el filtro)      
            //Si quieres que filtre más de 1, puedes hacerlo a mano, por ejemplo en el for/foreach cuando obtenga uno, que vuelva a extraer otra vez con el otro filtro  



            //Mostrar los ficheros
            Console.WriteLine("Esta es la lista de los ficheros: ");
            foreach (string sTmp in ficheros)
            {
                Console.WriteLine(sTmp);
            }
            Console.WriteLine("\n\nEsta es la lista de los directorios: ");
            //Mostrar los directorios
            foreach (string sTmp in directorios)
            {
                Console.WriteLine(sTmp);
            }

            //Mostrar solo los nombres del fichero (no la ruta, solo archivo.extensión), usando la clase Path
            Console.WriteLine("\n\nEsta es la lista de los ficheros (solo archivo.extensión): ");
            for (int i = 0; i < ficheros.Length; i++)
            {
                Console.WriteLine(Path.GetFileName(ficheros[i]));
            }
            Console.ReadLine();

        }
    }
}
