using LibraryDB.DB.DataSet1TableAdapters;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryDB.Pages
{
    /// <summary>
    /// Логика взаимодействия для Zone.xaml
    /// </summary>
    public partial class Zone : Page
    {
        private ZoneTableAdapter ZoneTableAdapter  = new ZoneTableAdapter();
        private WorkersTableAdapter WorkersTableAdapter = new WorkersTableAdapter();
        Scripts.GetValue GetValueIn = new Scripts.GetValue();
        public Zone()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            GridZone.ItemsSource = ZoneTableAdapter.GetData();
            //
            WorkerCombo.ItemsSource = WorkersTableAdapter.GetData();
            WorkerCombo.DisplayMemberPath = "LastName";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var id = (GridZone.SelectedItem as DataRowView).Row[0];
            ZoneTableAdapter.DeleteQuery(Convert.ToInt32(id));
            Refresh();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var idWorker = GetValueIn.GetId(WorkerCombo, "LastName");
            ZoneTableAdapter.InsertQuery(ZoneName.Text, Convert.ToInt32(idWorker));
            Refresh();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var idWorker = GetValueIn.GetId(WorkerCombo, "LastName");
            var id = (GridZone.SelectedItem as DataRowView).Row[0];
            ZoneTableAdapter.UpdateQuery(ZoneName.Text, Convert.ToInt32(idWorker), Convert.ToInt32(id));
            Refresh();
        }

        private void GridZone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridZone.SelectedItem == null) return;
            ZoneName.Text = (GridZone.SelectedItem as DataRowView).Row[1].ToString();
            WorkerCombo.DisplayMemberPath = "id";
            WorkerCombo.Text = (GridZone.SelectedItem as DataRowView).Row[2].ToString();
            WorkerCombo.DisplayMemberPath = "LastName";
        }
    }
}
