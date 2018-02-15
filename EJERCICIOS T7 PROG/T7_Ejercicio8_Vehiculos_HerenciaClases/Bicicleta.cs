using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio8_Vehiculos_HerenciaClases
{
    //Abstracta porque no vas a crear un objeto bicicleta, sino que crearás de uno de sus 2 tipos que heredan de ella
    abstract class Bicicleta : Vehiculo
    {
        //Campos
        double _precio;
        DateTime _fechaCompra;

        //Constructores
        public Bicicleta() : base()
        {
            this._precio = 0;
            this._fechaCompra = DateTime.Parse("01/01/2018");
        }
        public Bicicleta(double precio, DateTime fechaCompra, string nombre, int numeroRuedas, ConsoleColor color, tipoTraccion tipo) 
            : base(nombre, numeroRuedas, color, tipo)
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

        //Métodos
        public override string ToString()
        {
            return  base.ToString() +
                    "         PRECIO: " + _precio + "\n" +
                    "FECHA DE COMPRA: " + _fechaCompra + "\n";
        }
    }
}
