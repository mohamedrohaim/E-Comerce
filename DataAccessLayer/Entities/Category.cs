using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        [Required(ErrorMessage ="category name is reqired")]
        public string category_name { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
