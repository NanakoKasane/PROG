using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T8_Ejercicio8_CrearListar
{
	class Alumnos
	{
		string _nombre;
		string _apellidos;
		public int id = 1;

		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}

		public string Apellidos
		{
			get { return _apellidos; }
			set { _apellidos = value; }
		}

		public Alumnos(string nombre, string apellidos)
		{
			this._nombre = nombre;
			this._apellidos = apellidos;
		}


		public override string ToString()
		{
			return "Alumno " + id.ToString().PadRight(6) +"Nombre: " + _nombre.PadRight(20) + " Apellidos: " + _apellidos + "\r\n";
		}
	}

	class ListaAlumnos
	{
		static List<Alumnos> lista = new List<Alumnos>();
		static int id = 1;


		static public bool AnadirAlumnos(Alumnos alumno)
		{
			lista.Add(alumno);
			alumno.id = id++;
			return true;
		}
		

	}
}
