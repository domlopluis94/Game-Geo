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
    /// Lógica de interacción para SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
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
            if (username.Text == "")
            {
                MessageBox.Show("Debe seleccionar un nombre de usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
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
                string code = RandomCode();
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand($@"
                    INSERT INTO smf_members(member_name, date_registered, last_login, passwd, email_address, gender, birthdate, validation_code, 
                    active, number_updates, continent) VALUES ('{username.Text}', '{ConvertToTimestamp(DateTime.Now)}', '{ConvertToTimestamp(DateTime.Now)}', 
                    '{stringToSHA1(username.Text.ToLower()+contraseña.Text)}', '{correo.Text}', '0', '{nacimiento.SelectedDate.Value.ToString("yyyy-MM-dd")}', 
                    '{code}', '0', '0', '{continente.SelectedItem.ToString()}')", conn);
                    cmd.ExecuteNonQuery();
                }
                try
                {
                    sendEmail(correo.Text, code);
                }
                catch
                {
                    MessageBox.Show("Error al enviar el correo", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }
                MessageBox.Show("Usuario creado. Le hemos enviado al correo un numero de verificacion que debera insertar la primera vez que entre en la aplicación", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
                return;
            }
            catch
            {
                MessageBox.Show("Error al crear el usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
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

        public static void sendEmail(string email, string code)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["User"].ToString(), ConfigurationManager.AppSettings["Pass"].ToString()),
                EnableSsl = true
            };
            client.Send("luiskar009@gmail.com", email, "Active su cuenta para disfrutar de iGeographic", $"Gracias por registrarse en iGeographic.\n Su codigo de activacion es {code}");
        }

        public static string RandomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string result = "";
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                result += chars[random.Next(chars.Length)];
            }

            return result;
        }
    }
}
