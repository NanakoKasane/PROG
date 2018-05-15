using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Ej18_ClaseJARRA
{
	class Jarra
	{
		int _capacidad;
		int _cantidadAgua;

		public Jarra(int capacidad, int cantidadAgua)
		{
			if (_capacidad >= 0)
			{
				this._capacidad = capacidad;
				this.CantidadAgua = cantidadAgua;
			}
		}

		#region Propiedades

		// Propiedad de solo lectura ya que en una jarra siempre será la misma capacidad
		public int Capacidad
		{
			get { return _capacidad; }
		}

		public int CantidadAgua
		{
			get { return _cantidadAgua; }
			set { 
					if (_cantidadAgua != value)
					{
						if (value <= _capacidad && value >= 0) // No podrá ser mayor el agua de la capacidad, ni menor que 0
							_cantidadAgua = value; 
					}
				}
		}
		#endregion 


		#region Métodos

		public void LlenarJarraEntera()
		{
			this._cantidadAgua = Capacidad;
		}

		public void VaciarJarraEntera()
		{
			this._cantidadAgua = 0;
		}

		public void LlenarJarraConOtra(Jarra jarra)
		{
			if (jarra != null)
			{
				int faltaRellenar = this.Capacidad - this.CantidadAgua;

				// Si ya estaba llena la jarra
				if (faltaRellenar == 0)
					return;

				// Relleno la jarra
				for (int i = this.CantidadAgua; i < this.Capacidad; i++)
				{
					if (jarra._cantidadAgua > 0)
					{
						this.CantidadAgua++;
						jarra._cantidadAgua--;
					}
				}

			}
		}

		public override string ToString()
		{
			return string.Format("Cantidad Agua: {0}. Capacidad: {1}", this.CantidadAgua, this.Capacidad);
		}

		#endregion 


	}
}
