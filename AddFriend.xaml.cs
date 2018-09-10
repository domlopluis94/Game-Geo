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
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;

namespace iGeographic
{
    /// <summary>
    /// Lógica de interacción para AddFriend.xaml
    /// </summary>
    public partial class AddFriend : Window
    {
        string user;

        public AddFriend(string id)
        {
            InitializeComponent();

            user = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
                {
                    conn.Open();

                    string friend = "";

                    MySqlCommand cmd = new MySqlCommand($"SELECT id_member FROM smf_members WHERE member_name = '{usuario.Text}'", conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if(!rdr.HasRows)
                        {
                            MessageBox.Show("Usuario no existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                            this.Close();
                            return;
                        }
                        rdr.Read();
                        friend = rdr["id_member"].ToString();
                    }


                    MySqlCommand cmd2 = new MySqlCommand($@"
                    INSERT INTO amigos(Usuarios_idUsuarios, Usuarios_idUsuarios1, A_pendiente) VALUES('{user}', '{friend}', '1')", conn);
                    cmd2.ExecuteNonQuery();
                }
                MessageBox.Show("Enviada peticion de amigo.", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                this.Close();
                return;
            }
            catch
            {
                MessageBox.Show("Error al enviar la peticion", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                this.Close();
                return;
            }
        }

    }
}
