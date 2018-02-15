using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ClonacionProfunda_05_02
{
    public class Punto
    {
        public int x;
        public int y;

        public Punto()
        {
            x = 0;
            y = 0;
        }

        public Punto(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return string.Format("({0}-{1})", x, y); //Para aplicar formato como si fuera un Console.WriteLine
        }

        //Debería reescribirse el Equals() en vez de crear un método propio de comparación:
        public bool SonIguales(Punto otro)
        {
            if (otro == null)
                return false;
            else
                return this.x == otro.x && this.y == otro.y; // 2 puntos son iguales cuando sus X e Y coinciden
        }
    }
}
