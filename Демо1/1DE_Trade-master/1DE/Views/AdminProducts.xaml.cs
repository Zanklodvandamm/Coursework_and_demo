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
using Microsoft.EntityFrameworkCore;

namespace _1DE.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminProducts.xaml
    /// </summary>
    public partial class AdminProducts : Page
    {
        private Db1deContext _Context = new Db1deContext();
        public AdminProducts(bool isAdmin)
        {
            InitializeComponent();

            LoadProducts();

            if (!isAdmin)
            {
                addProductBT.Visibility = Visibility.Collapsed;
                editProductBT.Visibility = Visibility.Collapsed;
                deleteProductBT.Visibility = Visibility.Collapsed;
            }
        }

        private void LoadProducts()
        {
            List<Product> products = _Context.Products.Include(p => p.ProductCategory).
                                                        Include(p => p.ProductManufacturer).
                                                        Include(p => p.ProductSupplier).ToList();
            productsDG.ItemsSource = products;
        }

        private void addProductBT_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow?.contentFR.NavigationService.Navigate(new EditProductPage(null));
        }

        private void editProductBT_Click(object sender, RoutedEventArgs e)
        {
            Product? selectedProduct = productsDG.SelectedItem as Product;

            if (selectedProduct != null)
            {
                MainWindow.mainWindow?.contentFR.NavigationService.Navigate(new EditProductPage(selectedProduct));
            }
            else
                MessageBox.Show("Сначала выберите товар, а потом изменяйте его", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void deleteProductBT_Click(object sender, RoutedEventArgs e)
        {
            Product? selectedProduct = productsDG.SelectedItem as Product;

            if (selectedProduct != null)
            {
                try
                {
                    var linkedOrderProducts = _Context.Orderproducts
                                                .Where(op => op.ProductArticleNumber == selectedProduct.ProductArticleNumber)
                                                .ToList();

                    _Context.Orderproducts.RemoveRange(linkedOrderProducts);
                    _Context.Products.Remove(selectedProduct);
                    _Context.SaveChanges();

                    MessageBox.Show("Вы успешно удалили товар", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    List<Product> products = _Context.Products.Include(p => p.ProductCategory).Include(p => p.ProductManufacturer).Include(p => p.ProductSupplier).ToList();
                    productsDG.ItemsSource = products;
                    productsDG.Items.Refresh();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось удалить товар \n{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
    }
}
