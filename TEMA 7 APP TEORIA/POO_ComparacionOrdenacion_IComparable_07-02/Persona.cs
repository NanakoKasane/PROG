using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.POO_ComparacionOrdenacion_IComparable_07_02
{
    public class Persona : IComparable<Persona>
    {
        string nombre;
        string apellidos;
        int codigo;

        /// <summary>
        /// Nombre de la Persona
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        /// <summary>
        /// Apellido de la Persona
        /// </summary>
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        /// <summary>
        /// Código de la Persona
        /// </summary>
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        /// <summary>
        /// Construye una Persona
        /// </summary>
        /// <param name="apellido"></param>
        /// <param name="nombre"></param>
        /// <param name="codigo"></param>
        public Persona(string apellido, string nombre, int codigo)
        {
            this.nombre = nombre;
            this.apellidos = apellido;
            this.codigo = codigo;
        }
        /// <summary>
        /// Muestra los datos de una Persona por pantalla
        /// </summary>
        /// <returns>String con los datos de la persona en orden: código, nombre, apellidos</returns>
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", codigo, nombre, apellidos);
        }

        //Lo que devuelve -> si x > y -> 1.
        //Si son iguales, devolverá un 0
        //Si x < y -> -1
        /// <summary>
        /// Ordena la persona por su código
        /// </summary>
        /// <param name="otra"></param>
        /// <returns></returns>
        public int CompareTo(Persona otra) 
        {
            //Pondrás criterio a ordenar (por codigo en este caso)
            if (this.codigo > otra.codigo) return 1;
            if (this.codigo < otra.codigo) return -1;
            else //Cuando son iguales
                return 0;
   
        }

        /// <summary>
        /// Ordena la Persona por Nombre
        /// </summary>
        public class OrdenaNombre : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                return string.Compare(x.nombre, y.nombre); // string.Compare compara string y devuelve 1, -1 o 0. Los compara por el ASCII
            }
        }

        /// <summary>
        /// Ordena la Persona por Apellido
        /// </summary>
        public class OrdenaApellido : IComparer<Persona>
        {

            public int Compare(Persona x, Persona y)
            {
                return string.Compare(x.apellidos, y.apellidos);
            }
        }

    }
}
