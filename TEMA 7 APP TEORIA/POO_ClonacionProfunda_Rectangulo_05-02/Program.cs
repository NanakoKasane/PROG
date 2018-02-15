using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ClonacionProfunda_05_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Punto p1 = new Punto(5, 5);
            Punto p3 = new Punto(20, 10);
            Rectangulo r1 = new Rectangulo(p1, p3);

            Console.WriteLine("Rectángulo original a copiar:\n");
            r1.Informacion();
            r1.Dibuja();
            Console.ReadLine();

            //Hacer la copia y comprobar que no se ha cambiado la del origen y se ha copiado bien
            Console.Clear();
            Console.WriteLine("Copia del rectángulo en p1(0,0): ");
            Rectangulo copia = (Rectangulo)r1.Clone();

            //Tendrán que asignarse de la siguiente forma: 
            copia.puntos[0] = new Punto(0,0); //cambiar punto 1 del clonado
            copia.puntos[1] = new Punto(3, 3); //cambiar punto 2
            // copia.puntos[0].x -> Así nop
            copia.Informacion();

            Console.WriteLine("\n\nOriginal: ");
            r1.Informacion();
            //No se había copiado bien porque hay una clase Punto (por referencia) -> Para solucionarlo, podría convertir la
            // clase Punto a una Estructura (que es por valor) y ya se copiaría bien y no la dirección de memoria.

            //Efectivamente ya se ha copiado bien, el original sigue con sus valores aun habiendo cambiado la primera coordenada a (0,0)


            Console.ReadLine();
        }
    }
}
