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
    /// Lógica de interacción para EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Window
    {

        string user;

        public EditProfile(string id)
        {
            InitializeComponent();
            user = id;
            continente.Items.Clear();
            continente.SelectedIndex = continente.Items.Add("-- Selecione un continente --");

            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($@"SELECT C_nombre FROM continente", conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        continente.Items.Add(rdr[0].ToString());
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (contraseña.Text == "")
            {
                MessageBox.Show("Debe seleccionar una contraseña correcta", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            if ((correo.Text == "") || !(new EmailAddressAttribute().IsValid(correo.Text)))
            {
                MessageBox.Show("Debe insertar un correo de electronico correcto", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            if (continente.SelectedItem.ToString() == "-- Selecione un continente --")
            {
                MessageBox.Show("Debe seleccionar un continente", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
                {
                    conn.Open();

                    string username = "";
                    int numupd = 0;
                    
                    MySqlCommand cmd = new MySqlCommand($"SELECT member_name, number_updates FROM smf_members WHERE id_member = '{user}'", conn);
                    using(MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        rdr.Read();
                        username = rdr["member_name"].ToString();
                        if((numupd = Int32.Parse(rdr["number_updates"].ToString())) == 3)
                        {
                            MessageBox.Show("Ya has modificado el usuario el numero maximo de veces permitido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                            return;
                        }
                        numupd++;
                    }

                    MySqlCommand cmd2 = new MySqlCommand($@"
                    UPDATE smf_members SET passwd = '{stringToSHA1(username.ToLower() + contraseña.Text)}', email_address = '{correo.Text}', 
                    birthdate = '{nacimiento.SelectedDate.Value.ToString("yyyy-MM-dd")}', number_updates = '{numupd}', continent = '{continente.SelectedItem.ToString()}'
                    WHERE id_member = '{user}'", conn);
                    cmd2.ExecuteNonQuery();
                }
                MessageBox.Show("Usuario Modificado.", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                this.Close();
                return;
            }
            catch
            {
                MessageBox.Show("Error al modificar el usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
        }

        private long ConvertToTimestamp(DateTime value)
        {
            long timestamp = (value.Ticks - 621355968000000000) / 10000000;
            return timestamp;
        }

        public static string stringToSHA1(string rowPass)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(rowPass);
            var sb = new StringBuilder();

            var sha1 = SHA1.Create();

            foreach (byte b in sha1.ComputeHash(bytes))
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
