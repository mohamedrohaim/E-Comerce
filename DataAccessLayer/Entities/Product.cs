using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }
        [Required,MaxLength(255,ErrorMessage ="maximum char number is 255")]

        public string product_name { get; set; }

        [DataType(DataType.Text)]
        public string description { get; set; }

        [Required(ErrorMessage ="Price is required")]
        public decimal price { get; set; }

        public byte[]? image { get; set; }

        public int quantity { get; set; }
        
        public DateTime? created_at { get; set; }= DateTime.Now;
        public DateTime? updated_at { get; set; } = null;

        public int? discount_id { get; set; }= null;
        public int? category_id { get; set; }= null;
        public int? brand_id { get; set; }= null;

        public Discount discount { get; set; }
        public Brand brand { get; set; }
        public Category category { get; set; }

        public ICollection<Review> reviews { get; set; }

    }
}
