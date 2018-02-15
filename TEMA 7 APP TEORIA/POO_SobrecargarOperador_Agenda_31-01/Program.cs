using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_SobrecargarOperador_Agenda_31_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Agenda AgendaSecreta = new Agenda();
            //AgendaSecreta.ListarAnotaciones();
            bool seAnadio = AgendaSecreta + "Mi primer contacto"; //Otra forma en vez de con el if siguiente

            //Te obliga a que recibas lo que te devuelve (la sobrecarga del operador, que en este caso hemos puesto que devuelve bool)
            if (AgendaSecreta + "Mi primer contacto")
                Console.WriteLine("Notación añadida");

            //Añadir 100 anotaciones
            for (int i = 0; i < 100; i++)
            {
                seAnadio = AgendaSecreta + "Anotacion_ ";
            }

            AgendaSecreta.ListarAnotaciones();


        }
    }
}
