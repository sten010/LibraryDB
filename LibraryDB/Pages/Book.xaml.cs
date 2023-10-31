using LibraryDB.DB.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
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

namespace LibraryDB.Pages
{
    /// <summary>
    /// Логика взаимодействия для Book.xaml
    /// </summary>
    public partial class Book : Page
    {
        private BookTableAdapter BookTableAdapter = new BookTableAdapter();
        private ZoneTableAdapter ZoneTableAdapter = new ZoneTableAdapter();
        private CodeTableAdapter CodeTableAdapter = new CodeTableAdapter();
        Scripts.GetValue GetValueIn = new Scripts.GetValue();

        public Book()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            GridBooks.ItemsSource = BookTableAdapter.GetData();
            //
            ZoneCombo.ItemsSource = ZoneTableAdapter.GetData();
            ZoneCombo.DisplayMemberPath = "Name";
            //
            CodeCombo.ItemsSource = CodeTableAdapter.GetData();
            CodeCombo.DisplayMemberPath = "Code";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (GridBooks.SelectedItem == null) return;
            DeleteSQL();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            InsertSQL();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (GridBooks.SelectedItem == null) return;
            UpdateSQL();
        }

        private void GridBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridBooks.SelectedItem == null) return;
            BookName.Text = (GridBooks.SelectedItem as DataRowView).Row[1].ToString();
            ZoneCombo.DisplayMemberPath = "id";
            CodeCombo.DisplayMemberPath = "id";
            CodeCombo.Text = (GridBooks.SelectedItem as DataRowView).Row[2].ToString();
            ZoneCombo.Text = (GridBooks.SelectedItem as DataRowView).Row[3].ToString();
            ZoneCombo.DisplayMemberPath = "Name";
            CodeCombo.DisplayMemberPath = "Code";
        }
        private void InsertSQL()
        {
            var idCode = GetValueIn.GetId(CodeCombo, "Code");
            var idZone = GetValueIn.GetId(ZoneCombo, "Name");
            BookTableAdapter.InsertQuery(BookName.Text, Convert.ToInt32(idCode), Convert.ToInt32(idZone));
            Refresh();
        }
        private void UpdateSQL()
        {
            var id = (GridBooks.SelectedItem as DataRowView).Row[0];
            var idCode = GetValueIn.GetId(CodeCombo, "Code");
            var idZone = GetValueIn.GetId(ZoneCombo, "Name");
            BookTableAdapter.UpdateQuery(BookName.Text, idCode, idZone, Convert.ToInt32(id));
            Refresh();
        }
        private void DeleteSQL()
        {
            var id = Convert.ToInt32((GridBooks.SelectedItem as DataRowView).Row[0]);
            BookTableAdapter.DeleteQuery(id);
            Refresh();
        }
    }
}
