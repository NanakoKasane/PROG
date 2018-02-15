using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_UsodeLambda_31_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = { 1, 3, 4, 77, 12, 67, 90, 22, 99, 21, 0 };
            string[] nombres = {"pepe", "dani", "Juan", "paco", "antonio" };

            #region Contar los pares del array con una expresión lambda y .Count
            // Expresión Lambda que evalua si el valor es PAR:
            int nPares = numeros.Count<int>(n => n%2 == 0); //Recibe n (que será cada número de la colección int[]numeros) y devuelve un bool

            Console.WriteLine("En el array hay {0} números PARES", nPares);
            #endregion 


            //Buscar a "Juan" en el array de nombres:
            MetodoBuscar(nombres, delegate(string nombre)
            {
                return nombre == "Juan"; //El delegado con su método enlazado lo estás escribiendo aquí mismo (Este es el código del método que enlazarías).
            });

            //Lo mismo con Expresión Lambda (Buscar a "Juan"):
            MetodoBuscar(nombres, nombre => nombre == "Juan");


            Console.ReadLine();
        }
        /// <summary>
        /// Método que recibe una función anónima y un nombre a buscar, para buscar el nombre en el array de string
        /// </summary>
        /// <param name="nombre">nombre que querrás encontrar en el array de string</param>
        /// <param name="miExpresion">Función anónima que recibe un string y devuelve un bool</param>
        public static void MetodoBuscar(string[] nombres, Func<string, bool> miExpresion)
        {
            Console.WriteLine("Uso de Lambda con método anónimo");
            foreach (string tmp in nombres)
            {
                if (miExpresion(tmp))
                    Console.WriteLine("Encontrado: " + tmp);
            }

            //lo mismo del foreach con un for:
            for (int i = 0; i < nombres.Length; i++)
            {
                if(miExpresion(nombres[i]))
                    Console.WriteLine("Encontrado en la posición: {0}", i);
            }
        }
    }
}
