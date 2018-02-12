using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio5_GestionPersonas
{
	class Program
	{
		static void Main(string[] args)
		{			

			Persona persona = new Persona();
			Persona persona2 = new Persona("Espinosa Galvez", "Marina", DateTime.Parse("10/10/1999"), 1000.20);
			Persona otraPersona = new Persona();
			ListaPersonas lista = new ListaPersonas();

			//Evento 
			lista.evento += lista_evento;

			lista.Anadir(persona);
			lista.Anadir(persona2);
			lista.Anadir(new Persona("Gutierrez Campos", "Laura", DateTime.Parse("04/03/1997"), 20040));
			//Añadir una persona con el operador + sobrecargado
			bool anadio = lista + otraPersona;

			lista.Listar("Personas");
			Console.ReadLine();

		}

		static void lista_evento()
		{
			Console.WriteLine("Has añadido una persona correctamente"); 
		}

	}
}
