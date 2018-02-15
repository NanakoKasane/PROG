using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Metodos_Clase_Herencia_15_01
{
    class Program
    {
        static void Main(string[] args)
        {
            LienzoImpresora lp = new LienzoImpresora();
            lp.Dibuja();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// Clase base que sirve para dibujar en pantalla
    /// </summary>
    public class Lienzo
    {
        public string _color;
        public int _x;
        public int _y;
        public int _alto;
        public int _ancho;

        public Lienzo()
        {
        }
        public Lienzo(int x, int y, int alto, int ancho) //Los constructores NO SE HEREDAN
        {
            //código
        }

        //Aquí los miembros --> Métodos, propiedades...
        public void Dibuja()
        {
            Console.WriteLine("Preparando LIENZO");
        }
    }

    /// <summary>
    /// Clase derivada para dibujar en la impresora
    /// </summary>
    public class LienzoImpresora : Lienzo
    {
        public LienzoImpresora() : base() { }
        public LienzoImpresora(int x, int y, int alto, int ancho, string color):base(x, y, alto, ancho)
        {
            //Es decir, llena lo demás el constructor de arriba pero el color hay que añadirlo
            _color = color;
        }
        public new void Dibuja()
        {
            base.Dibuja(); //Llama al método base
            Console.WriteLine("Dibujando en la IMPRESORA");
        }
    }

}
