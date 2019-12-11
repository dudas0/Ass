using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {

        public Home()
        {
            InitializeComponent();
            FillListView();

        }
        private ComboBox py1;

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

        private void wyszukaj_Click(object sender, RoutedEventArgs e)
        {
            dg.Visibility = Visibility.Visible;

            wyszukaj.Visibility = Visibility.Hidden;
        }


        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            roczek.Visibility = Visibility.Visible;
            tytul.Visibility = Visibility.Visible;
            rezyser.Visibility = Visibility.Visible;
            gatunek.Visibility = Visibility.Visible;
            ocena.Visibility = Visibility.Visible;
            wyswietlenia.Visibility = Visibility.Visible;
            title.Visibility = Visibility.Visible;
            director.Visibility = Visibility.Visible;
            year.Visibility = Visibility.Visible;
            genre.Visibility = Visibility.Visible;
            views.Visibility = Visibility.Visible;
            rate.Visibility = Visibility.Visible;
            Watched.Visibility = Visibility.Visible;
            Watchedtxt.Visibility = Visibility.Visible;
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                roczek.Text = row_selected["Year"].ToString();
                tytul.Text = row_selected["Title"].ToString();
                rezyser.Text = row_selected["Director"].ToString();
                gatunek.Text = row_selected["Genre"].ToString();
                ocena.Text = row_selected["AvgRate"].ToString();
                wyswietlenia.Text = row_selected["NumOfRates"].ToString();
                Watchedtxt.Text = row_selected["Watched"].ToString();

            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Watchedtxt.Text = "True";

        }


    }
}
