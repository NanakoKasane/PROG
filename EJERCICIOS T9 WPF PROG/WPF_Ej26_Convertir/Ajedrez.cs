using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Ej26_Convertir
{
    enum piezas { peon = 1, alfil = 3, caballo = 3, torre = 5, reina = 10, rey = 20 };

    class Ajedrez
    {
        piezas _pieza;
        DateTime _fecha;

        public Ajedrez() { }
        public Ajedrez(piezas pieza, DateTime fecha)
        {
            this.Pieza = pieza;
            this.Fecha = fecha;
        }


        #region Propiedades
        public piezas Pieza
        {
            get { return _pieza; }
            set { _pieza = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        #endregion 

    }
}
