using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------------
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace T8_SerializablePersonas_JAVI
{
    class GestionPersonas
    {
        #region Campos

        string _fichero;

        #endregion

        #region Constructores

        public GestionPersonas(string fichero)
        {
            this._fichero = fichero;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Añade la persona al fichero
        /// </summary>
        /// <param name="p">Persona a Añadir</param>
        /// <returns></returns>
        public bool Anadir(Persona p)
        {
            if (!File.Exists(_fichero))
            {
                FileStream flujoTmp = File.Create(_fichero);
                flujoTmp.Close();
            }

            IFormatter formato = new BinaryFormatter(); //No se pueden crear objetos de interfaces pero sí de las clases que las implementan. Como BinaryFormatter.

            using (FileStream flujo = new FileStream(_fichero, FileMode.Append, FileAccess.Write))
            {
                formato.Serialize(flujo, p); //Escribe en el flujo, el objeto indicado, pero ya serializado. Guarda todos los campos.
            }
            return true;
        }

        /// <summary>
        /// Deserealiza los datos y los muestra
        /// </summary>
        public void Listar()
        {
            int contador = 0;

            if (!File.Exists(_fichero))
            {
                Console.Clear();
                Console.WriteLine("El fichero no existe...");
                Console.ReadLine();
                return;
            }

            Persona pTmp = null;

            using (FileStream flujo = new FileStream(_fichero, FileMode.Open, FileAccess.Read))
            {
                IFormatter formato = new BinaryFormatter();
                while (contador < 3)
                {
                    try
                    {
                        //Avanza solo por lo que no hay que recorrerlo.
                        pTmp = (Persona)formato.Deserialize(flujo); //Tenemos que hacer un casting de Persona. Deserializa y lo guarda en Persona Temporal

                        //Compruebo que no esté borrado
                        if (pTmp.Borrado)
                            continue;
                        Console.WriteLine(pTmp.ToString());
                    }
                    catch
                    {
                        break;
                    }
                }
            }
        }

        #endregion
    }
}