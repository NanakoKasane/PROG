using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7POO_Ejercicio1_CoordenadasyMarcos
{
    /// <summary>
    /// Clase heredada de MenuPrincipal para cambiar el color del menú
    /// </summary>
    public class MenuPrincipalColor : MenuPrincipal
    {
        //Campos
        int coordenadaX;
        int coordenadaY;
        ConsoleColor color;

        //Propiedades
        public ConsoleColor Color
        {
            get
            {
                return Color;
            }

            set
            {
                for (ConsoleColor i = ConsoleColor.Black; i <= ConsoleColor.Yellow; i++)
                {
                    if (value == i)
                        Color = value;
                }
                //Si el color que le has metido no coincide con ninguno del sistema, se elegirá el negro
                Color = ConsoleColor.Black;
            }
        }
        /// <summary>
        /// Método para Mostrar el menú con un color de fondo y de letra 
        /// </summary>
        /// <param name="coordenadaX">coordenada X en la que se muestra el menú</param>
        /// <param name="coordenadaY">coordenada Y en la que se muestra el menú</param>
        /// <param name="opciones">array de string con las opciones del menú</param>
        /// <param name="colorFondo">color de fondo</param>
        /// <param name="colorLetras">color de la letra</param>
        public void MostrarMenu(int coordenadaX, int coordenadaY, string[] opciones, ConsoleColor colorFondo, ConsoleColor colorLetras)
        {
            Console.BackgroundColor = colorFondo;
            //Console.Clear();
            Console.ForegroundColor = colorLetras;
            base.MostrarMenu(coordenadaX, coordenadaY, opciones);

            Console.ReadLine(); //Para que se pare
            Console.ResetColor();
            Console.Clear();
        }
    }

}
