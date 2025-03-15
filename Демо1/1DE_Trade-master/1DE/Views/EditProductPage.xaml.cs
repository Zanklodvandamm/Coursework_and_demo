using _1DE.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для EditProductPage.xaml
    /// </summary>
    public partial class EditProductPage : Page
    {
        private Db1deContext _Context = new Db1deContext();

        private bool _isEdit;
        private Product? _Product;
        private Product? _OriginalProduct;
        public EditProductPage(Product? product)
        {
            InitializeComponent();
            LoadData();

            if (product != null)
            {
                _isEdit = true;
                _Product = product;

                _OriginalProduct = new Product
                {
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductQuantityInStock = product.ProductQuantityInStock,
                    ProductUnit = product.ProductUnit,
                    ProductCurrentDiscount = product.ProductCurrentDiscount,
                    ProductMaxDiscountAmount = product.ProductMaxDiscountAmount,
                    ProductCost = product.ProductCost,
                    ProductPhoto = product.ProductPhoto,
                    ProductCategoryId = product.ProductCategoryId,
                    ProductCategory = product.ProductCategory,
                    ProductManufacturerId = product.ProductManufacturerId,
                    ProductManufacturer = product.ProductManufacturer,
                    ProductSupplierId = product.ProductSupplierId,
                    ProductSupplier = product.ProductSupplier
                };

            }
            else
            {
                _isEdit = false;
                _Product = new Product();
            }

            DataContext = _Product;
        }
        private void LoadData()
        {
            List<String> categories = _Context.Categories.Select(c => c.CategoryName).Distinct().ToList();
            categoriesCB.ItemsSource = categories;
            List<String> manufacturers = _Context.Manufacturers.Select(m => m.ManufacturerName).Distinct().ToList();
            manufacturersCB.ItemsSource = manufacturers;
            List<String> suppliers = _Context.Suppliers.Select(s => s.SupplierName).Distinct().ToList();
            suppliersCB.ItemsSource = suppliers;
        }

        private void cancelBT_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите отменить изменения?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (_isEdit)
                {
                    _Product!.ProductName = _OriginalProduct!.ProductName;
                    _Product.ProductDescription = _OriginalProduct.ProductDescription;
                    _Product.ProductQuantityInStock = _OriginalProduct.ProductQuantityInStock;
                    _Product.ProductUnit = _OriginalProduct.ProductUnit;
                    _Product.ProductCurrentDiscount = _OriginalProduct.ProductCurrentDiscount;
                    _Product.ProductMaxDiscountAmount = _OriginalProduct.ProductMaxDiscountAmount;
                    _Product.ProductCost = _OriginalProduct.ProductCost;
                    _Product.ProductPhoto = _OriginalProduct.ProductPhoto;
                    _Product.ProductCategoryId = _OriginalProduct.ProductCategoryId;
                    _Product.ProductCategory = _OriginalProduct.ProductCategory;
                    _Product.ProductManufacturerId = _OriginalProduct.ProductManufacturerId;
                    _Product.ProductManufacturer = _OriginalProduct.ProductManufacturer;
                    _Product.ProductSupplierId = _OriginalProduct.ProductSupplierId;
                    _Product.ProductSupplier = _OriginalProduct.ProductSupplier;

                    DataContext = null;
                    DataContext = _Product;
                }
                else
                {
                    articleTB.Text = "";
                    nameTB.Text = "";
                    descriptionTB.Text = "";
                    quantityTB.Text = "";
                    unitTB.Text = "";
                    discountTB.Text = "";
                    maxDiscountTB.Text = "";
                    costTB.Text = "";
                    photoTB.Text = "";
                    categoriesCB.SelectedItem = null;
                    manufacturersCB.SelectedItem = null;
                    suppliersCB.SelectedItem = null;
                }
            }
        }

        private void saveBT_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidInputs())
            {
                try
                {
                    // Получение категорий, производителей и поставщиков
                    var selectedCategoryName = categoriesCB.SelectedItem as string;
                    var category = _Context.Categories.FirstOrDefault(c => c.CategoryName == selectedCategoryName);

                    var selectedManufacturerName = manufacturersCB.SelectedItem as string;
                    var manufacturer = _Context.Manufacturers.FirstOrDefault(m => m.ManufacturerName == selectedManufacturerName);

                    var selectedSupplierName = suppliersCB.SelectedItem as string;
                    var supplier = _Context.Suppliers.FirstOrDefault(s => s.SupplierName == selectedSupplierName);

                    if (_isEdit)
                    {
                        // Поиск существующего продукта
                        var existingProduct = _Context.Products.FirstOrDefault(p => p.ProductArticleNumber == articleTB.Text);
                        if (existingProduct != null)
                        {
                            existingProduct.ProductName = nameTB.Text;
                            existingProduct.ProductDescription = descriptionTB.Text;
                            existingProduct.ProductUnit = unitTB.Text;
                            existingProduct.ProductPhoto = photoTB.Text;

                            // Безопасное преобразование числовых значений
                            if (int.TryParse(quantityTB.Text, out int quantity))
                                existingProduct.ProductQuantityInStock = quantity;

                            if (decimal.TryParse(costTB.Text, out decimal cost))
                                existingProduct.ProductCost = cost;

                            if (sbyte.TryParse(discountTB.Text, out sbyte discount))
                                existingProduct.ProductCurrentDiscount = discount;

                            existingProduct.ProductMaxDiscountAmount = maxDiscountTB.Text;

                            if (category != null)
                            {
                                existingProduct.ProductCategoryId = category.CategoryId;
                            }
                            if (manufacturer != null)
                            {
                                existingProduct.ProductManufacturerId = manufacturer.ManufacturerId;
                            }
                            if (supplier != null)
                            {
                                existingProduct.ProductSupplierId = supplier.SupplierId;
                            }

                            _Context.SaveChanges();
                            MessageBox.Show("Товар успешно изменён", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Товар с таким артикулом не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        // Создание нового продукта
                        var newProduct = new Product
                        {
                            ProductArticleNumber = articleTB.Text,
                            ProductName = nameTB.Text,
                            ProductDescription = descriptionTB.Text,
                            ProductUnit = unitTB.Text,
                            ProductPhoto = photoTB.Text,
                            ProductMaxDiscountAmount = maxDiscountTB.Text
                        };

                        // Безопасное присвоение числовых значений
                        if (int.TryParse(quantityTB.Text, out int quantity))
                            newProduct.ProductQuantityInStock = quantity;

                        if (decimal.TryParse(costTB.Text, out decimal cost))
                            newProduct.ProductCost = cost;

                        if (sbyte.TryParse(discountTB.Text, out sbyte discount))
                            newProduct.ProductCurrentDiscount = discount;

                        if (category != null)
                        {
                            newProduct.ProductCategoryId = category.CategoryId;
                        }
                        if (manufacturer != null)
                        {
                            newProduct.ProductManufacturerId = manufacturer.ManufacturerId;
                        }
                        if (supplier != null)
                        {
                            newProduct.ProductSupplierId = supplier.SupplierId;
                        }

                        _Context.Products.Add(newProduct);
                        _Context.SaveChanges();
                        MessageBox.Show("Товар успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private bool IsValidInputs()
        {
            List<String> errors = new List<String>();

            if (string.IsNullOrEmpty(articleTB.Text))
                errors.Add("Артикул не может быть пустым");
            if (string.IsNullOrEmpty(nameTB.Text))
                errors.Add("Название товара не может быть пустым");
            if (string.IsNullOrEmpty(descriptionTB.Text))
                errors.Add("Описание не может быть пустым");
            if (!int.TryParse(quantityTB.Text, out _))
                errors.Add("Количество должно быть числом");
            if (string.IsNullOrEmpty(unitTB.Text))
                errors.Add("Единица измерения не может быть пустой");
            if (!sbyte.TryParse(discountTB.Text, out _))
                errors.Add("Скидка должна быть числом");
            if (!sbyte.TryParse(maxDiscountTB.Text, out _))
                errors.Add("Максимальная скидка должна быть числом");
            if (!decimal.TryParse(costTB.Text, out _))
                errors.Add("Цена должна быть числом");
            if (string.IsNullOrEmpty(photoTB.Text))
                errors.Add("Фото не может быть пустым");
            if (categoriesCB.SelectedItem == null)
                errors.Add("Категория не может быть пустой");
            if (manufacturersCB.SelectedItem == null)
                errors.Add("Производитель не может быть пустым");
            if (suppliersCB.SelectedItem == null)
                errors.Add("Поставщик не может быть пустым");

            if (errors.Any())
            {
                MessageBox.Show(string.Join("\n", errors), "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
    
        private void closeBT_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow?.contentFR.NavigationService.GoBack();
        }

        private void textBoxes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
    }
}
