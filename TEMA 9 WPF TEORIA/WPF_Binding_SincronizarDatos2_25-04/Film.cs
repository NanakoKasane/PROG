using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------
using System.ComponentModel;

namespace Marina.WPF_Binding_SincronizarDatos_23_04
{        
    
    public enum Genero { Mafia, Drama, Catastrofismo, Aventuras, Comedia, Oeste, Ciencia_Ficcion };

    class Film : Notificador
    {
        string _titulo;
        Genero _genero;
        bool? _oscar; // Lo mismo que poner Nullable<bool>
        double _calificacion;

        #region Propiedaes
        public string Titulo
        {
            get { return _titulo; }
            set { 
                    if (_titulo != value) // si cambia el valor del título
                        onPropertyChanged("Titulo"); // Ahora propagaría el título

                    _titulo = value;
                }
        }

        public Genero Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public bool? Oscar
        {
            get { return _oscar; }
            set { _oscar = value; }
        }

        public double Calificacion
        {
            get { return _calificacion; }
            set { _calificacion = value; }
        }
        #endregion 

        // Tiene que tener un constructor por defecto vacío para poder usarlo en XML
        public Film() { }
        public Film(string titulo, Genero genero, bool? oscar, double calificacion)
        {
            this._titulo = titulo;
            this._genero = genero;
            this._oscar = oscar;
            this._calificacion = calificacion;
        }

    }

    /// <summary>
    /// Clase usada para informar de los cambios del valor de las propiedades 
    /// </summary>
    public class Notificador : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; // Del interfaz INotifyPropertyChanged, para que si cambies algo de la clase se propaguen los cambios a los elementos enlazados

        // Método del evento:
        protected void onPropertyChanged(string nombre)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nombre));

            
        }
    }
}
