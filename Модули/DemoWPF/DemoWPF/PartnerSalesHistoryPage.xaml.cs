using System.Windows;
using System.Windows.Controls;
using DemoWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWPF
{
    public partial class PartnerSalesHistoryPage : Page
    {
        private readonly Partner _partner;

        public PartnerSalesHistoryPage(Partner partner)
        {
            InitializeComponent();
            _partner = partner;

            LoadSalesHistory();
        }

        private void LoadSalesHistory()
        {
            using (var context = new ProductiondbContext())
            {
                var salesHistory = context.Partnerproducts
                    .Include(pp => pp.Product) 
                    .Where(pp => pp.PartnerId == _partner.PartnerId) 
                    .ToList();

                SalesHistoryListView.ItemsSource = salesHistory;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}