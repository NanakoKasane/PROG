using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Interfaces_IPresentable_12_02
{
    class Triangulo : IPresentable
    {
        //Campos
        double _base;
        double _altura;

        //Constructor
        public Triangulo(double _base, double _altura)
        {
            this._base = _base;
            this._altura = _altura;
        }

        //Propiedad Area de solo lectura
        public double Area
        {
            get { return (_altura*_base)/2;}
        }

        //Método que implementa la interfaz IPresentable
        /// <summary>
        /// Escribe los valores del triángulo
        /// </summary>
        public void Presentar()
        {
            Console.WriteLine("     Base: {0}", _base);
            Console.WriteLine("     Altura: {0}", _altura);
            Console.WriteLine("     Área: {0}", Area);
        }
    }
}
