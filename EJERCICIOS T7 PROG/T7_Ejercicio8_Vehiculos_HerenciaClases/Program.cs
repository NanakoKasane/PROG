using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Ejercicio8_Vehiculos_HerenciaClases
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehiculo v = new Bicicleta();
            Vehiculo v2 = new Vehiculo("Vehiculo01", 2, ConsoleColor.Blue, Vehiculo.tipoTraccion.Integral);
            

            Console.ReadLine();
        }
    }
}
