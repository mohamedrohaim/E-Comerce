using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class User:IdentityUser
    {
        [Required,MaxLength(100)]
        public string firstName { get; set; }
        [Required, MaxLength(100)]
        public string lastName { get; set; }

        public byte[] picture { get; set; }
        

    }
}
