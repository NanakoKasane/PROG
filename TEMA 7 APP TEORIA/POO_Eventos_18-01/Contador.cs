using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------------------------
using System.Threading;

namespace POO_Eventos_18_01
{
    class Contador
    {
        //Crear un delegado:
        public delegate void CambiaContador();

        //Crear un evento:
        public event CambiaContador cambioValor;
        // ámbito + event + delegado + nombre evento;

        public event CambiaContador cambioValor5;


        //Campo
        int _contador;
        bool _iniciar;
        int _fin;

        //Constructor
        public Contador()
        {
            _contador = 0;
            _iniciar = false;
            _fin = 100;
        }
        
        //Propiedad
        public bool Iniciar
        {
            get { return _iniciar; }
            set { _iniciar = value; }
        }

        //Método
        public void VerContador()
        {
            if (!_iniciar)
                return;

            for (int i = 0; i < _fin; i++)
            {
                Thread.Sleep(500);
                Console.SetCursorPosition(10, 10);
                Console.WriteLine(_contador++);

                //EVENTO:
                //Quiero que me lance un evento cada vez que el valor del contador cambie.
                if (cambioValor != null) //Hay que poner esto, si no, se lanzará siempre.
                    //Preguntas si hay algún evento apuntado (!= null -> no hay apuntados).
                    cambioValor(); //ejecuta el evento
                if (cambioValor5 != null && _contador % 5 == 0)
                    cambioValor5();
            }
        }
    }
}
