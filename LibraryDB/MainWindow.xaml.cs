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

namespace LibraryDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Labery.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void Labery_Click(object sender, RoutedEventArgs e)
        {
           
            SelectPage(sender , new Pages.LibraryMain());
        }

        private void Workers_Click(object sender, RoutedEventArgs e)
        {
            SelectPage(sender, new Pages.Workers());
        }

        private void Zone_Click(object sender, RoutedEventArgs e)
        {
            SelectPage(sender, new Pages.Zone());
        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {
            SelectPage(sender, new Pages.Book());
        }

        private void Code_Click(object sender, RoutedEventArgs e)
        {
            SelectPage(sender, new Pages.Code());
        }
        private void SelectPage(object sender, object see)
        {
            foreach (Button button in FindVisualChildren<Button>(this))
            {
                button.Background = Brushes.Transparent;
            }
            var selectButton = (Button)sender;
            selectButton.Background = Brushes.SkyBlue;
            PageFrame.Content = see;
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

    }
}
