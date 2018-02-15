using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Interfaces_Poliformismo_08_02
{
    public class Factura : ICloneable
    {
        //public void Clonar()
        //{
        //}

        public object Clone()
        {            
            Console.WriteLine("Soy Factura.Clonar()");
            return null; //Ya que tiene que devolver algo, por poner

        }
    }

    public class Pila : ICloneable
    {
        //public void Clonar()
        //{
        //}

        public object Clone()
        {            
            Console.WriteLine("Soy Pila.Clonar()");
            return null;
        }
    }
}
