using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DemoWPF.Models;

public partial class Partner
{
    public int PartnerId { get; set; }

    public string PartnerType { get; set; } = null!;

    public string PartnerName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int PostCode { get; set; }

    public string Region { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string House { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public int Rating { get; set; }

    public virtual ICollection<Partnerproduct> Partnerproducts { get; set; } = new List<Partnerproduct>();

    public string FullName => $"{Surname} {Name} {Patronymic}".Trim();

    public string FullCompany => $"{PartnerType} | {PartnerName}".Trim();

    public string FullPhone => $"+7 {Phone}".Trim();

    public string FullRating => $"Рейтинг: {Rating}".Trim();

    // Метод для расчета общего количества продукции
    public int GetTotalQuantitySold()
    {
        return Partnerproducts.Sum(pp => pp.Quantity);
    }

    // Метод для расчета скидки
    public double CalculateDiscount()
    {
        int totalQuantity = GetTotalQuantitySold();

        if (totalQuantity < 10000)
            return 0;
        else if (totalQuantity >= 10000 && totalQuantity < 50000)
            return 5;
        else if (totalQuantity >= 50000 && totalQuantity < 300000)
            return 10;
        else
            return 15;
    }

    // Свойство для получения скидки
    public double Discount => CalculateDiscount();
}