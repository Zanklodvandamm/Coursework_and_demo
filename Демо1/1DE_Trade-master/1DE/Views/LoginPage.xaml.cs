using _1DE.Models;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private Db1deContext _Context = new Db1deContext();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void loginBT_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = _Context.Users.ToList();


            var user = _Context.Users.FirstOrDefault(u => u.UserLogin == loginTB.Text);

            // Если пользователь не найден — неверный логин
            if (user == null)
            {
                MessageBox.Show("Неверный логин");
                return;
            }

            // Если пароль не совпадает — неверный пароль
            if (user.UserPassword != passwordTB.Text)
            {
                MessageBox.Show("Неверный пароль");
                return;
            }

            MainWindow.mainWindow?.contentFR.NavigationService.Navigate(new AdminPage());

            //// Авторизация успешна - переход на страницу в зависимости от роли
            //switch (user.UserRole)
            //{
            //    case 1:
            //        MainWindow.mainWindow?.contentFR.NavigationService.Navigate(new AdminPage());
            //        break;
            //    case 2:
            //        MainWindow.mainWindow?.contentFR.NavigationService.Navigate(new ManagerPage());
            //        break;
            //    case 3:
            //        MainWindow.mainWindow?.contentFR.NavigationService.Navigate(new UserPage());
            //        break;
            //    default:
            //        MessageBox.Show("Неизвестная роль пользователя");
            //        break;
            //}
        }


        private void adminBT_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow?.contentFR.NavigationService.Navigate(new AdminPage());
        }

        private void managerBT_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow?.contentFR.NavigationService.Navigate(new ManagerPage());
        }
    }
}
