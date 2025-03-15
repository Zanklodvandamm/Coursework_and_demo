using System.Windows;
using System.Windows.Controls;
using DemoWPF.Models;

namespace DemoWPF
{
    public partial class PageListPartners : Page
    {
        public PageListPartners()
        {
            InitializeComponent();
        }

        private void LoadPartners()
        {
            var data = new DataClass();
            ListPartners.ItemsSource = data.GetPartners();
        }

        private void ListPartners_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selectedPartner = ListPartners.SelectedItem as Partner;

            if (selectedPartner != null)
            {
                var editPage = new EditPartnerPage(selectedPartner);
                NavigationService?.Navigate(editPage);
            }
        }

        private void BtnAddPartner_Click(object sender, RoutedEventArgs e)
        {
            var addPage = new AddPartnerPage();
            NavigationService?.Navigate(addPage);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPartners();
        }

        private void BtnViewPartnerHistory_Click(object sender, RoutedEventArgs e)
        {
            var selectedPartner = ListPartners.SelectedItem as Partner;

            if (selectedPartner != null)
            {
                var historyPage = new PartnerSalesHistoryPage(selectedPartner);
                NavigationService?.Navigate(historyPage);
            }
        }

        private void BtnCheckMethod_Click(object sender, RoutedEventArgs e)
        {
            var dataClass = new DataClass();
            int requiredMaterial = dataClass.CalculateRequiredMaterial(
                productTypeId: 1,
                materialTypeId: 1,
                productQuantity: 1000,
                parameter1: 2.5,
                parameter2: 3.0
            );

            if (requiredMaterial == -1)
            {
                MessageBox.Show("Некорректные данные для расчета.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show($"Необходимое количество материала: {requiredMaterial}", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}