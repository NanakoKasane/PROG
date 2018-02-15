using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Propiedades_15_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Ficha f1 = new Ficha();
            f1.Nombre = "Pepito Grillo";
            f1.Edad = 22;
            f1.Nota = 8.2F;

            Ficha f2 = new Ficha();
            f2.Nombre = "Juanito el LOCO";
            f2.Edad = 20;
            f2.Nota = 16.3F;
            f2.NExpediente = "12091";

            Console.WriteLine(f1.ToString());
            Console.WriteLine(f2.ToString());

            Console.ReadLine();
        }
    }

    public class Ficha
    {
        //Campos
        string _nombre;
        int _edad;
        float _nota;

        //Autopropiedads
        public string NExpediente { get; set; } //Se crea la propiedad sola aunque sea un campo

        //Constructores
        public Ficha(){}
        public Ficha(string nombre, int edad, float nota)
        {
            _nombre = nombre;
            _edad = edad;
            _nota = nota;
        }

        //Propiedades
        public string Nombre //El tipo es el tipo del constructor
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
        public int Edad 
        {
            get
            {
                return _edad;
            }
            set
            {
                _edad = value;
            }
        }
        public float Nota
        {
            get
            {
                return _nota;
            }
            set
            {
                //Controlar que no ponga más de 10 de Nota
                if (value > 10)
                    value = 10;
                //Ni nota negativa
                if (value < 0)
                    value = 0;

                _nota = value;
            }
        }

        //Reescribir método ToString()
        public override string ToString() // Lo escribe solo al poner override (da 3 a elegir y al clickar ToString)
        {
            return _nombre + "; " + _edad.ToString() + "; " + _nota;

        }
    }
}
