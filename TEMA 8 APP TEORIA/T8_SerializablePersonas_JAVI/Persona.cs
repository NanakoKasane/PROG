using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T8_SerializablePersonas_JAVI
{
    [Serializable]
    class Persona
    {
        #region Campos

        string _apellidos;
        string _nombre;
        float _sueldo;
        bool _borrado;

        #endregion

        #region Campos

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

        #endregion

        #region Constructor

        public Persona(string a, string n, float s)
        {
            _apellidos = a;
            _nombre = n;
            _sueldo = s;
            _borrado = false;
        }

        #endregion

        #region Métodos

        public override string ToString()
        {
            return Apellidos.PadRight(30) + " " + Nombre.PadRight(20) + " " + Sueldo.ToString().PadRight(9);
        }

        #endregion

    }
}
