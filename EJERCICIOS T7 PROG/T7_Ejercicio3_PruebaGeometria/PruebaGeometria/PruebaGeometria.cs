using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------------------------
using Geometria;
using T7POO_Ejercicio1_CoordenadasyMarcos;

namespace PruebaGeometria
{
	class PruebaGeometria
	{
		static void Main(string[] args)
		{
			#region Declaración de variables (que algunas se pedirían al usuario)
			const int lado = 10; //Para probar. Se pedirá luego el lado al usuario. Controlar que no sea negativo.
			Punto vertice1 = new Punto(10, 20); //el 10 y 20 son para probar (coordenadas X e Y), esos valores se pedirían al usuario.
			//Al pedir los datos tendrá que controlar que las coordenadas NO fueran NEGATIVAS, ni el lado tampoco. Todo lo demás válido.

			Punto vertice2 = new Punto(10, 20); 
			Punto vertice3 = new Punto(vertice1.CoordenadaX, 30); //Lo mismo que arriba, se pedirían al usuario los valores, estos datos son para probarlo.
			//Aquí tendría que controlar, a parte de que NO sea NEGATIVAS las coordenadas, que su coordenada Y sea MAYOR que la del vértice 1
			//Es decir, por ejemplo --> if (vertice1.coordenadaY >= vertice3.coordenada Y) { throw new Exception(); }

			Marcos dibujarCuadrado = new Marcos();
			#endregion 


			#region Prueba del cuadrado a partir del primer vértice y el lado
			Console.WriteLine("=".PadRight(50, '='));
			Console.WriteLine("CUADRADO A PARTIR DEL PRIMER VÉRTICE Y EL LADO");
			Console.WriteLine("=".PadRight(50, '='));
			Cuadrado cuadrado1 = new Cuadrado(vertice1, lado);
			Console.WriteLine("Vértice 1 -> (" + vertice1.CoordenadaX + ", " + vertice1.CoordenadaY + ")");
			Console.WriteLine("Lado -> " + cuadrado1.Lado); 
			Console.WriteLine("\nPerímetro del Cuadrado: " + cuadrado1.Perimetro);
			Console.WriteLine("Área del Cuadrado: " + cuadrado1.Area);
			Console.ReadLine();
			Console.Clear();

			//Las Coordenadas X las multiplico por 2 para que se vea como un cuadrado, ya que en C# los saltos de línea (Y) son el doble de grandes
			//que los espacios (X). Así que para que se vea realmente como un cuadado, tendrá que multiplicarse por 2 las X o dividir por 2 las Y
			dibujarCuadrado.DibujarMarco(vertice1.CoordenadaX*2, vertice1.CoordenadaY, cuadrado1.Vertice4.CoordenadaX*2, cuadrado1.Vertice4.CoordenadaY);			
			
			Console.ReadLine();
			Console.Clear();
			#endregion 


			#region Prueba del cuadrado a partir del primer y tercer vértice 
			Console.WriteLine("=".PadRight(50, '='));
			Console.WriteLine("CUADRADO A PARTIR DEL PRIMER Y TERCER VÉRTICE");
			Console.WriteLine("=".PadRight(50, '='));
			
			Cuadrado cuadrado2 = new Cuadrado(vertice1, vertice3); 
			cuadrado2.Lado = vertice3.CoordenadaX - vertice1.CoordenadaX;
			Console.WriteLine("Perímetro del Cuadrado: " + lado * 4); //cuadrado2.Perimetro
			Console.WriteLine("Área del Cuadrado: " + lado * lado); //cuadrado2.Area
			Console.WriteLine("Lado del Cuadrado: " + lado);
				

			Console.ReadLine();
			Console.Clear();
			dibujarCuadrado.DibujarMarco(vertice1.CoordenadaX * 2, vertice1.CoordenadaY, (cuadrado2.Vertice3.CoordenadaX + lado)* 2, cuadrado2.Vertice3.CoordenadaY);			
			
			#endregion 


			//Cosas que controlar -> Tiene que ser cuadrado, todos los lados iguales. 

			Console.ReadLine();
		}
	}
}
