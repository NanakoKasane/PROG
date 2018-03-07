using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T8_ControlFlujo_Puntero_7_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"../../../ficheros/fichero.txt";
            long pos = 3;

            FileStream fichero = new FileStream(ruta, FileMode.Open, FileAccess.Read);
            MostrarBytes(fichero, pos);

            fichero.Seek(4, SeekOrigin.Current); //Al teminar, mueve el puntero 4 hacia adelante desde donde está.
            Console.WriteLine("\n\nLetra de la posición actual del puntero: " + (char)fichero.Position);

            Console.Write("\n\n\nEso es todo...");
            Console.ReadLine();

        }

        static void MostrarBytes(FileStream flujo, long posInicial)
        {
            int posActual = (int)flujo.Position; // flujo.Position devuelve un long. posActual debería ser mejor long que hacer Casting
            //Guardo la posición actual

            try
            {
                if (posInicial >= flujo.Length) // (posInicial > flujo.Length -1)
                    throw new ArgumentOutOfRangeException();

                flujo.Position = posInicial;
                for (long i = posInicial; i < flujo.Length; i++)
                {
                    Console.WriteLine("Byte: {1} Posición -> {0}", i, (char)flujo.ReadByte());
                }
                flujo.Position = posActual; //Al acabar el puntero volverá a estar en la posición que estaba antes de modificarlo


            }

            catch (Exception e)
            {
                Console.WriteLine("Fuera del contenido del fichero\n\n" + e.Message);
            }

        }
    }
}
