using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio5_GestionPersonas
{
	class Persona
	{
		#region Campos
		//Campos
		int _codigo; //será único
		string _apellidos;
		string _nombre;
		DateTime _fechaNacimiento;
		double _sueldo;
		#endregion 

		#region Propiedades
		//Propiedades
		public int Codigo
		{
			get { return _codigo; }
			set { 
					_codigo = value; 
				}
		}

		public string Apellidos
		{
			get { return _apellidos; }
			set { _apellidos = value; }
		}

		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}

		public DateTime FechaNacimiento
		{
			get { return _fechaNacimiento; }
			set { _fechaNacimiento = value; }
		}

		public double Sueldo
		{
			get { return _sueldo; }
			set {
					if (value < 0)
						_sueldo = 0; //No podrá ser negativo
					else
						_sueldo = value; 
				}
		}
		#endregion

		#region Constructores
		//Constructores
		public Persona(string apellidos, string nombre, DateTime fechaNacimiento, double sueldo) //El código se crea automáticamente incrementándose
		{
			this._apellidos = apellidos;
			this._nombre = nombre;
			this._fechaNacimiento = fechaNacimiento;
			this._sueldo = sueldo;
		}

		public Persona()
		{
			this._apellidos = "Expósito Expósito";
			this._nombre = "Juan";
			this.FechaNacimiento = DateTime.Parse("10/10/1995");
			this._sueldo = 0.0;
		}
		#endregion 

		#region Métodos
		public override string ToString()
		{
			return "| " + Codigo.ToString().PadLeft(6) + " | " + _apellidos.PadRight(30) + " | " + _nombre.PadRight(20) + " | " 
				+ _fechaNacimiento.ToShortDateString() + " | " + _sueldo.ToString().PadLeft(10) + " euros mensuales" + " |";
		}
		#endregion 

	}
}
