﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POO_GestionPERSONAS_17_01
{
    public class Persona
    {

        #region Campos
        //Campos
        private int _id;
        private string _nombre;
        private string _apellidos;
        private DateTime _fechaNacimiento;
        private double _estatura;
        #endregion 

        #region Constructores
        //Constructores:
        public Persona()
        {
            //Vacío
            this._nombre = "IES";
            this._apellidos = "Portada Alta";
            this._fechaNacimiento = DateTime.Parse("01/01/2000");
            this._estatura = 0.0;
        }
        public Persona(string nombre, string apellidos, DateTime fechaNacimiento, double estatura)
        {
            //Con datos
            this._nombre = nombre;
            this._apellidos = apellidos;
            this._fechaNacimiento = fechaNacimiento;
            this._estatura = estatura;
        }
        #endregion

        #region Propiedades
        //Propiedades:
        public int Id //Esto puede sacarse -> Botón derech en el campo -> Refactorizar -> Encapsular campo
        {
            get{ return _id; }
            set
            {
                _id = value;
            }
        }       
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

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public double Estatura
        {
            get { return _estatura; }
            set { _estatura = value; }
        }
        #endregion 

        #region Métodos
        //Métodos
        /// <summary>
        /// Método que muestra una línea con los datos de la persona
        /// </summary>
        /// <returns>String con los datos de la persona</returns>
        public override string ToString()
        {
            return "| " + _id.ToString().PadLeft(6) + " | " +
                _apellidos.PadRight(30) + " | " + _nombre.PadRight(15) +
                " | " + _fechaNacimiento.ToShortDateString() + " | ";
        }
        #endregion 
    }
}
