using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------
using System.Windows.Data;


namespace WPF_Personas_Template_Lista_10_05
{
    class ConvertirFecha : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime fecha = DateTime.Parse(value.ToString());

            return fecha.ToLongDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
