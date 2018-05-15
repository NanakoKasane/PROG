using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------
using System.Windows.Data;

namespace WPF_Ej26_Convertir
{
    class ConvertirPieza : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Convierto el valor de la pieza a su entero y lo multiplico por 15, que será el valor de la barra 
            int valorPieza = (int)value; // Tomo el valor de la enumeración  (el caballo era 3, el peón 1...)
            int valorBarra = valorPieza * 15;

            return valorBarra;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
