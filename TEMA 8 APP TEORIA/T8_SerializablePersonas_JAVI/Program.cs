using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T8_SerializablePersonas_JAVI
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"..\..\..\ficheros\personasJavi.dat";
            GestionPersonas personas = new GestionPersonas(ruta);

            personas.Anadir(new Persona("Grillo", "Pepito", 123.66F));
            personas.Anadir(new Persona("Heartfilia", "Lucy", 300F));
            personas.Anadir(new Persona("Dragneel", "Natsu", 0.66F));

            personas.Listar();

            Console.ReadLine();
        }
    }
}
