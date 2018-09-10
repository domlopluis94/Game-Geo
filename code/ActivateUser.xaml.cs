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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Navigation;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace iGeographic
{
    /// <summary>
    /// Lógica de interacción para ActivateUser.xaml
    /// </summary>
    public partial class ActivateUser : Window
    {

        string user;

        public ActivateUser(string id)
        {
            InitializeComponent();
            user = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT validation_code FROM smf_members WHERE id_member = '{user}'", conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr["validation_code"].ToString() == code.Text)
                {
                    rdr.Close();
                    MySqlCommand cmd2 = new MySqlCommand($"UPDATE smf_members SET active = '1' WHERE id_member = '{user}'", conn);
                    cmd2.ExecuteNonQuery();
                    GetStarted gs = new GetStarted(user);
                    gs.Show();
                    this.Close();
                    return;
                }
                MessageBox.Show("El codigo introducido no es correcto", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                rdr.Close();
                return;
            }
        }
    }
}
