using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Review
    {
        [Key]
        public int review_id { get; set; }
        public int user_id { get; set; }
        public int product_id { get; set; }
        [Range(0, 5)]
        public int rating { get; set; }

        public string comment { get; set; }

        public DateTime? Commented_at { get; set; }=DateTime.Now;
        public DateTime? Coment_Updated { get; set; }

        public Product product { get; set; }

        
    }
}
