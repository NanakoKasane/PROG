using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;


namespace WPF_Ej19_Matriz2DBotones
{
	class CBotones
	{
		Grid rejilla = new Grid();
		int nFilas;
		int nColumnas;
		const int _HEIGHTBOTON = 30;
		const int _WIDTHBOTON = 30;
		const int _MARGINBOTON = 2;


		#region Constructores
		public CBotones() { }

		public CBotones(int nFilas, int nColumnas)
		{
			this.NFilas = nFilas;
			this.NColumnas = nColumnas;
		}
		#endregion 

		#region Propiedades
		public int NFilas
		{
			get { return nFilas; }
			set {
					if (value > 20)
						nFilas = 20;
					else
						nFilas = value; 
				}
		}

		public int NColumnas
		{
			get { return nColumnas; }
			set {
					if (value > 20)
						nColumnas = 20;
					else
						nColumnas = value; 
				}
		}

		public Grid Rejilla
		{
			get { return rejilla; }
			set { rejilla = value; }
		}

		public int HEIGHTBOTON
		{
			get { return _HEIGHTBOTON; }
		}

		public int WIDTHBOTON
		{
			get { return _WIDTHBOTON; }
		}

		public int MARGINBOTON
		{
			get { return _MARGINBOTON; }
		} 
		#endregion 
		


		public void RellenarRejilla()
		{
			// Le añado el número de columnas al Grid
			for (int i = 0; i < nColumnas; i++)
			{
				Rejilla.ColumnDefinitions.Add(new ColumnDefinition());
			}
			
			// Le añado el número de filas al Grid
			for (int i = 0; i < nFilas; i++)
			{
				Rejilla.RowDefinitions.Add(new RowDefinition());
			}
			
			
			// Relleno el Grid con los botones
			for (int i = 0; i < nFilas; i++)
			{
				for (int j = 0; j < nColumnas; j++)
				{
					Button btnTmp = new Button();
					btnTmp.Name = string.Format("btn{0}_{1}", i, j); //btn0_1 será el botón de la fila 0 columna 1
					btnTmp.Margin = new System.Windows.Thickness(MARGINBOTON); 
					btnTmp.Content = string.Format("[{0},{1}]", i, j);
					btnTmp.Height = HEIGHTBOTON;
					btnTmp.Width = WIDTHBOTON;

					// Eventos
					btnTmp.Click += btnTmp_Click;
					btnTmp.MouseLeave += btnTmp_MouseLeave;
					btnTmp.MouseEnter += btnTmp_MouseEnter;
					
					// Lo añado a la rejilla
					Grid.SetRow(btnTmp, i);
					Grid.SetColumn(btnTmp, j);					
					rejilla.Children.Add(btnTmp); 

				}
			}
		}


		// EVENTOS

		void btnTmp_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			Button boton = sender as Button;
			boton.Background = new SolidColorBrush(Colors.Red);
		}

		void btnTmp_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			Button boton = sender as Button;
			boton.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));

		}

		void btnTmp_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			Button boton = sender as Button;
			MessageBox.Show(boton.Name);		
		}

	}
}
