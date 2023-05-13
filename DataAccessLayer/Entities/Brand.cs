using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Brand
    {
        [Key]
        public int brand_id { get; set; }
        [Required(ErrorMessage ="name is required")]
        public string brand_name { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
