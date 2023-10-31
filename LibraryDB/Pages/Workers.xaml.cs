using LibraryDB.DB.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reactive.Subjects;
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
using System.Xml.Linq;

namespace LibraryDB.Pages
{
    /// <summary>
    /// Логика взаимодействия для Workers.xaml
    /// </summary>
    public partial class Workers : Page
    {
        private WorkersTableAdapter workersTable = new WorkersTableAdapter();
        private LibraryTableAdapter Library = new LibraryTableAdapter();
        Scripts.GetValue GetValueIn = new Scripts.GetValue();
        public Workers()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            GridWorkers.ItemsSource = workersTable.GetData();
            LibraryData.ItemsSource = Library.GetData();
            LibraryData.DisplayMemberPath = "Name";
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            LibraryData.DisplayMemberPath = "id";

            var idLibrary = GetValueIn.GetId(LibraryData, "Name");
            workersTable.InsertQuery(FirstName.Text, LastName.Text, Convert.ToInt32(idLibrary));
            Refresh();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var id = (GridWorkers.SelectedItem as DataRowView).Row[0];
            workersTable.DeleteQuery(Convert.ToInt32(id));
            GridWorkers.ItemsSource = workersTable.GetData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var id = (GridWorkers.SelectedItem as DataRowView).Row[0];
            ComboBoxItem comboBoxItem = (ComboBoxItem)LibraryData.SelectedItem;
            var idLibrary = GetValueIn.GetId(LibraryData, "Name");
            workersTable.InsertQuery(FirstName.Text, LastName.Text, Convert.ToInt32(idLibrary));
            Refresh();
        }

        private void GridWorkers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridWorkers.SelectedItem == null) return;
            FirstName.Text = (GridWorkers.SelectedItem as DataRowView).Row[1].ToString();
            LastName.Text = (GridWorkers.SelectedItem as DataRowView).Row[2].ToString();
            LibraryData.DisplayMemberPath = "id";
            LibraryData.Text = (GridWorkers.SelectedItem as DataRowView).Row[3].ToString();
            LibraryData.DisplayMemberPath = "Name";
        }
    }
    }
