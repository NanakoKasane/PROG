using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio7_InterfazICarrera
{

    public class EdadMinimaDeportistaException : Exception { };

    public class Deportista : ICarrera
    {
        #region Campos
        private string _nombre;
        private string _apellidos;
        private int _codigo = 1;
        private DateTime _fechaNacimiento;    
        public DateTime fechaNacimientoMin = new DateTime(2002, 12, 31); 

        #endregion 

        #region Constructor
        public Deportista()
        {
            this._nombre = "Fulano";
            this._apellidos = "Expósito Expósito";
            this._fechaNacimiento = DateTime.Parse("31/12/2002");

        }
        public Deportista(string nombre, string apellidos, DateTime fechaNacimiento) //El código no se le pasa, se incrementará automáticamente
        {
            this._nombre = nombre;
            this._apellidos = apellidos;
            this._fechaNacimiento = fechaNacimiento;
        }

        #endregion 

        #region Propiedades
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set {
                    if (value < fechaNacimientoMin)
                        throw new EdadMinimaDeportistaException();
                    else
                        _fechaNacimiento = value; 
                }
        }
        #endregion 


        public override string ToString()
        {
            return "|" + _codigo.ToString().PadLeft(8) + "| " + _nombre.PadRight(15) + "| " 
                + _apellidos.PadRight(25) +  "| " + _fechaNacimiento.ToShortDateString() + " |";
        }

		//Método que implementa la interfaz ICarrera
        public void Correr()
        {
            Console.WriteLine("\n" + this.ToString());
            Console.WriteLine("El corredor de fondo está en ello...");
        }
    }

    public class DeportistaAleatorio
    {
        static string[] nombres = { "Pepe", "Hector", "Juan", "Manuel", "Alejandro", "Sandra", "Maria", "Marina",
                                  "Raul", "Rodrigo", "Alfonso", "Alfred", "Amaia", "Aitana"};
        static string[] apellidos = { "Gil", "Muñoz", "Rodriguez", "Sanchez", "Ganadora", "García", "Moreno", "Bilal", "Espinosa",
                                    "Gálvez", "Mudarra", "López", "Expósito"};
        static Random rnd = new Random();

        static public Deportista ObtenerDeportistaAleatorio()
        {
            Deportista d = new Deportista(NombreAleatorio(), ApellidoAleatorio() + " " + ApellidoAleatorio(), FechaNacimientoAleatoria());
            return d;
        }

		#region Métodos privados 
		static string NombreAleatorio()
        {
            int posicion = rnd.Next(nombres.Length);
            return nombres[posicion];
        }
        static string ApellidoAleatorio()
        {
            int posicion = rnd.Next(apellidos.Length);
            return apellidos[posicion];
        }
        static DateTime FechaNacimientoAleatoria()
        {
            int random = rnd.Next(365 * 16, 365 * 50); //Fecha aleatoria que sea entre mínimo tener 16 años (a dias) y máximo tener 50 
            
            DateTime fecha = DateTime.Now - TimeSpan.FromDays(random);
            return fecha;
		}
		#endregion 

	}

    public class ListaDeDeportistas
    {
        private int _codigo = 1;
        private List<Deportista> _listaDeportistas;

        #region Propiedades
        public List<Deportista> ListaDeportistas
        {
          get { return _listaDeportistas; }
          set { _listaDeportistas = value; }
        }

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        #endregion 

        public ListaDeDeportistas()
        {
            this._listaDeportistas = new List<Deportista>();
            
        }

        #region Métodos
        public void AnadirDeportista(Deportista d)
        {
            d.Codigo = this._codigo++;
            _listaDeportistas.Add(d);
        }

        public void AnadirDeportistaAlea(int cantidadAnadir)
        {
            for (int i = 0; i < cantidadAnadir; i++)
            {
                Deportista d = DeportistaAleatorio.ObtenerDeportistaAleatorio();
                _listaDeportistas.Add(d);
                d.Codigo = this._codigo++;               
            }

        }

        public void ListarPaginado(string titulo)
        {
			int nLineasPorPagina = 20;
			int nPaginaActual = 1;
			int nLineaActual = 0;
			int nPaginasTotales = _listaDeportistas.Count / nLineasPorPagina;
			int anchoListado = 67;
			//ConsoleKey salir = ConsoleKey.Escape;

			
			foreach (Deportista deportistaTmp in _listaDeportistas)
			{
				if (nLineaActual == 0)
				{
					Console.CursorLeft = (anchoListado / 2) - (titulo.Length / 2);
					Console.WriteLine(titulo.ToUpper());
					Console.WriteLine("=".PadLeft(anchoListado, '='));
				}
				
					if (nLineaActual < nLineasPorPagina)
					{
						Console.WriteLine(deportistaTmp.ToString());
						nLineaActual++;						

					}
				
				if (nLineaActual == nLineasPorPagina)
				{
					Console.WriteLine("=".PadLeft(anchoListado, '='));
					Console.WriteLine("Página {0} de {1}", nPaginaActual, nPaginasTotales);				
					nPaginaActual++;
					Console.ReadLine(); //ReadKey();
					Console.Clear();
					nLineaActual = 0;
				}

			}

        }

        #endregion 


    }
}
