using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_GestionPERSONAS_17_01
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDePersonas Bomberos = new ListaDePersonas();

            //Bomberos.AnadirPersonaAlea();
            //Bomberos.AnadirPersonaAlea(150);
            //Bomberos.Listar("Listado de Bomberos de Málaga");

            //ListaDePersonas Administrativos = new ListaDePersonas();
            //Administrativos.AnadirPersonaAlea(100);
            //Administrativos.Anadir(new Persona("Pepe", "Gil García", DateTime.Parse("10/10/2000"), 1.70));
            //Administrativos.Listar();
            //Console.WriteLine(" Hay {0} personas", Bomberos.Cuantos);

            //Apuntarse al EVENTO:
            Bomberos.EntradaOK += Bomberos_EntradaOK;
            Bomberos.AnadirPersonaAlea(30);
            Bomberos.ListarPaginado("BOMBEROS CON EVENTOS"); //LISTAR PAGINADO


            //SOBRECARGA OPERADOR +:
            //Persona Pablo = new Persona();
            // if (Bomberos + Pablo) ; 


            //INDIZADOR:            
            Bomberos[0] = new Persona();
            Console.Clear();
            for (int i = 0; i < Bomberos.Cuantos; i++)
            {
                Console.WriteLine(Bomberos[i].ToString());
            }


            //Implementado interfaz para poder usar foreach 
            Console.ReadLine();
            Console.Clear();
            ListaDePersonas policias = new ListaDePersonas();
            policias.AnadirPersonaAlea(20);
            Console.WriteLine("CON FOREACH (lista de policías)\n");
            foreach (Persona tmp in policias)
            {
                Console.WriteLine(tmp.ToString());
            }          


            Console.ReadLine();
        }

        static void Bomberos_EntradaOK(DateTime ahora)
        {
            Console.WriteLine(" Se ha añadido una persona a las: {0}", ahora.ToShortTimeString());
        }
    }
}
