using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.POO_Clases_version1_08_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Clase1 c1 = new Clase1(); //Hereda de Object, por eso ya tiene 4 miembros de instancia (c1. algo) y 2 normales (Clase1. algo)
            Console.WriteLine(c1.ToString());

            Clase2 c2 = new Clase2();

            Console.ReadLine();
        }
    }
}
