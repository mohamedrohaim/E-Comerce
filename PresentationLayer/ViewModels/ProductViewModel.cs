using System.ComponentModel.DataAnnotations;
using System;

namespace PresentationLayer.ViewModels
{
    public class ProductViewModel
    {
        public int product_id { get; set; }
        [Required, MaxLength(255, ErrorMessage = "maximum char number is 255")]

        public string product_name { get; set; }

        public string description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal price { get; set; }

        public byte[]? image { get; set; }

        public int quantity { get; set; }

        public DateTime? created_at { get; set; } = DateTime.Now;
        public DateTime? updated_at { get; set; } = null;

        public string brand_name { get; set; }
        public string category_name { get; set; }

    }
}
