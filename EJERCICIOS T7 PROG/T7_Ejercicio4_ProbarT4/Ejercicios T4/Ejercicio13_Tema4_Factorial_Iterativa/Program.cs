/*
 * AUTOR: Marina Espinosa Gálvez
 * FECHA: 10-11-2017
 * VERSIÓN: 1.0
 * DESCRIPCIÓN: Función (método) Factorial Iterativo
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio13_Tema4_Factorial_Iterativa
{
	class Program
	{
		static void Main(string[] args)
		{

			//Declaración de variables
			int numero = 0;
			bool error = true;

			//Información del programa
			Console.WriteLine("FACTORIAL DE UN NÚMERO");
			Console.WriteLine("----------------------");

			//Control de error y pedir dato
			do
			{
				try
				{
					error = false;
					Console.Write("\nDime un número: ");
					numero = int.Parse(Console.ReadLine());
					if (numero < 0)
						Console.WriteLine("\nEl número tiene que ser positivo");
				}
				catch
				{
					error = true;
				}
			} while (numero < 0 || error);

			//Resultado

			Console.WriteLine("\nEl factorial de {0} es: {1}", numero, FactorialI(numero));


			Console.ReadLine();
		}



		static double FactorialI(int numero)
		{
			double resultado = 1;

			for (int i = 1; i <= numero; i++)
				resultado *= i; //resultado = resultado * i
			return resultado;

		}
	}
}
