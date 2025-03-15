using System.Windows;
using System.Windows.Controls;
using DemoWPF.Models;

namespace DemoWPF
{
    public partial class EditPartnerPage : Page
    {
        private Partner _partner;
        private readonly DataClass _dataClass;

        public EditPartnerPage(Partner partner)
        {
            InitializeComponent();
            _partner = partner;
            _dataClass = new DataClass();

            DataContext = _partner;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            bool isUpdated = _dataClass.UpdatePartner(_partner);

            if (isUpdated)
            {
                MessageBox.Show("Изменения сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                NavigationService?.GoBack();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}