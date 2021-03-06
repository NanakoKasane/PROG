﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListaLetras_15_03
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int indice = 0;
        string texto = "ABCDEFGHIJKLMN";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            if (indice == 0) //false para indicar que no está habilitado el botón
                btnAnterior.IsEnabled = false; //indice = texto.Length -1;

            else
            {
                if (!btnAnterior.IsEnabled)
                    btnAnterior.IsEnabled = true;
                lblContenedor.Content = texto[--indice];
            }

            //Habilita de nuevo el botón Siguiente
            if (!btnSiguiente.IsEnabled)
                btnSiguiente.IsEnabled = true;


        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (indice == texto.Length -1)
                btnSiguiente.IsEnabled = false;

            else
            {
                if (!btnSiguiente.IsEnabled)
                    btnSiguiente.IsEnabled = true;
                lblContenedor.Content = texto[++indice % texto.Length]; //Circular para que no se salga 
            }

            //Habilita de nuevo el botón Anterior
            if (!btnAnterior.IsEnabled)
                btnAnterior.IsEnabled = true;

        }
    }
}
