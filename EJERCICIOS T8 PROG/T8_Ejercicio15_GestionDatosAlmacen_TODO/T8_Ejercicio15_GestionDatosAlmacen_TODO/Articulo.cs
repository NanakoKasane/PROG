using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T8_Ejercicio15_GestionDatosAlmacen_TODO
{
	class Articulo : IComparable
	{
		#region Campos
		int cod_articulo; //longitud 3, AUTO numérico. No podrá ser mayor de 999
		string nombre_articulo; //longitud max 15
		double precio; //No podrá ser negativo
		double pvp; //Se calcula. 25% del precio. No negativo
		string comentario; //longitud max 50. No se muestra en listados, solo en las consultas
		#endregion 

		#region Propiedades
		public int Cod_articulo
		{
			get { return cod_articulo; }
			set
			{
				if (value > 999)
					throw new Exception(); //Tienen longitud 3 los códigos, así que no podrán ser más de 999
				else
					cod_articulo = value; 
			}
		}

		public string Nombre_articulo
		{
			get { return nombre_articulo; }
			set
			{
				if (value.Length > 15)
					nombre_articulo = value.Substring(0, 15);
				else
					nombre_articulo = value; 
			}
		}

		public double Precio
		{
			get { return precio; }
			set {
					if (value < 0)
						precio = 0;
					else
						precio = value; 
				}
		}

		public double Pvp
		{
			get { return pvp; }
			set {
					if (value < 0)
						pvp = 0;
					else
						pvp = value; 
				}
		}

		public string Comentario
		{
			get { return comentario; }
			set {
				if (value.Length > 50) //Si le pasas más de 50, lo corta a 50
					comentario = value.Substring(0, 50);
				else
					comentario = value; 
				}
		}
		#endregion 

		#region Constructores
		public Articulo()
		{
			this.Nombre_articulo = "ArtículoPrueba";
			this.Precio = 0.00;
			this.Comentario = "Sin comentarios";

			this.Pvp = (25.00 / 100.00 * precio);
		}

		public Articulo(string nombre, double precio, string comentario)
		{
			this.Nombre_articulo = nombre;
			this.Precio = precio;
			this.Comentario = comentario;

			this.Pvp = (25.00/100.00 * precio);
		}
		#endregion 

		#region Métodos ToString()
		public override string ToString()
		{
			return "| Código: " + string.Format("{0:D3}", Cod_articulo) + " | Nombre: " + nombre_articulo.PadRight(15) + 
				" | Precio: " + precio.ToString().PadLeft(8) + " | Pvp: " + pvp.ToString().PadLeft(8) + " | "; 
		}

		/// <summary>
		/// Sobrecarga de ToString() para mostrar o no el comentario 
		/// </summary>
		/// <param name="mostarComentario">bool para mostrar o no el comentario. Con true lo muestra</param>
		/// <returns>String sin el comentario si el parámetro es false. String con el comentario si el parámetro es true </returns>
		public string ToString(bool mostarComentario) //Sobrecarga de ToString() para mostrar el comentario si se le pasa true
		{
			if (!mostarComentario)
				this.ToString();
	
			return this.ToString() + "\n\nComentario: " + comentario.PadRight(50);
		}
		#endregion

		#region Equals
		public override bool Equals(object obj)
		{
			Articulo articulo = (Articulo)obj;
			if (articulo.nombre_articulo == this.nombre_articulo && articulo.precio == this.precio)
				return true;
			return false;
		}
		#endregion 

		#region CompareTo (Para usar Sort)
		public int CompareTo(object objeto)
		{
			Articulo articulo = (Articulo)objeto;
			if (Equals(objeto)) //(articulo.nombre_articulo == this.nombre_articulo && articulo.precio == this.precio)
				return 0; //Son iguales
			if (articulo.cod_articulo < this.cod_articulo)
				return 1;
			//if (articulo.cod_articulo > this.cod_articulo)
			return -1;

		}
		#endregion 

	}

	class OrdenarPorNombre : IComparer<Articulo>
	{
		#region Compare (Para usar Sort con otro criterio)
		public int Compare(Articulo x, Articulo y)
		{
			return string.Compare(x.Nombre_articulo, y.Nombre_articulo);
		}
		#endregion 
	}
}
