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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dranken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       DrankenDBDataContext db = new DrankenDBDataContext();

        public MainWindow()
        {
            InitializeComponent();
            dgDranken2.ItemsSource = db.drankens.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            dranken hetdrankje = new dranken();
            hetdrankje.Naam = KlantNaamtxt.Text;
            hetdrankje.Soort = Dranksoorttxt.Text;
            hetdrankje.Prijs = Prijstxt.Text;

            db.drankens.InsertOnSubmit(hetdrankje);
            db.SubmitChanges();

            dgDranken2.ItemsSource = db.drankens.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            dranken dedrank = (dranken)dgDranken2.SelectedItem;
            dedrank.Naam = KlantNaamtxt.Text;
            dedrank.Soort = Dranksoorttxt.Text;
            dedrank.Prijs = Prijstxt.Text;

            if (dedrank != null)
            {
                dedrank.Naam = KlantNaamtxt.Text;
                dedrank.Soort = Dranksoorttxt.Text;
                dedrank.Prijs = Prijstxt.Text;

                db.SubmitChanges();
                dgDranken2.ItemsSource = db.drankens.ToList();
            }

        }

        private void dgDranken2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dranken dedrank = (dranken)dgDranken2.SelectedItem;
            KlantNaamtxt.Text = dedrank.Naam;
            Dranksoorttxt.Text = dedrank.Soort;
            Prijstxt.Text = dedrank.Prijs;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
            this.Close();
        }
    }
}
