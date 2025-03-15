using _1DE.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1DE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow? mainWindow;
        public MainWindow()
        {
            InitializeComponent();

            mainWindow = this;

            ShowLoginPage();
        }

        private void ShowLoginPage()
        {
            contentFR.NavigationService.Navigate(new LoginPage());
        }

        private void contentFR_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Content is Page page)
                Title = page.Title;
        }
    }
}