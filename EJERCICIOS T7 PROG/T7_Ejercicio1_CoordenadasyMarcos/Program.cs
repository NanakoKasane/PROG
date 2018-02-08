using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7POO_Ejercicio1_CoordenadasyMarcos
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Probar MENÚ
            //PROBAR EL MENU:
            MenuPrincipalColor menu = new MenuPrincipalColor();
            string[] opciones = { "Opcion 1", "Opcion 2" };
            menu.MostrarMenu(10,5, opciones, ConsoleColor.Blue, ConsoleColor.White); //Para probar el método MostrarMenu
            //Console.ReadLine();
            #endregion 


            #region Probar MARCO
            //PROBAR EL MARCO:
            #region Declaración de variables
            int x1 = 0;
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;
            int anchoMax = Console.LargestWindowWidth;
            int altoMax = Console.LargestWindowHeight;

            int ancho = x2 - x1;
            int alto = y2 - y1;

            bool correcto = false;
            #endregion

            #region Pedir datos, control de errores y que no se salga de la pantalla
            Console.Write("Se dibujará un marco según las coordenadas iniciales y finales que introduzcas");
            Console.ReadLine();

            do
            {
                Console.Clear();
                correcto = true;

                try
                {
                    correcto = true;
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

            #endregion

            #region LLamada al método que pinta el marco
            Console.Clear();
            Marcos marco = new Marcos();
            marco.DibujarMarcoColor(x1, y1, x2, y2, ConsoleColor.Magenta);

            Console.ReadLine();
            #endregion 

            #endregion

        }
    }
}
