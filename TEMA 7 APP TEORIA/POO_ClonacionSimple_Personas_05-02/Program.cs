using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------
using POO_GestionPERSONAS_17_01;

namespace POO_Clonacion_05_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona pOrigen = new Persona("Uno", "Uno", DateTime.Now, 2.0);
            Persona pCopia = (Persona)pOrigen.Clone(); //Hemos sobreescrito el método Clone() implementando el interfaz. 
            //Hay que cumplir la firma, que dice que devuelve un objeto, por tanto, hay que hacerle el casting a (Persona) en este caso
            //ya que Persona hereda de Object y se hace una conversión explícita (automática) de Persona a Object.

            
            Console.WriteLine(pOrigen.ToString());
            Console.WriteLine(pCopia.ToString());

            pOrigen.Nombre = "Pepito";
            Console.WriteLine();
            Console.WriteLine(pOrigen.ToString()); 
            Console.WriteLine(pCopia.ToString()); //No ha cambiado en la Copia al cambiarlo en el Origen, así que eso demuestra que 
            //se ha copiado bien 

            Console.ReadLine();
        }
    }
}
