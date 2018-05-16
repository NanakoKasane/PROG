using System;
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

namespace WPF_Ej20_3EnRaya
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			RellenarGrid();

			tbl_turnos.Text = "Turno J1" + "\n";

		}
		public enum Turno { J1 = 1, J2 = 2};
		Turno turno = Turno.J1;
		int nTurnos = 0;
		BitmapImage imagenDefecto = new BitmapImage(new Uri("../../imagenes/n.png", UriKind.Relative));
		BitmapImage imagenO_J1 = new BitmapImage(new Uri("../../imagenes/O.png", UriKind.Relative));
		BitmapImage imagenX_J2 = new BitmapImage(new Uri("../../imagenes/X.png", UriKind.Relative));

        Image[,] arrayImagenesGrid = new Image[3, 3];
		bool haGanado = false;


		private void RellenarGrid()
		{
			// Borro por si hubiera algo:
			grd_3Raya.Children.Clear();
			grd_3Raya.ColumnDefinitions.Clear();
			grd_3Raya.RowDefinitions.Clear();

			// Definir columnas
			for (int i = 0; i < 3; i++)
			{
				grd_3Raya.ColumnDefinitions.Add(new ColumnDefinition());
			}

			// Definir filas
			for (int i = 0; i < 3; i++)
			{
				grd_3Raya.RowDefinitions.Add(new RowDefinition());
			}

			// Relleno las celdas 
			for (int i = 0; i < grd_3Raya.RowDefinitions.Count; i++)
			{
				for (int j = 0; j < grd_3Raya.ColumnDefinitions.Count; j++)
				{
					// BORDE
					Border borde = new Border();
					borde.IsEnabled = false;
					borde.Background = new SolidColorBrush(Colors.White);
					borde.BorderBrush = new SolidColorBrush(Colors.Black);
					borde.BorderThickness = new Thickness(3);
					grd_3Raya.Children.Add(borde);
					Grid.SetRow(borde, i);
					Grid.SetColumn(borde, j);


					// IMAGEN
					Image fotoFicha = new Image();
					fotoFicha.Source = imagenDefecto;
					fotoFicha.MouseLeftButtonDown += fotoFicha_MouseLeftButtonDown;
                    arrayImagenesGrid[i, j] = fotoFicha;

					grd_3Raya.Children.Add(fotoFicha);
					Grid.SetRow(fotoFicha, i);
					Grid.SetColumn(fotoFicha, j);
				}
			}

		}

		void fotoFicha_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Image imagen = sender as Image;
			int fila = Grid.GetRow(imagen);
			int columna = Grid.GetColumn(imagen);

			//if (haGanado == true)
			//	ReiniciarJuego();

			if (turno == Turno.J1) // Jugador 1 -> O 
			{
				if (imagen.Source != imagenDefecto)
					MessageBox.Show("No puede poner la ficha aquí");
				else
				{
					nTurnos++;
					imagen.Source = imagenO_J1;

					// Cambio de turno
					if (nTurnos < 9) // Si no es el último turno, que entonces no se cambiará de turno
					{
						tbl_turnos.Text += "Turno J2" + "\n";
						turno = Turno.J2;
						ComprobarSiGano();
					}
				}
			}

			else if (turno == Turno.J2) // Jugador 2 -> X
			{
				if (imagen.Source != imagenDefecto)
					MessageBox.Show("No puede poner la ficha aquí");
				else
				{
					nTurnos++;
					imagen.Source = imagenX_J2;

					if (nTurnos < 9)
					{
						tbl_turnos.Text += "Turno J1" + "\n";
						turno = Turno.J1;
						ComprobarSiGano();
					}
				}
			}

			// Reiniciar el juego
			if (nTurnos == 9)
				ReiniciarJuego();
			

		}

		private void ReiniciarJuego()
		{
			if (!haGanado)
				MessageBox.Show("Ha acabado la partida en EMPATE");
			nTurnos = 0;
			RellenarGrid();
			tbl_turnos.Text = "Turno J1" + "\n";
			turno = Turno.J1;
			haGanado = false;
		}

		private void ComprobarVictoriaV1()
		{
			// LINEAS VERTICALES (compruebo si ha ganado con una línea vertical)
			for (int i = 0; i < arrayImagenesGrid.GetLength(0); i++)
			{
				if (arrayImagenesGrid[i, 0].Source != imagenDefecto) // Primero si la imagen no es la por defecto
				{
					if (arrayImagenesGrid[0, i].Source == arrayImagenesGrid[1, i].Source && arrayImagenesGrid[0, i].Source == arrayImagenesGrid[2, i].Source)
					{
						MessageBox.Show(string.Format("Ha ganado el jugador {0}", (arrayImagenesGrid[0, i].Source == imagenO_J1) ? "J1" : "J2"));
						haGanado = true;
						ReiniciarJuego();
					}
				}

			}

			// LINEAS HORIZONTALES (compruebo si ha ganado con una línea horizontal)
			for (int i = 0; i < arrayImagenesGrid.GetLength(1); i++)
			{
				if (arrayImagenesGrid[i, 0].Source == arrayImagenesGrid[i, 1].Source && arrayImagenesGrid[i, 0].Source == arrayImagenesGrid[i, 2].Source)
				{
					MessageBox.Show(string.Format("Ha ganado el jugador {0}", (arrayImagenesGrid[i, 0].Source == imagenO_J1) ? "J1" : "J2"));
					haGanado = true;
					ReiniciarJuego();
				}
			}

			// Comprobar diagonales:
			if (arrayImagenesGrid[0, 0].Source == arrayImagenesGrid[1, 1].Source && arrayImagenesGrid[0, 0].Source == arrayImagenesGrid[2, 2].Source)
			{
				MessageBox.Show(string.Format("Ha ganado el jugador {0}", (arrayImagenesGrid[0, 0].Source == imagenO_J1) ? "J1" : "J2"));
				haGanado = true;
				ReiniciarJuego();
			}
			else if (arrayImagenesGrid[0, 2].Source == arrayImagenesGrid[1, 1].Source && arrayImagenesGrid[0, 2].Source == arrayImagenesGrid[2, 0].Source && arrayImagenesGrid[2, 0].Source != imagenDefecto)
			{
				MessageBox.Show(string.Format("Ha ganado el jugador {0}", (arrayImagenesGrid[0, 2].Source == imagenO_J1) ? "J1" : "J2"));
				haGanado = true;
				ReiniciarJuego();
			}

		}

		private void ComprobarSiGano()
		{
			for (int i = 0; i < arrayImagenesGrid.GetLength(0); i++)
			{
				for (int j = 0; j < arrayImagenesGrid.GetLength(1); j++)
				{
					// Primero que no sea la imagen en blanco por defecto
                    if (arrayImagenesGrid[i, j].Source != imagenDefecto) 
                    {
						// LINEAS VERTICALES (compruebo si ha ganado con una línea vertical)
						if (i == 0 && arrayImagenesGrid[i, j].Source == arrayImagenesGrid[i+1, j].Source && arrayImagenesGrid[i, j].Source == arrayImagenesGrid[i+2, j].Source)
						{
							MessageBox.Show(string.Format("Ha ganado el jugador {0}", (arrayImagenesGrid[i, j].Source == imagenO_J1)?"J1":"J2"));
							haGanado = true;
							ReiniciarJuego();
						}

						// LINEAS HORIZONTALES (compruebo si ha ganado con una línea horizontal)
						else if (j == 0 && arrayImagenesGrid[i, j].Source == arrayImagenesGrid[i, j + 1].Source && arrayImagenesGrid[i, j].Source == arrayImagenesGrid[i, j + 2].Source)
						{
							MessageBox.Show(string.Format("Ha ganado el jugador {0}", (arrayImagenesGrid[i, j].Source == imagenO_J1) ? "J1" : "J2"));
							haGanado = true;
							ReiniciarJuego();
						}

						// LINEAS DIAGONALES (compruebo si  ha ganado con una línea diagonal)
						else if (j == 0 && i == 0 && arrayImagenesGrid[i, j].Source == arrayImagenesGrid[i +1, j + 1].Source && arrayImagenesGrid[i, j].Source == arrayImagenesGrid[i +2, j + 2].Source)
						{
							MessageBox.Show(string.Format("Ha ganado el jugador {0}", (arrayImagenesGrid[i, j].Source == imagenO_J1) ? "J1" : "J2"));
							haGanado = true;
							ReiniciarJuego();
						}
						else if (j == 0 && i == 0 && arrayImagenesGrid[i, j + 2].Source == arrayImagenesGrid[i + 1, j + 1].Source && arrayImagenesGrid[i, j + 2].Source == arrayImagenesGrid[i + 2, j].Source && arrayImagenesGrid[i + 2, j].Source != imagenDefecto)
						{
							MessageBox.Show(string.Format("Ha ganado el jugador {0}", (arrayImagenesGrid[i, j].Source == imagenO_J1) ? "J1" : "J2"));
							haGanado = true;
							ReiniciarJuego();
						}
                    }
				}
			}
		}

	}
}

// CASILLAS PARA GANAR:
// En linea diagonal --> 0,0 con 1,1 con 2,2
// Linea diagonal al revés --> 0,2 con 1,1 con 2,0

// Lineas horizontales:
// 0,0 con 0,1 con 0,2
// 1,0 con 1,1 con 1,2
// 2,0 con 2,1 con 2,2

// Lineas verticales:
// 0,0 con 1,0 con 2,0
// 0,1 con 1,1 con 2,1
// 0,2 con 1,2 con 2,2
