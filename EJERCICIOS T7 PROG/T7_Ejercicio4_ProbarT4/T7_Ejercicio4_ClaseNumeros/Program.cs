using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio4_ClaseNumeros
{
    class Program
    {
        static void Main(string[] args)
        {
            ProbarEsPrimo();

            ProbarFactorialI();

            //Probar SumaNNumeros

            ProbarFibonacci();

        }

        private static void ProbarFactorialI()
        {
            //Declaración de variables
            int numero = 0;
            bool error = true;
            Numeros numeroFactorial = new Numeros();

            Console.WriteLine("FACTORIAL DE UN NÚMERO");
            Console.WriteLine("----------------------");

            //Pedir datos y control de errores
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
            Console.WriteLine("\nEl factorial de {0} es: {1}", numero, numeroFactorial.FactorialIterativo(numero));
        }

        private static void ProbarEsPrimo()
        {
            //Declaración de variables
            Numeros numeroPrimo = new Numeros();
            int numeroPrimoIntroducir = 1;
            bool error = true;

            //Pedir datos y control de errores
            do
            {
                try
                {
                    do
                    {
                        error = false;
                        Console.Clear();
                        Console.Write("Dime un número y te diré si es primo o no, hasta que introduzcas 0: ");
                        numeroPrimoIntroducir = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEl numero {0} {1} es primo", numeroPrimoIntroducir, (numeroPrimo.NumeroEsPrimo(numeroPrimoIntroducir)) ? "sí" : "no");
                        Console.ReadLine();

                    } while (numeroPrimoIntroducir != 0);
                }

                catch
                {
                    error = true;
                    Console.WriteLine("Error no controlado");
                }
            } while (error);
        }

        static void ProbarFibonacci()
        {
            //Declaración de variables
            int numeroMeses = 0;
            bool error = true;
            const int MAXIMO = 35;
            Numeros numero = new Numeros();

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
            } while (error || numeroMeses < 0 || numeroMeses > MAXIMO);

            //Resultado
            Console.WriteLine("\nEl número de conejos que habrá en {0} meses será de: {1}", numeroMeses, numero.Fibonacci(numeroMeses));

        }
    }
}
