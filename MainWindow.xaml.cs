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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        ///                                                                                            ///                                               
        ///                             Comprueba si el usuario es correcto                            ///               
        ///                                                                                            ///                                    
        //////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT id_member, passwd, active FROM smf_members WHERE member_name = '{user.Text}'", conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    if (!rdr.HasRows)
                    {
                        MessageBox.Show("Usuario incorrecto", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                        return;
                    }
                    if (rdr[1].ToString() == stringToSHA1(user.Text.ToLower()+pass.Password))
                    {
                        if (rdr["active"].ToString() == "0")
                        {
                            ActivateUser au = new ActivateUser(rdr[0].ToString());
                            au.Show();
                            this.Close();
                            return;
                        }
                        GetStarted gs = new GetStarted(rdr[0].ToString());
                        gs.Show();
                        this.Close();
                        return;
                    }
                    MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }
            }
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

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            SignIn si = new SignIn();
            si.Show();
            this.Close();
            return;
        }
    } 
}
