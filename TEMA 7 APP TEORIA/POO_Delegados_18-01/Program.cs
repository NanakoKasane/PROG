using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Delegados_18_01
{
    class Program
    {
        //Declaro el tipo de dato delegado llamado MiDelegado
        public delegate void MiDelegado(string mensaje);
        //El método que enlaces tendrá que tener la misma firma (devolver void y recibir un string)

        public delegate void MiDelegado2();

        static void Main(string[] args)
        {
            //Crear un objeto del tipo del delegado.
            MiDelegado llamada = MetodoQueUsaElDelegado1; //Le asignas una dirección de memoria (método)

            llamada("Hola, soy el delegado"); //Llamada al método desde la instancia del delegado
            MetodoQueUsaElDelegado1("Hola caracola, soy el método");

            llamada = MetodoQueUsaElDelegado2;
            llamada(" "); //Ahora ejecutará el otro método (método 2). Deja de estar enlazado al primer método 
            //y ahora se enlaza al segundo

            MetodoConDevolucion("Texto recibido", llamada);
            Console.ReadLine();




            //Para llamar a más de un método con el delegado (MULTIDIFUSIÓN):
            MiDelegado2 delegado = M1;
            delegado += M2;
            delegado += M3;
            delegado(); //LLama a M1, M2 y M3
            Console.WriteLine("Hay {0} métodos en la lista.", delegado.GetInvocationList().GetLength(0));

            delegado -= M2; //Quitando a M2 de la lista
            delegado(); //LLama a M1 y M3. (M2 lo has quitado).
            Console.WriteLine("Hay {0} métodos en la lista.", delegado.GetInvocationList().GetLength(0));

            Console.ReadLine();
        }

        //Método con la misma firma del delegado para enlazarlo:
        static void MetodoQueUsaElDelegado1(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
        static void MetodoQueUsaElDelegado2(string mensaje)
        {
            Console.WriteLine("Soy el método 1");
        }
        //Así un método podrá recibir como parámetro otro método (el enlazado al delegado):
        static void MetodoConDevolucion(string texto, MiDelegado delegado)
        { //No podrías pasarle el método directamente porque sería el dato que devuelve y no ejecutará el método
          //Además en este caso es void el dato que devuelve el método y no puedes pasarselo
            delegado("---------------------"); //llama al otro método
        }



        //Para MiDelegado2, que se enlace a varios métodos
        static void M1()
        {
            Console.WriteLine("Soy M1()");
        }
        static void M2()
        {
            Console.WriteLine("Soy M2()");
        }
        static void M3()
        {
            Console.WriteLine("Soy M3()");
        }
    }
}
