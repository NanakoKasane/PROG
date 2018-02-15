using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Eventos_18_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Contador c1 = new Contador();

            //Apuntarse al evento:
            c1.cambioValor += c1_cambioValor; //Después del += --> tabula tabula y se crea el método
            c1.cambioValor5 += c1_cambioValor5;

            c1.Iniciar = true; //Para que se inicie el contador
            c1.VerContador();



            Console.ReadLine();
        }

        static void c1_cambioValor5()
        {
            Console.WriteLine("Ehhh, múltiplo de 5");
            Console.ReadLine();
        }

        //Lo que hará el evento apuntado
        static void c1_cambioValor()
        {   
            Console.WriteLine("-");
        }
    }
}
