using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio5_GestionPersonas
{
	delegate void MiDelegado();

	class ListaPersonas
	{
		//Campos
		List<Persona> _personas = new List<Persona>();
		int _codigo = 1;
		public event MiDelegado evento;


		//Sobrecarga operador + 
		static public bool operator +(ListaPersonas lista, Persona p)
		{
			lista.Anadir(p);
			return true;
		}

		//Dotar de indizadores de solo lectura
		public Persona this[int indice]
		{
			get { return _personas[indice]; }
		}

		//Métodos
		public void Anadir(Persona p)
		{
			p.Codigo = _codigo++;
			_personas.Add(p);

			if (evento != null)
				evento();
		}

		public void Buscar(Persona p)
		{
			_personas.BinarySearch(p);
		}

		public void Ver(Persona p)
		{
			p.ToString();
		}

		public void Borrar(Persona p)
		{
			_personas.Remove(p);
		}

		public void Listar(string titulo)
		{
			const int ANCHOLISTADO = 108;

			Console.WriteLine(); //Salto de línea
			Console.CursorLeft = (ANCHOLISTADO / 2) - (titulo.Length / 2);
			Console.WriteLine(titulo.ToUpper());
			Console.WriteLine("=".PadLeft(ANCHOLISTADO, '='));
			Console.WriteLine( "| " + "Código".PadLeft(6) + " | " + "Apellidos".PadRight(30) + " | " + "Nombre".PadRight(20) + " | "
				+ "Fecha Nac " + " | " + "Salario".ToString().PadLeft(26) + " |");
			Console.WriteLine("-".PadLeft(ANCHOLISTADO, '-'));

			foreach (Persona p in _personas)
			{
				Console.WriteLine(p.ToString());
			}
			Console.WriteLine("=".PadLeft(ANCHOLISTADO, '='));
		}
	}
}
