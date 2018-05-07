using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------
using System.Windows.Data;

namespace Marina.WPF_Binding_SincronizarDatos_23_04
{        
    [ValueConversion(typeof(double), typeof(string))] // Con esto ya no se necesitarán las comprobaciones del método Convert
    class ConvertirClasificacion : IValueConverter
    {
        /// <summary>
        /// Convierte el origen al destino
        /// </summary>
        /// <param name="value">Objeto que pretendes convertir</param>
        /// <param name="targetType">Tipo de dato de destino donde pondrás el dato</param>
        /// <param name="parameter"></param> 
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string[] valoresLetra = { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco" };

            // Compruebo el tipo del destino (string) y el valor del dato origen (double):
            if (targetType == typeof(string) && value.GetType() == typeof(double))
            {
                // Valor ya convertido:
                return valoresLetra[(int)Math.Round((double)value)];
            }

            // No se ha podido convertir
            else
                return value; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
