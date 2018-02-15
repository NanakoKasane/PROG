using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio8_Vehiculos_HerenciaClases
{

    class Coche : Vehiculo
    {
        public enum estado { Marchando, Parado };

        //Campos
        double _velocidadMaxima;
        estado _estado;

        //Constructores
        public Coche() : base()
        {
            this._velocidadMaxima = 0;
            this._estado = estado.Parado;
        }
        public Coche(double _velocidadMaxima, estado _estado,  string nombre, int nRuedas, ConsoleColor color, tipoTraccion tipo) 
            : base(nombre, nRuedas, color, tipo)
        {
            this._velocidadMaxima = _velocidadMaxima;
            this._estado = _estado;
        }

        //Propiedades
        private estado Estado //De solo lectura?
        {
            get { return _estado; }
        }

        public double VelocidadMaxima
        {
            get { return _velocidadMaxima; }
            set
            {
                if (value < 0) //La velocidad tampoco puede ser negativa 
                    _velocidadMaxima = 0; //value = 0;
                else
                    _velocidadMaxima = value;
            }
        }

        //Métodos
        public override string ToString()
        {
            return "DATOS DEL COCHE" + "\n" +
                   "===============" + "\n\n" + base.ToString() +
                   "          ESTADO: " + _estado + "\n" +
                   "VELOCIDAD MÁXIMA: " + _velocidadMaxima + "\n";
        }

    }
}
