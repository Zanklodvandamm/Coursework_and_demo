using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DemoWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWPF
{
    public class DataClass
    {
        public ProductiondbContext context = new ProductiondbContext();

        public List<Partner> GetPartners()
        {
            return context.Partners
                .Include(p => p.Partnerproducts) 
                .ToList();
        }

        public bool AddPartner(Partner partner)
        {
            try
            {
                context.Partners.Add(partner);

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении партнера: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public bool UpdatePartner(Partner partner)
        {
            try
            {
                var existingPartner = context.Partners.Find(partner.PartnerId);

                if (existingPartner != null)
                {
                    existingPartner.PartnerType = partner.PartnerType;
                    existingPartner.PartnerName = partner.PartnerName;
                    existingPartner.Surname = partner.Surname;
                    existingPartner.Name = partner.Name;
                    existingPartner.Patronymic = partner.Patronymic;
                    existingPartner.Email = partner.Email;
                    existingPartner.Phone = partner.Phone;
                    existingPartner.PostCode = partner.PostCode;
                    existingPartner.Region = partner.Region;
                    existingPartner.City = partner.City;
                    existingPartner.Street = partner.Street;
                    existingPartner.House = partner.House;
                    existingPartner.Inn = partner.Inn;
                    existingPartner.Rating = partner.Rating;

                    context.SaveChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Партнер не найден в базе данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public int CalculateRequiredMaterial(int productTypeId, int materialTypeId, int productQuantity, double parameter1, double parameter2)
        {
            using (var context = new ProductiondbContext())
            {
                var productType = context.Producttypes.Find(productTypeId);
                var materialType = context.Materialtypes.Find(materialTypeId);

                if (productType == null || materialType == null || productQuantity <= 0 || parameter1 <= 0 || parameter2 <= 0)
                {
                    return -1;
                }

                double materialPerUnit = parameter1 * parameter2 * (double)productType.ProductTypeCoefficient;

                double totalMaterial = materialPerUnit * productQuantity * (1 + (double)materialType.DefectPercentage / 100);

                return (int)Math.Ceiling(totalMaterial);
            }
        }
    }
}
