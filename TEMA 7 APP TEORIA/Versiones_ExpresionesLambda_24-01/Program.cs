using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versiones_ExpresionesLambda_24_01
{
    class Program
    {
        delegate int dlgCuadrado(int x);

        static void Main(string[] args)
        {
            int numero = 10;

            //C# 1.0. Uso de delegados
            Console.WriteLine("\n --- C# 1.0: Uso de delegados ---");
            //Creo una instancia del delegado asignada a cuadrado()
            dlgCuadrado dc1 = new dlgCuadrado(Cuadrado); // dlgCuadrado dc1 = Cuadrado;
            //Llamo al delegado y paso un valor
            Console.WriteLine("\t{0}\n", dc1(numero).ToString());

            //C# 2.0. Delegados con código de inicialización (metodo Anónimo)
            Console.WriteLine("\n --- C# 2.0: Uso de delegados con cod.inicialización ---");
            dlgCuadrado dc2 = delegate(int x)
            {
                return x * x; //Código del método 
            };
            Console.WriteLine("\t{0}\n", dc2(numero).ToString());

            //C# 3.0. Delegados con expresiones Lambda
            Console.WriteLine("\n --- C# 3.0: Uso de delegados con expresiones Lambda ---");
            dlgCuadrado dc3 = x => x * x;
            Console.WriteLine("\t{0}\n", dc3(numero).ToString());

            //Siguientes versiones.-> Permiten crear un delegado genérico usando la palabra Func:
            // (Delegados genéricos integrados con expresión Lambda)
            Console.WriteLine("\n --- C# 3.0: Uso de delegados genéricos integrados con expresiones Lambda ---");
            Func<int, int> dc4 = x => x * x;
            Console.WriteLine("\t{0}\n", dc4(numero).ToString());


            Console.ReadLine();
        }

        static int Cuadrado(int i)
        {
            return i * i;
        }
    }
}
