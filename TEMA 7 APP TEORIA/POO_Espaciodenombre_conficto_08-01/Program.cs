using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cfgs1 = Marina.POO_Espaciodenombre_conficto_08_01.Espacio2;
using cfgs2 = Marina.POO_Espaciodenombre_conficto_08_01.Espacio3;
using System.Windows.Forms;


namespace Marina.POO_Espaciodenombre_conficto_08_01
{
    public static class Principal
    {
        static void Main()
        {
            cfgs1.Hola hola = new cfgs1.Hola();
            hola.Saluda();

            Button b = new Button(); //Puedes por haber referenciado y using System.Windows.Forms;
        }
    }

    namespace Espacio2
    {
        public class Hola 
        {
            public void Saluda()
            {
                Console.WriteLine("Saludo desde Espacio2.Hola...");
            }
        }
    }

    namespace Espacio3
    {
        public class Hola
        {
            public void Saluda()
            {
                Console.WriteLine("Saludo desde Espacio3.Hola...");
            }
        }
    }
}
