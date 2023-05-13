using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class ProductDetails
    {
        public int product_id { get; set; }

        public string product_name { get; set; }

        public string description { get; set; }
        public decimal price { get; set; }

        public byte[]? image { get; set; }

        public int quantity { get; set; }
        public int? rate { get; set; } = null;

        public DateTime? created_at { get; set; } = DateTime.Now;
        public DateTime? updated_at { get; set; } = null;

        public string brand_name { get; set; }
        public int? brand_id { get; set; }
        public string category_name { get; set; }
        public int? category_id { get; set; }
        public Discount discount { get; set; }
        public Brand brand { get; set; }
        public Category category { get; set; }

    }
}
