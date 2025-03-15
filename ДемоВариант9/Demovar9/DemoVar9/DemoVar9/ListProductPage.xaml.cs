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
using DemoVar9.Models;

namespace DemoVar9
{
    /// <summary>
    /// Логика взаимодействия для ListProductPage.xaml
    /// </summary>
    public partial class ListProductPage : Page
    {
        DataClass data = new DataClass();
        public ListProductPage()
        {
            InitializeComponent();
            listProduct.ItemsSource = data.GetProduct();
        }

        private void listProduct_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            
            EditproductWindow editproductWindow = new EditproductWindow((Product)listProduct.SelectedItem);
            editproductWindow.Show();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Close();
        }
    }
}
