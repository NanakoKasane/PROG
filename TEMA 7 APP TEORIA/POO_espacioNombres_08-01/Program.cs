using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Marina.Dos; //Ahora podrás ahorrarte lo de Marina.Dos.ClaseDos.Saluda(); --> Pones solo: ClaseDos.Saluda;
using Marina.Tres;

namespace Marina.POO_espacioNombres_08_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola Mundo... desde Marina.POO_espacioNombres_08_01.Program");
            HolaMundo.Principal();
            Marina.Dos.ClaseDos.Saluda();

            Console.ReadLine();
        }
    }

    class HolaMundo
    {
        public static void Principal()
        {
            Console.WriteLine("Hola Mundo... desde Marina.POO_espacioNombres_08_01.HolaMundo");
        }
        static public void Saluda()
        {
            Console.WriteLine("Hola soy la HolaMundo, saluda()");
        }

    }
}

namespace Marina.Dos
{
    public static class ClaseDos
    {
        static public void Saluda()
        {
            Console.WriteLine("Hola soy la clase2, saluda()");
        }
    }
}

namespace Marina.Tres
{
    public static class ClaseTres
    {
        static public void Saluda()
        {
            Console.WriteLine("Hola soy la clase3, saluda()");
        }
    }
}