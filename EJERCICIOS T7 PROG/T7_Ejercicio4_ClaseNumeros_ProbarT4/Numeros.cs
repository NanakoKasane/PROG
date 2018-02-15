using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio4_ClaseNumeros
{
    class Numeros
    {
        //Métodos:

        #region EsPrimo
        public bool NumeroEsPrimo(int numero)
        {
            int numeroDividir = 2;

			if (numero == 0 || numero == 1) //caso especial, 0 y 1 no es primo
				return false;

            while (numero > numeroDividir)
            {
                if (numero % numeroDividir == 0)
                    return false;

                numeroDividir++;
            }
            return true;
        }
        #endregion 

        #region Factorial Recursivo e Iterativo
        public double FactorialRecursivo(int numero)
        {
            if (numero == 0)
                return 1;
            return numero * FactorialRecursivo(numero - 1);
        }
        public double FactorialIterativo(int numero)
        {
            double resultado = 1;

            for (int i = 1; i <= numero; i++)
                resultado *= i; 
            return resultado;
        }
        #endregion 

        #region Suma Primeros N números Recursivo e Iterativo

        public int SumaPrimerosNnumerosR(int numero)
		{
			if (numero == 0)
				return 0;
			if (numero == 1)
				return 1;
			else return numero + (SumaPrimerosNnumerosR(numero -1));
		}

		public int SumaPrimerosNnumerosI(int numero)
		{
			int resultadoTotal = 0;
			for (int i = 1; i <= numero; i++)
			{
				resultadoTotal += i; 
			}
			return resultadoTotal;
        }       
        #endregion 

        #region Fibonacci Recursivo e Iterativo
        public int FibonacciRecursivo(int numeroMeses)
        {
            if (numeroMeses == 0)
                return 1; // sería return 1 si contamos que el primer mes ya hay una pareja de adultos (todo lo demás sería igual)

            if (numeroMeses == 1)
                return 1;

            else
                return (FibonacciRecursivo(numeroMeses - 1) + FibonacciRecursivo(numeroMeses - 2));
        }

        public int FibonacciIterativo(int numeroMeses)
        {
            int[] array = new int[3]; //Tendrá 3 posiciones, la primera es la del (nMeses -1) y la segunda (nMeses -2). La tercera será el resultado de sumar estas 2 posiciones
            array[0] = 1; //Primer mes es 1 en la primera iteración
            array[1] = 1; //Segundo mes es 1 en la primera iteración

            if (numeroMeses == 0)
                return 1;
            if (numeroMeses == 1)
                return 1;

            for (int i = 2; i < numeroMeses + 1; i++) //Desde el mes 2 al número de meses
            {
                array[2] = array[1] + array[0]; //Es como el Recursivo, llama a (mes -1) + (mes -2) --> Que está guardado en las 2 primeras posiciones del array
                
                //Y por cada iteración del bucle, guardas nuevos valores en el array de 3 posiciones. Los valores anteriores calculados, siempre dejando la última posición para el resultado 
                array[0] = array[1];
                array[1] = array[2];
            }
            return array[2];
        }
        #endregion 

    }
}
