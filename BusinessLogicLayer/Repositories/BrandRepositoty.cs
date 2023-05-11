using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories
{
    public class BrandRepositoty : GenericRepository<Brand>,IBrandRepository
    {
        private readonly AppDbContext _appDbContext;

        

        public BrandRepositoty(AppDbContext appDbContext) :base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

       
    }
}
