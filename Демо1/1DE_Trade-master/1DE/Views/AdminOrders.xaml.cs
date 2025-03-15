using _1DE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для AdminOrders.xaml
    /// </summary>
    public partial class AdminOrders : Page
    {
        private Db1deContext _Context = new Db1deContext();
        private List<Order> _Orders = new List<Order>();
        public AdminOrders(bool isAdmin)
        {
            InitializeComponent();

            if (isAdmin)
            {
                addOrderBT.Visibility = Visibility.Collapsed;
            }

            PopulateListView();
            LoadSort();
            LoadFilters();
        }
        private void PopulateListView()
        {
            _Orders = _Context.Orders.Include(o => o.Orderproducts).
                                                    ThenInclude(op => op.ProductArticleNumberNavigation).
                                                    Include(o => o.OrderUser).ToList();


            foreach (var partner in _Orders)
            {
                OrderViewElement partnerElement = new OrderViewElement
                {
                    DataContext = partner
                };
                ordersLV.Items.Add(partnerElement);
            }
        }
        private void LoadSort()
        {
            List<String> sorts = new()
            {
                "По умолчанию", "По возрастанию", "По убыванию"
            };
            sortCB.ItemsSource = sorts;
        }
        private void LoadFilters()
        {
            List<string> filters = new()
            {
                "Все диапазоны", "0-10%", "11-14%", "15% и более"
            };
            filtCB.ItemsSource = filters;
        }
        private void sortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void filtCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            List<Order> sortedOrders = _Orders.ToList();

            if (sortCB.SelectedItem is string selectedSort && !string.IsNullOrEmpty(selectedSort))
            {
                switch (selectedSort)
                {
                    case "По возрастанию":
                        sortedOrders = sortedOrders.OrderBy(o => o.TotalOrderSum).ToList();
                        break;
                    case "По убыванию":
                        sortedOrders = sortedOrders.OrderByDescending(o =>  o.TotalOrderSum).ToList();
                        break;
                }
                UpdateOrdersLV(sortedOrders);
            }
            if (filtCB.SelectedItem is string selectedFilt && !string.IsNullOrEmpty(selectedFilt))
            {
                switch (selectedFilt)
                {
                    case "0-10%":
                        sortedOrders = sortedOrders.Where(o => (float)o.TotalOrderDiscount is >=0 and <=10).ToList();
                        break;
                    case "11-14%":
                        sortedOrders = sortedOrders.Where(o => (float)o.TotalOrderDiscount is >=11 and <=14).ToList();
                        break;
                    case "15% и более":
                        sortedOrders = sortedOrders.Where(o => (float)o.TotalOrderDiscount is >=15).ToList();
                        break;
                }
                UpdateOrdersLV(sortedOrders);
            }
        }
        private void UpdateOrdersLV(List<Order> orders)
        {
            ordersLV.Items.Clear();
            foreach (var partner in orders)
            {
                OrderViewElement partnerElement = new OrderViewElement
                {
                    DataContext = partner
                };
                ordersLV.Items.Add(partnerElement);
            }
        }

        private void editOrderBT_Click(object sender, RoutedEventArgs e)
        {
            if (ordersLV.SelectedItem is OrderViewElement orderViewElement && orderViewElement.DataContext is Order selectedOrder)
            {
                MainWindow.mainWindow?.contentFR.NavigationService.Navigate(new EditOrderPage(selectedOrder));
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказ для редактирования.",
                                "Предупреждение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
        }

        private void addOrderBT_Click(object sender, RoutedEventArgs e)
        {
           MainWindow.mainWindow?.contentFR.NavigationService.Navigate(new EditOrderPage());
        }
    }
}
