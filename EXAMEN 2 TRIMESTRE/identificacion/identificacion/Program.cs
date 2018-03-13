using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace identificacion
{
    class Program
    {
        static Dictionary<string, string> diccionario = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            string ruta = @"c:\basura\claves.dat";

            //Comprobar que existe en la ruta
            if (!File.Exists(ruta))
            {
                Console.WriteLine("El fichero no existe en la ruta");
                Console.ReadLine();
                return;
            }

            //Primero separaré por ; y luego por espacio.
            string contenidoFichero = File.ReadAllText(ruta, Encoding.Default);
            char[] separadores1 = { ';' };
            char[] separadores2 = { ' ' };
            string[] contenido1 = contenidoFichero.Split(separadores1);
            string contenido2 = "";
            for (int i = 0; i < contenido1.Length; i++)
            {
                contenido2 += contenido1[i] + " ";
            }

            string[] contenidoFinal = contenido2.Split(separadores2, StringSplitOptions.RemoveEmptyEntries); //Ya está todo separado

            //Ahora lo meto en un diccionario
            for (int i = 0; i < contenidoFinal.Length; i++)
            {
                try
                {
                    diccionario.Add(contenidoFinal[i], contenidoFinal[++i]);
                }
                catch //Si hay usuarios repetidos, solo es válido el primero. Los usuarios tienen que ser únicos. Entrará por el catch y no se añadirán 
                {
                }
            }

            //Y ahora procedemos al login
            Login();

        }

        static public void Login()
        {
            string usuario;
            string clave;
            int contador = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("\n\n");
                Console.CursorLeft = 10;
                Console.WriteLine("IDENTIFICACION");
                Console.CursorLeft = 9;
                Console.WriteLine("==============================");
                Console.WriteLine();                
                Console.CursorLeft = 10;
                Console.Write("Usuario: ");
                usuario = Console.ReadLine();
                Console.CursorLeft = 10;
                Console.WriteLine();
                Console.CursorLeft = 10;
                Console.Write("  Clave: ");
                clave = Console.ReadLine();

                if (diccionario.ContainsKey(usuario) && diccionario[usuario] == clave)
                {
                    Console.Clear();
                    Console.SetCursorPosition(10, 6);
                    Console.WriteLine("B I E N V E N I D O ");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.CursorLeft = 10;
                    Console.Write("Pulsa una tecla para salir ...");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.Clear();
                    ++contador;
                    if (contador <= 2)
                    {
                        Console.SetCursorPosition(10, 10);
                        Console.WriteLine("Intento de Acceso Fallido... Le quedan {0} intentos", 3 - contador);
                    }
                    if (contador > 2)
                    {
                        Console.SetCursorPosition(10, 10);
                        Console.WriteLine("Ya no le quedan intentos... ");
                    }
                    Console.ReadKey();
                }
            } while (contador < 3); //Empieza en 0 asi que 0, 1 y 2 serán los 3 intentos.
        }

    }
}
