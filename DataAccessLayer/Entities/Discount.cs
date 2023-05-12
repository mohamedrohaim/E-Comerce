using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Discount
    {
        [Key]
        public int discount_id { get; set; }
        [Required(ErrorMessage = "discount name is required")]
        public string discount_name { get;set; }
        public string discount_description { get;set; }
        [Required(ErrorMessage = "persentage is required")]
        [Range(0,99)]
        public int discount_persentage { get;set; }

        public bool discount_enabled { get; set; } = true;
        public decimal maxValue { get; set; }

        public DateTime? created_at { get; set; } = DateTime.Now;


        public DateTime? updated_at { get; set; } = null;

        public ICollection<Product> products { get; set;}
    }
}
