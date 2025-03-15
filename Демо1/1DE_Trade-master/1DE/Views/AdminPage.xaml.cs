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

namespace _1DE.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public static AdminPage adminPage = new AdminPage();
        public AdminPage()
        {
            InitializeComponent();

            adminPage = this;
        }

        private void backBT_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow?.contentFR.NavigationService.Navigate(new LoginPage());
        }

        private void ordersBT_Click(object sender, RoutedEventArgs e)
        {
            contentFR.NavigationService.Navigate(new AdminOrders(true));
        }

        private void productsBT_Click(object sender, RoutedEventArgs e)
        {
            contentFR.NavigationService.Navigate(new AdminProducts(true));
        }
    }
}
