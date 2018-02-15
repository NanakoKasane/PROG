using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio8_Vehiculos_HerenciaClases
{
    class Paseo : Bicicleta
    {
        //Campos
        int _numeroCestas;
        string _modelo;
        string _marca;

        //Constructores
        public Paseo() : base()
        {
            this._numeroCestas = 1;
            this._modelo = "Vintage";
            this._marca = "Monty City";
        }
        public Paseo(int numeroCestas, string modelo, string marca, double precio, DateTime fechaCompra, string nombre, 
            int numeroRuedas, ConsoleColor color, tipoTraccion tipo) : base(precio, fechaCompra, nombre, numeroRuedas, color, tipo)
        {
            this._numeroCestas = numeroCestas;
            this._modelo = modelo;
            this._marca = marca;
        }

        //Propiedades
        public int NumeroCestas
        {
            get { return _numeroCestas; }
            set
            {
                if (value < 0) //El número de cestas no puede ser negativo
                    _numeroCestas = 0;
                else
                    _numeroCestas = value;
            }
        }

        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        //Métodos
        public override string ToString()
        {
            return "DATOS DE LA BICICLETA DE PASEO" + "\n" +
                   "==============================" + "\n\n" + base.ToString() +
                   "       NÚMERO DE CESTAS: " + _numeroCestas + "\n" +
                   "                 MODELO: " + _modelo + "\n" +
                   "                  MARCA: " + _marca + "\n";
        }

    }

}
