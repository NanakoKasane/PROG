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

        #region Fibonacci
        public int Fibonacci(int numeroMeses)
        {
            if (numeroMeses == 0)
                return 0; // sería return 1 si contamos que el primer mes ya hay una pareja de adultos (todo lo demás sería igual)

            if (numeroMeses == 1)
                return 1;

            else
                return (Fibonacci(numeroMeses - 1) + Fibonacci(numeroMeses - 2));
        }
        #endregion 

    }
}
