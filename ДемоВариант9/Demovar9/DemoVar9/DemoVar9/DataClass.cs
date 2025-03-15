using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoVar9.Models;

namespace DemoVar9
{
    public class DataClass
    {
        public TradedbContext tradedbContext = new TradedbContext();
        public List<Product> GetProduct()
        {
            return tradedbContext.Products.ToList();
        }

        // Получение категорий
        public List<ProductCategory> GetCategory()
        {
            return tradedbContext.ProductCategories.ToList();
        }

        // Получение производителей
        public List<Manufacturer> GetManufacturer()
        {
            return tradedbContext.Manufacturers.ToList();
        }

        // Получение поставщиков
        public List<Supplier> GetSupplier()
        {
            return tradedbContext.Suppliers.ToList();
        }

    }
}
