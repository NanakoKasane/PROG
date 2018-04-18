using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ClaseApp_18_04
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string Compartir { get ; set ; }

        private void Application_Activated(object sender, EventArgs e)
        {
            Compartir = "hola";
        }


    }
}
