using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio12tema4_factorial_recursiva
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

            Console.WriteLine("\nEl factorial de {0} es: {1}", numero, FactorialRecursivo(numero));

            Console.ReadLine();
        }


        //Método que calcula el factorial de un número. 
        static double FactorialRecursivo(int numero)
        {
                if (numero == 0)
                    return 1;
                return numero * FactorialRecursivo(numero - 1);

        }
    }
}
