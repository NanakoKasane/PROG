using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------------------------------
using T7POO_Ejercicio1_CoordenadasyMarcos;

namespace T7_Ejercicio4_ClaseNumeros
{
    class Program
    {
        static void Main(string[] args)
        {
			MenuPrincipal menu = new MenuPrincipal();
			Marcos marcoMenu = new Marcos();
			string[] opciones = {"1. Probar si un número es primo", "2. Factorial de un número con método Iterativo", 
									"3. Factorial de un número con método Recursivo", "4. Suma de N Números con método Iterativo",
									"5. Suma de N Números con método Recursivo", "6. Número de Fibonacci"};
			ConsoleKeyInfo opcion;
			bool error = true;
			int coordenadaXInicio = 5; //Esto se pediría por teclado, 5 es número para probarlo. ¿Coordenadas donde quieras que empiece el menú?.
			int coordenadaYInicio = 5; //Se pediría por teclado. Número de prueba

			do
			{
				Console.Clear();
				menu.MostrarMenu(coordenadaXInicio, coordenadaYInicio, opciones);
				opcion = Console.ReadKey();

				switch (opcion.KeyChar)
				{
					case '1':
						Console.Clear();
						ProbarEsPrimo();
						break;
					case '2':
						Console.Clear();
						ProbarFactorialI();
						break;
					case '3':
						Console.Clear();
						ProbarFactorialR();
						break;
					case '4':
						Console.Clear();
						ProbarSumaNNumerosI();

						break;
					case '5':
						Console.Clear();
						ProbarSumaNNumerosR();
						break;
					case '6':
						Console.Clear();
						ProbarFibonacci();
						break;
					case '0':
						return;
				}
			} while (error || opcion.KeyChar < 0 || opcion.KeyChar > opciones.Length); //Suponemos que las opciones irán numeradas en orden


        }

        static void ProbarEsPrimo()
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
						Console.WriteLine("=".PadLeft(20, '='));
						Console.WriteLine("NÚMEROS PRIMOS");
						Console.WriteLine("=".PadLeft(20, '=') + "\n");
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

        static void ProbarFactorialI()
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
			Console.ReadLine();
        }

		static void ProbarFactorialR()
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
			Console.WriteLine("\nEl factorial de {0} es: {1}", numero, numeroFactorial.FactorialRecursivo(numero));
			Console.ReadLine();
		}

		static void ProbarSumaNNumerosI()
		{
			//Declaración de variables
			int numero = 0;
			bool error = true;
			Numeros unNumero = new Numeros();

			Console.WriteLine("SUMA N NÚMEROS ITERATIVA");
			Console.WriteLine("-----------------------");

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
			Console.WriteLine("\nLa suma de los primeros números hasta de {0} es: {1}", numero, unNumero.SumaPrimerosNnumerosI(numero));
			Console.ReadLine();
		}

		static void ProbarSumaNNumerosR()
		{
			//Declaración de variables
			int numero = 0;
			bool error = true;
			Numeros unNumero = new Numeros();

			Console.WriteLine("SUMA N NÚMEROS RECURSIVA");
			Console.WriteLine("-----------------------");

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
			Console.WriteLine("\nLa suma de los primeros números hasta de {0} es: {1}", numero, unNumero.SumaPrimerosNnumerosR(numero));
			Console.ReadLine();
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
			Console.ReadLine();

        }
    }
}
