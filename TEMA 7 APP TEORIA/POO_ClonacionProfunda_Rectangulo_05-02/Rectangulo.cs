using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------
using System.Collections;

namespace POO_ClonacionProfunda_05_02
{
    class Rectangulo : ICloneable
    {
        #region Campos
        //Campos
        ConsoleColor color; //color de relleno del rectángulo
        char textura;
        public Punto[] puntos;
        #endregion 

        #region Constructores
        //Constructores
        public Rectangulo()
        {
            puntos = new Punto[4]; //4 puntos
            textura = ' ';
            this.color = ConsoleColor.Red;
        }

        public Rectangulo(Punto p1, Punto p3)
        {
            Punto p2 = new Punto(p3.x, p1.x);
            Punto p4 = new Punto(p1.x, p3.y);
            puntos = new Punto[4]{p1, p2, p3, p4};
            textura = '.';
            this.color = ConsoleColor.Red;
        }
        #endregion 

        #region Métodos
        /// <summary>
        /// Método que escribe los puntos del Recángulo
        /// </summary>
        public void Informacion()
        {
            Console.WriteLine("p1: {0},\t p2: {1},\t p3: {2},\t p4: {3}", puntos[0], puntos[1], puntos[2], puntos[3]);
            //No hace falta poner .ToString() pero porque está reescrito

            Console.WriteLine("Color: {0},\t\t Textura: {1}", color, textura);
        }

        public void Dibuja()
        {
            char caracter = textura;
            ConsoleColor colorEntrada = Console.BackgroundColor;
            Console.BackgroundColor = color;

            int x1 = puntos[0].x; //Punto 1
            int y1 = puntos[0].y; //Punto 1
            int x3 = puntos[2].x; //Punto 3
            int y3 = puntos[2].y; //Punto 3
            for (int i = x1; i <= x3; i++)
            {
                for (int j = y1; j <= y3; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(caracter);
                }
            }
            Console.BackgroundColor = colorEntrada; //Como -> Console.ResetColor();

        }
        #endregion 



        //ICloneable
        public object Clone()
        {
            Rectangulo copia = new Rectangulo();

            //Copia profunda, no se puede hacer con Memberwise, sino a mano:
            copia.textura = this.textura;
            copia.color = this.color;

            //Copiar el array puntos
            for (int i = 0; i < puntos.Length; i++)
            {
                copia.puntos[i] = this.puntos[i];
            }
            return copia;
        }
        


        //Criterio de comparación de la clase (Comparar 2 rectángulos)
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            return this.puntos[0].SonIguales(((Rectangulo)obj).puntos[0]) && this.puntos[2].SonIguales(((Rectangulo)obj).puntos[2]);
            //Son iguales si el punto 1 y 3 son iguales
        }
    }
}
