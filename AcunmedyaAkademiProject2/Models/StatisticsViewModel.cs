using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunmedyaAkademiProject2.Models
{
    public class StatisticsViewModel
    {
        public int ProductCount { get; set; }
        public int CategoryCount { get; set; }
        public int HappyCustomerCount { get; set; }
        public int OrderCount { get; set; }
        public decimal MinProductPrice { get; set; }
        public decimal MaxProductPrice { get; set; }
        public int SupplierCount { get; set; } // Tedarikçi sayısı
        public int TotalStockQuantity { get; set; } // Toplam stok miktarı
        public int ActiveOrderCount { get; set; } //Tamamlanmamış spariş sayısı
        public decimal AverageProductPrice { get; set; }// Ortalama ürün fiyatı
        public string MostExpensiveProductName { get; set; }// En pahalı ürünün adı
        public string CheapestProductName { get; set; } // En ucuz ürünün adı

    }
}