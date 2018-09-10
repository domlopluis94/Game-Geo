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
    /// Lógica de interacción para AcceptFriend.xaml
    /// </summary>
    public partial class AcceptFriend : Window
    {
        string user;
        public AcceptFriend(string id)
        {
            InitializeComponent();
            usuario.Items.Clear();

            user = id;

            usuario.SelectedIndex = usuario.Items.Add("-- Selecione el amigo a agregar --");

            List<string> amigos = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($@"SELECT Usuarios_idUsuarios FROM amigos WHERE Usuarios_idUsuarios1 = '{user}' AND A_pendiente = '1'", conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        amigos.Add(rdr[0].ToString());
                    }
                }
                foreach(string element in amigos)
                {
                    MySqlCommand cmd2 = new MySqlCommand($@"SELECT member_name FROM smf_members WHERE id_member = '{element}'", conn);
                    using (MySqlDataReader rdr = cmd2.ExecuteReader())
                    {
                        rdr.Read();
                        if(rdr.HasRows)
                            usuario.Items.Add(rdr[0].ToString());
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(usuario.SelectedItem.ToString() == "-- Selecione el amigo a agregar --")
                {
                    MessageBox.Show("Seleccione el amigo a agregar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
                {
                    conn.Open();
                    string idfriend = "";

                    MySqlCommand cmd = new MySqlCommand($@"SELECT id_member FROM smf_members WHERE member_name  = '{usuario.SelectedItem.ToString()}'", conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        rdr.Read();
                        if (rdr.HasRows)
                            idfriend = rdr[0].ToString();
                    }

                    MySqlCommand cmd2 = new MySqlCommand($@"UPDATE amigos SET A_pendiente = 0 WHERE Usuarios_idUsuarios = '{idfriend}' AND Usuarios_idUsuarios1 = '{user}'", conn);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Amigo aceptado.", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            catch
            {
                MessageBox.Show("Error al aceptar amigo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
        }
    }
}
