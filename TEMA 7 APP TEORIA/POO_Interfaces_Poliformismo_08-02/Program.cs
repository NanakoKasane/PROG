using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Interfaces_Poliformismo_08_02
{
    class Program
    {
        static void Main(string[] args)
        {
            ICloneable[] cosas = new ICloneable[100];


            Factura f = new Factura();
            Pila p = new Pila();
            //int i = 10;


            Copiar(f);
            Copiar(p);

            Console.ReadLine();

        }

        static void Copiar(ICloneable obj) //Antes era-> (Object obj)
        { 
            //Factura f;
            //Pila p;
            //Pregunta si es objeto pasado por el parámetro es una Factura (Si es un objeto de la clase factura). Se pregunta con IS.
            //if (obj is Factura) // IS -> Pregunta/Comprueba si el objeto es de esa clase/tipo Factura.
            //{
            //    f = (Factura)obj; //Hay que hacer casting para convertir el Object al tipo concreto.
            //    f.Clonar();
            //}
            //if (obj is Pila)
            //{
            //    p = (Pila)obj;
            //    p.Clonar();
            //}


            //Ahora no es necesario lo de arriba al pasarle el Interfaz, ya distingue automáticamente de qué clase/tipo
            // es el objeto para llamar a su .Clone()
            obj.Clone();

        }

      
    }
}
