using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEntradas
{
    class Entrada
    {
        //Campos
        string _tipo;
        int _nPlazas;
        int _precio; //En este caso no hace falta que sea doble, no hay ninguna con decimales
        public int Contador;

        //Propiedades
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public int NPlazas
        {
            get { return _nPlazas; }
            set { _nPlazas = value; }
        }

        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        //Constructor
        public Entrada(string tipo, int nPlazas, int precio)
        {
            this._tipo = tipo;
            this._nPlazas = nPlazas;
            this._precio = precio;
        }


    }
}
