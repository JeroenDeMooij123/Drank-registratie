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

namespace Dranken
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    { 
        DrankenDBDataContext db = new DrankenDBDataContext();
    public Window1()
    {
        InitializeComponent();
        dgDranken3.ItemsSource = db.drankens.ToList();
    }

    private void dgDranken3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        dranken drankenrow = (dranken)dgDranken3.SelectedItem;
        int ID = drankenrow.ID;
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {

        {
            DrankenDBDataContext DD = new DrankenDBDataContext();
            dranken drankendata = dgDranken3.SelectedItem as dranken;
            var drankje = (from Dranken in DD.drankens
                           where Dranken.ID == drankendata.ID
                           select Dranken).Single();

            DD.drankens.DeleteOnSubmit(drankje);
            DD.SubmitChanges();
            dgDranken3.ItemsSource = db.drankens.ToList();
        }
    }

    private void Searchbtn_Click(object sender, RoutedEventArgs e)
    {
        string did = Searchtxt.Text;
        var lijst = db.drankens.Where(p => Convert.ToString(p.ID).Contains(did));
        var list = db.drankens.Where(p => Convert.ToString(p.Soort).Contains(did));
        dgDranken3.ItemsSource = lijst;
        dgDranken3.ItemsSource = list;
    }

    private void page1txt_Click(object sender, RoutedEventArgs e)
    {
        MainWindow window = new MainWindow();
        window.Show();
        this.Close();
    }
}
}