using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------------------------------------------  -> Esto se pone por ej. para indicar que lo hemos añadido nosotros
using Marina.POO_ConstructorDestructor_11_01;

namespace Marina.POO_ConstructorDestructor_11_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona();
            // p1._nombre -> La clase tiene que ser public si quieres seguir viendo los miembros fuera de la .dll

            //Persona.quienSoy; // Los estáticos se llaman con el nombre de la clase.campo 
            //y los no estáticos como objeto.campo


            Clase_A a = new Clase_A(); //Al instanciarlo, se ejecuta la llamada a todos los constructores 
            //ancestros (primero el de A - va desde la derivada al padre) primero los estáticos 
            // y luego los de instancia (primero el de C - va desde el padre a la derivada)

            Console.ReadLine();
        }
    }
}
