using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Marina.WPF_Binding_SincronizarDatos_23_04
{        
    
    public enum Genero { Mafia, Drama, Catastrofismo, Aventuras, Comedia, Oeste, Ciencia_Ficcion };

    class Film : Notificador
    {
        string _titulo;
        Genero _genero;
        bool? _oscar; // Lo mismo que poner Nullable<bool>
        double _calificacion;
        Director _director;
        ObservableCollection<string> _actores = new ObservableCollection<string>();

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

        public Director DirectorFilm
        {
            get { return _director; }
            set { _director = value; }
        }
        public ObservableCollection<string> Actores
        {
            get { return _actores; }
            set { _actores = value; }
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

        public override string ToString()
        {
            return _titulo;
        }

    }

}
