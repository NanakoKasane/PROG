using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------
using System.IO;

namespace T8_ClaseFile_21_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"c:\basura\prueba.txt";
            string texto = "hola Caracola";
            string nuevaLinea = "\r\n"; //El block de notas para hacer un salto de lineas necesita \r\n

            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText(ruta, texto + "_" + i.ToString("000") + nuevaLinea);  //Te añade el texto al fichero de esa ruta. Si el fichero no existe, lo crea          
            } 
            //Cada vez que ejecutas (F5), se ejecuta el bucle y se vuelve a guardar en el fichero)
            //Esto podríamos controlando poniendo que solo se guarde si está vacío.

            //Método Read para que te muestre el contenido añadido al fichero. Append es solo para añadirlo al fichero, no lo muestra aquí
            Console.WriteLine(File.ReadAllText(ruta)); //Te muestra el contenido del fichero (guardado en él).
            Console.ReadLine();

        }
    }
}
