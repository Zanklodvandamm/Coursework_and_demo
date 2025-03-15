using System.Windows;
using System.Windows.Controls;
using DemoWPF.Models;

namespace DemoWPF
{
    public partial class AddPartnerPage : Page
    {
        private readonly DataClass _dataClass;

        public AddPartnerPage()
        {
            InitializeComponent();
            _dataClass = new DataClass(); 
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newPartner = new Partner
                {
                    PartnerType = TbPartnerType.Text,
                    PartnerName = TbPartnerName.Text,
                    Surname = TbSurname.Text,
                    Name = TbName.Text,
                    Patronymic = TbPatronymic.Text,
                    Email = TbEmail.Text,
                    Phone = TbPhone.Text,
                    PostCode = int.Parse(TbPostCode.Text),
                    Region = TbRegion.Text,
                    City = TbCity.Text,
                    Street = TbStreet.Text,
                    House = TbHouse.Text,
                    Inn = TbInn.Text,
                    Rating = int.Parse(TbRating.Text)
                };

                bool isAdded = _dataClass.AddPartner(newPartner);

                if (isAdded)
                {
                    MessageBox.Show("Партнер успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    NavigationService?.GoBack();
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении партнера.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } catch (Exception) {
                MessageBox.Show("Ошибка при добавлении партнера.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}