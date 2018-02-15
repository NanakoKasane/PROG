using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.POO_ClasesHerencia_10_01
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaseBase cBase = new ClaseBase(); //No tiene constructor, lo creas llamando al constructor vacío
            //Toda clase al crearla tiene un constructor vacío. Los constructores no se heredan.

            ClaseDerivada cDerivada = new ClaseDerivada();
            //Si tiene miembros estático aparecerá al poner ClaseDerivada. (con el nombre de la clase)
            //Y si no son estáticos aparecen al poner el nombre del objeto -> cDerivada.
            Console.WriteLine(cDerivada.Saluda());

            ClaseDerivadaOrden2 cDerivada2 = new ClaseDerivadaOrden2(); //Tiene todo lo que hereda de ClaseDerivada

            ClaseDerivadadeAbstracta cDerivadaDeAbstracta = new ClaseDerivadadeAbstracta();
            cDerivadaDeAbstracta.Saluda();

            ClaseAbstracta cb = new ClaseDerivadadeAbstracta(); //No puedes crear objeto de la Clase Abstracta,
            //pero de ese tipo sí puedes crear un objeto de la clase derivada a ella.
            //El objeto original es a pero se está comportando como b.

            Console.ReadLine();         
        }
    }

    //Esta clase tiene como base Object
    class ClaseBase // Si pones --> sealed class ClaseBase no podrías heredar de ella
    {
        int valor = 0; //privado

        public string Saluda()
        {
            return "Hola, soy la claseBase...";
        }
    }

    class ClaseDerivada : ClaseBase // Hereda de la clase base, y tiene por tanto el método saluda()
    {
        public int Cuadrado(int n)
        {
            return n*n;
        }
    }

    class ClaseDerivadaOrden2 : ClaseDerivada { } //Hereda de ClaseDerivada y por tanto tiene todos sus métodos

    class ClaseDerivadaOrden3 : List<int> //Esta clase ya es una lista con todos sus métodos y propiedades
    { 
        //Reescribir un método para que ejecute el siguiente código en vez del método propio 
        //(pero los demás métodos, etc se van a quedar igual):

    }

    abstract class ClaseAbstracta //No podrás crear un objeto ni usar sus métodos, solo puedes heredar de ella
    {
        int valor = 0; //privado

        public string Saluda()
        {
            return "Hola, soy la claseBase...";
        }

        public abstract string SaludaAbstracto(string texto); //Método abstracto. 
        //No puede tener código por ser abstracto, solo la firma. Tiene que ser público sí o sí
    }
    class ClaseDerivadadeAbstracta : ClaseAbstracta //Ahora si puedes crear objetos de esa cláse etc
    {     
        //Tienes que escribir el método abstracto obligatoriamente. 
        // Click derecho sobre la ClaseAbstracta -> Implementar clase abstracta
        public override string SaludaAbstracto(string texto)
        {
            return "Soy método abstracto heredado";
        }

        //Reescribir método de la clase padre
        public new string Saluda() //Ponerle new no es obligatorio pero es lo que se pone para 
        {                          //indicar que se ha heredado y reescrito y es un método normal (no abstracto)
            return "Hola, soy la claseDerivada...";
        }
    }
}
