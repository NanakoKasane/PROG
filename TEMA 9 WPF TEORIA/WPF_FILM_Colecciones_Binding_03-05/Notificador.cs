using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ---------------------------
using System.ComponentModel;


namespace Marina.WPF_Binding_SincronizarDatos_23_04
{
 
    /// <summary>
    /// Clase usada para informar de los cambios del valor de las propiedades 
    /// </summary>
    public class Notificador : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; // Del interfaz INotifyPropertyChanged, para que si cambies algo de la clase se propaguen los cambios a los elementos enlazados

        // Método del evento:
        protected void onPropertyChanged(string nombre)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nombre));

            
        }
    }
    
}
