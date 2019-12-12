using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = MA; Integrated Security = True;");
            using SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand("Select Title, Director, Year, Genre, AvgRate, NumOfRates, Watched  from movies", con)
            };

            DataTable dt = new DataTable("movies");
            adapter.Fill(dt);
            dg.ItemsSource = dt.DefaultView;

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
            obejrzane.Visibility = Visibility.Visible;
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
                obejrzane.Text = row_selected["Watched"].ToString();

            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            obejrzane.Text = "True";

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*CollectionViewSource Icollect = this.Resources["Icollect"] as CollectionViewSource;
            Icollect.View.Filter = (obj) =>
            {
                System.Xml.XmlElement element = obj as System.Xml.XmlElement;
                if (element.Attributes["Name"].Value.ToLower().StartsWith(filter.Text.Trim().ToLower()))
                    return true;

                return false;
                */
            SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = MA; Integrated Security = True;");
            using SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand("Select Title, Director, Year, Genre, AvgRate, NumOfRates, Watched  from movies", con)
            };

            DataTable dt = new DataTable("movies");
            adapter.Fill(dt);
            dg.ItemsSource = dt.DefaultView;

            string filtr = filter.Text;
                if (string.IsNullOrEmpty(filtr))
                    dt.DefaultView.RowFilter = null;
                else
                    dt.DefaultView.RowFilter = string.Format("Title Like '%{0}%' OR Director Like '%{0}%'", filtr);
            }
        }

    }
