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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Device.Location;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace iGeographic
{
    /// <summary>
    /// Lógica de interacción para Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        string user;
        string continent;
        string dif;
        int points;
        int load = 1;
        int round = 1;
        DraggablePin pin;
        DispatcherTimer temporizador;
        TimeSpan time = TimeSpan.FromSeconds(30);
        GeoCoordinate fotoCoord;
        List<string> id;


        public Game(string idUser, string idCont, string dificulty)
        {
            InitializeComponent();
            user = idUser;
            continent = idCont;
            dif = dificulty;

            MyMap.Loaded += (s, e) =>
            {
                pin = new DraggablePin(MyMap)
                {
                    Location = MyMap.Center
                };

                MyMap.Children.Add(pin);
            };

            id = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT idfotos FROM fotos WHERE Ciudad_Continente_idContinente = '{continent}' AND Dificultad = '{dif}'", conn);
                using(MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                        id.Add(rdr[0].ToString());
                }
            }
            
            randomLocation(id);        

            temporizador = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                Timer.Text = time.ToString("c");
                if (time == TimeSpan.Zero)
                {
                    temporizador.Stop();
                    var coor = pin.Location;
                    updatePoins(new GeoCoordinate(coor.Latitude, coor.Longitude));
                    if (finishGame(round))
                        return;
                    randomLocation(id);
                    time = TimeSpan.FromSeconds(31);
                    Round.Text = $"{round}/5";
                    temporizador.Start();
                }
       
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            temporizador.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            temporizador.Stop();
            var coor = pin.Location;
            updatePoins(new GeoCoordinate(coor.Latitude, coor.Longitude));
            if (finishGame(round))
                return;
            randomLocation(id);
            time = TimeSpan.FromSeconds(30);
            Round.Text = $"{round}/5";
            temporizador.Start();
        }

        private void updatePoins(GeoCoordinate pinCoord)
        {
            if (round == load)
            {
                load++;
                points += (int)pinCoord.GetDistanceTo(fotoCoord) / 100;
                round++;
            }           
        }

        private void randomLocation(List<string> idPictures)
        {
            string id = idPictures[new Random().Next(0, idPictures.Count)];
            idPictures.Remove(id);

            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT urlFotos, latitud, longitud FROM fotos WHERE idfotos = '{id}'", conn);
                using(MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    Uri imageUri = new Uri(rdr[0].ToString(), UriKind.Absolute);
                    BitmapImage imageBitmap = new BitmapImage(imageUri);
                    Image.Source = imageBitmap;
                    fotoCoord = new GeoCoordinate(double.Parse(rdr[1].ToString()), double.Parse(rdr[2].ToString()));
                }
            } 
        }

        private Boolean finishGame(int round)
        {
            if (round > 5)
            {
                temporizador.Stop();
                MessageBox.Show($"Puntuacion: {points}", "Partida finalizada", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO partida(Torneo_idTorneo, 	Torneo_Usuarios_idUsuarios, Usuarios_idUsuarios, Continente_IDContinente, P_fecha, P_puntuacion) VALUES ('0', '0', '{user}','{continent}', now(),'{points}')", conn);
                    cmd.ExecuteNonQuery();
                }
                
                GetStarted gs = new GetStarted(user);
                gs.Show();
                this.Close();

                return true;
            }

            return false;
        }
    }
}