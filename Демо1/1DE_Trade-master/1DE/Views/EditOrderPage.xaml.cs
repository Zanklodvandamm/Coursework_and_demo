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
    /// Логика взаимодействия для EditOrderPage.xaml
    /// </summary>
    public partial class EditOrderPage : Page
    {
        private Db1deContext _Context = new Db1deContext();
        private List<Order>? _Orders;

        private bool _isEditing;
        private Order _Order;
        private Order? _OriginalOrder;
        public EditOrderPage(Order? order = null)
        {
            InitializeComponent();

            if (order != null )
            {
                _Order = order;
                _OriginalOrder = new Order
                {
                    OrderDate = order.OrderDate,
                    OrderDeliveryDate = order.OrderDeliveryDate,
                    OrderPickupPointId = order.OrderPickupPointId,
                    OrderUserId = order.OrderUserId,
                    OrderCode = order.OrderCode,
                    OrderStatus = order.OrderStatus
                };
                _isEditing = true;
            }
            else
            {
                _Order = new Order();
                _isEditing = false;
            }

            LoadLists();
            DataContext = _Order;
        }
        private void LoadLists()
        {
            _Orders = _Context.Orders.ToList();

            List<String> pickuppoints = _Orders.Select(o => o.OrderPickupPointId).Distinct().ToList();
            pickupPointsCB.ItemsSource = pickuppoints;  

            List<int> users = _Orders.Select(o => o.OrderUserId).Distinct().ToList();
            usersCB.ItemsSource = users;

            List<String> statuses = _Orders.Select(o => o.OrderStatus).Distinct().ToList();
            statusesCB.ItemsSource = statuses;
        }
        private void canselBT_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите отменить изменения?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (_isEditing)
                {
                    _Order.OrderDate = _OriginalOrder!.OrderDate;
                    _Order.OrderDeliveryDate = _OriginalOrder!.OrderDeliveryDate;
                    _Order.OrderPickupPointId = _OriginalOrder!.OrderPickupPointId;
                    _Order.OrderUserId = _OriginalOrder!.OrderUserId;
                    _Order.OrderCode = _OriginalOrder!.OrderCode;
                    _Order.OrderStatus = _OriginalOrder!.OrderStatus;

                    DataContext = null;
                    DataContext = _Order;
                }
                else
                {
                    orderDateDP = null;
                    deliveryDateDP = null;
                    pickupPointsCB.SelectedItem = null;
                    usersCB.SelectedItem = null;
                    codeTB.Text = "";
                    statusesCB.SelectedItem = null;
                }
            }
        }

        private void saveBT_Click(object sender, RoutedEventArgs e)
        {
            if (valideInputs())
            {
                try
                {
                    if (_isEditing)
                    {
                        Order? existingOrder = _Orders?.FirstOrDefault(o => o.OrderId == _Order.OrderId);
                        if (existingOrder != null)
                        {
                            existingOrder.OrderStatus = _Order.OrderStatus;
                            existingOrder.OrderDeliveryDate = _Order.OrderDeliveryDate;

                            _Context.SaveChanges();

                            MessageBoxResult result = MessageBox.Show("Заказ успешно обновлен.\nПерейти к окну заказов?", "Успех!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.Yes)
                            {
                                MainWindow.mainWindow?.contentFR.NavigationService.GoBack();
                            }
                        }
                        else
                            MessageBox.Show($"Заказ {_Order.OrderId} не найден в базе данных.", "Ошибка редактирования заказа");
                    }
                    else
                    {
                        Order? existingOrder = _Orders?.FirstOrDefault(o => o.OrderId == _Order.OrderId);
                        if (existingOrder == null)
                        {
                            _Context.Orders.Add(_Order);
                            _Context.SaveChanges();

                            MessageBoxResult result = MessageBox.Show("Заказ успешно добавлен.\nПерейти к окну заказов?", "Успех!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.Yes)
                            {
                                MainWindow.mainWindow?.contentFR.NavigationService.GoBack();
                            }
                        }
                        else
                            MessageBox.Show("Такой заказ уже существует", "Ошибка добавления заказа");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: \n {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        
        private bool valideInputs()
        {
            List<String> errors = new List<string>();

            if (orderDateDP.SelectedDate == null)
                errors.Add("Выберите дату заказа");
            if (deliveryDateDP.SelectedDate == null)
                errors.Add("Выберите дату доставки");
            if (pickupPointsCB.SelectedItem == null)
                errors.Add("Выберите пункт выдачи заказа");
            if (usersCB.SelectedItem == null)
                errors.Add("Выберите клиента, оформившего заказ");
            if (statusesCB.SelectedItem == null)
                errors.Add("Выберите статус заказа");

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
    }
}
