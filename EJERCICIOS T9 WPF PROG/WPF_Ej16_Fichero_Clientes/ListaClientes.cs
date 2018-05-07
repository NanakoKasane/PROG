using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------
using System.Collections.ObjectModel;

namespace WPF_Ej16_Fichero_Clientes
{
    public class ListaClientes 
    {
        ObservableCollection<Cliente> listaClientes = new ObservableCollection<Cliente>();

        public ObservableCollection<Cliente> ListaDeClientes
        {
            get { return listaClientes; }
            set { listaClientes = value; }
        }

        public ListaClientes()
        {
			//listaClientes.Add(new Cliente("1111", 10, 2000, "Espinosa", "Marina"));
			//listaClientes.Add(new Cliente("2222", 20, 2000, "Amado", "Javier"));
			//listaClientes.Add(new Cliente("3333", 21, 2000, "Bueno", "Ismael"));

        }

        public ListaClientes(Cliente cliente)
        {
            listaClientes.Add(cliente);
        }
    }
}
