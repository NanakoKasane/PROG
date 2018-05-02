using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------
using System.ComponentModel;

namespace Marina.WPF_DataContext_Personas_02_05
{
    class Persona : INotifyPropertyChanged
    {
        string _nombre;
        string _apellidos;
        DateTime _fechaNacimiento;
        double _estatura;

        public Persona()
        {
            _nombre = "Eliseo";
            _apellidos = "Moreno";
            _fechaNacimiento = DateTime.Parse("01/01/1970");
            _estatura = 0.0;
        }

        public Persona(string nombre, string apellidos, DateTime fechaNac, double estatura)
        {
            this._nombre = nombre;
            this._apellidos = apellidos;
            this._fechaNacimiento = fechaNac;
            this._estatura = estatura;
        }

        #region Propiedades
        public string Nombre
        {
            get { return _nombre; }
            set {   _nombre = value;
                    MetodoAuxiliarCambio("Nombre");
                }
        }
        public string Apellidos
        {
            get { return _apellidos; }
            set
            {
                _apellidos = value;
                MetodoAuxiliarCambio("Apellidos");
            }
        }
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        public double Estatura
        {
            get { return _estatura; }
            set { _estatura = value; }
        }
        #endregion 

    
        public event PropertyChangedEventHandler PropertyChanged;
        private void MetodoAuxiliarCambio(string propagarPropiedad) // onPropertyChanged
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propagarPropiedad));
        }

    }
}
