using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio6_GestionFechas
{
    public class FechaNoValidaException : Exception { };
    public enum Meses { Enero = 1, Febrero, Marzo, Abril, Mayo, Junio, Julio, Agosto, Septiembre, Octubre, Noviembre, Diciembre }

    class CFechas
	{
		#region Campos
		private int _dia;
        private int _mes;
        private int _anio;

		//private bool _correcto; //Lo quito y lo cambio por la excepción creada, para mejora de la clase CFechas 
		#endregion

		#region Propiedades
		public int Dia
        {
            get { return _dia; }
            set {
                    //No hay días negativos ni que sean 0. 
                    if (value <= 0)
                    {
                        throw new FechaNoValidaException(); //_correcto = false; 
                    }
                    //Mes de Febrero, caso especial, que tiene diferentes días si es el año bisiesto o no:
                    if (_mes == (int)Meses.Febrero && value > 28) 
                    {
                        if (!EsBisiesto(_anio) && value > 28)//Si un año no es bisiesto Febrero tendrá 28 días y no podrá tener más de 28
                            throw new FechaNoValidaException(); // _correcto = false; 
                        else if (EsBisiesto(_anio) && value > 29) //Si un año es bisiesto Febrero tendrá 29 días
                            throw new FechaNoValidaException(); //_correcto = false;
                    }
                    //Meses de 30 días:
                    else if (MesesDe30Dias() && value > 30) //No pueden tener más de 30 días
					    throw new FechaNoValidaException(); //_correcto = false; 
                    //Meses de 31 días. También valdría con un else, ya que los meses que no son de 30 días serán de 31
                    else if (value > 31 && MesesDe31Dias())
					    throw new FechaNoValidaException(); //_correcto = false; 

                    else
                    {
                        //_correcto = true;
                        _dia = value;
                    }
                }
        }

		public int Mes
		{
			get { return _mes; }
			set
			{
				if (value < (int)Meses.Enero) //El mes no puede ser negativo ni menor que Enero (que es el mes 1)
					throw new FechaNoValidaException();//_correcto = false;
				if (value > (int)Meses.Diciembre) //El mes no puede ser mayor de 12 (Diciembre)
					throw new FechaNoValidaException();//_correcto = false;
				else
				{
					//_correcto = true;
					_mes = value;
				}
			}
		}

		public int Anio // Años pueden ser negativos, en caso de ser "Antes de Cristo". ¿Pero debería poner un máximo?
		{
			get { return _anio; }
			set { _anio = value; }
		}

        //public bool Correcto
        //{
        //    get { return _correcto; }
        //    set { _correcto = value; }
		//}
		#endregion 

		#region Constructor
		public CFechas(int anio, int mes,  int dia)
        {
			//Aquí tengo que asignarlo a las propiedades y no a los campos para que haga las comprobaciones de si son correctos al crear la fecha
			this.Anio = anio;
			this.Mes = mes;
			this.Dia = dia;

            //if (Dia == 0)
            //    thow new FechaNoValidaException(); //_correcto = false;
        }
		#endregion


		#region Métodos
		public override string ToString()
        {
            return string.Format("{0} de {1} de {2}", _dia, (Meses)(_mes), _anio);
        }

		public string EscribirFechaCorta()
		{
			return string.Format("{0:D2}/{1:D2}/{2:D2}", _dia, _mes, _anio);
		}
        /// <summary>
        /// Función que comprueba si el año es o no bisiesto
        /// </summary>
        /// <param name="año">Año a comprobar si es o no bisiesto</param>
        /// <returns>Devuelve true si el año es bisiesto y falso si no lo es</returns>
        public bool EsBisiesto(int anio)
        {
            if (anio % 400 == 0)
                return true;
            if (anio % 100 == 0)
                return false;
            if (anio % 4 == 0)
                return true;
            else
                return false;
		}
		/// <summary>
		/// Método que devuelve true si el mes dado tiene 31 días
		/// </summary>
		/// <returns></returns>
		public bool MesesDe31Dias()
		{
			if (_mes == (int)Meses.Enero || _mes == (int)Meses.Marzo || _mes == (int)Meses.Mayo ||
				_mes == (int)Meses.Julio || _mes == (int)Meses.Agosto || _mes == (int)Meses.Octubre || _mes == (int)Meses.Diciembre)
				return true;
			else
				return false;
		}
		/// <summary>
		/// Método que devuelve true si el mes dado tiene 30 días
		/// </summary>
		/// <returns></returns>
		public bool MesesDe30Dias()
		{
			if (_mes == (int)Meses.Abril || _mes == (int)Meses.Junio || _mes == (int)Meses.Septiembre || _mes == (int)Meses.Noviembre)
				return true;
			else
				return false;
		}

		#endregion 
	}
}
