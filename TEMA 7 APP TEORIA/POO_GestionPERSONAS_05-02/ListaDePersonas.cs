using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------
using System.Collections;

namespace POO_GestionPERSONAS_17_01
{
    public delegate void DelegPersona(DateTime ahora);

    /// <summary>
    /// Representa una colección de personas
    /// </summary>
    public class ListaDePersonas : IEnumerable, IEnumerator
    {
        #region Campos
        //Evento que se lanza en cada alta nueva
        public event DelegPersona EntradaOK;

        //Campos
        List<Persona> _personas = null; // Está vacía
        int _id = 100;
        public int _posicion = -1;
        #endregion 

        #region Constructores
        //Constructores
        public ListaDePersonas()
        {
            _personas = new List<Persona>();
        }
        #endregion 

        #region Sobrecarga operador +
        //Sobrecargar el operador + para añadir persona a la lista
		static public bool operator +(ListaDePersonas lista, Persona personaAnadir)
		{
            return lista.Anadir(personaAnadir);
            //personaAnadir.Id = lista._id++;
            //lista._personas.Add(personaAnadir);
            //return true;
		}
        #endregion 

        #region Dotar de Indizador
        //Dotar de indizador a la clase (de solo lectura)
        public Persona this[int indice]
        {
            get
            {
                return _personas[indice];
            }
            set
            {
                _personas.Insert(indice, value); // Inserta en la posición que le digas y desplaza lo demás.
                //También se podría hacer machacando el valor que hubiera ahí por ejemplo en vez de insertando.
            }
        }
        #endregion 

        #region Métodos de la clase
        //Métodos
        /// <summary>
        /// Añade una persona a la lista 
        /// </summary>
        /// <param name="p">La persona</param>
        /// <returns>True si se ha podido añadir. False si no.</returns>
        public bool Anadir(Persona p)
        {
            p.Id = _id++;
            _personas.Add(p);
            if (EntradaOK != null)
                EntradaOK(DateTime.Now);
            return true;
        }

        /// <summary>
        /// Añade una persona aleatoriamente a la colección de personas
        /// </summary>
        /// <returns>True si se ha podido añadir.</returns>
        public bool AnadirPersonaAlea()
        {
            Persona p = ObtenerPersonaAlea.CrearPersona();
            p.Id = _id++;
            _personas.Add(p);

            if (EntradaOK != null)
                EntradaOK(DateTime.Now);
            return true;
        }
        public bool AnadirPersonaAlea(int nPersonas)
        {
            for (int i = 0; i < nPersonas; i++)
            {
                AnadirPersonaAlea();
            }
            return true;
        }

        public void Listar()
        {
            int anchoListado = 74;
            Console.WriteLine("   L I S T A D O   D E   P E R S O N A S ");
            Console.WriteLine("=".PadRight(anchoListado, '='));
            foreach (Persona pTmp in _personas)
                Console.WriteLine(pTmp.ToString());
            Console.WriteLine("=".PadRight(anchoListado, '='));
            Console.WriteLine("   No hay más personas a listar...");
            Console.ReadLine();
        }
        public void Listar(string tituloListado)
        {
            int anchoListado = 74;
            //Para centrar el título:
            Console.CursorLeft = (anchoListado / 2) - (tituloListado.Length/2);
            Console.WriteLine(tituloListado);
            Console.WriteLine("=".PadRight(anchoListado, '='));
            foreach (Persona pTmp in _personas)
                Console.WriteLine(pTmp.ToString());
            Console.WriteLine("=".PadRight(anchoListado, '='));
            Console.WriteLine("   No hay más personas a listar...");
            Console.ReadLine();
        }

        //Listado paginado. Habrá un máximo de Bomberos por página y pasarás de página 
        public void ListarPaginado(string tituloListado)
        {                    
            int anchoListado = 74; //Ancho de las lineas del listado
            ConsoleKey salirListado = ConsoleKey.Escape; //tecla que aborta el listado
            int nLineasPorPagina = 20; // Máximo de líneas por página
            int nLineaActual = 0;
            int nPaginaActual = 1;
            int nPaginasDelListado = (int)Math.Ceiling((double)_personas.Count / (double)nLineasPorPagina);


            foreach (Persona tmp in _personas)
            {
                //Muestra la cabecera
                if (nLineaActual == 0)
                {
                    //Centrar el titulo en la cabecera 
                    Console.Clear();
                    Console.CursorLeft = (anchoListado / 2) - (tituloListado.Length / 2);
                    Console.WriteLine(tituloListado);
                    Console.WriteLine("".PadRight(anchoListado, '='));
                }

                //Mostrar cuerpo del listado
                Console.WriteLine(tmp.ToString());
                nLineaActual++;

                //Mostrar el pie de pagina
                if (nLineasPorPagina == nLineaActual && nPaginaActual < nPaginasDelListado)
                {
                    Console.WriteLine("".PadRight(anchoListado, '='));
                    Console.WriteLine("[ESC] Abortar Listado.                               Página: {0}/{1} ...", nPaginaActual++, nPaginasDelListado);
                    nLineaActual = 0;

                    //Abortar al pulsar ESC
                    if (Console.ReadKey(true).Key == salirListado)
                        return;
                }
            }               
            
            //Última página 
            Console.WriteLine("".PadRight(anchoListado, '='));            
            Console.Write(" FIN DEL LISTADO ");
            Console.WriteLine("                                    Página {0}/{1}", nPaginaActual, nPaginasDelListado);
            Console.ReadLine();               

        }
        #endregion 

        //Propiedad de solo lectura
        /// <summary>
        /// Obtiene la cantidad de personas que hay en la lista
        /// </summary>
        public int Cuantos
        {
            get { return _personas.Count; }
        }



        public object Current
        {
            get { return _personas[_posicion]; }
        }

        public bool MoveNext()
        {
            if (_posicion < _personas.Count - 1)
            {
                _posicion++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            _posicion = -1;
        }        
        
        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}
