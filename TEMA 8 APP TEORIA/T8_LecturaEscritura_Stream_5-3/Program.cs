using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T8_LecturaEscritura_Stream_5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"..\..\..\ficheros\entrada.txt";

            //Esto debería hacerse en el método:
            FileStream fichero = new FileStream(ruta, FileMode.Open); //Al abrirse el puntero está al principio y por defecto lo abre para leer.
            Listar(fichero);
            fichero.Close();
            

            Console.ReadLine();

        }

        static void Listar(Stream flujo) //Le pasas un flujo con el fichero a listar (Que está unido a la ruta y sus modos)
        {
            int caracter;

            while ((caracter = flujo.ReadByte()) != -1) //Esto solo vale si la clase maneja texto porque no hay ASCII negativo, pero si lee Byte, puede estar -1 y no leería más
                Console.Write((char)caracter); //Es decir, solo si es un fichero de texto.
            
        }
    }
}
