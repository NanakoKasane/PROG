using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.POO_ConstructorDestructor_11_01
{
    class Clase_C
    {
        //Constructor de la clase -> para usarlo con nombreClase.constructor
        static Clase_C() //Los static no pueden ser public, ya lo son por defecto y ponerlo da error
        {
            Console.WriteLine("Clase_C: Constructor de CLASE (static)");
        }
        //Constructor de Instancia -> al crearlo con new y llamarlo con nombreObjecto.constructor
        public Clase_C()
        {
            Console.WriteLine("Clase_C: Constructor de INSTANCIA");
        }

        //Destructor
        ~Clase_C()
        {
            Console.WriteLine("Clase_C: Destructor");
        }
    }

    class Clase_B : Clase_C
    {
        //Constructor de la clase
        static Clase_B()
        {
            Console.WriteLine("Clase_B: Constructor de CLASE (static)");
        }
        //Constructor de instancia
        public Clase_B()
        {
            Console.WriteLine("Clase_B: Constructor de INSTANCIA");
        }
        //Destructor
        ~Clase_B()
        {
            Console.WriteLine("Clase_B: Destructor");
        }
    }

    class Clase_A : Clase_B
    {
        //Constructor de la clase
        static Clase_A()
        {
            Console.WriteLine("Clase_A: Constructor de CLASE (static)");
        }
        //Constructor de instancia
        public Clase_A()
        {
            Console.WriteLine("Clase_A: Constructor de INSTANCIA");
        }
        //Destructor
        ~Clase_A()
        {
            Console.WriteLine("Clase_A: Destructor");
        }
    }
}
