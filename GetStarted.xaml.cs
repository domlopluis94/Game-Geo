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

namespace iGeographic
{
    /// <summary>
    /// Lógica de interacción para GetStarted.xaml
    /// </summary>
    public partial class GetStarted : Window
    {
        string user;

        public GetStarted(string id)
        {
            InitializeComponent();
            user = id;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.Title = "iGeographic";
        }
        protected void LogOutBtn_Click(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        protected void RankingBtn_Click(object sender, MouseButtonEventArgs e)
        {
            ListRanking lr = new ListRanking(user);
            lr.Show();
            lr.Owner = this;
        }

        protected void PerfilBtn_Click(object sender, MouseButtonEventArgs e)
        {
            Profile pf = new Profile(user);
            pf.Show();
            pf.Owner = this;
        }

        protected void GameBtn_Click(object sender, MouseButtonEventArgs e)
        {
            SelectContinent sc = new SelectContinent(user);
            sc.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectContinent sc = new SelectContinent(user);
            sc.Show();
            this.Close();
        }
    }
}
