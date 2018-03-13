using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace T8_Ejercicio15_GestionDatosAlmacen_TODO
{
	public delegate void miDelegado();

	class ListaArticulos : IEnumerable<Articulo>, IEnumerator<Articulo>
	{
		//Campos
		static public List<Articulo> _listaArticulos = new List<Articulo>();
		int codigo;
		int posicion = -1;
		public event miDelegado onEvento;
		//bool borrado = false;



		//Métodos
		#region Método Alta Artículo
		public bool AltaArticulo(Articulo articulo)
		{
			if (codigo > 999)
				return false;

			for (int i = 0; i < _listaArticulos.Count; i++)
			{
				if (articulo.Equals(_listaArticulos[i])) //Son iguales si tienen mismo nombre y precio (reescrito Equals). No puedes añadir 2 iguales
				{
					return false;
				}
			}
			//if (onEvento != null)
			//	onEvento();
			_listaArticulos.Add(articulo);
			articulo.Cod_articulo = ++codigo;
			return true;
		}
		#endregion 

		#region Método Baja Artículo
		public bool BajaArticulo(int cod)
		{
			ConsoleKeyInfo tecla;
			for (int i = 0; i < _listaArticulos.Count; i++)
			{
				if (_listaArticulos[i].Cod_articulo == cod)
				{
					Console.Write("\n¿Está seguro de que desea eliminar el artículo? S/N: ");
					tecla = Console.ReadKey();
					if (tecla.Key == ConsoleKey.S)
					{
						_listaArticulos.Remove(_listaArticulos[i]);
						return true;
					}
				}
			}
			return false; //No existe el código así que no se ha podido dar de baja ningún artículo
		}
		#endregion 

		#region Métodos Listar
		public void ListarArticulosPorCodigo()
		{
			_listaArticulos.Sort();

			Console.WriteLine("LISTA DE ARTÍCULOS POR CÓDIGO");
			Console.WriteLine("=============================\n");

			Console.WriteLine("-".PadLeft(76, '-'));
			foreach (Articulo articulo in _listaArticulos)
			{
				//if (!articulo.borrado)
				Console.WriteLine(articulo.ToString());
			}
			Console.WriteLine("-".PadLeft(76, '-'));
		}
		public void ListarArticulosPorNombre()
		{
			OrdenarPorNombre ordenarNombre = new OrdenarPorNombre();
			_listaArticulos.Sort(ordenarNombre);

			Console.WriteLine("LISTA DE ARTÍCULOS POR NOMBRE");
			Console.WriteLine("=============================\n");

			Console.WriteLine("-".PadLeft(76, '-'));
			foreach (Articulo articulo in _listaArticulos)
			{
				//if(!articulo.borrado)
				Console.WriteLine(articulo.ToString());
			}
			Console.WriteLine("-".PadLeft(76, '-'));

		}

		//Para practicarlo, no lo pide el ejercicio
		public void ListarPaginado(string titulo)
		{
			int anchoListado = 76;
			int nLineasPorPagina = 20;
			int lineaActual = 0;
			int paginaActual = 1;
			int nPaginas = (int)Math.Ceiling((double)_listaArticulos.Count / (double)nLineasPorPagina);
			

			Console.CursorLeft = anchoListado / 2 - titulo.Length / 2;
			Console.WriteLine(titulo);
			foreach (Articulo articulo in _listaArticulos)
			{
				if (lineaActual == 0)
					Console.WriteLine("-".PadLeft(anchoListado, '-'));
				lineaActual++;
				Console.WriteLine(articulo.ToString());

				if (lineaActual == nLineasPorPagina)
				{
					Console.WriteLine("-".PadLeft(anchoListado, '-'));
					Console.WriteLine("\t\t\t\t\t\tPágina {0} de {1}", paginaActual, nPaginas);
					Console.ReadLine();
					Console.Clear();
					paginaActual++;
					lineaActual = 0;
				}
			}

			
			//Última página
			if (paginaActual <= nPaginas)
			{
				Console.WriteLine("-".PadLeft(anchoListado, '-'));
				Console.WriteLine("\t\t\t\t\t\tPágina {0} de {1}", paginaActual, nPaginas);
			}


		}

		#endregion 

		#region Sobrecarga operador e Indizadores
		static public bool operator +(ListaArticulos lista, Articulo articulo)
		{
			lista.AltaArticulo(articulo);
			return true;
		}
		
		public Articulo this[int indice]
		{
			get { return _listaArticulos[indice]; } //De solo lectura
		}
		#endregion 

		#region Métodos del Interfaz para usar foreach
		public IEnumerator<Articulo> GetEnumerator()
		{
			return this;
		}


		public Articulo Current
		{
			get { return _listaArticulos[posicion]; }
		}

		public void Dispose()
		{
			;
		}

		public bool MoveNext()
		{
			if (posicion < _listaArticulos.Count - 1)
			{
				posicion++;
				return true;
			}
			return false;

		}

		public void Reset()
		{
			posicion = -1;
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this;
		}

		object System.Collections.IEnumerator.Current
		{
			get { return _listaArticulos[posicion]; }
		}
		#endregion 

	}
}
