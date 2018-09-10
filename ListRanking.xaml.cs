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
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace iGeographic
{
    /// <summary>
    /// Lógica de interacción para ListRanking.xaml
    /// </summary>
    public partial class ListRanking : Window
    {
        public ListRanking(string id)
        {
            InitializeComponent();

            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT P_puntuacion as Puntuacion FROM partida WHERE Usuarios_idUsuarios = '{id}' ORDER BY P_fecha DESC LIMIT 1", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Ultima Puntuacion");
                sda.Fill(dt);
                LastScore.ItemsSource = dt.DefaultView;

                MySqlCommand cmd2 = new MySqlCommand($"SELECT MIN(P_puntuacion) as Puntuacion FROM partida WHERE Usuarios_idUsuarios = '{id}'", conn);
                MySqlDataAdapter sda2 = new MySqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable("Record");
                sda2.Fill(dt2);
                Record.ItemsSource = dt2.DefaultView;

                MySqlCommand cmd3 = new MySqlCommand($@"SELECT m.member_name as Usuario, MIN(p.P_puntuacion) as Puntuacion FROM partida p, smf_members m WHERE 
                m.id_member = p.Usuarios_idUsuarios
                AND(p.Usuarios_idUsuarios IN(SELECT Usuarios_idUsuarios FROM amigos WHERE Usuarios_idUsuarios1 = '{id}')
                OR p.Usuarios_idUsuarios IN(SELECT Usuarios_idUsuarios1 FROM amigos WHERE Usuarios_idUsuarios = '{id}')
                OR p.Usuarios_idUsuarios = '{id}')
                GROUP BY m.member_name
                ORDER BY MIN(p.P_puntuacion) ASC", conn);
                MySqlDataAdapter sda3 = new MySqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable("Record Amigos");
                sda3.Fill(dt3);
                Amigos.ItemsSource = dt3.DefaultView;
            }

        }
    }
}
