using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio8_Vehiculos_HerenciaClases
{
    class Montana : Bicicleta
    {
        //Campos
        string _tipoAmortiguacion;
        bool _kitReparacion;
        double _diametroRueda;

        //Constructores
        public Montana() : base()
        {
            this._tipoAmortiguacion = "";
            this._kitReparacion = true;
            this._diametroRueda = 0;
        }
        public Montana(string tipoAmortiguacion, bool kitReparacion, double diametroRueda, double precio, DateTime fechaCompra, string nombre, 
            int numeroRuedas, ConsoleColor color, tipoTraccion tipo) : base(precio, fechaCompra, nombre, numeroRuedas, color, tipo)
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
            set
            {
                if (value < 0) //El diámetro no podrá ser negativo
                    _diametroRueda = 0;
                else
                    _diametroRueda = value;
            }
        }
        
        //Métodos
        public override string ToString()
        {
            return "DATOS DE LA BICICLETA DE MONTAÑA" + "\n" +
                   "================================" + "\n\n" + base.ToString() +
                   "  TIPO DE AMORTIGUACION: " + _tipoAmortiguacion + "\n" +
                   "      KIT DE REPARACIÓN: " + _kitReparacion.ToString() + "\n" +
                   "   DIÁMETRO DE LA RUEDA: " + _diametroRueda + "\n";
        }

    }
}
