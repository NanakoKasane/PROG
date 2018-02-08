using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7POO_Ejercicio1_CoordenadasyMarcos
{

    /// <summary>
    /// Clase para gestionar Marcos (Dibuja marcos de diferentes tipos)
    /// </summary>
    public class Marcos
    {
        //Método para dibujar Marco de trazo simple o doble de algunos colores y en las posiciones
        //indicadas por sus vértices 1 (sup-izq) y su vértice 3 (inf-dcho)

        //Método para dibujar el marco simple:
        /// <summary>
        /// Método que pinta un Marco de trazo simple en las coordenadas de inicio y de fin pasadas
        /// </summary>
        /// <param name="x1">Coordenada X en la que empieza el marco</param>
        /// <param name="y1">Coordenada Y en la que empieza el marco</param>
        /// <param name="x2">Coordenada X en la que acaba el marco</param>
        /// <param name="y2">Coordenada Y en la que acaba el marco</param>
        public void DibujarMarco(int x1, int y1, int x2, int y2)
        {
            #region Declaración de variables
            char esquinaSuperiorIzq = '┌'; // (char)218;
            char lineaHorizontal = '─'; // (char)196;
            char esquinaSuperiorDer = '┐'; // (char) 191;
            char lineaVertical = '│'; //179
            char esquinaInferiorIzq = '└'; //(char)192;
            char esquinaInferiorDerech = '┘'; //217;
            int ancho = x2 - x1;
            int alto = y2 - y1;
            #endregion 

            #region Primera linea horizontal
            Console.SetCursorPosition(x1, y1);
            Console.Write(esquinaSuperiorIzq);

            // x2 - x1 = ancho de la línea. y hay que restarle uno porque hay que poner la esquinaSuperiorDerecha
            //Primera línea horizontal:
            Console.Write(lineaHorizontal.ToString().PadLeft(ancho - 1, lineaHorizontal));

            Console.SetCursorPosition(x2, y1);
            Console.Write(esquinaSuperiorDer);
            #endregion 

            //Bucles para las líneas verticales:
            #region linea izquierda
            //Linea izquierda:
            for (int i = y1 + 1; i < y2; i++)
            {
                Console.SetCursorPosition(x1, i);
                Console.Write(lineaVertical);
            }
            Console.SetCursorPosition(x1, y2);
            Console.Write(esquinaInferiorIzq);
            #endregion

            #region linea derecha
            //Linea derecha:
            for (int i = y1 + 1; i < y2; i++)
            {
                Console.SetCursorPosition(x2, i);
                Console.Write(lineaVertical);
            }
            Console.SetCursorPosition(x2, y2);
            Console.Write(esquinaInferiorDerech);
            #endregion

            #region Última línea horizontal
            //Última línea horizontal:
            Console.SetCursorPosition(x1 + 1, y2); // x1 + 1 para que no lo pinte encima de la esquinaInferiorDerecha
            Console.Write(lineaHorizontal.ToString().PadLeft(ancho - 1, lineaHorizontal));
            #endregion


            //PROCEDIMIENTO seguido:
            //Primero ascii de la primera posicion (que es especial)
            //Luego un _.PadLeft(ancho?)
            //luego 1 o 2 for para las 2 lineas verticales 
            //Luego otro _.Pad...
            //Ascii de la ultima posicion 

        }

        //Intento de dibujar un Marco del alto y ancho máximos 
        public void DibujarMarcoAnchoAltoMax(int x1, int y1, int x2, int y2)
        {
            int anchoMax = Console.LargestWindowWidth; //170
            int altoMax = Console.LargestWindowHeight; //58

            int ancho = x2 - x1;
            int alto = y2 - y1;

            //De ancho máximo y alto si procede
            if (ancho >= anchoMax)
            {
                if (alto >= altoMax)
                    DibujarMarco(x1, y1, anchoMax - 1 - x1, altoMax - 1 - y1); // -> Se sale del rango -> X2 FALLA
                else
                    DibujarMarco(x1, y1, anchoMax - 1 - x1, y2);
            }

            //De alto máximo y ancho si procede
            if (alto >= altoMax)
            {
                if (ancho >= anchoMax)
                    DibujarMarco(x1, y1, anchoMax - 1 - x1, altoMax - 1 - y1);
                else
                    DibujarMarco(x1, y1, x2, altoMax - 1 - y1);
            }

            else
                DibujarMarco(x1, y1, x2, y2);
        }

        /// <summary>
        /// Método sobrecargado que dibuja el marco del color introducido
        /// </summary>
        /// <param name="x1">Coordenada X en la que empieza el marco</param>
        /// <param name="y1">Coordenada Y en la que empieza el marco</param>
        /// <param name="x2">Coordenada X en la que acaba el marco</param>
        /// <param name="y2">Coordenada Y en la que acaba el marco</param>
        /// <param name="color">color del marco</param>
        public void DibujarMarcoColor(int x1, int y1, int x2, int y2, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            DibujarMarco(x1, y1, x2, y2);
        }

        //Para un marco doble sería exactamente igual que el simple pero con los ASCII dobles 
        public void DibujarMarcoDoble(int vertice1X, int vertice1Y, int vertice3X, int vertice3Y) // ConsoleColor color) 
        {
            Console.SetCursorPosition(vertice1X, vertice1Y);
            //DIBUJAR MARCO

        }

    }
}
