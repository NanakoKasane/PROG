using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T7POO_Ejercicio1_CoordenadasyMarcos;

namespace prueba2
{
    class Program
    {
        #region Declaración de variables
        static public int x1 = 0;
        static public int x2 = 0;
        static public int y1 = 0;
        static public int y2 = 0;
        static public int anchoMax = Console.LargestWindowWidth;
        static public int altoMax = Console.LargestWindowHeight;
        static public bool correcto = false;
        #endregion


        static void Main(string[] args)
        {
            PedirDatos();

            #region Probar MENU dentro del MARCO
            //PROBAR EL MENU DENTRO DEL MARCO:
            Console.Clear();
            Console.CursorVisible = false;
            Marcos marco = new Marcos();
            marco.DibujarMarcoColor(x1, y1, x2, y2, ConsoleColor.Magenta);
            Console.ResetColor();
            Console.WriteLine("\n\nPulse una tecla para finalizar...");

            //Poner el menú dentro del marco:
            MenuPrincipalColor menu = new MenuPrincipalColor();
            string[] opciones = { "Opcion 1", "Opcion 2" };
            int largoMenu = 11;
            int posicionX = ((x1 + x2) / 2) - (largoMenu / 2) + 1;
            int posicionY = y1 + 2;
            if (opciones[0].Length < x2 - x1 && opciones[1].Length < x2 - x1 && largoMenu < x2 - x1) //No cabría escribirlo si no
            {
                Console.SetCursorPosition(posicionX, posicionY);
                menu.MostrarMenu(posicionX, posicionY, opciones);
            }

            Console.ReadKey();

            ////Poner "MENU" dentro del marco CENTRADO:
            //string tituloMenu = "MENU";
            //if (tituloMenu.Length < x2 - x1) //No cabría escribirlo si no
            //{
            //    Console.SetCursorPosition(((x1 + x2) / 2) - (tituloMenu.Length / 2) + 1, y1 + 2);
            //    Console.Write(tituloMenu);
            //}

            #endregion 

        }

        #region Método para pedir datos
        /// <summary>
        /// Método para pedir datos, control de errores y que no se salga de la pantalla
        /// </summary>
        static void PedirDatos()
        {
            
            Console.WriteLine("A continuación se dibujará un MARCO según las coordenadas iniciales" +
               " \ny finales que introduzcas, y si cabe, se dibujará el MENU dentro del marco");
            Console.Write("\nPulse una tecla para continuar...");
            Console.ReadKey();

            do
            {
                Console.Clear();
                correcto = true;

                try
                {
                    correcto = true;
                    Console.WriteLine("".PadLeft(20, '='));
                    Console.WriteLine("DIBUJO DE MARCO");
                    Console.WriteLine("".PadLeft(20, '=') + "\n");

                    Console.Write("Introduzca la primera coordenada X: ");
                    x1 = int.Parse(Console.ReadLine());

                    Console.Write("Introduzca la primera coordenada Y: ");
                    y1 = int.Parse(Console.ReadLine());

                    Console.Write("Introduzca la última coordenada X: ");
                    x2 = int.Parse(Console.ReadLine());

                    Console.Write("Introduzca la última coordenada y: ");
                    y2 = int.Parse(Console.ReadLine());
                }
                catch
                {
                    correcto = false;
                }
                //Aquí iba lo de controlar que no se salga de la pantalla, pero al final decidí
                //que si se sale, dibujar el marco del tamano máximo posible en vez de lo siguiente:
                if (x2 >= anchoMax || y2 >= altoMax)
                    correcto = false;

                if (x1 >= x2 || y1 >= y2) // La segunda coordenada tiene que ser mayor a la primera o no hay marco xD
                    correcto = false;

            } while (!correcto);

        }
        #endregion

    }
}
