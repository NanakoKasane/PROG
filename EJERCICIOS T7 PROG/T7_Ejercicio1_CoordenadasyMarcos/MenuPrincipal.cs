using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7POO_Ejercicio1_CoordenadasyMarcos
{
    /// <summary>
    /// Clase para gestionar un menú
    /// </summary>
    public class MenuPrincipal
    {
        int coordenadaX;
        int coordenadaY;
        public int largoMenu = 11;

        //Método sobrecargados para mostrar menú en las posiciones (coordenadas) que le pases
        // y pasándole también array de string con las opciones para mostrar el menú
        /// <summary>
        /// Método que Muestra el menú en las coordenadas pasadas 
        /// </summary>
        /// <param name="coordenadaX">coordenada X en la que se muestra el menú</param>
        /// <param name="coordenadaY">coordenada Y en la que se muestra el menú</param>
        /// <param name="opciones">array de string con las opciones del menú</param>
        public void MostrarMenu(int coordenadaX, int coordenadaY, string[] opciones)
        {
            Console.SetCursorPosition(coordenadaX, coordenadaY); // left = coordenadaX

            Console.WriteLine("=".PadLeft(10, '='));
            Console.SetCursorPosition(coordenadaX, coordenadaY++);
            Console.WriteLine();
            Console.SetCursorPosition(coordenadaX, coordenadaY++);
            Console.WriteLine("MENU");
            Console.SetCursorPosition(coordenadaX, coordenadaY++);
            Console.WriteLine("=".PadLeft(10, '='));
            Console.SetCursorPosition(coordenadaX, coordenadaY++);
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.WriteLine(opciones[i]);
                Console.SetCursorPosition(coordenadaX, coordenadaY++);
            }
        }
        /// <summary>
        /// Método sobrecargado para Mostrar el menú (añadiendo el color de fondo)
        /// </summary>
        /// <param name="coordenadaX">coordenada X en la que se muestra el menú</param>
        /// <param name="coordenadaY">coordenada Y en la que se muestra el menú</param>
        /// <param name="opciones">array de string con las opciones del menú</param>
        /// <param name="color">color de fondo</param>
        public void MostrarMenu(int coordenadaX, int coordenadaY, string[] opciones, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            MostrarMenu(coordenadaX, coordenadaY, opciones);
            Console.Clear();
        }
    }
}
