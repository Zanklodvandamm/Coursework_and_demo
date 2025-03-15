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
    /// Логика взаимодействия для EditproductWindow.xaml
    /// </summary>
    public partial class EditproductWindow : Window
    {
        Product product1;
        public EditproductWindow(Product product)
        {
            InitializeComponent();
            product1 = product;
            nameTB.Text = product1.Name;
            costTB.Text = product1.Cost.ToString();
            maxDiscountTB.Text = product1.MaxDiscount.ToString();
            manufacturerCB.Text = product1.IdManufacturer.ToString();
            supplierCB.Text = product1.IdSupplier.ToString();
            categoryCB.Text = product1.IdProductCategory.ToString();
            currentDiscountTB.Text = product1.CurrentDiscount.ToString();
            quantityTB.Text = product1.Quantity.ToString();
            descriptionTB.Text = product1.Description.ToString();
            imageTB.Text = product1.Image.ToString();

        }

        private void addProductBtn_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();


            product1.Name = nameTB.Text;
            product1.Cost = int.Parse(costTB.Text);
            product1.MaxDiscount = int.Parse(maxDiscountTB.Text);
            product1.IdManufacturer = int.Parse(manufacturerCB.Text);
            product1.IdSupplier = int.Parse(supplierCB.Text);
            product1.IdProductCategory = int.Parse(categoryCB.Text);
            product1.CurrentDiscount = int.Parse(currentDiscountTB.Text);
            product1.Quantity = int.Parse(quantityTB.Text);
            product1.Description = descriptionTB.Text;
            product1.Image = imageTB.Text;

            TradedbContext context = new TradedbContext();

            context.Update(product1);
            context.SaveChanges();

            
            this.Close();

            MessageBox.Show("Товар изменен");
        }
    }
}
