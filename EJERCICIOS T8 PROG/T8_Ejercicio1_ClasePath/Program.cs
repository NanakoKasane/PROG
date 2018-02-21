using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------
using System.IO;

namespace T8_Ejercicio1_ClasePath
{
    class Program
    {
        static void Main(string[] args)
        {
            string rutaFichero = @"c:/basura/basura1/basura2/basura3/texto.txt";
            VerInformacion(rutaFichero);

            Console.ReadLine();

        }

        static void VerInformacion(string rutaFichero)
        {
            Console.WriteLine("     Ruta y fichero origen: {0}", rutaFichero);
            Console.WriteLine("                 Extensión: {0}", Path.GetExtension(rutaFichero));
            Console.WriteLine("           Nombre Completo: {0}", Path.GetFileName(rutaFichero));
            Console.WriteLine("               Unidad Raiz: {0}", Path.GetPathRoot(rutaFichero));
            Console.WriteLine("      Nombre sin Extensión: {0}", Path.GetFileNameWithoutExtension(rutaFichero));
        }
    }
}
