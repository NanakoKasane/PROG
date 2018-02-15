using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio8_Vehiculos_HerenciaClases
{
    class Vehiculo
    {        
        public enum tipoTraccion { Trasera, Delantera, Integral };

        //Campos
        string _nombre;
        int _numeroRuedas;
        ConsoleColor _color;
        tipoTraccion _tipoTraccion;


        //Constructores
        public Vehiculo()
        {
            this._nombre = "Vehiculo";
            this._numeroRuedas = 1;
            this._color = ConsoleColor.White;
            this._tipoTraccion = tipoTraccion.Delantera;
        }
        public Vehiculo(string nombre, int numeroRuedas, ConsoleColor color, tipoTraccion tipo)
        {
            this._nombre = nombre;
            this._numeroRuedas = numeroRuedas;
            this._color = color;
            this._tipoTraccion = tipo;
        }

        //Propiedades
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int NumeroRuedas
        {
            get { return _numeroRuedas; }
            set {
                    if (value <= 0) //Un vehículo al menos tiene que tener 1 rueda para que pueda ser considerado vehículo
                        _numeroRuedas = 1;
                    else
                        _numeroRuedas = value; 
                }
        }
        public tipoTraccion TipoTraccion //internal?
        {
            get { return _tipoTraccion; } //Solo lectura
        }
        public ConsoleColor Color
        {
            get { return _color; }
            set { _color = value; }
        }       

    }


    class Moto : Vehiculo
    {        
        public enum tipoCombustible { Mezcla, Normal };

        //Campos
        double _potencia;
        tipoCombustible _tipoCombustible;

        //Constructores
        public Moto()
        {
            this._potencia = 0;
            this._tipoCombustible = tipoCombustible.Normal;
        }
        public Moto(double _potencia, tipoCombustible _tipoCombustible)
        {
            this._potencia = _potencia;
            this._tipoCombustible = _tipoCombustible;
        }

        //Propiedades
        public double Potencia
        {
            get { return _potencia; }
            set {
                    if (value < 0) //La potencia nunca podrá ser negativa
                        _potencia = 0;
                    else
                        _potencia = value; 
                }
        }
        public tipoCombustible TipoCombustible
        {
            get { return _tipoCombustible; }
        }

    }

    class Coche : Vehiculo
    {
        public enum estado { Marchando, Parado };

        //Campos
        double _velocidadMaxima;
        estado _estado;

        //Constructores
        public Coche()
        {
            this._velocidadMaxima = 0;
            this._estado = estado.Parado;
        }
        public Coche(double _velocidadMaxima, estado _estado)
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
            set {
                    if (value < 0) //La velocidad tampoco puede ser negativa 
                        _velocidadMaxima = 0; //value = 0;
                    else
                        _velocidadMaxima = value; 
                }
        }


    }


}
