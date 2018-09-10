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
    /// Lógica de interacción para SelectContinent.xaml
    /// </summary>
    public partial class SelectContinent : Window
    {
        string user;
        public SelectContinent(string id)
        {
            InitializeComponent();
            user = id;
        }
        
        protected void GameBtn_Click(object sender, MouseButtonEventArgs e)
        {
            String dificultad = ((ComboBoxItem)Dificulty.SelectedItem).Content.ToString();
            
            var button = (Button)sender;
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BBDD"].ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT idContinente FROM continente WHERE C_nombre = '{button.Name}'", conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    if (!rdr.HasRows)
                    {
                        MessageBox.Show("Error al conseguir la id del continente en la BBDD", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                        return;
                    }
                    Game gm = new Game(user, rdr[0].ToString(), dificultad);
                    gm.Show();
                    this.Close();
                    return;
                }
            }
        }
    }
}
