using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T8_SerializacionPersonas_8_03
{
    [Serializable]
    class Persona
    {
        //Campos
        string _apellidos;
        string _miNombre;
        float _sueldo;
        bool _borrado;

        //Constructor
        public Persona(string apellidos, string nombre, float sueldo)
        {
            this._apellidos = apellidos;
            this._miNombre = nombre;
            this._sueldo = sueldo;
            _borrado = false;
        }

        //Propiedades
        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public string Nombre
        {
            get { return _miNombre; }
            set { _miNombre = value; }
        }

        public float Sueldo
        {
            get { return _sueldo; }
            set { _sueldo = value; }
        }

        public bool Borrado
        {
            get { return _borrado; }
            set { _borrado = value; }
        }


        public override string ToString()
        {
            return _apellidos.PadRight(30).ToString() + _miNombre.PadRight(30).ToString(); // Apellidos.PadRight(30) + Nombre.PadRight(20) + Sueldo.ToString().PadRight(9);
        }


    }
}
