using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T8_RedireccionarSalidaConsola_5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ruta al fichero de salida
            string ruta = @"..\..\..\ficheros\salida.txt";
            Console.WriteLine("Escribiendo en la pantalla...");

            //Crear un flujo para conectarlo a la salida (para que apunte a la ruta en vez de a la pantalla)            
            using (FileStream flujo = new FileStream(ruta, FileMode.Create)) //Crea un flujo, lo conecta a la ruta y con este modo siempre lo crea. (Truncate borra el contenido del que hay)
            {
                TextWriter tmp = Console.Out;//Aquí en tmp guardo el flujo de salida hacia la consola. Console.Out --> Flujo de salida actual (consola)

                StreamWriter sw = new StreamWriter(flujo); //FileStream hereda de Stream, es un flujo 

                //Escribir en el fichero: (el fichero es la salida)
                Console.SetOut(sw); //Cambia el flujo de salida hacia sw (que es un flujo en la ruta indicada con el modo indicado)
                Console.WriteLine("Escribiendo en el flujo en vez de en la consola..."); //Escribes en el flujo en vez de en la consola
                Console.WriteLine(DateTime.Now.ToShortDateString());
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("\t{0},", i);
                } 

                //Restaurar valores de entrada --> Consola vuelve a ser la salida
                Console.SetOut(tmp);
                Console.WriteLine("Has vuelto a la consola...");
                sw.Dispose();
                Console.ReadLine();
            }


        }
    }
}
