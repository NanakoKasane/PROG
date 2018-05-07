using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Ej16_Fichero_Clientes
{
    public class Cliente
    {
        #region Campos
        string _dni;
        int _edad;
        double _sueldo;
        string _apellidos;
        string _nombre;
        #endregion 

        #region Propiedades
        public string Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }

        public int Edad
        {
            get { return _edad; }
            set { _edad = value; }
        }

        public double Sueldo
        {
            get { return _sueldo; }
            set { _sueldo = value; }
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
        #endregion 

        public Cliente() { }

        public Cliente(string dni, int edad, double sueldo, string apellidos, string nombre)
        {
            this._dni = dni;
            this._edad = edad;
            this._sueldo = sueldo;
            this._apellidos = apellidos;
            this._nombre = nombre;
        }

		//dni;edad;sueldo;apellidos;nombre;
		//77281928R;20;2000;Garcia Robles;Mario;
		//37281928P;22;2000;Bueno Molina;Marina;
		//27281928W;18;2000;Amado Bueno;Ismael;
		//17281928X;33;2000;Galvez Espinosa;Javier;

    }
}
