using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio8_Vehiculos_HerenciaClases
{
    class Moto : Vehiculo
    {
        public enum tipoCombustible { Mezcla, Normal };

        //Campos
        double _potencia;
        tipoCombustible _tipoCombustible;

        //Constructores
        public Moto() : base()
        {
            this._potencia = 0;
            this._tipoCombustible = tipoCombustible.Normal;
        }
        public Moto(double _potencia, tipoCombustible _tipoCombustible, string nombre, int nRuedas, ConsoleColor color, tipoTraccion tipo) 
            : base(nombre, nRuedas, color, tipo)
        {
            this._potencia = _potencia;
            this._tipoCombustible = _tipoCombustible;
        }

        //Propiedades
        public double Potencia
        {
            get { return _potencia; }
            set
            {
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

        //Métodos
        public override string ToString()
        {
            return "DATOS DE LA MOTO" + "\n" +
                   "================" + "\n\n" + base.ToString() +
                   "        POTENCIA: " + _potencia + "\n" +
                   "TIPO COMBUSTIBLE: " + _tipoCombustible + "\n";
        }

    }
}
