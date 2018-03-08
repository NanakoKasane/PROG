using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T8_StreamWriter_8_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"..\..\..\ficheros\texto.txt";
            string cadena = "Esto es una cadena de texto";
            char[] array = { 'E', 's', 't', 'o', ' ', 'e', 's', ' ', 'u', 'n', ' ', 'a', 'r', 'r', 'a', 'y', ' ', '<', '3' };

            //Abro el fichero
            FileStream flujo = new FileStream(ruta, FileMode.Append, FileAccess.Write);
            StreamWriter escribir = new StreamWriter(flujo, Encoding.Default);

            for (int i = 0; i < 50; i++)
            {
                escribir.WriteLine("Línea_" + i.ToString("000"));

            }
            escribir.WriteLine(array);

            escribir.Close();
        }
    }
}
