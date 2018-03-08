using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T8_BinaryReaderWriter_8_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"..\..\..\ficheros\FicheroBinario.txt";
            string texto = "Soy un texto";
            int entero = 133;
            double doble = Math.PI;


            FileStream flujoEscribir = new FileStream(ruta, FileMode.Append, FileAccess.Write);
            Escribir(flujoEscribir, texto, entero, doble);

            FileStream flujoLeer = new FileStream(ruta, FileMode.Open, FileAccess.Read);
            Leer(flujoLeer);
            Console.ReadLine();
        }

        static void Escribir(FileStream flujo, string texto, int entero, double doble)
        {

            BinaryWriter escribir = new BinaryWriter(flujo);

            escribir.Write(texto);
            escribir.Write(entero);
            escribir.Write(doble);

            flujo.Close();
            if (escribir != null)
                escribir.Close();
        }

        static void Leer(FileStream flujo)
        {
            BinaryReader leer = new BinaryReader(flujo);

            //Importante leerlo en las mismas posiciones que están escritos y cada tipo.
            Console.WriteLine(leer.ReadString());
            Console.WriteLine(leer.ReadInt32());
            Console.WriteLine(leer.ReadDouble());
            leer.Close();
            flujo.Close();
        }
    }
}
