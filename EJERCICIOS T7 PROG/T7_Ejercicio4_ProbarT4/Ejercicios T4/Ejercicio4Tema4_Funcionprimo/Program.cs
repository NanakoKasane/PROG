using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Ejercicio3Tema4_Esprimo
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroPrimo = 1;
			bool error = true; 

			do
			{

				try
				{
					do {
						error = false;
						Console.Clear();
						Console.Write("Dime un número y te diré si es primo o no, hasta que introduzcas 0: ");
						numeroPrimo = int.Parse(Console.ReadLine());
						Console.WriteLine("\nEl numero {0} {1} es primo", numeroPrimo, NumerosPrimos(numeroPrimo) ? "sí" : "no");
						Console.ReadLine();

					} while (numeroPrimo != 0) ;
				}

				catch
				{
					error = true; 
					Console.WriteLine("Error no controlado");
				}
			} while (error);


			}


        static bool NumerosPrimos(int numero)
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
    }
}
