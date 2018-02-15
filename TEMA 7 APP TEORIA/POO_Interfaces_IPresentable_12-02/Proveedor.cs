using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Interfaces_IPresentable_12_02
{
    class Proveedor : IPresentable
    {
        //Evento
        public event EventHandler onPresentar; //Los eventos suelen llamarse empezando por ON
        
        //Campos
        string _nombre;
        string _apellidos;
        int _nProveedor;

        //Constructor
        public Proveedor(string nombre, string apellidos, int nProveedor)
        {
            this._nombre = nombre;
            this._apellidos = apellidos;
            this._nProveedor = nProveedor;
        }

        //Método que implementa la interfaz IPresentable
        public void Presentar()
        {
            if (onPresentar != null)
                onPresentar(this, null);
            Console.WriteLine("     Nombre: {0}", _nombre);
            Console.WriteLine("     Apellidos: {0}", _apellidos);
            Console.WriteLine("     Número de Proveedor: {0}", _nProveedor);
        }
    }

    //Solo puedes heredar de una clase. Si vas a heredad de clase y de interfaces, la clase que heredas va la primera y luego ya la lista de interfaces
    class Basura : Proveedor, IPresentable, IEnumerable<int>, IComparable, ICloneable
    {

    }
}
