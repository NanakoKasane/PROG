using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------
using System.Windows.Controls;

namespace Marina.WPF_Binding_SincronizarDatos_23_04
{
    class RangeValidationRule : ValidationRule
    {
        double? _minValue;
        double? _maxValue;

        public double? MinValue
        {
            get { return _minValue; }
            set { _minValue = value; }
        }


        public double? MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; }
        }


        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            double valorDoble;

            string strValidar = value as string;
            if (strValidar != null) // No hace falta en este caso comprobar que sea un string ya que viene de un TextBox
            {
                if (double.TryParse(strValidar, out valorDoble))
                {
                    if (_minValue.HasValue && valorDoble < _minValue) // .HasValue comprueba si no es null y ha tomado valor 
                        return new ValidationResult(false, "ERROR, el valor debe ser mayor que " + _minValue); // No ha ido bien, no se ha validado

                    else if (_maxValue.HasValue && valorDoble > _maxValue)
                        return new ValidationResult(false, "ERROR, el valor debe ser menor que " + _maxValue);

                    else
                        return new ValidationResult(true, null); // Si no se dieron las opciones anteriores, será válido
                }
            }

            return new ValidationResult(false, "ERROR: El formato no es correcto");
        }
    }
}
