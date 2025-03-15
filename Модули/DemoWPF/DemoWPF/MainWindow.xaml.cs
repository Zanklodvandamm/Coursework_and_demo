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

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Подписываемся на событие Navigated
            MainFrame.Navigated += MainFrame_Navigated;

            MainFrame.Navigate(new PageListPartners());
        }

        // Обработчик события Navigated
        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            // Обновляем заголовок окна в зависимости от текущей страницы
            if (e.Content is Page page)
            {
                this.Title = $"{page.Title}";
            }
        }
    }
}