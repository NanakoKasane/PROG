using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Interfaces_IPresentable_12_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangulo t = new Triangulo(10, 2.3);
            Proveedor p = new Proveedor("Juan", "Velazquez Diaz", 10);
            p.onPresentar += p_onPresentar; //Apuntarse al evento

            Presentar(t);
            Presentar(p);

        }

        static void p_onPresentar(object sender, EventArgs e)
        {
            Console.Write("Voy a presentar al proveedor");
            Console.ReadLine();
        }

        public static void Presentar(IPresentable obj)
        {
            obj.Presentar();
            Console.WriteLine(" Eso es todo ...");
            Console.ReadLine();

        }
    }
}
