using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Geometria
{
    public class Punto
    {
        //Campos
        int coordenadaX;
        int coordenadaY;

        //Propiedades de solo lectura
        public int CoordenadaY
        {
            get { return coordenadaY; }
        }
        public int CoordenadaX
        {
            get { return coordenadaX; }
        }

		//Constructor
		public Punto(int coordenadaX, int coordenadaY)
		{
			this.coordenadaX = coordenadaX;
			this.coordenadaY = coordenadaY;
		}

    }

    public class Cuadrado
    {
        //Campos
        Punto vertice1;
        Punto vertice2;
        Punto vertice3;
        Punto vertice4;
        //
		//double area;
		//int perimetro;
		//int lado;

        //Propiedades de solo lectura:
        public Punto Vertice1
        {
            get { return vertice1; }
        }
        public Punto Vertice2
        {
            get { return vertice2; }
        }
        public Punto Vertice3
        {
            get { return vertice3; }
        }
        public Punto Vertice4
        {
            get { return vertice4; }
        }

        //Area
        public double Area
        {
            get { return lado * lado; } 
        }

        //Perimetro
        public int Perimetro
        {
            get { return lado * 4; } // 4 es el número de lados del cuadrado. Todos tienen el mismo lado.
        }

        //Propiedad de lectura-escritura
        //Lado
		private int lado; //CAMPO DE LADO
        public int Lado
        {
            get { return lado; }
            set
            {
				//Casos que hay que controlar: Que no llegue al máximo, que no sea negativo y que el vérice 2 no sea menor que el 1.
				if (value < Console.LargestWindowWidth && value < Console.LargestWindowHeight || value < 0 || vertice2.CoordenadaX < vertice1.CoordenadaX)
					value = lado; //Si llega al máximo o es negativo, no coge como lado el valor que le introduzcas.

				else
					lado = value; 
            }
        }
       
		#region Constructores
		/// <summary>
		/// Constructor para crear un cuadrado a partir del primer y tercer vértice
		/// </summary>
		/// <param name="vertice1">Vértice superior izquierdo del cuadrado</param>
		/// <param name="vertice3">Vértice inferior izquierdo del cuadrado</param>
		public Cuadrado(Punto vertice1, Punto vertice3) //Siendo vertice1 el vértice superior izquierdo y vertice 3 el vértice inferior izquierdo
		{			
			this.vertice1 = vertice1;
			this.vertice3 = vertice3;			
			this.lado = vertice3.CoordenadaX - vertice1.CoordenadaX; //Ya que en un cuadrado todos los lados son iguales lo puedo calcular con estos 2 vértices 
			this.vertice2 = new Punto(vertice1.CoordenadaX + lado, vertice1.CoordenadaY); //Saco el vértice2 a partir del vértice1 y el Lado
			this.vertice4 = new Punto(vertice3.CoordenadaX + lado, vertice3.CoordenadaY); //Saco el vértice4 a partir del vértice3 y el Lado
		}

		/// <summary>
		/// Constructor para crear un cuadrado a partir del primer vértice y el lado
		/// </summary>
		/// <param name="vertice1">Primer vértice del cuadrado (vértice superior izquierdo)</param>
		/// <param name="Lado">Lado del cuadrado</param>
		public Cuadrado(Punto vertice1, int lado)
		{
			this.vertice1 = vertice1;
			this.vertice2 = new Punto(vertice1.CoordenadaX + lado, vertice1.CoordenadaY);
			this.vertice3 = new Punto(vertice1.CoordenadaX, vertice1.CoordenadaY + lado);
			this.vertice4 = new Punto(vertice3.CoordenadaX + lado, vertice3.CoordenadaY);
			this.lado = lado;
		}
		#endregion 


	}
}
