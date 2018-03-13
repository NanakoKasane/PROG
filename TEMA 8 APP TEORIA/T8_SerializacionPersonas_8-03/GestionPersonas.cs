using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//------------------------------------ IMPORTANTE para serializar
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace T8_SerializacionPersonas_8_03
{
    class GestionPersonas
    {
        string _fichero;
        public GestionPersonas(string fichero)
        {
            this._fichero = fichero;
        }
           
        //Añade una persona al fichero
        public bool Anadir(Persona p)
        {
            if (!File.Exists(_fichero))
            {
                FileStream ftmp = File.Create(_fichero);
                ftmp.Close();
            }

            IFormatter formato = new BinaryFormatter(); //Clase que implementa el interfaz

            using (FileStream flujo = new FileStream(_fichero, FileMode.Append, FileAccess.Write))
            {
                formato.Serialize(flujo, p); //SERIALIZAR
            }
            return true;
        }

        public void Listar()
        {
            bool error = false;
            if (!File.Exists(_fichero))
            {
                Console.WriteLine("El fichero no existe");
                Console.ReadLine();
                return;
            }

            Persona pTmp = null;

            using (FileStream flujo = new FileStream(_fichero, FileMode.Open, FileAccess.Read)) 
            {
                IFormatter formato = new BinaryFormatter();

                while (!error)
                {
                    try
                    {
                        pTmp = (Persona)formato.Deserialize(flujo); //DESERIALIZAR
                        //Compruebo que no esté borrado
                        if (pTmp.Borrado)
                            continue; //Salta al siguiente y no muestra ese
                        Console.WriteLine(pTmp.ToString());
                    }
                    catch (Exception e)
                    { //break;
                        error = true; //Cuando acaba de escribir lo que haya, entra por aquí y para
                        //Console.WriteLine(e.Message);
                        //Console.ReadLine();
                        break;
                    }
                }

            }


        }

    }
}
