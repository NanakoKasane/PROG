using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ExpresionesLambda_24_01
{
    class Program
    {
        delegate int MiDelegado(int i);

        static void Main(string[] args)
        {
            int j;
            MiDelegado delegado = x => x * x; //En vez de apuntar a un método, el método lo escribes 
            //aquí con una expresión LAMBDA.
            //MiDelegado delegado2 = Cuadrado; -> lo mismo que con una expresión lambda

            j = delegado(10);
            Console.WriteLine(j);

            Console.ReadLine();
        }

        //La expresión lambda equivaldría al método siguiente:
        static int Cuadrado(int i)
        {
            return i * i;
        }
    }
}

/* EJEMPLOS DE EXPRESIONES LAMBDA:
 *1)  (x, y) => x == y;    Equivalente a escribir una función que recibe 2 parámetros y devuelve un bool (true si x == y) -> Ya que "==" devuelve bool
 *2)  (int x, string s) => s.Length > x;      Recibe 2 parámetros y devuelve un bool (cuando la longitud de la cadena sea mayor a x devuelve true)
 *3)  () => algunMetodo();        
 *4)  Delegado miDelegado = n => {
 *                                 //Código
 *                               }
 *5)
 * 
 * 
 */
