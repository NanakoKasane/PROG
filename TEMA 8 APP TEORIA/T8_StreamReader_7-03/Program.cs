using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T8_StringReader_7_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"..\..\..\ficheros\entrada.txt";




            using (StreamReader fichero = new StreamReader(ruta, Encoding.Default))
            {
                VerUnoAUno(fichero);
                Console.ReadLine();
                //Al leer uno el puntero se queda al final y entonces no podrá leer los demás.
                //Esto se solucionaría cerrando el fichero y abriéndolo en cada método. Porque al abrirlo para leer el puntero vuelve a la primera posición
                //O creando un objeto nuevo para cada método.

                //O así --> Cambiando el puntero a 0 con la clase base Stream:
                Stream s = fichero.BaseStream; //Propiedad que devuelve el flujo base del mismo objeto. (Flujo en el que está basado)
                s.Seek(0, SeekOrigin.Begin); //Al moverlo de la clase base de ese flujo también lo mueves en tu objeto.

                VerUnoAUnoEOF(fichero);
                Console.ReadLine();
                s.Seek(0, SeekOrigin.Begin);

                VerLineaALinea(fichero);
                Console.ReadLine();
                s.Seek(0, SeekOrigin.Begin);

                VerTodo(fichero);
                s.Seek(0, SeekOrigin.Begin);

            }

            Console.ReadLine();

            //EJERCICIO DE EXAMEN:
            //Usuario, clave. Si el usuario y la clave está en el fichero de texto separado por "; ", le dejas entrar (iniciar sesión).
            //Abre el fichero de texto, separa los campos de ";" y buscas si está.

            //Buscar el usuario y la contraseña está a continuación
        }

        static void VerUnoAUno(StreamReader fichero)
        {
            int tmp;
            while ((tmp = fichero.Read()) != -1)
                Console.Write((char)tmp); //Al convertirlo a char ya se ven las letras, si no saldrían los enteros del ASCII que equivalen a ese char
        }

        static void VerUnoAUnoEOF(StreamReader fichero)
        {
            while (!fichero.EndOfStream)
                Console.Write((char)fichero.Read()); 
        }

        static void VerLineaALinea(StreamReader fichero)
        {
            string linea = string.Empty;
            while ((linea = fichero.ReadLine()) != null)
                Console.Write(linea);
        }

        static void VerTodo(StreamReader fichero)
        {
            string todo = string.Empty;
            todo = fichero.ReadToEnd();
            Console.Write(todo);
        }

    }
}
