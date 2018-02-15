using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ExcepcionesIntroducion_14_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int denominador = 1;
            int numerador = 1;
            int resultado = 0;

            TryCatchAnidados();
            Console.ReadLine();

            try
            {
                Console.Write("Denominador: ");
                denominador = int.Parse(Console.ReadLine());
                resultado = numerador / denominador;
            }
            catch (Exception e) //Ponerle nombre a la excepción para que los la información la guarde ahí y poder preguntarle sus datos 
            {
                Console.WriteLine(e.Message); //Muestra solo el mensaje de la excepción
                Console.WriteLine(e.Source); //Origen de la excepción
                Console.WriteLine(e.TargetSite);// Método que produce la excepción
            }

            Console.ReadLine();

        }

        static void TryCatchAnidados()
        {
            try
            {
                Console.WriteLine("Try ... del NIVEL 0");
                try
                {
                    throw new Exception();
                    Console.WriteLine("Try ... del NIVEL 1");
                }
                catch
                {
                    Console.WriteLine("Catch ... del NIVEL 1");
                }
                finally
                {
                    Console.WriteLine("Finally ... del NIVEL 1");
                }

            }
            catch
            {
                Console.WriteLine("Catch ... del NIVEL 0");
            }
            finally
            {
                Console.WriteLine("Finally ... del NIVEL 0");
            }

        }
    }
}
