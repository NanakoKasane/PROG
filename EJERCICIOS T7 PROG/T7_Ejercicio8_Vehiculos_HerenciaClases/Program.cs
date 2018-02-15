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
            //Probando mostrar datos de una moto
            Moto moto = new Moto(10, Moto.tipoCombustible.Mezcla, "Moto de prueba", 2, ConsoleColor.Blue, Vehiculo.tipoTraccion.Delantera);
            Console.WriteLine(moto.ToString());
            Console.ReadLine();

            //Probando mostrar los datos de un coche
            Coche coche = new Coche(10, Coche.estado.Parado, "Coche de prueba", 4, ConsoleColor.Blue, Vehiculo.tipoTraccion.Delantera);
            Console.WriteLine(coche.ToString());
            Console.ReadLine();

            //Probando mostrar los datos de una bicicleta de montaña
            Montana bicicletaMontana = new Montana("Simple", true, 10, 20, DateTime.Parse("10/10/2017"),"Bicicleta", 4, ConsoleColor.Blue, Vehiculo.tipoTraccion.Delantera);
            Console.WriteLine(bicicletaMontana.ToString());
            Console.ReadLine();

            //Probando mostrar los datos de una bicicleta de paseo
            Paseo bicicletaPaseo = new Paseo(2, "Tu Marca Blanca", "C8", 25, DateTime.Parse("20/01/2016"), "Bicicleta", 4, ConsoleColor.Blue, Vehiculo.tipoTraccion.Delantera);
            Console.WriteLine(bicicletaPaseo.ToString());
            Console.ReadLine();


            //Vale, lo que me falta es arreglar el ToString() de las bicicletas ><

            Console.ReadLine();
        }
    }
}
