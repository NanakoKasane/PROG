using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------
using System.IO;

namespace T8_ClasePath_19_02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Extraer solo los nombres de las imágenes -> Ejercicio de examen

            string rutafichero = @"C:\dir1\dir2\dir3\dir4\datos.dat";
            string rutaUniversal = Path.DirectorySeparatorChar + "datos" + Path.DirectorySeparatorChar; // + etc...

            VerDatos(rutafichero);

            //Cambiar extensión
            rutafichero = Path.ChangeExtension(rutafichero, "IES"); //.IES --> Sería lo mismo, no pone "..", simplemente no le añade otro "." más solo si ya está
            VerDatos(rutafichero);

            


        }

        static public void VerDatos(string rutaFichero)
        {
            //Obtener información y mostrarla
            Console.WriteLine("     Ruta y fichero origen: {0}", rutaFichero);
            Console.WriteLine("                 Extensión: {0}", Path.GetExtension(rutaFichero));
            Console.WriteLine("           Nombre Completo: {0}", Path.GetFileName(rutaFichero));
            Console.WriteLine("               Unidad Raiz: {0}", Path.GetPathRoot(rutaFichero));
            Console.WriteLine("      Nombre sin Extensión: {0}", Path.GetFileNameWithoutExtension(rutaFichero));
            //Etc...

            Console.WriteLine("Esto es todo...");
            Console.ReadLine();
        }
    }
}
