using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_InterfazDefinidoUsuario_08_02
{
    public delegate void Agenda(string s);

    interface IPrueba
    {
        void Mostrar(); //Método mostrar
        string Anotacion { get; set; } //Propiedad de lectura-escritura
        string this[int indice] { get; } //Indizador -> Propiedad de lectura
        event Agenda Anadido; //Evento
    }

    class Agenda : IPrueba
    {

        public void Mostrar()
        {
            throw new NotImplementedException();
        }

        string IPrueba.Anotacion
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string this[int indice]
        {
            get { throw new NotImplementedException(); }
        }

        public event Agenda Anadido;
    }
}
