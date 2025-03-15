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
using System.Windows.Shapes;
using DemoVar9.Models;

namespace DemoVar9
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void addProductBtn_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();

            product.IdProduct = IdTB.Text;
            product.Name = nameTB.Text;
            product.Position = "шт.";
            product.Cost = int.Parse(costTB.Text);
            product.MaxDiscount = int.Parse(maxDiscountTB.Text);
            product.IdManufacturer = int.Parse(manufacturerCB.Text);
            product.IdSupplier = int.Parse(supplierCB.Text);
            product.IdProductCategory = int.Parse(categoryCB.Text);
            product.CurrentDiscount = int.Parse(currentDiscountTB.Text);
            product.Quantity = int.Parse(quantityTB.Text);
            product.Description = descriptionTB.Text;
            product.Image = imageTB.Text;

            TradedbContext context = new TradedbContext();
            
            context.Products.Add(product);
            context.SaveChanges();

            
            this.Close();

            MessageBox.Show("Товар добавлен");
        }
    }
}
