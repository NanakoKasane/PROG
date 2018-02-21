using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------
using System.IO;

namespace T8_ClaseDriveInfo_21_02
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] unidades = DriveInfo.GetDrives(); //Método estático que devuelve un array con la información de las unidades
            
            Informacion(unidades);
            Console.ReadLine();
        }

        static void Informacion(DriveInfo[] unidades)
        {
            foreach (DriveInfo d in unidades)
            {
                Console.WriteLine();
                Console.WriteLine("              Unidad: {0}", d.Name);
                Console.WriteLine("      Tipo de Unidad: {0}", d.DriveType);

                if (d.IsReady) //Si la unidad está preparada/activa para preguntarle información
                {
                    Console.WriteLine("Volumen de la Unidad: {0}", d.VolumeLabel);
                    Console.WriteLine(" Sistema de archivos: {0}", d.DriveFormat);
                    Console.WriteLine("  Espacio disponible: {0}", d.AvailableFreeSpace);
                    Console.WriteLine("       Espacio libre: {0}", d.TotalFreeSpace);
                    Console.WriteLine(" Tamaño de la unidad: {0}", d.TotalSize);
                }
            }
        }
    }
}
