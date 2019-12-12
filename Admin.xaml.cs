using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            FillListView();
            SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = MA; Integrated Security = True;");

            con.Open();
//filmy
            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM movies");
            sqlCommand.Connection = con;

            int filmy = Convert.ToInt32(sqlCommand.ExecuteScalar());

            lmovies.Content = filmy.ToString();
//użytkwnicy
            SqlCommand sqlCommand2 = new SqlCommand("SELECT COUNT(*) FROM tableUser");
            sqlCommand2.Connection = con;
            int uzytkownicy = Convert.ToInt32(sqlCommand2.ExecuteScalar());

            lusers.Content = uzytkownicy.ToString();
//komedie
            SqlCommand sqlCommand3 = new SqlCommand("SELECT COUNT(*) FROM movies WHERE genre='komedia'");
            sqlCommand3.Connection = con;
            int komedie = Convert.ToInt32(sqlCommand3.ExecuteScalar());

            lcomedy.Content = komedie.ToString();
//dramaty
            SqlCommand sqlCommand4 = new SqlCommand("SELECT COUNT(*) FROM movies WHERE genre='dramat'");
            sqlCommand4.Connection = con;
            int dramaty = Convert.ToInt32(sqlCommand4.ExecuteScalar());

            ldrama.Content = dramaty.ToString();
//horrory
            SqlCommand sqlCommand5 = new SqlCommand("SELECT COUNT(*) FROM movies WHERE genre='horror'");
            sqlCommand5.Connection = con;
            int horrory = Convert.ToInt32(sqlCommand5.ExecuteScalar());

            lhorror.Content = horrory.ToString();
//animowane
            SqlCommand sqlCommand6 = new SqlCommand("SELECT COUNT(*) FROM movies WHERE genre='animowany'");
            sqlCommand6.Connection = con;
            int animowane = Convert.ToInt32(sqlCommand6.ExecuteScalar());

            lanim.Content = animowane.ToString();

//świąteczne
            SqlCommand sqlCommand7 = new SqlCommand("SELECT COUNT(*) FROM movies WHERE genre='świąteczny'");
            sqlCommand7.Connection = con;
            int swiateczne = Convert.ToInt32(sqlCommand7.ExecuteScalar());

            lchrist.Content = swiateczne.ToString();
        }
        private void FillListView()
        {
            SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = MA; Integrated Security = True;");
            using SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand("Select Title, Director, Year, Genre, AvgRate, NumOfRates, Watched  from movies", con)
            };

            DataTable dt = new DataTable("movies");
            adapter.Fill(dt);
            dg.ItemsSource = dt.DefaultView;


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = MA; Integrated Security = True;");
            try
            {
                string query = "Insert into [movies] (Title, Director, Year, Genre, AvgRate, NumOfRates, Watched) values ('" + this.tytula.Text + "', '" + this.rezysera.Text + "', '" + this.roczeka.Text + "', '" + this.gatuneka.Text + "', '" + this.ocenaa.Text + "', '" + this.wyswietleniaa.Text + "', '" + this.obejrzanya.Text + "') ;";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                con.Open();
                da.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data saved successfully.");
            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new MainWindow().Show();
        }
    }
}
