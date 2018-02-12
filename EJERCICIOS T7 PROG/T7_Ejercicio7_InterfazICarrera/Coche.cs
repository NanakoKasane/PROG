using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio7_InterfazICarrera
{
    public class Coche : ICarrera
    {
        #region Campos
        private string _marca;
        private string _modelo;
        private string _matricula;
        private DateTime _fechaCreacion;
        #endregion 

        #region Propiedades
        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }
        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }
        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }
        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }
        #endregion 

        #region Constructores
        public Coche()
        {
            this._marca = "Citroen";
            this._modelo = "C4";
            this._matricula = "1234567A";
            this._fechaCreacion = DateTime.Parse("01/01/2001");

        }
        public Coche(string marca, string modelo, string matricula, DateTime fechaCreacion)
        {
            this._marca = marca;
            this._modelo = modelo;
            this._matricula = matricula;
            this._fechaCreacion = fechaCreacion;
        }

        #endregion 

        #region Métodos
        public override string ToString()
        {
            return "|" + _matricula.PadLeft(15) + " | " + _marca.PadRight(15) + "| " + _modelo.PadRight(10) + "| " 
                + _fechaCreacion.ToShortDateString() + " |";
        }

        #endregion 

    
		//Método que implementa la interfaz ICarrera
        public void Correr()
        {
            Console.WriteLine("\n" + this.ToString());
            Console.WriteLine("El coche está en marcha");
        }

    }

}
