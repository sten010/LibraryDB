using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryDB.DB.DataSet1TableAdapters;
using LibraryDB.Scripts;

namespace LibraryDB.Pages
{
    /// <summary>
    /// Логика взаимодействия для LibraryMain.xaml
    /// </summary>
    public partial class LibraryMain : Page
    {
        private LibraryTableAdapter libery = new LibraryTableAdapter();
        Scripts.GetValue GetValueIn = new Scripts.GetValue();
        public LibraryMain()
        {
            InitializeComponent();

            Refresh();
        }
        private void Refresh()
        {
            GridLibrary.ItemsSource = libery.GetData();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            InsertSQL();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSQL();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateSQL();
        }
        private void GridLibrary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridLibrary.SelectedItem == null) return;
                NameLibrary.Text = (GridLibrary.SelectedItem as DataRowView).Row[1].ToString();
        }
        private void InsertSQL()
        {
            libery.InsertQuery(NameLibrary.Text);
            Refresh();
        }
        private void UpdateSQL()
        {
            if (GridLibrary.SelectedItem == null) return;
            var id = (GridLibrary.SelectedItem as DataRowView).Row[0];
            libery.UpdateQuery(NameLibrary.Text, Convert.ToInt32(id));
            Refresh();
        }
        private void DeleteSQL()
        {
            var id = (GridLibrary.SelectedItem as DataRowView).Row[0];
            libery.DeleteQuery(Convert.ToInt32(id));
            Refresh();
        }
    }
}
