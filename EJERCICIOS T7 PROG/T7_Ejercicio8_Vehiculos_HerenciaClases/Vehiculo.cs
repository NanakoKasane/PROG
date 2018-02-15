using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio8_Vehiculos_HerenciaClases
{
    //Abstracta porque no vas a crear un vehiculo sino que crearás coches, motos, etc... La Clase Vehículo es solo para que hereden de ella 
    abstract class Vehiculo
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
       
        //Métodos
        public override string ToString() 
        {
            return  "          NOMBRE: " + _nombre + "\n" + //Todo esto realmente tendría que hacerlo en vez de con espacios/tabulaciones con .PadRight y .PadLeft
                    "NÚMERO DE RUEDAS: " + _numeroRuedas + "\n" +
                    "           COLOR: " + _color + "\n" +
                    "   TIPO TRACCIÓN: " + _tipoTraccion + "\n";
        }

    }


}
