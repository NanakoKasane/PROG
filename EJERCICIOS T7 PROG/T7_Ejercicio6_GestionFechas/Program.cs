using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio6_GestionFechas
{
    class Program
    {
        static void Main(string[] args)
        {
			PruebaFechas();


            Console.ReadLine();
        }

		static void PruebaFechas()
		{
			int dia = 1;
			int mes = 1;
			int anio = 1;
			bool correcto = true;

			do
			{
				Console.Clear();
				Console.WriteLine("=".PadLeft(26, '='));
				Console.WriteLine("Gestion de fechas válidas".ToUpper());
				Console.WriteLine("=".PadLeft(26, '=') + "\n");

				try
				{
					correcto = true;
					Console.Write("Introduzca un año: ");
					anio = int.Parse(Console.ReadLine());

					Console.Write("\nIntroduzca un mes: ");
					mes = int.Parse(Console.ReadLine());

					Console.Write("\nIntroduzca un día: ");
					dia = int.Parse(Console.ReadLine());

					CFechas fecha = new CFechas(anio, mes, dia);
					correcto = true;

					 //REVISAR febrero en bisiesto 29/2/2016 me sale -> dia = 0, WHY?
					
                    Console.WriteLine("\n\n" + fecha.ToString());
					Console.WriteLine(fecha.EscribirFechaCorta());
                    correcto = true;
					
                    //else
                    //{
                    //    Console.WriteLine("Fecha no válida");
                    //    Console.ReadLine();
                    //    correcto = false;
                    //}
					
				}
				catch (FormatException)
				{
					Console.WriteLine("\nDebe escribir un número entero");
					Console.ReadLine();
					correcto = false;
				}
				catch (OverflowException)
				{
					Console.WriteLine("\nFecha demasiado grande");
					Console.ReadLine();
					correcto = false;
				}
				//Excepción propia para la clase CFechas que comprueba si la fecha es válida y si no lo es lanza la siguiente Excepción
				catch (FechaNoValidaException)
				{
					Console.WriteLine("\nLa fecha no es válida");
					Console.ReadLine();
					correcto = false;
				}
				catch
				{
					Console.WriteLine("Error");
					Console.ReadLine();
					correcto = false;
				}
			} while (!correcto);

		}
    }
}
