using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEntradas
{
    class Program
    {
        static void Main(string[] args)
        {
            Entrada popular = new Entrada("popular", 20, 5);
            Entrada general = new Entrada("general", 10, 10);
            Entrada VIP = new Entrada("VIP", 5, 20);
            ConsoleKeyInfo opcion;

            Menu(popular, general, VIP);

        }

        static public void Menu(Entrada popular, Entrada general, Entrada VIP)
        {
            ConsoleKeyInfo opcion;
            int opcionEntrada = 0;
            bool error = false;

            do
            {
                error = false;
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("==============\n");
                Console.WriteLine("A. Entradas libres y vendidas de cada tipo");
                Console.WriteLine("B. Comprar entrada");
                Console.WriteLine("C. Cantidad recaudada por entrada\n");
                Console.WriteLine("0. Si pulsa cualquier otra opción se saldrá del programa\n\n");
                Console.Write("                    Opción: ");
                opcion = Console.ReadKey();

                if (opcion.Key != ConsoleKey.A && opcion.Key != ConsoleKey.B && opcion.Key != ConsoleKey.C && opcion.Key != ConsoleKey.D)
                    return;

                switch (opcion.KeyChar)
                {
                    case 'A': case 'a':
                        Console.Clear();
                        Console.WriteLine("Entrada popular -> {0} libres, {1} vendidas", popular.NPlazas - popular.Contador, popular.Contador);
                        Console.WriteLine("Entrada general -> {0} libres, {1} vendidas", general.NPlazas - general.Contador, general.Contador);
                        Console.WriteLine("Entrada VIP -> {0} libres, {1} vendidas", VIP.NPlazas - VIP.Contador, VIP.Contador);

                        Console.ReadLine();
                        Menu(popular, general, VIP);
                        break;

                    case 'B': case 'b':
                        do
                        {
                            error = false;
                            Console.Clear();
                            Console.WriteLine("1. Entrada popular");
                            Console.WriteLine("2. Entrada general");
                            Console.WriteLine("3. Entrada VIP\n");
                            Console.WriteLine("0. Salir. \n");
                            Console.Write("        Opción: ");
                            error = false;
                            try
                            {
                                opcionEntrada = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                error = true;
                            }

                            if (opcionEntrada < 0 || opcionEntrada > 3)
                                error = true;
                            if (opcionEntrada == 1)
                            {
                                if (popular.NPlazas > popular.Contador)
                                {
                                    ++popular.Contador;
                                    Console.Clear();
                                    Console.WriteLine("Has comprado una entrada popular");
                                    Console.WriteLine("Pulse una tecla para salir... ");
                                    Console.ReadKey(true);
                                }
                                else if (popular.NPlazas <= popular.Contador)
                                {
                                    Console.Clear();
                                    Console.WriteLine("NO QUEDAN ENTRADAS LIBRES DE ESTE TIPO");
                                    Console.WriteLine("Pulse una tecla para salir... ");
                                    Console.ReadKey(true);
                                }
                            }
                            if (opcionEntrada == 2)
                            {
                                if (general.NPlazas > general.Contador)
                                {
                                    ++general.Contador;
                                    Console.Clear();
                                    Console.WriteLine("Has comprado una entrada general");
                                    Console.WriteLine("Pulse una tecla para salir... ");
                                    Console.ReadKey(true);
                                }
                                else if (general.NPlazas <= general.Contador)
                                {
                                    Console.Clear();
                                    Console.WriteLine("NO QUEDAN ENTRADAS LIBRES DE ESTE TIPO");
                                    Console.WriteLine("Pulse una tecla para salir... ");
                                    Console.ReadKey(true);
                                }
                            }
                            if (opcionEntrada == 3)
                            {
                                if (VIP.NPlazas > VIP.Contador)
                                {
                                    ++VIP.Contador;
                                    Console.Clear();
                                    Console.WriteLine("Has comprado una entrada VIP");
                                    Console.WriteLine("Pulse una tecla para salir... ");
                                    Console.ReadKey(true);
                                }
                                else if (VIP.NPlazas <= VIP.Contador)
                                {
                                    Console.Clear();
                                    Console.WriteLine("NO QUEDAN ENTRADAS LIBRES DE ESTE TIPO");
                                    Console.WriteLine("Pulse una tecla para salir... ");
                                    Console.ReadKey(true);
                                }
                            }
                        } while (error);
                        Menu(popular, general, VIP);
                        break;

                    case 'C' : case 'c':
                        Console.Clear();
                        Console.WriteLine("Cantidad recaudada de Entrada Popular -> {0} euros", popular.Contador * popular.Precio);
                        Console.WriteLine("Cantidad recaudada de Entrada General -> {0} euros", general.Contador * general.Precio);
                        Console.WriteLine("Cantidad recaudada de Entrada VIP -> {0} euros", VIP.Contador * VIP.Precio);

                        Console.ReadLine();
                        Menu(popular, general, VIP);
                        break;

                    case '0': 
                        error = false;
                        break;
                }

            } while (error);




        }
    }
}
