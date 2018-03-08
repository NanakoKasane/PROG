using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T8_SerializacionPersonas_8_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"..\..\..\ficheros\persona.dat";
            GestionPersonas personas = new GestionPersonas(ruta);

            personas.Anadir(new Persona("Apellido", "nombre", 10.10F));
            //personas.Anadir(new Persona("Pepito", "Grillo", 900.50F));
            //personas.Anadir(new Persona("Impertinente", "Tú sabrás", 2.50F));


            personas.Listar();
            Console.ReadLine();

        }
    }
}
