using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio7_InterfazICarrera
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime fechaNac = new DateTime(1998, 12, 03);

            Deportista deportista1 = new Deportista("Juan", "Dominguez Leal", fechaNac);
            Coche coche1 = new Coche();

			//Llamada al método Correr
			Console.WriteLine("Llamando a Correr con el objeto de tipo Deportista: ".ToUpper());
            Correr(deportista1);
			Console.WriteLine("\n\nLlamando a Correr con el objeto de tipo Coche: ".ToUpper());
            Correr(coche1);

			Console.ReadLine();

			//Probando el listar paginado básicamente hecho for fun para practicar, no porque lo pidiera el ejercicio x'D
			Console.Clear();
			ListaDeDeportistas Futbolistas = new ListaDeDeportistas();
			Futbolistas.AnadirDeportistaAlea(100);
			Futbolistas.ListarPaginado("Futbolistas");

        }

        //Método correr que ejecuta según el objeto que le pases el método Correr() de la clase correspondiente, que es el que implementa el interfaz ICarrera
        static void Correr(ICarrera obj)
        {
            obj.Correr();
        }
    }
}
