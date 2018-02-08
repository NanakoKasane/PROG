/*
 * AUTOR: Marina Espinosa Gálvez
 * FECHA: 11-11-2017
 * VERSIÓN: 1.0
 * DESCRIPCIÓN: Función recursiva que calcula el número de Fibonacci
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19tema4_Fibonacci
{
	class Program
	{
		static void Main(string[] args)
		{
			//Declaración de variables
			int numeroMeses = 0;
			bool error = true;
			const int MAXIMO = 35;

			//Información del programa
			Console.WriteLine("NÚMERO DE FIBONACCI");
			Console.WriteLine("===================");

			//Control de error y pedir datos
			do
			{
				try
				{
					error = false;
					Console.Write("\nDime el número de meses que pasan y te diré cuántas parejas de conejos adultos hay (el máximo es 35): ");
					numeroMeses = int.Parse(Console.ReadLine());
				}
				catch
				{
					error = true;
				}
			} while (error || numeroMeses<0 || numeroMeses>MAXIMO);

			//Resultado
			Console.WriteLine("\nEl número de conejos que habrá en {0} meses será de: {1}", numeroMeses, Fibonacci(numeroMeses));


			Console.ReadLine();
		}

		/// <summary>
		/// Método para calcular el número de Fibonacci
		/// </summary>
		/// <param name="numeroMeses"></param>
		/// <returns></returns>
		static int Fibonacci(int numeroMeses)
		{
			if (numeroMeses == 0)
				return 0; // sería return 1 si contamos que el primer mes ya hay una pareja de adultos (todo lo demás sería igual)

			if (numeroMeses == 1)
				return 1;

			else
				return (Fibonacci(numeroMeses - 1) + Fibonacci(numeroMeses -2));

		}


	}
}
