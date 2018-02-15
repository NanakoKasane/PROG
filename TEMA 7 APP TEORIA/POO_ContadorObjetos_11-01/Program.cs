using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ContadorObjetos_11_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Coche[] coches = new Coche[100];
            Console.WriteLine("hay {0} coches", Coche.Contador);

            coches[0] = new Coche();
            Console.WriteLine("hay {0} coches", Coche.Contador);

            Coche c1 = new Coche();
            Console.WriteLine("hay {0} coches", Coche.Contador);

            Console.ReadLine();
        }
    }

    class Coche
    {
        public static int Contador = 0;

        //Constructor vacío, cada vez que crees un coche, va a sumarse (incrementarse 1) el contador:
        public Coche()
        {
            Coche.Contador++;
        }

        //Método para borrar
        public void Borrar()
        {
            Coche.Contador--;
        }
    }
}
