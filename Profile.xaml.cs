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
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace iGeographic
{
    /// <summary>
    /// Lógica de interacción para Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        string user;

        public Profile(string id)
        {
            InitializeComponent();

            user = id;

            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT member_name as Usuario, email_address as Email, birthdate as Nacimiento FROM smf_members WHERE id_member = '{id}'", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Perfil");
                sda.Fill(dt);
                Perfil.ItemsSource = dt.DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditProfile ep = new EditProfile(user);
            ep.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddFriend af = new AddFriend(user);
            af.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AcceptFriend ac = new AcceptFriend(user);
            ac.Show();
        }
    }
}
