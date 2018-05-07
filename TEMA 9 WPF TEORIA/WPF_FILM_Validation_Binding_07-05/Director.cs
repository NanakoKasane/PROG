using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------
using System.Collections.ObjectModel;

namespace Marina.WPF_Binding_SincronizarDatos_23_04
{
    class Director : Notificador
    {
        ObservableCollection<Film> _filmes = new ObservableCollection<Film>(); // No podrá ser una autopropiedad

        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }

        public ObservableCollection<Film> Filmes
        {
            get { return _filmes; }
            set { _filmes = value; }
        }

    }
}
