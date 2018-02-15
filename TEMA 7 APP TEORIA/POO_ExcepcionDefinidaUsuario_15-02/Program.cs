using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ExcepcionDefinidaUsuario_15_02
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] array1 = new float[] { 1.2F, 3.5F, 7.6F};
            float[] array2 = new float[] {};
            Media media = new Media();

            try
            {
                //return;
                Console.WriteLine("La media del array1 es {0}", media.HacerMedia(array1));
                throw new DivideByZeroException();
                Console.WriteLine("La media del array1 es {0}", media.HacerMedia(array2)); //Dará la excepción por estar vacío el array2
            }

            catch (ContadorCeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch
            {
                Console.WriteLine("HORROR: Error no esperado.");
                //Aquí guardaría para mí los datos del error
            }
            finally
            {
                Console.WriteLine("Hasta luego <3"); //Aunque esté el return; llega al finally
                //Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
