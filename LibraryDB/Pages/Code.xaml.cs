using LibraryDB.DB.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Code.xaml
    /// </summary>
    public partial class Code : Page
    {
        private CodeTableAdapter CodeTableAdapter = new CodeTableAdapter();
        public Code()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            GridCode.ItemsSource = CodeTableAdapter.GetData();
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

        private void GridCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridCode.SelectedItem == null) return;
            CodeName.Text = (GridCode.SelectedItem as DataRowView).Row[1].ToString();
        }
        private void DeleteSQL()
        {
            var id = (GridCode.SelectedItem as DataRowView).Row[0];
            CodeTableAdapter.DeleteQuery(Convert.ToInt32(id));
            Refresh();
        }
        private void UpdateSQL()
        {
            var id = (GridCode.SelectedItem as DataRowView).Row[0];
            CodeTableAdapter.UpdateQuery(Convert.ToInt32(CodeName.Text), Convert.ToInt32(id));
            Refresh();
        }
        private void InsertSQL()
        {
            CodeTableAdapter.InsertQuery(Convert.ToInt32(CodeName.Text));
            Refresh();
        }

        private void CodeName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
    }
}
