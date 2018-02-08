/*
 * AUTOR: Marina Espinosa Gálvez
 * FECHA: 10-11-2017
 * VERSIÓN: 1.0
 * DESCRIPCIÓN: Suma de los primeros N números
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio14Tema4_SumaPrimerosNnumeros
{
	class Program
	{
		static void Main(string[] args)
		{
			//Declarar parámetro
			int nParametro = args.Length;




			//Controlar error y resultado
			try
			{
				nParametro = int.Parse(args[0]);

				if (args.Length == 0)
				{
					Console.WriteLine("No hay ningún parámetro a mostrar");
					Console.ReadLine();

					return;
				}

				if (args.Length > 1)
				{
					Console.WriteLine("Demasiados parámetros");
					return;
				}

				if (args.Length == 1)
				{
					Console.WriteLine("La suma de los primeros {0} números, es: {1}", nParametro, SumaPrimerosNnumerosR(nParametro));
					Console.WriteLine("La suma de los primeros {0} números (Iterativa), es: {1}", nParametro, SumaPrimerosNnumerosI(nParametro));

				}


			}

			catch
			{
			}



			Console.ReadLine();
		}




		static int SumaPrimerosNnumerosR(int nParametrointroducido)
		{
			// 1+2+3+...+N
			if (nParametrointroducido == 0)
				return 0;
			if (nParametrointroducido == 1)
				return 1;


			else return nParametrointroducido + (SumaPrimerosNnumerosR(nParametrointroducido -1));


		}

		static int SumaPrimerosNnumerosI(int nParametrointroducido)
		{

			int resultadoTotal = 0;
			for (int i = 1; i <= nParametrointroducido; i++)
			{
				resultadoTotal += i; // resultadoTotal = resultadoTotal + i 
			}
			return resultadoTotal;


			/* int numero = 0;
			int contador = 1;

			while (numero <= nParametrointroducido)
			{
				numero = contador + numero;
				contador++;
			}
			return numero; 
			 */
			


		}
	}
}
