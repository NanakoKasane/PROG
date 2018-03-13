using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Contar
{
    class Program
    {
        static void Main(string[] args)
        {
            BuscarPintarPalabra(args);

        }

        public static void BuscarPintarPalabra(string[] args)
        {
            string lineas = "";

            if (args.Length >= 2)
            {
                if (!File.Exists(args[0]))
                {
                    Console.WriteLine("El fichero no existe, compruebe la ruta pasada");
                    Console.ReadLine();
                    return;
                }

                //Máximo 5 palabras. Ignoraremos los args a partir de args.Length == 7, es decir, desde args[6] ese ya no vale y se ignora

                using (FileStream flujo = new FileStream(args[0], FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(flujo))
                    {

                        while (!sr.EndOfStream)
                        {
                            lineas = sr.ReadLine();

                            if (args.Length == 2 && lineas.ToUpper().Contains(args[1].ToUpper()))
                            {
                                int posicion = lineas.ToUpper().IndexOf(args[1].ToUpper());

                                for (int i = 0; i < lineas.Length; i++)
                                {
                                    if (i >= posicion && i < posicion + args[1].Length)
                                    {
                                        //Lo escribe rojo
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(lineas[i]);
                                        Console.ResetColor();
                                    }
                                    if (i < posicion || i >= posicion + args[1].Length)
                                        Console.Write(lineas[i]);
                                }
                                Console.WriteLine();

                            }


                                if (args.Length == 3 && lineas.ToUpper().Contains(args[1].ToUpper() + " " + args[2].ToUpper()))
                                {
                                    int posicion = lineas.ToUpper().IndexOf(args[1].ToUpper() + " " + args[2].ToUpper());

                                    for (int i = 0; i < lineas.Length; i++)
                                    {
                                        if (i >= posicion && i < posicion + args[1].Length + args[2].Length + 1) // +1 por el espacio
                                        {
                                            //Lo escribe rojo
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write(lineas[i]);
                                            Console.ResetColor();
                                        }
                                        if (i < posicion || i >= posicion + args[1].Length + args[2].Length + 1)
                                            Console.Write(lineas[i]);
                                    }
                                    Console.WriteLine();

                                }

                                if (args.Length == 4 && lineas.ToUpper().Contains(args[1].ToUpper() + " " + args[2].ToUpper() + " " + args[3].ToUpper()))
                                {
                                    int posicion = lineas.ToUpper().IndexOf(args[1].ToUpper() + " " + args[2].ToUpper() + " " + args[3].ToUpper());

                                    for (int i = 0; i < lineas.Length; i++)
                                    {
                                        if (i >= posicion && i < posicion + args[1].Length + args[2].Length + args[3].Length + 2) // +2 por los espacio
                                        {
                                            //Lo escribe rojo
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write(lineas[i]);
                                            Console.ResetColor();
                                        }
                                        if (i < posicion || i >= posicion + args[1].Length + args[2].Length + args[3].Length + 2)
                                            Console.Write(lineas[i]);
                                    }
                                    Console.WriteLine();
                                }

                                if (args.Length == 5 && lineas.ToUpper().Contains(args[1].ToUpper() + " " + args[2].ToUpper() + " " + args[3].ToUpper() + " " + args[4].ToUpper()))
                                {
                                    int posicion = lineas.ToUpper().IndexOf(args[1].ToUpper() + " " + args[2].ToUpper() + " " + args[3].ToUpper() + " " + args[4].ToUpper());

                                    for (int i = 0; i < lineas.Length; i++)
                                    {
                                        if (i >= posicion && i < posicion + args[1].Length + args[2].Length + args[3].Length + args[4].Length + 3) // +3 por los espacios
                                        {
                                            //Lo escribe rojo
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write(lineas[i]);
                                            Console.ResetColor();
                                        }
                                        if (i < posicion || i >= posicion + args[1].Length + args[2].Length + args[3].Length + args[4].Length + 3)
                                            Console.Write(lineas[i]);
                                    }
                                    Console.WriteLine();

                                }

                                //A partir de ahí los ignora (las siguientes palabras). No más de 5.
                                if (args.Length >= 6 && lineas.ToUpper().Contains(args[1].ToUpper() + " " + args[2].ToUpper() + " " + args[3].ToUpper() + " " + args[4].ToUpper() + " " + args[5].ToUpper()))
                                {
                                    int posicion = lineas.ToUpper().IndexOf(args[1].ToUpper() + " " + args[2].ToUpper() + " " + args[3].ToUpper() + " " + args[4].ToUpper() + " " + args[5].ToUpper());

                                    for (int i = 0; i < lineas.Length; i++)
                                    {
                                        if (i >= posicion && i < posicion + args[1].Length + args[2].Length + args[3].Length + args[4].Length + args[5].Length + 4) // +4 por los espacios
                                        {
                                            //Lo escribe rojo
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write(lineas[i]);
                                            Console.ResetColor();
                                        }
                                        if (i < posicion || i >= posicion + args[1].Length + args[2].Length + args[3].Length + args[4].Length + args[5].Length + 4)
                                            Console.Write(lineas[i]);
                                    }
                                    Console.WriteLine();

                                }
                            }

                        }

                    }


                }

                if (args.Length < 2)
                {
                    Console.WriteLine("Debe introducir al menos 2 argumentos-> Ruta (Palabra/palabras a buscar en el fichero de la ruta)");
                    Console.ReadLine();
                    return;
                }

                Console.ReadLine();

              
            }


        }
    }

