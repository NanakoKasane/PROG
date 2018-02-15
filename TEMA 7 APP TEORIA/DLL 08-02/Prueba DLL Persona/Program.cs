using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------
using Marina.POO_ComparacionOrdenacion_IComparable_07_02;

namespace Prueba_DLL_Persona
{
    class Program
    {

        static List<Persona> personas = new List<Persona>();
        static void Main(string[] args)
        {
            
            CrearVariasPersonas();
            //Listar 1: Sin ordenar
            Console.WriteLine("LISTA SIN ORDENAR:");
            Listar();

            //Ordena la lista y la lista ordenada
            Console.WriteLine("\n\nLISTA ORDENADA (por código):");
            personas.Sort();
            Listar();

            //Ordenar por otros criterios:
            personas.Sort(new Persona.OrdenaApellido()); //Una clase es su interfaz (Se comporta como el interfaz). Así que como...
            personas.Sort(new Persona.OrdenaNombre()); // ...te pide un interfaz, le pasas la clase que implementa el interfaz (instanciándola la nueva clase)

            Listar();

        }

        static void CrearVariasPersonas()
        {
            personas.Add(new Persona("Gil", "Pepe", 100));
            personas.Add(new Persona("Bueno", "Victor", 150));
            personas.Add(new Persona("Ruiz", "José", 125));
            personas.Add(new Persona("Salvador", "Fer", 200));
            personas.Add(new Persona("Macias", "Lourdes", 110));

        }

        static void Listar()
        {
            foreach (Persona tmp in personas)
            {
                Console.WriteLine(tmp.ToString());
            }
            Console.WriteLine("\nFin del listado ...");
            Console.ReadLine();
        }
    }
}
