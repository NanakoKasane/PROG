using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio8_Vehiculos_HerenciaClases
{
    class Bicicleta : Vehiculo
    {
        //Campos
        double _precio;
        DateTime _fechaCompra;

        //Constructores
        public Bicicleta()
        {
            this._precio = 0;
            this._fechaCompra = DateTime.Parse("01/01/2018");
        }
        public Bicicleta(double precio, DateTime fechaCompra)
        {
            this._precio = precio;
            this._fechaCompra = fechaCompra;
        }

        //Propiedades
        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public DateTime FechaCompra
        {
            get { return _fechaCompra; }
            set { _fechaCompra = value; }
        }

    }

    class Paseo : Bicicleta
    {
        //Campos
        int _numeroCestas;
        string _modelo;
        string _marca;

        //Constructores
        public Paseo()
        {
            this._numeroCestas = 1;
            this._modelo = "Vintage";
            this._marca = "Monty City";
        }
        public Paseo(int numeroCestas, string modelo, string marca)
        {
            this._numeroCestas = numeroCestas;
            this._modelo = modelo;
            this._marca = marca;
        }

        //Propiedades
        public int NumeroCestas
        {
            get { return _numeroCestas; }
            set {
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

    }

    class Montana : Bicicleta
    {
        //Campos
        string _tipoAmortiguacion;
        bool _kitReparacion;
        double _diametroRueda;

        //Constructores
        public Montana()
        {
            this._tipoAmortiguacion = "";
            this._kitReparacion = true;
            this._diametroRueda = 0;
        }
        public Montana(string tipoAmortiguacion, bool kitReparacion, double diametroRueda)
        {
            this._tipoAmortiguacion = tipoAmortiguacion;
            this._kitReparacion = kitReparacion;
            this._diametroRueda = diametroRueda;
        }

        //Propiedades
        public string TipoAmortiguacion
        {
            get { return _tipoAmortiguacion; }
            set { _tipoAmortiguacion = value; }
        }

        public bool KitReparacion
        {
            get { return _kitReparacion; }
            set { _kitReparacion = value; }
        }

        public double DiametroRueda
        {
            get { return _diametroRueda; }
            set {
                    if (value < 0) //El diámetro no podrá ser negativo
                        _diametroRueda = 0;
                    else
                        _diametroRueda = value; 
                }
        }

    }
}
